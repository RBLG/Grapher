namespace Grapher.GuiElement.ScaleSettings
{
    partial class FrequencyInputGui
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
            UnitComboBox = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // UnitComboBox
            // 
            UnitComboBox.FormattingEnabled = true;
            UnitComboBox.Location = new System.Drawing.Point(3, 3);
            UnitComboBox.Name = "UnitComboBox";
            UnitComboBox.Size = new System.Drawing.Size(121, 23);
            UnitComboBox.TabIndex = 0;
            // 
            // FrequencyLinearGui
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(UnitComboBox);
            MaximumSize = new System.Drawing.Size(235, 58);
            MinimumSize = new System.Drawing.Size(235, 58);
            Name = "FrequencyLinearGui";
            Size = new System.Drawing.Size(235, 58);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox UnitComboBox;
    }
}
