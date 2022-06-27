namespace Grapher.GuiElement.ScaleSettings
{
    partial class ModeSetGui
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.NumUdIntensity = new System.Windows.Forms.NumericUpDown();
            this.MaxLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdIntensity)).BeginInit();
            this.SuspendLayout();
            // 
            // NumUdIntensity
            // 
            this.NumUdIntensity.DecimalPlaces = 3;
            this.NumUdIntensity.Location = new System.Drawing.Point(3, 21);
            this.NumUdIntensity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumUdIntensity.Name = "NumUdIntensity";
            this.NumUdIntensity.Size = new System.Drawing.Size(82, 23);
            this.NumUdIntensity.TabIndex = 3;
            this.NumUdIntensity.ValueChanged += new System.EventHandler(this.NumUdIntensity_ValueChanged);
            // 
            // MaxLabel
            // 
            this.MaxLabel.AutoSize = true;
            this.MaxLabel.Location = new System.Drawing.Point(3, 3);
            this.MaxLabel.Name = "MaxLabel";
            this.MaxLabel.Size = new System.Drawing.Size(33, 15);
            this.MaxLabel.TabIndex = 2;
            this.MaxLabel.Text = "Max:";
            // 
            // ModeSetGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NumUdIntensity);
            this.Controls.Add(this.MaxLabel);
            this.MaximumSize = new System.Drawing.Size(235, 58);
            this.MinimumSize = new System.Drawing.Size(235, 58);
            this.Name = "ModeSetGui";
            this.Size = new System.Drawing.Size(235, 58);
            ((System.ComponentModel.ISupportInitialize)(this.NumUdIntensity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumUdIntensity;
        private System.Windows.Forms.Label MaxLabel;
    }
}
