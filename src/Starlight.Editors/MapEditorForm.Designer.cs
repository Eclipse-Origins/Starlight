namespace Starlight.Editors
{
    partial class MapEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditorForm));
            this.menu = new DarkUI.Controls.DarkMenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.darkToolStrip1 = new DarkUI.Controls.DarkToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tilesGroupBox = new DarkUI.Controls.DarkGroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tilesetPanel = new Starlight.Editors.Controls.TilesetViewer();
            this.tilesetsComboBox = new DarkUI.Controls.DarkComboBox();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.darkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.darkButton2 = new DarkUI.Controls.DarkButton();
            this.darkButton1 = new DarkUI.Controls.DarkButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menu.SuspendLayout();
            this.darkToolStrip1.SuspendLayout();
            this.tilesGroupBox.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetPanel)).BeginInit();
            this.darkGroupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1325, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "darkMenuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem});
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(33, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.exitMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitMenuItem.Size = new System.Drawing.Size(132, 26);
            this.exitMenuItem.Text = "Exit";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem2.Text = "Editors";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGrid1.Location = new System.Drawing.Point(1106, 24);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(219, 966);
            this.propertyGrid1.TabIndex = 1;
            // 
            // darkToolStrip1
            // 
            this.darkToolStrip1.AutoSize = false;
            this.darkToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkToolStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.darkToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.darkToolStrip1.Location = new System.Drawing.Point(269, 24);
            this.darkToolStrip1.Name = "darkToolStrip1";
            this.darkToolStrip1.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.darkToolStrip1.Size = new System.Drawing.Size(837, 35);
            this.darkToolStrip1.TabIndex = 2;
            this.darkToolStrip1.Text = "darkToolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "Save";
            // 
            // tilesGroupBox
            // 
            this.tilesGroupBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tilesGroupBox.Controls.Add(this.panel4);
            this.tilesGroupBox.Controls.Add(this.tilesetsComboBox);
            this.tilesGroupBox.Controls.Add(this.darkLabel1);
            this.tilesGroupBox.Controls.Add(this.panel1);
            this.tilesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilesGroupBox.Location = new System.Drawing.Point(0, 43);
            this.tilesGroupBox.Name = "tilesGroupBox";
            this.tilesGroupBox.Size = new System.Drawing.Size(269, 923);
            this.tilesGroupBox.TabIndex = 3;
            this.tilesGroupBox.TabStop = false;
            this.tilesGroupBox.Text = "Tiles";
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.tilesetPanel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 71);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(263, 849);
            this.panel4.TabIndex = 8;
            // 
            // tilesetPanel
            // 
            this.tilesetPanel.BackColor = System.Drawing.Color.White;
            this.tilesetPanel.Location = new System.Drawing.Point(0, 0);
            this.tilesetPanel.Name = "tilesetPanel";
            this.tilesetPanel.Size = new System.Drawing.Size(234, 405);
            this.tilesetPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.tilesetPanel.TabIndex = 0;
            this.tilesetPanel.TabStop = false;
            // 
            // tilesetsComboBox
            // 
            this.tilesetsComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilesetsComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.tilesetsComboBox.FormattingEnabled = true;
            this.tilesetsComboBox.Location = new System.Drawing.Point(3, 43);
            this.tilesetsComboBox.Name = "tilesetsComboBox";
            this.tilesetsComboBox.Size = new System.Drawing.Size(263, 28);
            this.tilesetsComboBox.TabIndex = 6;
            this.tilesetsComboBox.SelectedIndexChanged += new System.EventHandler(this.tilesetsComboBox_SelectedIndexChanged);
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(3, 23);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(52, 20);
            this.darkLabel1.TabIndex = 7;
            this.darkLabel1.Text = "Tileset";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(-280, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 599);
            this.panel1.TabIndex = 5;
            // 
            // darkGroupBox2
            // 
            this.darkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.darkGroupBox2.Controls.Add(this.darkButton2);
            this.darkGroupBox2.Controls.Add(this.darkButton1);
            this.darkGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.darkGroupBox2.Name = "darkGroupBox2";
            this.darkGroupBox2.Size = new System.Drawing.Size(269, 43);
            this.darkGroupBox2.TabIndex = 4;
            this.darkGroupBox2.TabStop = false;
            // 
            // darkButton2
            // 
            this.darkButton2.Location = new System.Drawing.Point(93, 8);
            this.darkButton2.Name = "darkButton2";
            this.darkButton2.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton2.Size = new System.Drawing.Size(81, 29);
            this.darkButton2.TabIndex = 0;
            this.darkButton2.Text = "Attributes";
            // 
            // darkButton1
            // 
            this.darkButton1.Location = new System.Drawing.Point(6, 8);
            this.darkButton1.Name = "darkButton1";
            this.darkButton1.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton1.Size = new System.Drawing.Size(81, 29);
            this.darkButton1.TabIndex = 0;
            this.darkButton1.Text = "Tiles";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tilesGroupBox);
            this.panel2.Controls.Add(this.darkGroupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 966);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Lime;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(269, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(837, 931);
            this.panel3.TabIndex = 6;
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 990);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.darkToolStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MapEditorForm";
            this.Text = "Map Editor - Eclipse Starlight";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.darkToolStrip1.ResumeLayout(false);
            this.darkToolStrip1.PerformLayout();
            this.tilesGroupBox.ResumeLayout(false);
            this.tilesGroupBox.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetPanel)).EndInit();
            this.darkGroupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private DarkUI.Controls.DarkToolStrip darkToolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private DarkUI.Controls.DarkGroupBox tilesGroupBox;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkComboBox tilesetsComboBox;
        private System.Windows.Forms.Panel panel1;
        private DarkUI.Controls.DarkGroupBox darkGroupBox2;
        private DarkUI.Controls.DarkButton darkButton2;
        private DarkUI.Controls.DarkButton darkButton1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Starlight.Editors.Controls.TilesetViewer tilesetPanel;
        private System.Windows.Forms.Panel panel4;
    }
}