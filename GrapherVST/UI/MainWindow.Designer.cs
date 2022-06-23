namespace GrapherVST.UI
{
    partial class MainWindow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.settings = new Grapher.GuiElement.MainSettings();
            this.SuspendLayout();
            // 
            // mainSettings1
            // 
            this.settings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settings.BackColor = System.Drawing.SystemColors.Control;
            this.settings.Location = new System.Drawing.Point(4, 3);
            this.settings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.settings.Name = "mainSettings1";
            this.settings.Size = new System.Drawing.Size(478, 273);
            this.settings.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.settings);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Size = new System.Drawing.Size(486, 280);
            this.ResumeLayout(false);

        }

        #endregion

        public Grapher.GuiElement.MainSettings settings;
    }
}
