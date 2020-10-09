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
            using (var fileStream = new FileStream(documentPath, FileMode.Open)) {
                using (var streamReader = new StreamReader(fileStream)) {
                    string line = null;
                    do{
                        line = streamReader.ReadLine();
                        if (line != null) {
                            AddString(line);
                        }
                    }while (line != null) ;
                }
            }
        }
    }
}
