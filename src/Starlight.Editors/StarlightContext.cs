using Starlight.Editors.Network;
using Starlight.Network;
using Starlight.Translations;
using System.IO;

namespace Starlight.Editors
{
    public class StarlightContext
    {
        public string WorkingDirectory { get; }

        public StarlightClient NetworkClient { get; }
        public NetworkDispatch NetworkDispatch { get; }

        public FormContainer FormContainer { get; }

        public StarlightContext(string workingDirectory)
        {
            this.WorkingDirectory = workingDirectory;

            this.FormContainer = new FormContainer(this);

            this.NetworkClient = new StarlightClient(new Telepathy.Client());
            this.NetworkDispatch = new NetworkDispatch(this.NetworkClient, this.FormContainer);

            this.NetworkDispatch.ResolveHandlers();
        }

        public void LoadContent()
        {
            TranslationManager.Instance.ImportFromDocument(Path.Combine(WorkingDirectory, "Content", "Languages", "en-us.json"));
        }

        public void Connect()
        {
            this.NetworkClient.Client.Connect("localhost", 1338);
        }
    }
}
