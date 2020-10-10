using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Starlight.Server.Security
{
    class DenyList
    {
        static DenyList instance;
        public static DenyList Instance {
            get {
                if (instance == null) {
                    instance = new DenyList();
                }

                return instance;
            }
        }

        private readonly List<string> strings;

        public DenyList() {
            this.strings = new List<string>();
        }

        public void AddString(string value) {
            this.strings.Add(value);
        }

        public string Sanitize(string value) {
            return Regex.Escape(value);
        }

        public Boolean CheckDenied(string value) {
            if (strings.Contains(value)) {
                return true;
            }
            foreach (var check in strings) {
                if (Regex.IsMatch(value, check)) {
                    return true;
                }
            }
            return false;
        }

        public void ImportFromDocument(string documentPath) {
            try {
                using (var fileStream = new FileStream(documentPath, FileMode.Open)) {
                    using (var streamReader = new StreamReader(fileStream)) {
                        string line = null;
                        do {
                            line = streamReader.ReadLine();
                            if (line != null) {
                                AddString(line);
                            }
                        } while (line != null);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Log.Warning("Wordlist not found, creating...");
                CreateDocument(documentPath);
                ImportFromDocument(documentPath);
            }
        }

        public void CreateDocument(string documentPath) {
            //Defaults to check for when booting up
            AddString("root");
            AddString("admin");
            AddString("demo");
            AddString("sql");
            AddString("test");
            AddString("system");
            using (var fileStream = new FileStream(documentPath, FileMode.Create)) {
                using (var streamWriter = new StreamWriter(fileStream)) {
                    foreach (string banname in strings) {
                        if (banname != null) {
                            streamWriter.WriteLine(banname);
                        }
                    }
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
        }
    }
}
