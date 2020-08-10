using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Starlight.Translations
{
    public class TranslationManager
    {
        static TranslationManager instance;
        public static TranslationManager Instance {
            get {
                if (instance == null) {
                    instance = new TranslationManager();
                }

                return instance;
            }
        }

        private readonly Dictionary<string, string> strings;

        public TranslationManager() {
            this.strings = new Dictionary<string, string>();
        }

        public void AddString(string key, string value) {
            this.strings.Add(key, value);
        }

        public string Translate(string key) {
            if (this.strings.TryGetValue(key, out var value)) {
                return value;
            } else {
                return "Missing translation.";
            }
        }

        public bool TryTranslate(string key, out string value) {
            if (string.IsNullOrEmpty(key)) {
                value = string.Empty;
                return false;
            }

            return this.strings.TryGetValue(key, out value);
        }

        public void ImportFromDocument(string documentPath) {
            using (var fileStream = new FileStream(documentPath, FileMode.Open)) {
                using (var streamReader = new StreamReader(fileStream)) {
                    using (var jsonReader = new JsonTextReader(streamReader)) {
                        var jObject = JObject.Load(jsonReader);

                        ImportChildStrings(jObject);
                    }
                }
            }
        }

        private void ImportChildStrings(JToken parent) {
            foreach (var child in parent.Children()) {
                switch (child) {
                    case JProperty childProperty: {
                            if (childProperty.Value.Type == JTokenType.String) {
                                AddString(child.Path, childProperty.Value.Value<string>());
                            } else {
                                ImportChildStrings(child);
                            }
                        }
                        break;
                    case JObject childObject: {
                            foreach (var childProperty in childObject.Properties()) {
                                if (childProperty.Value.Type == JTokenType.String) {
                                    AddString(childProperty.Path, childProperty.Value.Value<string>());
                                } else {
                                    ImportChildStrings(childProperty);
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}
