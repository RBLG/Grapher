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
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numLength = new System.Windows.Forms.NumericUpDown();
            this.EditInputButton = new System.Windows.Forms.Button();
            this.InputLabel = new System.Windows.Forms.Label();
            this.ToolTabs = new System.Windows.Forms.TabControl();
            this.Tab1Brush = new System.Windows.Forms.TabPage();
            this.Tab2Scales = new System.Windows.Forms.TabPage();
            this.scalesSettingsControl1 = new Grapher.GuiElement.ScalesSettingsControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CheckboxCumulLength = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckboxCumulWidth = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.brushSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            this.ToolTabs.SuspendLayout();
            this.Tab1Brush.SuspendLayout();
            this.Tab2Scales.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputComboBox
            // 
            this.InputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InputComboBox.FormattingEnabled = true;
            this.InputComboBox.Location = new System.Drawing.Point(258, 23);
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
            this.brushSize.Location = new System.Drawing.Point(8, 16);
            this.brushSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.brushSize.Maximum = 10000;
            this.brushSize.Name = "brushSize";
            this.brushSize.Size = new System.Drawing.Size(229, 29);
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
            this.checkBox1.Location = new System.Drawing.Point(42, 125);
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
            this.checkBox2.Location = new System.Drawing.Point(76, 125);
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
            this.checkBox3.Location = new System.Drawing.Point(8, 125);
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
            this.WidthLabel.BackColor = System.Drawing.Color.Transparent;
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
            this.LengthLabel.BackColor = System.Drawing.Color.Transparent;
            this.LengthLabel.Location = new System.Drawing.Point(807, 3);
            this.LengthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(41, 15);
            this.LengthLabel.TabIndex = 14;
            this.LengthLabel.Text = "length";
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
            // EditInputButton
            // 
            this.EditInputButton.BackColor = System.Drawing.Color.Transparent;
            this.EditInputButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditInputButton.BackgroundImage")));
            this.EditInputButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditInputButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditInputButton.Location = new System.Drawing.Point(352, 23);
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
            this.InputLabel.Location = new System.Drawing.Point(258, 3);
            this.InputLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(35, 15);
            this.InputLabel.TabIndex = 23;
            this.InputLabel.Text = "input";
            // 
            // ToolTabs
            // 
            this.ToolTabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ToolTabs.Controls.Add(this.Tab1Brush);
            this.ToolTabs.Controls.Add(this.Tab2Scales);
            this.ToolTabs.Controls.Add(this.tabPage1);
            this.ToolTabs.Location = new System.Drawing.Point(4, 3);
            this.ToolTabs.Margin = new System.Windows.Forms.Padding(0);
            this.ToolTabs.Name = "ToolTabs";
            this.ToolTabs.SelectedIndex = 0;
            this.ToolTabs.Size = new System.Drawing.Size(249, 469);
            this.ToolTabs.TabIndex = 0;
            // 
            // Tab1Brush
            // 
            this.Tab1Brush.BackColor = System.Drawing.SystemColors.Control;
            this.Tab1Brush.Controls.Add(this.brushSize);
            this.Tab1Brush.Controls.Add(this.checkBox3);
            this.Tab1Brush.Controls.Add(this.checkBox1);
            this.Tab1Brush.Controls.Add(this.checkBox2);
            this.Tab1Brush.Location = new System.Drawing.Point(4, 24);
            this.Tab1Brush.Margin = new System.Windows.Forms.Padding(0);
            this.Tab1Brush.Name = "Tab1Brush";
            this.Tab1Brush.Size = new System.Drawing.Size(241, 441);
            this.Tab1Brush.TabIndex = 0;
            this.Tab1Brush.Text = "Brush";
            // 
            // Tab2Scales
            // 
            this.Tab2Scales.BackColor = System.Drawing.SystemColors.Control;
            this.Tab2Scales.Controls.Add(this.scalesSettingsControl1);
            this.Tab2Scales.Location = new System.Drawing.Point(4, 24);
            this.Tab2Scales.Margin = new System.Windows.Forms.Padding(0);
            this.Tab2Scales.Name = "Tab2Scales";
            this.Tab2Scales.Size = new System.Drawing.Size(241, 441);
            this.Tab2Scales.TabIndex = 1;
            this.Tab2Scales.Text = "Axis";
            // 
            // scalesSettingsControl1
            // 
            this.scalesSettingsControl1.BackColor = System.Drawing.Color.Transparent;
            this.scalesSettingsControl1.Editor = null;
            this.scalesSettingsControl1.Location = new System.Drawing.Point(0, 0);
            this.scalesSettingsControl1.MaximumSize = new System.Drawing.Size(241, 380);
            this.scalesSettingsControl1.MinimumSize = new System.Drawing.Size(241, 380);
            this.scalesSettingsControl1.Name = "scalesSettingsControl1";
            this.scalesSettingsControl1.Size = new System.Drawing.Size(241, 380);
            this.scalesSettingsControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CheckboxCumulLength);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.CheckboxCumulWidth);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(241, 441);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Misc";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CheckboxCumulLength
            // 
            this.CheckboxCumulLength.AutoSize = true;
            this.CheckboxCumulLength.Location = new System.Drawing.Point(15, 48);
            this.CheckboxCumulLength.Name = "CheckboxCumulLength";
            this.CheckboxCumulLength.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckboxCumulLength.Size = new System.Drawing.Size(63, 19);
            this.CheckboxCumulLength.TabIndex = 2;
            this.CheckboxCumulLength.Text = "Length";
            this.CheckboxCumulLength.UseVisualStyleBackColor = true;
            this.CheckboxCumulLength.CheckedChanged += new System.EventHandler(this.CheckboxCumulLength_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cumulative values:";
            // 
            // CheckboxCumulWidth
            // 
            this.CheckboxCumulWidth.AutoSize = true;
            this.CheckboxCumulWidth.Location = new System.Drawing.Point(20, 23);
            this.CheckboxCumulWidth.Name = "CheckboxCumulWidth";
            this.CheckboxCumulWidth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckboxCumulWidth.Size = new System.Drawing.Size(58, 19);
            this.CheckboxCumulWidth.TabIndex = 0;
            this.CheckboxCumulWidth.Text = "Width";
            this.CheckboxCumulWidth.UseVisualStyleBackColor = true;
            this.CheckboxCumulWidth.CheckedChanged += new System.EventHandler(this.CheckboxCumulWidth_CheckedChanged);
            // 
            // Graph3DEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToolTabs);
            this.Controls.Add(this.InputComboBox);
            this.Controls.Add(this.EditInputButton);
            this.Controls.Add(this.numLength);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.InputLabel);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.WidthLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Graph3DEditor";
            this.Size = new System.Drawing.Size(875, 475);
            ((System.ComponentModel.ISupportInitialize)(this.brushSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            this.ToolTabs.ResumeLayout(false);
            this.Tab1Brush.ResumeLayout(false);
            this.Tab2Scales.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
        public System.Windows.Forms.Button EditInputButton;
        public System.Windows.Forms.Label WidthLabel;
        public System.Windows.Forms.Label LengthLabel;
        public System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.TabPage Tab1Brush;
        private System.Windows.Forms.TabPage Tab2Scales;
        private GuiElement.ScalesSettingsControl scalesSettingsControl1;
        public System.Windows.Forms.TabControl ToolTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox CheckboxCumulLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckboxCumulWidth;
    }
}
