using Starlight.Resources;
using System;
using System.IO;

namespace Starlight.Editors
{
    public partial class MapEditorForm : StarlightForm
    {
        public MapEditorForm(StarlightContext context) : base(context)
        {
            InitializeComponent();

            this.LoadTilesets();
        }

        private void LoadTilesets()
        {
            this.tilesetsComboBox.Items.Clear();

            foreach (var file in Directory.EnumerateFiles(ResourceStore.Instance.TilesetsDirectory, "*.png", SearchOption.TopDirectoryOnly))
            {
                this.tilesetsComboBox.Items.Add(Path.GetFileName(file));
            }

            this.tilesetsComboBox.SelectedIndex = 0;
        }

        private void DisplayTileset(string tileset)
        {
            this.tilesetPanel.ChangeTileset(Path.Combine(ResourceStore.Instance.TilesetsDirectory, tileset));
        }

        private void tilesetsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tileset = (string)tilesetsComboBox.SelectedItem;

            DisplayTileset(tileset);
        }
    }
}
