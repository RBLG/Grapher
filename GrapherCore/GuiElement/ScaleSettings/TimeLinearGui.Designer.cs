namespace Grapher.GuiElement.ScaleSettings
{
    partial class TimeLinearGui
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
            this.NumUdLength = new System.Windows.Forms.NumericUpDown();
            this.LabelChunkSize = new System.Windows.Forms.Label();
            this.NumUdHold = new System.Windows.Forms.NumericUpDown();
            this.ComboBoxMode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdHold)).BeginInit();
            this.SuspendLayout();
            // 
            // NumUdLength
            // 
            this.NumUdLength.DecimalPlaces = 1;
            this.NumUdLength.Location = new System.Drawing.Point(3, 28);
            this.NumUdLength.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NumUdLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUdLength.Name = "NumUdLength";
            this.NumUdLength.Size = new System.Drawing.Size(83, 23);
            this.NumUdLength.TabIndex = 7;
            this.NumUdLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUdLength.ValueChanged += new System.EventHandler(this.LoopLength_ValueChanged);
            // 
            // LabelChunkSize
            // 
            this.LabelChunkSize.AutoSize = true;
            this.LabelChunkSize.Location = new System.Drawing.Point(3, 6);
            this.LabelChunkSize.Name = "LabelChunkSize";
            this.LabelChunkSize.Size = new System.Drawing.Size(83, 15);
            this.LabelChunkSize.TabIndex = 6;
            this.LabelChunkSize.Text = "Duration (ms):";
            // 
            // NumUdHold
            // 
            this.NumUdHold.DecimalPlaces = 2;
            this.NumUdHold.Location = new System.Drawing.Point(164, 28);
            this.NumUdHold.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NumUdHold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUdHold.Name = "NumUdHold";
            this.NumUdHold.Size = new System.Drawing.Size(68, 23);
            this.NumUdHold.TabIndex = 8;
            this.NumUdHold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUdHold.ValueChanged += new System.EventHandler(this.NumUdHold_ValueChanged);
            // 
            // ComboBoxMode
            // 
            this.ComboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxMode.FormattingEnabled = true;
            this.ComboBoxMode.Items.AddRange(new object[] {
            "Loop",
            "Hold"});
            this.ComboBoxMode.Location = new System.Drawing.Point(164, 3);
            this.ComboBoxMode.Name = "ComboBoxMode";
            this.ComboBoxMode.Size = new System.Drawing.Size(68, 23);
            this.ComboBoxMode.TabIndex = 9;
            this.ComboBoxMode.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMode_SelectedIndexChanged);
            // 
            // TimeLinearGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ComboBoxMode);
            this.Controls.Add(this.NumUdHold);
            this.Controls.Add(this.NumUdLength);
            this.Controls.Add(this.LabelChunkSize);
            this.MaximumSize = new System.Drawing.Size(235, 58);
            this.MinimumSize = new System.Drawing.Size(235, 58);
            this.Name = "TimeLinearGui";
            this.Size = new System.Drawing.Size(235, 58);
            ((System.ComponentModel.ISupportInitialize)(this.NumUdLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdHold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumUdLength;
        private System.Windows.Forms.Label LabelChunkSize;
        private System.Windows.Forms.NumericUpDown NumUdHold;
        private System.Windows.Forms.ComboBox ComboBoxMode;
    }
}
