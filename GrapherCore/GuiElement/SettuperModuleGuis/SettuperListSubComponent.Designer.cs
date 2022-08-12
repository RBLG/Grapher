namespace Grapher.GuiElement.SettuperModuleGui
{
    partial class SettuperListSubComponent
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
            this.components = new System.ComponentModel.Container();
            this.NumUdHarmonic = new System.Windows.Forms.NumericUpDown();
            this.NumUdAmplitude = new System.Windows.Forms.NumericUpDown();
            this.LabelHarmonic = new System.Windows.Forms.Label();
            this.LabelAmplitude = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdHarmonic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdAmplitude)).BeginInit();
            this.SuspendLayout();
            // 
            // NumUdHarmonic
            // 
            this.NumUdHarmonic.DecimalPlaces = 1;
            this.NumUdHarmonic.Location = new System.Drawing.Point(28, 3);
            this.NumUdHarmonic.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumUdHarmonic.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumUdHarmonic.Name = "NumUdHarmonic";
            this.NumUdHarmonic.Size = new System.Drawing.Size(58, 23);
            this.NumUdHarmonic.TabIndex = 0;
            this.NumUdHarmonic.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumUdHarmonic.ValueChanged += new System.EventHandler(this.NumUdHarmonic_ValueChanged);
            // 
            // NumUdAmplitude
            // 
            this.NumUdAmplitude.DecimalPlaces = 2;
            this.NumUdAmplitude.Location = new System.Drawing.Point(116, 3);
            this.NumUdAmplitude.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumUdAmplitude.Name = "NumUdAmplitude";
            this.NumUdAmplitude.Size = new System.Drawing.Size(58, 23);
            this.NumUdAmplitude.TabIndex = 2;
            this.NumUdAmplitude.ValueChanged += new System.EventHandler(this.NumUdAmplitude_ValueChanged);
            // 
            // LabelHarmonic
            // 
            this.LabelHarmonic.AutoSize = true;
            this.LabelHarmonic.Location = new System.Drawing.Point(3, 5);
            this.LabelHarmonic.Name = "LabelHarmonic";
            this.LabelHarmonic.Size = new System.Drawing.Size(19, 15);
            this.LabelHarmonic.TabIndex = 3;
            this.LabelHarmonic.Text = "H:";
            // 
            // LabelAmplitude
            // 
            this.LabelAmplitude.AutoSize = true;
            this.LabelAmplitude.Location = new System.Drawing.Point(92, 5);
            this.LabelAmplitude.Name = "LabelAmplitude";
            this.LabelAmplitude.Size = new System.Drawing.Size(18, 15);
            this.LabelAmplitude.TabIndex = 4;
            this.LabelAmplitude.Text = "A:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(177, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SettuperListSubComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LabelAmplitude);
            this.Controls.Add(this.LabelHarmonic);
            this.Controls.Add(this.NumUdAmplitude);
            this.Controls.Add(this.NumUdHarmonic);
            this.MinimumSize = new System.Drawing.Size(204, 30);
            this.Name = "SettuperListSubComponent";
            this.Size = new System.Drawing.Size(204, 30);
            ((System.ComponentModel.ISupportInitialize)(this.NumUdHarmonic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdAmplitude)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumUdHarmonic;
        private System.Windows.Forms.NumericUpDown NumUdAmplitude;
        private System.Windows.Forms.Label LabelHarmonic;
        private System.Windows.Forms.Label LabelAmplitude;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
    }
}
