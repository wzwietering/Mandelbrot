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
            this.preset1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preset2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coolStuffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preset1ToolStripMenuItem,
            this.preset2ToolStripMenuItem,
            this.coolStuffToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // preset1ToolStripMenuItem
            // 
            this.preset1ToolStripMenuItem.Name = "preset1ToolStripMenuItem";
            this.preset1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.preset1ToolStripMenuItem.Text = "Preset1";
            // 
            // preset2ToolStripMenuItem
            // 
            this.preset2ToolStripMenuItem.Name = "preset2ToolStripMenuItem";
            this.preset2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.preset2ToolStripMenuItem.Text = "Hoi!";
            this.preset2ToolStripMenuItem.Click += new System.EventHandler(this.preset2ToolStripMenuItem_Click);
            // 
            // coolStuffToolStripMenuItem
            // 
            this.coolStuffToolStripMenuItem.Name = "coolStuffToolStripMenuItem";
            this.coolStuffToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.coolStuffToolStripMenuItem.Text = "CoolStuff";
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

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preset1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preset2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coolStuffToolStripMenuItem;
    }
}

