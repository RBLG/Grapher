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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EditInputButton = new System.Windows.Forms.Button();
            this.InputComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NoteUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Detuner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Detuner
            // 
            this.Detuner.AutoSize = false;
            this.Detuner.Location = new System.Drawing.Point(3, 89);
            this.Detuner.Maximum = 100;
            this.Detuner.Minimum = -100;
            this.Detuner.Name = "Detuner";
            this.Detuner.Size = new System.Drawing.Size(103, 23);
            this.Detuner.TabIndex = 0;
            this.Detuner.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Detuner.Scroll += new System.EventHandler(this.Detuner_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Location = new System.Drawing.Point(112, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 231);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "input";
            // 
            // EditInputButton
            // 
            this.EditInputButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditInputButton.BackgroundImage")));
            this.EditInputButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditInputButton.Location = new System.Drawing.Point(84, 16);
            this.EditInputButton.Name = "EditInputButton";
            this.EditInputButton.Size = new System.Drawing.Size(22, 21);
            this.EditInputButton.TabIndex = 25;
            this.EditInputButton.UseVisualStyleBackColor = true;
            this.EditInputButton.Click += new System.EventHandler(this.EditInputButton_Click);
            // 
            // InputComboBox
            // 
            this.InputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InputComboBox.FormattingEnabled = true;
            this.InputComboBox.Location = new System.Drawing.Point(3, 16);
            this.InputComboBox.Name = "InputComboBox";
            this.InputComboBox.Size = new System.Drawing.Size(75, 21);
            this.InputComboBox.TabIndex = 24;
            this.InputComboBox.SelectedIndexChanged += new System.EventHandler(this.InputComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "detune";
            // 
            // NoteUpDown
            // 
            this.NoteUpDown.Location = new System.Drawing.Point(3, 205);
            this.NoteUpDown.Maximum = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.NoteUpDown.Name = "NoteUpDown";
            this.NoteUpDown.Size = new System.Drawing.Size(75, 20);
            this.NoteUpDown.TabIndex = 28;
            this.NoteUpDown.Value = new decimal(new int[] {
            69,
            0,
            0,
            0});
            this.NoteUpDown.ValueChanged += new System.EventHandler(this.NoteUpDown_ValueChanged);
            // 
            // MainSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NoteUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.InputComboBox);
            this.Controls.Add(this.EditInputButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Detuner);
            this.MaximumSize = new System.Drawing.Size(410, 237);
            this.MinimumSize = new System.Drawing.Size(410, 237);
            this.Name = "MainSettings";
            this.Size = new System.Drawing.Size(410, 237);
            ((System.ComponentModel.ISupportInitialize)(this.Detuner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar Detuner;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button EditInputButton;
        private System.Windows.Forms.ComboBox InputComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NoteUpDown;
    }
}
