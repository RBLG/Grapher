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
            this.CheckBoxIsRandom = new System.Windows.Forms.CheckBox();
            this.CheckBoxIsLooping = new System.Windows.Forms.CheckBox();
            this.LabelChunkSize = new System.Windows.Forms.Label();
            this.NumUdChunkSize = new System.Windows.Forms.NumericUpDown();
            this.NumUdSeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckBoxIsPhased = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdChunkSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdSeed)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckBoxIsRandom
            // 
            this.CheckBoxIsRandom.AutoSize = true;
            this.CheckBoxIsRandom.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBoxIsRandom.Location = new System.Drawing.Point(161, 3);
            this.CheckBoxIsRandom.Name = "CheckBoxIsRandom";
            this.CheckBoxIsRandom.Size = new System.Drawing.Size(71, 19);
            this.CheckBoxIsRandom.TabIndex = 0;
            this.CheckBoxIsRandom.Text = "Random";
            this.CheckBoxIsRandom.UseVisualStyleBackColor = true;
            this.CheckBoxIsRandom.CheckedChanged += new System.EventHandler(this.CheckBoxIsRandom_CheckedChanged);
            // 
            // CheckBoxIsLooping
            // 
            this.CheckBoxIsLooping.AutoSize = true;
            this.CheckBoxIsLooping.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBoxIsLooping.Location = new System.Drawing.Point(179, 22);
            this.CheckBoxIsLooping.Name = "CheckBoxIsLooping";
            this.CheckBoxIsLooping.Size = new System.Drawing.Size(53, 19);
            this.CheckBoxIsLooping.TabIndex = 1;
            this.CheckBoxIsLooping.Text = "Loop";
            this.CheckBoxIsLooping.UseVisualStyleBackColor = true;
            this.CheckBoxIsLooping.CheckedChanged += new System.EventHandler(this.CheckBoxIsLooping_CheckedChanged);
            // 
            // LabelChunkSize
            // 
            this.LabelChunkSize.AutoSize = true;
            this.LabelChunkSize.Location = new System.Drawing.Point(3, 3);
            this.LabelChunkSize.Name = "LabelChunkSize";
            this.LabelChunkSize.Size = new System.Drawing.Size(82, 15);
            this.LabelChunkSize.TabIndex = 3;
            this.LabelChunkSize.Text = "Chunk length:";
            // 
            // NumUdChunkSize
            // 
            this.NumUdChunkSize.Location = new System.Drawing.Point(3, 21);
            this.NumUdChunkSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumUdChunkSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUdChunkSize.Name = "NumUdChunkSize";
            this.NumUdChunkSize.Size = new System.Drawing.Size(84, 23);
            this.NumUdChunkSize.TabIndex = 4;
            this.NumUdChunkSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUdChunkSize.ValueChanged += new System.EventHandler(this.NumUdChunkSize_ValueChanged);
            // 
            // NumUdSeed
            // 
            this.NumUdSeed.Location = new System.Drawing.Point(93, 21);
            this.NumUdSeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUdSeed.Name = "NumUdSeed";
            this.NumUdSeed.Size = new System.Drawing.Size(54, 23);
            this.NumUdSeed.TabIndex = 5;
            this.NumUdSeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUdSeed.ValueChanged += new System.EventHandler(this.NumUdSeed_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Seed:";
            // 
            // checkBox1
            // 
            this.CheckBoxIsPhased.AutoSize = true;
            this.CheckBoxIsPhased.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBoxIsPhased.Location = new System.Drawing.Point(168, 39);
            this.CheckBoxIsPhased.Name = "checkBox1";
            this.CheckBoxIsPhased.Size = new System.Drawing.Size(64, 19);
            this.CheckBoxIsPhased.TabIndex = 7;
            this.CheckBoxIsPhased.Text = "Phased";
            this.CheckBoxIsPhased.UseVisualStyleBackColor = true;
            this.CheckBoxIsPhased.CheckedChanged += new System.EventHandler(this.CheckBoxIsPhased_CheckedChanged);
            // 
            // TimeModuloGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CheckBoxIsPhased);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumUdSeed);
            this.Controls.Add(this.NumUdChunkSize);
            this.Controls.Add(this.LabelChunkSize);
            this.Controls.Add(this.CheckBoxIsLooping);
            this.Controls.Add(this.CheckBoxIsRandom);
            this.MaximumSize = new System.Drawing.Size(235, 58);
            this.MinimumSize = new System.Drawing.Size(235, 58);
            this.Name = "TimeModuloGui";
            this.Size = new System.Drawing.Size(235, 58);
            ((System.ComponentModel.ISupportInitialize)(this.NumUdChunkSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdSeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBoxIsRandom;
        private System.Windows.Forms.CheckBox CheckBoxIsLooping;
        private System.Windows.Forms.Label LabelChunkSize;
        private System.Windows.Forms.NumericUpDown NumUdChunkSize;
        private System.Windows.Forms.NumericUpDown NumUdSeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckBoxIsPhased;
    }
}
