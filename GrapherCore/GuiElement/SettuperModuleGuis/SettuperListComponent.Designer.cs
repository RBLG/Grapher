namespace Grapher.GuiElement.SettuperModuleGuis
{
    partial class SettuperListComponent
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
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonAddHarmonic = new System.Windows.Forms.Button();
            this.MainSettingGroupBox = new System.Windows.Forms.GroupBox();
            this.ampTrackBar = new System.Windows.Forms.TrackBar();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.NumUdFrequency = new System.Windows.Forms.NumericUpDown();
            this.HarmonicsFlPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MainSettingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ampTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Harmonics:";
            // 
            // ButtonAddHarmonic
            // 
            this.ButtonAddHarmonic.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonAddHarmonic.Location = new System.Drawing.Point(76, 57);
            this.ButtonAddHarmonic.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonAddHarmonic.Name = "ButtonAddHarmonic";
            this.ButtonAddHarmonic.Size = new System.Drawing.Size(18, 21);
            this.ButtonAddHarmonic.TabIndex = 4;
            this.ButtonAddHarmonic.Text = "+";
            this.ButtonAddHarmonic.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ButtonAddHarmonic.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.ButtonAddHarmonic.UseVisualStyleBackColor = true;
            this.ButtonAddHarmonic.Click += new System.EventHandler(this.AddHarmonicButton_Click);
            // 
            // MainSettingGroupBox
            // 
            this.MainSettingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainSettingGroupBox.Controls.Add(this.ampTrackBar);
            this.MainSettingGroupBox.Controls.Add(this.DeleteButton);
            this.MainSettingGroupBox.Controls.Add(this.label3);
            this.MainSettingGroupBox.Controls.Add(this.FrequencyLabel);
            this.MainSettingGroupBox.Controls.Add(this.NumUdFrequency);
            this.MainSettingGroupBox.Location = new System.Drawing.Point(5, 3);
            this.MainSettingGroupBox.Name = "MainSettingGroupBox";
            this.MainSettingGroupBox.Size = new System.Drawing.Size(325, 53);
            this.MainSettingGroupBox.TabIndex = 5;
            this.MainSettingGroupBox.TabStop = false;
            this.MainSettingGroupBox.Text = "Main wave:";
            // 
            // ampTrackBar
            // 
            this.ampTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ampTrackBar.AutoSize = false;
            this.ampTrackBar.Location = new System.Drawing.Point(170, 17);
            this.ampTrackBar.Maximum = 1000;
            this.ampTrackBar.Minimum = 1;
            this.ampTrackBar.Name = "ampTrackBar";
            this.ampTrackBar.Size = new System.Drawing.Size(119, 23);
            this.ampTrackBar.TabIndex = 10;
            this.ampTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ampTrackBar.Value = 500;
            this.ampTrackBar.Scroll += new System.EventHandler(this.ampTrackBar_Scroll);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(295, 17);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(23, 23);
            this.DeleteButton.TabIndex = 9;
            this.DeleteButton.Text = "X";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Amp:";
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.AutoSize = true;
            this.FrequencyLabel.Location = new System.Drawing.Point(6, 19);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(33, 15);
            this.FrequencyLabel.TabIndex = 7;
            this.FrequencyLabel.Text = "Freq:";
            // 
            // NumUdFrequency
            // 
            this.NumUdFrequency.Location = new System.Drawing.Point(45, 17);
            this.NumUdFrequency.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.NumUdFrequency.Name = "NumUdFrequency";
            this.NumUdFrequency.Size = new System.Drawing.Size(77, 23);
            this.NumUdFrequency.TabIndex = 5;
            this.NumUdFrequency.ValueChanged += new System.EventHandler(this.NumUdFrequency_ValueChanged);
            // 
            // HarmonicsFlPanel
            // 
            this.HarmonicsFlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.HarmonicsFlPanel.AutoScroll = true;
            this.HarmonicsFlPanel.AutoSize = true;
            this.HarmonicsFlPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HarmonicsFlPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.HarmonicsFlPanel.Location = new System.Drawing.Point(5, 77);
            this.HarmonicsFlPanel.MaximumSize = new System.Drawing.Size(24200, 160);
            this.HarmonicsFlPanel.MinimumSize = new System.Drawing.Size(325, 65);
            this.HarmonicsFlPanel.Name = "HarmonicsFlPanel";
            this.HarmonicsFlPanel.Size = new System.Drawing.Size(325, 65);
            this.HarmonicsFlPanel.TabIndex = 6;
            this.HarmonicsFlPanel.WrapContents = false;
            // 
            // SettuperListComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.HarmonicsFlPanel);
            this.Controls.Add(this.MainSettingGroupBox);
            this.Controls.Add(this.ButtonAddHarmonic);
            this.Controls.Add(this.label2);
            this.MinimumSize = new System.Drawing.Size(334, 80);
            this.Name = "SettuperListComponent";
            this.Size = new System.Drawing.Size(336, 148);
            this.MainSettingGroupBox.ResumeLayout(false);
            this.MainSettingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ampTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUdFrequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonAddHarmonic;
        private System.Windows.Forms.GroupBox MainSettingGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label FrequencyLabel;
        private System.Windows.Forms.NumericUpDown NumUdFrequency;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.FlowLayoutPanel HarmonicsFlPanel;
        private System.Windows.Forms.TrackBar ampTrackBar;
    }
}
