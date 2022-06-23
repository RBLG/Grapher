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
            this.LoopLength = new System.Windows.Forms.NumericUpDown();
            this.LabelChunkSize = new System.Windows.Forms.Label();
            this.CheckBoxIsLooping = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.LoopLength)).BeginInit();
            this.SuspendLayout();
            // 
            // LoopLength
            // 
            this.LoopLength.Location = new System.Drawing.Point(3, 21);
            this.LoopLength.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.LoopLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LoopLength.Name = "LoopLength";
            this.LoopLength.Size = new System.Drawing.Size(84, 23);
            this.LoopLength.TabIndex = 7;
            this.LoopLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LoopLength.ValueChanged += new System.EventHandler(this.LoopLength_ValueChanged);
            // 
            // LabelChunkSize
            // 
            this.LabelChunkSize.AutoSize = true;
            this.LabelChunkSize.Location = new System.Drawing.Point(3, 3);
            this.LabelChunkSize.Name = "LabelChunkSize";
            this.LabelChunkSize.Size = new System.Drawing.Size(74, 15);
            this.LabelChunkSize.TabIndex = 6;
            this.LabelChunkSize.Text = "Loop length:";
            // 
            // CheckBoxIsLooping
            // 
            this.CheckBoxIsLooping.AutoSize = true;
            this.CheckBoxIsLooping.Location = new System.Drawing.Point(179, 3);
            this.CheckBoxIsLooping.Name = "CheckBoxIsLooping";
            this.CheckBoxIsLooping.Size = new System.Drawing.Size(53, 19);
            this.CheckBoxIsLooping.TabIndex = 5;
            this.CheckBoxIsLooping.Text = "Loop";
            this.CheckBoxIsLooping.UseVisualStyleBackColor = true;
            this.CheckBoxIsLooping.CheckedChanged += new System.EventHandler(this.CheckBoxIsLooping_CheckedChanged);
            // 
            // TimeLinearGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LoopLength);
            this.Controls.Add(this.LabelChunkSize);
            this.Controls.Add(this.CheckBoxIsLooping);
            this.MaximumSize = new System.Drawing.Size(235, 58);
            this.MinimumSize = new System.Drawing.Size(235, 58);
            this.Name = "TimeLinearGui";
            this.Size = new System.Drawing.Size(235, 58);
            ((System.ComponentModel.ISupportInitialize)(this.LoopLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown LoopLength;
        private System.Windows.Forms.Label LabelChunkSize;
        private System.Windows.Forms.CheckBox CheckBoxIsLooping;
    }
}
