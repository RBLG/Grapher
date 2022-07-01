namespace Grapher.GuiElement.ScaleSettings
{
    partial class PhaseInputGui
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
            this.NumUdDetune = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckBoxIsAbsolute = new System.Windows.Forms.CheckBox();
            this.NumUdAmount = new System.Windows.Forms.NumericUpDown();
            this.OffsetLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdDetune)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // NumUdDetune
            // 
            this.NumUdDetune.Location = new System.Drawing.Point(64, 21);
            this.NumUdDetune.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.NumUdDetune.Minimum = new decimal(new int[] {
            20000,
            0,
            0,
            -2147483648});
            this.NumUdDetune.Name = "NumUdDetune";
            this.NumUdDetune.Size = new System.Drawing.Size(82, 23);
            this.NumUdDetune.TabIndex = 6;
            this.NumUdDetune.ValueChanged += new System.EventHandler(this.NumUdDetune_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Detune:";
            // 
            // CheckBoxIsAbsolute
            // 
            this.CheckBoxIsAbsolute.AutoSize = true;
            this.CheckBoxIsAbsolute.Location = new System.Drawing.Point(159, 3);
            this.CheckBoxIsAbsolute.Name = "CheckBoxIsAbsolute";
            this.CheckBoxIsAbsolute.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckBoxIsAbsolute.Size = new System.Drawing.Size(73, 19);
            this.CheckBoxIsAbsolute.TabIndex = 12;
            this.CheckBoxIsAbsolute.Text = "Absolute";
            this.CheckBoxIsAbsolute.UseVisualStyleBackColor = true;
            this.CheckBoxIsAbsolute.CheckedChanged += new System.EventHandler(this.CheckBoxIsAbsolute_CheckedChanged);
            // 
            // NumUdAmount
            // 
            this.NumUdAmount.Location = new System.Drawing.Point(3, 21);
            this.NumUdAmount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumUdAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUdAmount.Name = "NumUdAmount";
            this.NumUdAmount.Size = new System.Drawing.Size(55, 23);
            this.NumUdAmount.TabIndex = 14;
            this.NumUdAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUdAmount.ValueChanged += new System.EventHandler(this.NumUdAmount_ValueChanged);
            // 
            // OffsetLabel
            // 
            this.OffsetLabel.AutoSize = true;
            this.OffsetLabel.Location = new System.Drawing.Point(3, 3);
            this.OffsetLabel.Name = "OffsetLabel";
            this.OffsetLabel.Size = new System.Drawing.Size(54, 15);
            this.OffsetLabel.TabIndex = 13;
            this.OffsetLabel.Text = "Amount:";
            // 
            // PhaseInputGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NumUdAmount);
            this.Controls.Add(this.OffsetLabel);
            this.Controls.Add(this.CheckBoxIsAbsolute);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumUdDetune);
            this.MaximumSize = new System.Drawing.Size(235, 58);
            this.MinimumSize = new System.Drawing.Size(235, 58);
            this.Name = "PhaseInputGui";
            this.Size = new System.Drawing.Size(235, 58);
            ((System.ComponentModel.ISupportInitialize)(this.NumUdDetune)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown NumUdDetune;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckBoxIsAbsolute;
        private System.Windows.Forms.NumericUpDown NumUdAmount;
        private System.Windows.Forms.Label OffsetLabel;
    }
}
