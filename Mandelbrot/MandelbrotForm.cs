﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class MandelbrotForm : Form
    {
        public Control centerX;
        public Control centerY;
        public Control scale;
        public Control max;

        internal InputHandler InputHandler { get; private set; }

        public MandelbrotForm()
        {
            this.InputHandler = new InputHandler();

            InitializeComponent();

            CreateControls();

            this.MouseClick += HandleMouseClick;
            this.Enter += HandleGoButtonClick;
        }

        private void HandleMouseClick(object sender, MouseEventArgs e)
        {
            InputHandler.HandleMouseClick(this, e);
        }

        private void HandleGoButtonClick(object sender, EventArgs e)
        {
            InputHandler.HandleGoButtonClick(this);
        }

        /// <summary>
        /// Create the controls for the form.
        /// </summary>
        private void CreateControls()
        {
            this.centerX = CreateControl(20, 30, 0.0, "centerX", "Middelste x:");
            this.centerY = CreateControl(20, 50, 0.0, "centerY", "Middelste y:");
            this.scale = CreateControl(300, 30, 0.001, "scale", "Schaal:");
            this.max = CreateControl(300, 50, 100, "max", "Max:", false);

            MenuStrip menu = new MenuStrip();
            ToolStripDropDownButton dropdown = new ToolStripDropDownButton("Image");
            menu.Items.Add(dropdown);
            Controls.Add(menu);

            CreateGoButton();
        }

        /// <summary>
        /// Create the go button for the form.
        /// </summary>
        private void CreateGoButton()
        {
            var goButton = new Button() { Text = "Go!" };
            goButton.Click += HandleGoButtonClick;
            goButton.Location = new Point(20,100);

            this.Controls.Add(goButton);
        }

        private Control CreateControl(int x, int y, double value, string name, string label, bool hasDecimalValues = true)
        {
            Label Description = new Label()
            {
                Text = label,
                Location = new Point(x, y)
            };

            this.Controls.Add(Description);

            //Nummerbox
            NumericUpDown ValueBox = new NumericUpDown()
            {
                Location = new Point(Description.Width + 20 + x, y),
                Size = new Size(100, 20),
                Text = value.ToString(),
                Name = name,
                DecimalPlaces = hasDecimalValues ? 8 : 0,
                Increment = hasDecimalValues ? 0.01m : 1,
                Minimum = hasDecimalValues  ? - 100 : 0,
                Maximum = 1000,
            };

            this.Controls.Add(ValueBox);
            return ValueBox;
        }
    }
}
