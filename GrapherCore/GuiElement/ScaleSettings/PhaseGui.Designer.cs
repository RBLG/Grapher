namespace Grapher.GuiElement.ScaleSettings
{
    partial class PhaseGui
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
            this.NumUdOffset = new System.Windows.Forms.NumericUpDown();
            this.OffsetLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // NumUdOffset
            // 
            this.NumUdOffset.DecimalPlaces = 3;
            this.NumUdOffset.Location = new System.Drawing.Point(3, 18);
            this.NumUdOffset.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumUdOffset.Name = "NumUdOffset";
            this.NumUdOffset.Size = new System.Drawing.Size(82, 23);
            this.NumUdOffset.TabIndex = 5;
            this.NumUdOffset.ValueChanged += new System.EventHandler(this.NumUdOffset_ValueChanged);
            // 
            // OffsetLabel
            // 
            this.OffsetLabel.AutoSize = true;
            this.OffsetLabel.Location = new System.Drawing.Point(3, 0);
            this.OffsetLabel.Name = "OffsetLabel";
            this.OffsetLabel.Size = new System.Drawing.Size(42, 15);
            this.OffsetLabel.TabIndex = 4;
            this.OffsetLabel.Text = "Offset:";
            // 
            // PhaseGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NumUdOffset);
            this.Controls.Add(this.OffsetLabel);
            this.MaximumSize = new System.Drawing.Size(235, 58);
            this.MinimumSize = new System.Drawing.Size(235, 58);
            this.Name = "PhaseGui";
            this.Size = new System.Drawing.Size(235, 58);
            ((System.ComponentModel.ISupportInitialize)(this.NumUdOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumUdOffset;
        private System.Windows.Forms.Label OffsetLabel;
    }
}
