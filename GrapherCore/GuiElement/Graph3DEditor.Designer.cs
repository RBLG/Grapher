namespace Grapher
{
    partial class Graph3DEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graph3DEditor));
            this.InputComboBox = new System.Windows.Forms.ComboBox();
            this.brushSize = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numLength = new System.Windows.Forms.NumericUpDown();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.AxisSettingsButton = new System.Windows.Forms.Button();
            this.EditInputButton = new System.Windows.Forms.Button();
            this.InputLabel = new System.Windows.Forms.Label();
            this.BrushGroupBox = new System.Windows.Forms.GroupBox();
            this.TimeLoop = new System.Windows.Forms.CheckBox();
            this.LoopLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.brushSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.BrushGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputComboBox
            // 
            this.InputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InputComboBox.FormattingEnabled = true;
            this.InputComboBox.Location = new System.Drawing.Point(98, 23);
            this.InputComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.InputComboBox.Name = "InputComboBox";
            this.InputComboBox.Size = new System.Drawing.Size(87, 23);
            this.InputComboBox.TabIndex = 4;
            this.InputComboBox.SelectedIndexChanged += new System.EventHandler(this.InputComboBox_SelectedIndexChanged);
            // 
            // brushSize
            // 
            this.brushSize.AutoSize = false;
            this.brushSize.BackColor = System.Drawing.SystemColors.Control;
            this.brushSize.Location = new System.Drawing.Point(7, 22);
            this.brushSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.brushSize.Maximum = 10000;
            this.brushSize.Name = "brushSize";
            this.brushSize.Size = new System.Drawing.Size(76, 29);
            this.brushSize.TabIndex = 6;
            this.brushSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.brushSize.Scroll += new System.EventHandler(this.BrushSizeX_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBox1.BackgroundImage")));
            this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(7, 58);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(26, 25);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBox2.BackgroundImage")));
            this.checkBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(40, 58);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(26, 25);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBox3.BackgroundImage")));
            this.checkBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(7, 90);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(26, 25);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // WidthLabel
            // 
            this.WidthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(742, 3);
            this.WidthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(37, 15);
            this.WidthLabel.TabIndex = 13;
            this.WidthLabel.Text = "width";
            // 
            // LengthLabel
            // 
            this.LengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Location = new System.Drawing.Point(807, 3);
            this.LengthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(41, 15);
            this.LengthLabel.TabIndex = 14;
            this.LengthLabel.Text = "length";
            // 
            // DurationLabel
            // 
            this.DurationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Location = new System.Drawing.Point(621, 3);
            this.DurationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(79, 15);
            this.DurationLabel.TabIndex = 15;
            this.DurationLabel.Text = "duration (ms)";
            // 
            // numWidth
            // 
            this.numWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numWidth.BackColor = System.Drawing.SystemColors.Control;
            this.numWidth.Location = new System.Drawing.Point(746, 24);
            this.numWidth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(58, 23);
            this.numWidth.TabIndex = 18;
            this.numWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWidth.ValueChanged += new System.EventHandler(this.NumWidth_ValueChanged);
            // 
            // numLength
            // 
            this.numLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numLength.BackColor = System.Drawing.SystemColors.Control;
            this.numLength.Location = new System.Drawing.Point(811, 24);
            this.numLength.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLength.Name = "numLength";
            this.numLength.Size = new System.Drawing.Size(58, 23);
            this.numLength.TabIndex = 19;
            this.numLength.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numLength.ValueChanged += new System.EventHandler(this.NumLength_ValueChanged);
            // 
            // numDuration
            // 
            this.numDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numDuration.BackColor = System.Drawing.SystemColors.Control;
            this.numDuration.Location = new System.Drawing.Point(624, 24);
            this.numDuration.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numDuration.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(75, 23);
            this.numDuration.TabIndex = 20;
            this.numDuration.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDuration.ValueChanged += new System.EventHandler(this.NumDuration_ValueChanged);
            // 
            // AxisSettingsButton
            // 
            this.AxisSettingsButton.Location = new System.Drawing.Point(4, 3);
            this.AxisSettingsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AxisSettingsButton.Name = "AxisSettingsButton";
            this.AxisSettingsButton.Size = new System.Drawing.Size(88, 27);
            this.AxisSettingsButton.TabIndex = 21;
            this.AxisSettingsButton.Text = "Axis Settings";
            this.AxisSettingsButton.UseVisualStyleBackColor = true;
            this.AxisSettingsButton.Click += new System.EventHandler(this.AxisSettingsButton_Click);
            // 
            // EditInputButton
            // 
            this.EditInputButton.BackColor = System.Drawing.Color.Transparent;
            this.EditInputButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditInputButton.BackgroundImage")));
            this.EditInputButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditInputButton.Location = new System.Drawing.Point(192, 23);
            this.EditInputButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditInputButton.Name = "EditInputButton";
            this.EditInputButton.Size = new System.Drawing.Size(26, 24);
            this.EditInputButton.TabIndex = 22;
            this.EditInputButton.UseVisualStyleBackColor = false;
            this.EditInputButton.Click += new System.EventHandler(this.EditInputButton_Click);
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Location = new System.Drawing.Point(98, 3);
            this.InputLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(35, 15);
            this.InputLabel.TabIndex = 23;
            this.InputLabel.Text = "input";
            // 
            // BrushGroupBox
            // 
            this.BrushGroupBox.Controls.Add(this.brushSize);
            this.BrushGroupBox.Controls.Add(this.checkBox1);
            this.BrushGroupBox.Controls.Add(this.checkBox2);
            this.BrushGroupBox.Controls.Add(this.checkBox3);
            this.BrushGroupBox.Location = new System.Drawing.Point(4, 37);
            this.BrushGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrushGroupBox.Name = "BrushGroupBox";
            this.BrushGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrushGroupBox.Size = new System.Drawing.Size(88, 435);
            this.BrushGroupBox.TabIndex = 24;
            this.BrushGroupBox.TabStop = false;
            this.BrushGroupBox.Text = "Brush :";
            // 
            // TimeLoop
            // 
            this.TimeLoop.Location = new System.Drawing.Point(583, 23);
            this.TimeLoop.Name = "TimeLoop";
            this.TimeLoop.Size = new System.Drawing.Size(22, 23);
            this.TimeLoop.TabIndex = 25;
            this.TimeLoop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TimeLoop.UseVisualStyleBackColor = true;
            this.TimeLoop.CheckedChanged += new System.EventHandler(this.TimeLoop_CheckedChanged);
            // 
            // LoopLabel
            // 
            this.LoopLabel.AutoSize = true;
            this.LoopLabel.Location = new System.Drawing.Point(583, 3);
            this.LoopLabel.Name = "LoopLabel";
            this.LoopLabel.Size = new System.Drawing.Size(31, 15);
            this.LoopLabel.TabIndex = 26;
            this.LoopLabel.Text = "loop";
            // 
            // Graph3DEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TimeLoop);
            this.Controls.Add(this.LoopLabel);
            this.Controls.Add(this.InputComboBox);
            this.Controls.Add(this.EditInputButton);
            this.Controls.Add(this.numLength);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.BrushGroupBox);
            this.Controls.Add(this.InputLabel);
            this.Controls.Add(this.AxisSettingsButton);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.WidthLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Graph3DEditor";
            this.Size = new System.Drawing.Size(875, 475);
            this.Resize += new System.EventHandler(this.Graph3DEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.brushSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.BrushGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ComboBox InputComboBox;
        private System.Windows.Forms.TrackBar brushSize;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.NumericUpDown numWidth;
        public System.Windows.Forms.NumericUpDown numLength;
        public System.Windows.Forms.NumericUpDown numDuration;
        public System.Windows.Forms.Button AxisSettingsButton;
        public System.Windows.Forms.Button EditInputButton;
        //private Canvas3D canvas3D2;
        private System.Windows.Forms.GroupBox BrushGroupBox;
        public System.Windows.Forms.Label DurationLabel;
        public System.Windows.Forms.Label WidthLabel;
        public System.Windows.Forms.Label LengthLabel;
        public System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.CheckBox TimeLoop;
        private System.Windows.Forms.Label LoopLabel;
    }
}
