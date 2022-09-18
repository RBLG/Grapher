namespace Grapher.GuiElement
{
    partial class MainSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSettings));
            this.Detuner = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EditInputButton = new System.Windows.Forms.Button();
            this.InputComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ReleaseDelayUd = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Detuner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReleaseDelayUd)).BeginInit();
            this.SuspendLayout();
            // 
            // Detuner
            // 
            this.Detuner.AutoSize = false;
            this.Detuner.Location = new System.Drawing.Point(3, 63);
            this.Detuner.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Detuner.Maximum = 100;
            this.Detuner.Minimum = -100;
            this.Detuner.Name = "Detuner";
            this.Detuner.Size = new System.Drawing.Size(120, 27);
            this.Detuner.TabIndex = 0;
            this.Detuner.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Detuner.Scroll += new System.EventHandler(this.Detuner_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Location = new System.Drawing.Point(131, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(344, 267);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "input";
            // 
            // EditInputButton
            // 
            this.EditInputButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditInputButton.BackgroundImage")));
            this.EditInputButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditInputButton.Location = new System.Drawing.Point(98, 18);
            this.EditInputButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditInputButton.Name = "EditInputButton";
            this.EditInputButton.Size = new System.Drawing.Size(26, 24);
            this.EditInputButton.TabIndex = 25;
            this.EditInputButton.UseVisualStyleBackColor = true;
            this.EditInputButton.Click += new System.EventHandler(this.EditInputButton_Click);
            // 
            // InputComboBox
            // 
            this.InputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InputComboBox.FormattingEnabled = true;
            this.InputComboBox.Location = new System.Drawing.Point(4, 18);
            this.InputComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.InputComboBox.Name = "InputComboBox";
            this.InputComboBox.Size = new System.Drawing.Size(87, 23);
            this.InputComboBox.TabIndex = 24;
            this.InputComboBox.SelectedIndexChanged += new System.EventHandler(this.InputComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "Detune:";
            // 
            // ReleaseDelayUd
            // 
            this.ReleaseDelayUd.Location = new System.Drawing.Point(3, 118);
            this.ReleaseDelayUd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ReleaseDelayUd.Name = "ReleaseDelayUd";
            this.ReleaseDelayUd.Size = new System.Drawing.Size(77, 23);
            this.ReleaseDelayUd.TabIndex = 28;
            this.ReleaseDelayUd.ValueChanged += new System.EventHandler(this.ReleaseDelayUd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Release delay (ms):";
            // 
            // MainSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ReleaseDelayUd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.InputComboBox);
            this.Controls.Add(this.EditInputButton);
            this.Controls.Add(this.Detuner);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainSettings";
            this.Size = new System.Drawing.Size(478, 273);
            ((System.ComponentModel.ISupportInitialize)(this.Detuner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReleaseDelayUd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TrackBar Detuner;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button EditInputButton;
        private System.Windows.Forms.ComboBox InputComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ReleaseDelayUd;
        private System.Windows.Forms.Label label2;
    }
}
