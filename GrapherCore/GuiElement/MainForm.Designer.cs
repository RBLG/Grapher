namespace Grapher
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainSettings1 = new Grapher.GuiElement.MainSettings();
            this.SuspendLayout();
            // 
            // mainSettings1
            // 
            this.mainSettings1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainSettings1.Location = new System.Drawing.Point(14, 14);
            this.mainSettings1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.mainSettings1.MaximumSize = new System.Drawing.Size(478, 273);
            this.mainSettings1.MinimumSize = new System.Drawing.Size(478, 273);
            this.mainSettings1.Name = "mainSettings1";
            this.mainSettings1.Size = new System.Drawing.Size(478, 273);
            this.mainSettings1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 301);
            this.Controls.Add(this.mainSettings1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(522, 340);
            this.MinimumSize = new System.Drawing.Size(522, 340);
            this.Name = "MainForm";
            this.Text = "Main settings";
            this.ResumeLayout(false);

        }

        #endregion

        private GuiElement.MainSettings mainSettings1;
    }
}

