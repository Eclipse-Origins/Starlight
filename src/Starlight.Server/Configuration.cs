using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Starlight.Server
{
    public class Configuration
    {
        public string ConnectionString { get; set; }
        public int Port { get; set; }

        public static Configuration Read(string path) {
            var serializer = JsonSerializer.Create();

            using var fileStream = new FileStream(path, FileMode.Open);
            using var streamReader = new StreamReader(fileStream);
            using var jsonReader = new JsonTextReader(streamReader);
            return serializer.Deserialize<Configuration>(jsonReader);
        }
    }
}
