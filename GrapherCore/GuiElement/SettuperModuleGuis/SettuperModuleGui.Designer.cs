namespace Grapher.GuiElement.SettuperModuleGuis
{
    partial class SettuperModuleGui
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
            this.SettingGroupBox = new System.Windows.Forms.GroupBox();
            this.AddWaveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ComponentFlPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // SettingGroupBox
            // 
            this.SettingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SettingGroupBox.Location = new System.Drawing.Point(3, 3);
            this.SettingGroupBox.Name = "SettingGroupBox";
            this.SettingGroupBox.Size = new System.Drawing.Size(257, 403);
            this.SettingGroupBox.TabIndex = 1;
            this.SettingGroupBox.TabStop = false;
            this.SettingGroupBox.Text = "General Settings:";
            // 
            // AddWaveButton
            // 
            this.AddWaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddWaveButton.Location = new System.Drawing.Point(646, 0);
            this.AddWaveButton.Name = "AddWaveButton";
            this.AddWaveButton.Size = new System.Drawing.Size(26, 23);
            this.AddWaveButton.TabIndex = 2;
            this.AddWaveButton.Text = "+";
            this.AddWaveButton.UseVisualStyleBackColor = true;
            this.AddWaveButton.Click += new System.EventHandler(this.AddWaveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Waves:";
            // 
            // ComponentFlPanel
            // 
            this.ComponentFlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComponentFlPanel.AutoScroll = true;
            this.ComponentFlPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ComponentFlPanel.Location = new System.Drawing.Point(266, 22);
            this.ComponentFlPanel.Name = "ComponentFlPanel";
            this.ComponentFlPanel.Size = new System.Drawing.Size(406, 390);
            this.ComponentFlPanel.TabIndex = 4;
            this.ComponentFlPanel.WrapContents = false;
            this.ComponentFlPanel.Resize += new System.EventHandler(this.FlowResized);
            // 
            // SettuperModuleGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ComponentFlPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddWaveButton);
            this.Controls.Add(this.SettingGroupBox);
            this.Name = "SettuperModuleGui";
            this.Size = new System.Drawing.Size(675, 412);
            this.Load += new System.EventHandler(this.SettuperModuleGui_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox SettingGroupBox;
        private System.Windows.Forms.Button AddWaveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel ComponentFlPanel;
    }
}
