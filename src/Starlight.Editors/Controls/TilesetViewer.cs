using System;
using System.Drawing;
using System.Windows.Forms;

namespace Starlight.Editors.Controls
{
    public class TilesetViewer : PictureBox
    {
        Point? selectionStart;
        public Rectangle? Selection { get; set; }

        public TilesetViewer()
        {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);

            this.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public void ChangeTileset(string tilesetPath)
        {
            this.Image = new Bitmap(tilesetPath);

            this.selectionStart = null;
            this.Selection = null;

            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            var startX = e.X / Constants.TileSize;
            var startY = e.Y / Constants.TileSize;

            this.selectionStart = new Point(startX, startY);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            UpdateSelection(e.X, e.Y);

            selectionStart = null;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            UpdateSelection(e.X, e.Y);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Selection.HasValue)
            {
                using (var selectionPen = new Pen(Color.Red))
                {
                    e.Graphics.DrawRectangle(selectionPen, new Rectangle(Selection.Value.X * Constants.TileSize, Selection.Value.Y * Constants.TileSize, Selection.Value.Width * Constants.TileSize, Selection.Value.Height * Constants.TileSize));
                }
            }
        }

        private void UpdateSelection(int x, int y)
        {
            var endX = x / Constants.TileSize;
            var endY = y / Constants.TileSize;

            if (this.selectionStart.HasValue)
            {
                var width = Math.Max(1, (endX - this.selectionStart.Value.X) + 1);
                var height = Math.Max(1, (endY - this.selectionStart.Value.Y) + 1);

                this.Selection = new Rectangle(this.selectionStart.Value.X, this.selectionStart.Value.Y, width, height);

                this.Invalidate();
            }
        }
    }
}
