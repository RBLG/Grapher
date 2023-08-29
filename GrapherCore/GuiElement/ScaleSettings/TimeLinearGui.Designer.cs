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
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            NumUdLength = new System.Windows.Forms.NumericUpDown();
            LabelChunkSize = new System.Windows.Forms.Label();
            NumUdHold = new System.Windows.Forms.NumericUpDown();
            ComboBoxMode = new System.Windows.Forms.ComboBox();
            checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)NumUdLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumUdHold).BeginInit();
            SuspendLayout();
            // 
            // NumUdLength
            // 
            NumUdLength.DecimalPlaces = 1;
            NumUdLength.Location = new System.Drawing.Point(3, 28);
            NumUdLength.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumUdLength.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumUdLength.Name = "NumUdLength";
            NumUdLength.Size = new System.Drawing.Size(83, 23);
            NumUdLength.TabIndex = 7;
            NumUdLength.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumUdLength.ValueChanged += LoopLength_ValueChanged;
            // 
            // LabelChunkSize
            // 
            LabelChunkSize.AutoSize = true;
            LabelChunkSize.Location = new System.Drawing.Point(3, 6);
            LabelChunkSize.Name = "LabelChunkSize";
            LabelChunkSize.Size = new System.Drawing.Size(83, 15);
            LabelChunkSize.TabIndex = 6;
            LabelChunkSize.Text = "Duration (ms):";
            // 
            // NumUdHold
            // 
            NumUdHold.DecimalPlaces = 2;
            NumUdHold.Location = new System.Drawing.Point(164, 28);
            NumUdHold.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumUdHold.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumUdHold.Name = "NumUdHold";
            NumUdHold.Size = new System.Drawing.Size(68, 23);
            NumUdHold.TabIndex = 8;
            NumUdHold.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumUdHold.ValueChanged += NumUdHold_ValueChanged;
            // 
            // ComboBoxMode
            // 
            ComboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ComboBoxMode.FormattingEnabled = true;
            ComboBoxMode.Items.AddRange(new object[] { "Loop", "Hold" });
            ComboBoxMode.Location = new System.Drawing.Point(164, 3);
            ComboBoxMode.Name = "ComboBoxMode";
            ComboBoxMode.Size = new System.Drawing.Size(68, 23);
            ComboBoxMode.TabIndex = 9;
            ComboBoxMode.SelectedIndexChanged += ComboBoxMode_SelectedIndexChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(92, 29);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(68, 19);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "phasing";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += OnPhaseCheckBox_CheckedChanged;
            // 
            // TimeLinearGui
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(checkBox1);
            Controls.Add(ComboBoxMode);
            Controls.Add(NumUdHold);
            Controls.Add(NumUdLength);
            Controls.Add(LabelChunkSize);
            MaximumSize = new System.Drawing.Size(235, 58);
            MinimumSize = new System.Drawing.Size(235, 58);
            Name = "TimeLinearGui";
            Size = new System.Drawing.Size(235, 58);
            ((System.ComponentModel.ISupportInitialize)NumUdLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumUdHold).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumUdLength;
        private System.Windows.Forms.Label LabelChunkSize;
        private System.Windows.Forms.NumericUpDown NumUdHold;
        private System.Windows.Forms.ComboBox ComboBoxMode;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
