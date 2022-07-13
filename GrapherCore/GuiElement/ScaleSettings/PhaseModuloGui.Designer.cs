namespace Grapher.GuiElement.ScaleSettings
{
    partial class PhaseModuloGui
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
            this.NumUdCount = new System.Windows.Forms.NumericUpDown();
            this.OffsetLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NumUdDetune = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.NumUdSeed = new System.Windows.Forms.NumericUpDown();
            this.CheckBoxIsLooping = new System.Windows.Forms.CheckBox();
            this.CheckBoxIsRandom = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdDetune)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdSeed)).BeginInit();
            this.SuspendLayout();
            // 
            // NumUdCount
            // 
            this.NumUdCount.Location = new System.Drawing.Point(3, 21);
            this.NumUdCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumUdCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUdCount.Name = "NumUdCount";
            this.NumUdCount.Size = new System.Drawing.Size(42, 23);
            this.NumUdCount.TabIndex = 18;
            this.NumUdCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUdCount.ValueChanged += new System.EventHandler(this.NumUdCount_ValueChanged);
            // 
            // OffsetLabel
            // 
            this.OffsetLabel.AutoSize = true;
            this.OffsetLabel.Location = new System.Drawing.Point(3, 3);
            this.OffsetLabel.Name = "OffsetLabel";
            this.OffsetLabel.Size = new System.Drawing.Size(43, 15);
            this.OffsetLabel.TabIndex = 17;
            this.OffsetLabel.Text = "Count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Detune:";
            // 
            // NumUdDetune
            // 
            this.NumUdDetune.Location = new System.Drawing.Point(52, 21);
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
            this.NumUdDetune.Size = new System.Drawing.Size(47, 23);
            this.NumUdDetune.TabIndex = 15;
            this.NumUdDetune.ValueChanged += new System.EventHandler(this.NumUdDetune_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Seed:";
            // 
            // NumUdSeed
            // 
            this.NumUdSeed.Location = new System.Drawing.Point(105, 21);
            this.NumUdSeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUdSeed.Name = "NumUdSeed";
            this.NumUdSeed.Size = new System.Drawing.Size(46, 23);
            this.NumUdSeed.TabIndex = 21;
            this.NumUdSeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUdSeed.ValueChanged += new System.EventHandler(this.NumUdSeed_ValueChanged);
            // 
            // CheckBoxIsLooping
            // 
            this.CheckBoxIsLooping.AutoSize = true;
            this.CheckBoxIsLooping.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBoxIsLooping.Location = new System.Drawing.Point(179, 28);
            this.CheckBoxIsLooping.Name = "CheckBoxIsLooping";
            this.CheckBoxIsLooping.Size = new System.Drawing.Size(53, 19);
            this.CheckBoxIsLooping.TabIndex = 20;
            this.CheckBoxIsLooping.Text = "Loop";
            this.CheckBoxIsLooping.UseVisualStyleBackColor = true;
            this.CheckBoxIsLooping.CheckedChanged += new System.EventHandler(this.CheckBoxIsLooping_CheckedChanged);
            // 
            // CheckBoxIsRandom
            // 
            this.CheckBoxIsRandom.AutoSize = true;
            this.CheckBoxIsRandom.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBoxIsRandom.Location = new System.Drawing.Point(161, 3);
            this.CheckBoxIsRandom.Name = "CheckBoxIsRandom";
            this.CheckBoxIsRandom.Size = new System.Drawing.Size(71, 19);
            this.CheckBoxIsRandom.TabIndex = 19;
            this.CheckBoxIsRandom.Text = "Random";
            this.CheckBoxIsRandom.UseVisualStyleBackColor = true;
            this.CheckBoxIsRandom.CheckedChanged += new System.EventHandler(this.CheckBoxIsRandom_CheckedChanged);
            // 
            // PhaseModuloGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumUdSeed);
            this.Controls.Add(this.CheckBoxIsLooping);
            this.Controls.Add(this.CheckBoxIsRandom);
            this.Controls.Add(this.NumUdCount);
            this.Controls.Add(this.OffsetLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumUdDetune);
            this.MaximumSize = new System.Drawing.Size(235, 58);
            this.MinimumSize = new System.Drawing.Size(235, 58);
            this.Name = "PhaseModuloGui";
            this.Size = new System.Drawing.Size(235, 58);
            ((System.ComponentModel.ISupportInitialize)(this.NumUdCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdDetune)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdSeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumUdCount;
        private System.Windows.Forms.Label OffsetLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumUdDetune;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumUdSeed;
        private System.Windows.Forms.CheckBox CheckBoxIsLooping;
        private System.Windows.Forms.CheckBox CheckBoxIsRandom;
    }
}
