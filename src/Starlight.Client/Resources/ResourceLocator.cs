using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Starlight.Client.Resources
{
    public class ResourceLocator
    {
        private readonly string workingDirectory;

        public ResourceLocator(string workingDirectory) {
            this.workingDirectory = workingDirectory;
        }

        public string LocateAssetPath(params string[] paths) {
            return Path.Combine(workingDirectory, "Assets", Path.Combine(paths));
        }

        public string LocateContentPath(params string[] paths) {
            return Path.Combine(workingDirectory, "Content", Path.Combine(paths));
        }
    }
}
