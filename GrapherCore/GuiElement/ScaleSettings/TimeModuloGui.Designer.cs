namespace Grapher.GuiElement.ScaleSettings
{
    partial class TimeModuloGui
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
            CheckBoxIsRandom = new System.Windows.Forms.CheckBox();
            CheckBoxIsLooping = new System.Windows.Forms.CheckBox();
            LabelChunkSize = new System.Windows.Forms.Label();
            NumUdChunkSize = new System.Windows.Forms.NumericUpDown();
            NumUdSeed = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            CheckBoxIsPhasing = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)NumUdChunkSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumUdSeed).BeginInit();
            SuspendLayout();
            // 
            // CheckBoxIsRandom
            // 
            CheckBoxIsRandom.AutoSize = true;
            CheckBoxIsRandom.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            CheckBoxIsRandom.Location = new System.Drawing.Point(161, 3);
            CheckBoxIsRandom.Name = "CheckBoxIsRandom";
            CheckBoxIsRandom.Size = new System.Drawing.Size(71, 19);
            CheckBoxIsRandom.TabIndex = 0;
            CheckBoxIsRandom.Text = "Random";
            CheckBoxIsRandom.UseVisualStyleBackColor = true;
            CheckBoxIsRandom.CheckedChanged += CheckBoxIsRandom_CheckedChanged;
            // 
            // CheckBoxIsLooping
            // 
            CheckBoxIsLooping.AutoSize = true;
            CheckBoxIsLooping.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            CheckBoxIsLooping.Location = new System.Drawing.Point(179, 21);
            CheckBoxIsLooping.Name = "CheckBoxIsLooping";
            CheckBoxIsLooping.Size = new System.Drawing.Size(53, 19);
            CheckBoxIsLooping.TabIndex = 1;
            CheckBoxIsLooping.Text = "Loop";
            CheckBoxIsLooping.UseVisualStyleBackColor = true;
            CheckBoxIsLooping.CheckedChanged += CheckBoxIsLooping_CheckedChanged;
            // 
            // LabelChunkSize
            // 
            LabelChunkSize.AutoSize = true;
            LabelChunkSize.Location = new System.Drawing.Point(3, 3);
            LabelChunkSize.Name = "LabelChunkSize";
            LabelChunkSize.Size = new System.Drawing.Size(82, 15);
            LabelChunkSize.TabIndex = 3;
            LabelChunkSize.Text = "Chunk length:";
            // 
            // NumUdChunkSize
            // 
            NumUdChunkSize.DecimalPlaces = 1;
            NumUdChunkSize.Location = new System.Drawing.Point(3, 21);
            NumUdChunkSize.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NumUdChunkSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumUdChunkSize.Name = "NumUdChunkSize";
            NumUdChunkSize.Size = new System.Drawing.Size(84, 23);
            NumUdChunkSize.TabIndex = 4;
            NumUdChunkSize.Tag = "";
            NumUdChunkSize.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumUdChunkSize.ValueChanged += NumUdChunkSize_ValueChanged;
            // 
            // NumUdSeed
            // 
            NumUdSeed.DecimalPlaces = 1;
            NumUdSeed.Location = new System.Drawing.Point(93, 21);
            NumUdSeed.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            NumUdSeed.Name = "NumUdSeed";
            NumUdSeed.Size = new System.Drawing.Size(54, 23);
            NumUdSeed.TabIndex = 5;
            NumUdSeed.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumUdSeed.ValueChanged += NumUdSeed_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(91, 3);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 15);
            label1.TabIndex = 6;
            label1.Text = "Seed:";
            // 
            // checkBox1
            // 
            CheckBoxIsPhasing.AutoSize = true;
            CheckBoxIsPhasing.Location = new System.Drawing.Point(164, 39);
            CheckBoxIsPhasing.Name = "checkBox1";
            CheckBoxIsPhasing.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            CheckBoxIsPhasing.Size = new System.Drawing.Size(68, 19);
            CheckBoxIsPhasing.TabIndex = 7;
            CheckBoxIsPhasing.Text = "Phasing";
            CheckBoxIsPhasing.UseVisualStyleBackColor = true;
            CheckBoxIsPhasing.CheckedChanged += CheckBoxIsPhasing_CheckedChanged;
            // 
            // TimeModuloGui
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(CheckBoxIsPhasing);
            Controls.Add(label1);
            Controls.Add(NumUdSeed);
            Controls.Add(NumUdChunkSize);
            Controls.Add(LabelChunkSize);
            Controls.Add(CheckBoxIsLooping);
            Controls.Add(CheckBoxIsRandom);
            MaximumSize = new System.Drawing.Size(235, 58);
            MinimumSize = new System.Drawing.Size(235, 58);
            Name = "TimeModuloGui";
            Size = new System.Drawing.Size(235, 58);
            ((System.ComponentModel.ISupportInitialize)NumUdChunkSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumUdSeed).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBoxIsRandom;
        private System.Windows.Forms.CheckBox CheckBoxIsLooping;
        private System.Windows.Forms.Label LabelChunkSize;
        private System.Windows.Forms.NumericUpDown NumUdChunkSize;
        private System.Windows.Forms.NumericUpDown NumUdSeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckBoxIsPhasing;
    }
}
