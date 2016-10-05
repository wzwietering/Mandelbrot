using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot
{
    partial class MandelbrotForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mooiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nogMooierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ookMooiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maaikeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redGreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueGreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redBlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem,
            this.presetToolStripMenuItem,
            this.colorsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImageMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // ImageMenuItem
            // 
            this.ImageMenuItem.Name = "ImageMenuItem";
            this.ImageMenuItem.Size = new System.Drawing.Size(98, 22);
            this.ImageMenuItem.Text = "Save";
            this.ImageMenuItem.Click += new System.EventHandler(this.HandleSaveClick);
            // 
            // presetToolStripMenuItem
            // 
            this.presetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mooiToolStripMenuItem,
            this.nogMooierToolStripMenuItem,
            this.ookMooiToolStripMenuItem,
            this.maaikeToolStripMenuItem});
            this.presetToolStripMenuItem.Name = "presetToolStripMenuItem";
            this.presetToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.presetToolStripMenuItem.Text = "Preset";
            // 
            // mooiToolStripMenuItem
            // 
            this.mooiToolStripMenuItem.Name = "mooiToolStripMenuItem";
            this.mooiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mooiToolStripMenuItem.Text = "Mooi";
            this.mooiToolStripMenuItem.Click += new System.EventHandler(this.PresetSelected);
            // 
            // nogMooierToolStripMenuItem
            // 
            this.nogMooierToolStripMenuItem.Name = "nogMooierToolStripMenuItem";
            this.nogMooierToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nogMooierToolStripMenuItem.Text = "Nog mooier";
            this.nogMooierToolStripMenuItem.Click += new System.EventHandler(this.PresetSelected);
            // 
            // ookMooiToolStripMenuItem
            // 
            this.ookMooiToolStripMenuItem.Name = "ookMooiToolStripMenuItem";
            this.ookMooiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ookMooiToolStripMenuItem.Text = "Ook mooi";
            this.ookMooiToolStripMenuItem.Click += new System.EventHandler(this.PresetSelected);
            // 
            // maaikeToolStripMenuItem
            // 
            this.maaikeToolStripMenuItem.Name = "maaikeToolStripMenuItem";
            this.maaikeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.maaikeToolStripMenuItem.Text = "Maaike";
            this.maaikeToolStripMenuItem.Click += new System.EventHandler(this.PresetSelected);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redGreenToolStripMenuItem,
            this.blueGreenToolStripMenuItem,
            this.redBlueToolStripMenuItem});
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.colorsToolStripMenuItem.Text = "Colors";
            // 
            // redGreenToolStripMenuItem
            // 
            this.redGreenToolStripMenuItem.Name = "redGreenToolStripMenuItem";
            this.redGreenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.redGreenToolStripMenuItem.Text = "RedGreen";
            this.redGreenToolStripMenuItem.Click += new System.EventHandler(this.ColorSelected);
            // 
            // blueGreenToolStripMenuItem
            // 
            this.blueGreenToolStripMenuItem.Name = "blueGreenToolStripMenuItem";
            this.blueGreenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.blueGreenToolStripMenuItem.Text = "BlueGreen";
            this.blueGreenToolStripMenuItem.Click += new System.EventHandler(this.ColorSelected);
            // 
            // redBlueToolStripMenuItem
            // 
            this.redBlueToolStripMenuItem.Name = "redBlueToolStripMenuItem";
            this.redBlueToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.redBlueToolStripMenuItem.Text = "RedBlue";
            this.redBlueToolStripMenuItem.Click += new System.EventHandler(this.ColorSelected);
            // 
            // MandelbrotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MandelbrotForm";
            this.Text = "Mandelbrot";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void CreateControls()
        {
            this.centerX = CreateControl(20, 30, 0.0, "centerX", "Middelste x:");
            this.centerY = CreateControl(20, 50, 0.0, "centerY", "Middelste y:");
            this.scale = CreateControl(300, 30, 0.001, "scale", "Schaal:");
            this.max = CreateControl(300, 50, 100, "max", "Max:", false);

            CreateGoButton();
        }

        /// <summary>
        /// Create the go button for the form.
        /// </summary>
        private void CreateGoButton()
        {
            var goButton = new Button() { Text = "Go!" };
            goButton.Click += HandleGoButtonClick;
            goButton.Location = new Point(20, 100);

            this.Controls.Add(goButton);
        }

        /// <summary>
        /// This method creates a label and a numericupdown.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="label"></param>
        /// <param name="hasDecimalValues"></param>
        /// <returns></returns>
        private Control CreateControl(int x, int y, double value, string name, string label, bool hasDecimalValues = true)
        {
            Label Description = new Label()
            {
                Text = label,
                Location = new Point(x, y)
            };

            this.Controls.Add(Description);

            //Nummerbox with its properties
            TextBox ValueBox = new TextBox()
            {
                Location = new Point(Description.Width + 10 + x, y),
                Size = new Size(100, 20),
                Text = value.ToString(),
                Name = name
            };

            this.Controls.Add(ValueBox);
            return ValueBox;
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mooiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nogMooierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redGreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueGreenToolStripMenuItem;
        private ToolStripMenuItem ookMooiToolStripMenuItem;
        private ToolStripMenuItem maaikeToolStripMenuItem;
        private ToolStripMenuItem redBlueToolStripMenuItem;
    }
}

