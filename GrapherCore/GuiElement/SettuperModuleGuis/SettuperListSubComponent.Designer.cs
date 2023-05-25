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
            this.LabelHarmonic = new System.Windows.Forms.Label();
            this.LabelAmplitude = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.ampTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdHarmonic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ampTrackBar)).BeginInit();
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
            this.toolTip1.SetToolTip(this.NumUdHarmonic, "n° of the harmonic");
            this.NumUdHarmonic.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumUdHarmonic.ValueChanged += new System.EventHandler(this.NumUdHarmonic_ValueChanged);
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
            this.button1.Location = new System.Drawing.Point(280, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ampTrackBar
            // 
            this.ampTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ampTrackBar.AutoSize = false;
            this.ampTrackBar.Location = new System.Drawing.Point(116, 3);
            this.ampTrackBar.Maximum = 2000;
            this.ampTrackBar.Minimum = 1;
            this.ampTrackBar.Name = "ampTrackBar";
            this.ampTrackBar.Size = new System.Drawing.Size(163, 23);
            this.ampTrackBar.TabIndex = 6;
            this.ampTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.ampTrackBar, "multiplier ");
            this.ampTrackBar.Value = 1000;
            this.ampTrackBar.Scroll += new System.EventHandler(this.AmpTrackBar_Scroll);
            // 
            // SettuperListSubComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ampTrackBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LabelAmplitude);
            this.Controls.Add(this.LabelHarmonic);
            this.Controls.Add(this.NumUdHarmonic);
            this.MinimumSize = new System.Drawing.Size(204, 30);
            this.Name = "SettuperListSubComponent";
            this.Size = new System.Drawing.Size(307, 30);
            ((System.ComponentModel.ISupportInitialize)(this.NumUdHarmonic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ampTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumUdHarmonic;
        private System.Windows.Forms.Label LabelHarmonic;
        private System.Windows.Forms.Label LabelAmplitude;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar ampTrackBar;
    }
}
