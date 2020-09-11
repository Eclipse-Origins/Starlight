using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Starlight.Editors.Controls
{
    public class TilesetViewer : PictureBox
    {
        Bitmap tilesetBitmap;

        public TilesetViewer() {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);

            this.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public void ChangeTileset(string tilesetPath) {
            this.Image = new Bitmap(tilesetPath);

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            if (tilesetBitmap != null) {
                e.Graphics.DrawImage(tilesetBitmap, new Point(0, 0));
            }
        }
    }
}
