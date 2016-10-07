using System;
using System.Drawing;
using System.Windows.Forms;
using Mandelbrot.Models;
//using System.Windows.Controls;

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
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorPicker = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem,
            this.presetToolStripMenuItem,
            this.helpToolStripMenuItem});
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
            this.presetToolStripMenuItem.Name = "presetToolStripMenuItem";
            this.presetToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.presetToolStripMenuItem.Text = "Presets";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userGuideToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // userGuideToolStripMenuItem
            // 
            this.userGuideToolStripMenuItem.Name = "userGuideToolStripMenuItem";
            this.userGuideToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.userGuideToolStripMenuItem.Text = "User guide";
            this.userGuideToolStripMenuItem.Click += new System.EventHandler(this.userGuide_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.about_Click);
            // 
            // colorPicker
            // 
            this.colorPicker.FormattingEnabled = true;
            this.colorPicker.Location = new System.Drawing.Point(400, 30);
            this.colorPicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(85, 21);
            this.colorPicker.TabIndex = 1;
            // 
            // MandelbrotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 641);
            this.Controls.Add(this.colorPicker);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MandelbrotForm";
            this.Text = "Mandelbrot";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void CreateCustomControls()
        {
            this.centerX = CreateControl(20, 30, 0.0, "centerX", "Center x:");
            this.centerY = CreateControl(20, 52, 0.0, "centerY", "Center y:");
            this.scale = CreateControl(200, 30, 0.001, "scale", "Scale:");
            this.max = CreateControl(200, 52, 100, "max", "Max:", false);

            AddPresetOptions();
            AddColorOpions();
            CreateGoButton();
        }

        private void AddPresetOptions()
        {
            foreach (var preset in PresetsHandler.presets)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem()
                {
                    Name = preset.Name,
                    Size = new Size(152, 22),
                    Text = preset.Name,

                };
                menuItem.Click += new EventHandler(this.PresetSelected);

                this.presetToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }

        private void AddColorOpions()
        {
            var schemes = Enum.GetValues(typeof(ColorSchemes));

            foreach (var scheme in schemes)
            {
                System.Windows.Controls.ComboBoxItem menuItem = new System.Windows.Controls.ComboBoxItem()
                {
                    Name = scheme.ToString()
                };

                this.colorPicker.Items.Add(menuItem.Name);
            }
            colorPicker.SelectedIndexChanged += new EventHandler(this.ColorSelected);
        }


        /// <summary>
        /// Create the go button for the form.
        /// </summary>
        private void CreateGoButton()
        {
            var goButton = new Button() { Text = "Go!" };
            goButton.Click += HandleGoButtonClick;
            goButton.Location = new Point(500, 30);
            goButton.Width = 50;

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
                Location = new Point(x, y),
                Width = 70
            };

            this.Controls.Add(Description);

            //Nummerbox with its properties
            TextBox ValueBox = new TextBox()
            {
                Location = new Point(Description.Width + 5 + x, y),
                Size = new Size(100, 20),
                Text = value.ToString(),
                Name = name
            };

            this.Controls.Add(ValueBox);
            return ValueBox;
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem imageToolStripMenuItem;
        private ToolStripMenuItem ImageMenuItem;
        private ToolStripMenuItem presetToolStripMenuItem;
        private ComboBox colorPicker;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem userGuideToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}

