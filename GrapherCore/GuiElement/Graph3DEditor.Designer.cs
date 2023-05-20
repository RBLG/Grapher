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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graph3DEditor));
            this.InputComboBox = new System.Windows.Forms.ComboBox();
            this.sliderBrushRadius = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numLength = new System.Windows.Forms.NumericUpDown();
            this.EditInputButton = new System.Windows.Forms.Button();
            this.ToolTabs = new System.Windows.Forms.TabControl();
            this.Tab2Scales = new System.Windows.Forms.TabPage();
            this.scalesSettingsControl1 = new Grapher.GuiElement.ScalesSettingsControl();
            this.Tab1Brush = new System.Windows.Forms.TabPage();
            this.labelBrushType = new System.Windows.Forms.Label();
            this.labelBrushRadius = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBoxLockedLength = new System.Windows.Forms.CheckBox();
            this.checkBoxLockedWidth = new System.Windows.Forms.CheckBox();
            this.labelFixedSize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sliderBrushRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            this.ToolTabs.SuspendLayout();
            this.Tab2Scales.SuspendLayout();
            this.Tab1Brush.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputComboBox
            // 
            this.InputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InputComboBox.FormattingEnabled = true;
            this.InputComboBox.Location = new System.Drawing.Point(4, 3);
            this.InputComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.InputComboBox.Name = "InputComboBox";
            this.InputComboBox.Size = new System.Drawing.Size(87, 23);
            this.InputComboBox.TabIndex = 4;
            this.InputComboBox.SelectedIndexChanged += new System.EventHandler(this.InputComboBox_SelectedIndexChanged);
            // 
            // sliderBrushRadius
            // 
            this.sliderBrushRadius.AutoSize = false;
            this.sliderBrushRadius.BackColor = System.Drawing.SystemColors.Control;
            this.sliderBrushRadius.Location = new System.Drawing.Point(3, 21);
            this.sliderBrushRadius.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sliderBrushRadius.Maximum = 600;
            this.sliderBrushRadius.Minimum = 1;
            this.sliderBrushRadius.Name = "sliderBrushRadius";
            this.sliderBrushRadius.Size = new System.Drawing.Size(234, 24);
            this.sliderBrushRadius.TabIndex = 6;
            this.sliderBrushRadius.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip.SetToolTip(this.sliderBrushRadius, "Brush radius.");
            this.sliderBrushRadius.Value = 100;
            this.sliderBrushRadius.Scroll += new System.EventHandler(this.BrushSizeX_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBox1.BackgroundImage")));
            this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(72, 66);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(26, 25);
            this.checkBox1.TabIndex = 8;
            this.toolTip.SetToolTip(this.checkBox1, "Drag brush.");
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBox2.BackgroundImage")));
            this.checkBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(38, 66);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(26, 25);
            this.checkBox2.TabIndex = 9;
            this.toolTip.SetToolTip(this.checkBox2, "Smoothen brush.");
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBox3.BackgroundImage")));
            this.checkBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(4, 66);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(26, 25);
            this.checkBox3.TabIndex = 10;
            this.toolTip.SetToolTip(this.checkBox3, "Noise brush.");
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // numWidth
            // 
            this.numWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numWidth.BackColor = System.Drawing.SystemColors.Control;
            this.numWidth.Location = new System.Drawing.Point(6, 21);
            this.numWidth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(58, 23);
            this.numWidth.TabIndex = 18;
            this.toolTip.SetToolTip(this.numWidth, "Width of the table.");
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
            this.numLength.Location = new System.Drawing.Point(72, 21);
            this.numLength.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLength.Name = "numLength";
            this.numLength.Size = new System.Drawing.Size(58, 23);
            this.numLength.TabIndex = 19;
            this.toolTip.SetToolTip(this.numLength, "Length of the table.");
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
            this.EditInputButton.Location = new System.Drawing.Point(94, 2);
            this.EditInputButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditInputButton.Name = "EditInputButton";
            this.EditInputButton.Size = new System.Drawing.Size(25, 25);
            this.EditInputButton.TabIndex = 22;
            this.EditInputButton.UseVisualStyleBackColor = false;
            this.EditInputButton.Click += new System.EventHandler(this.EditInputButton_Click);
            // 
            // ToolTabs
            // 
            this.ToolTabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ToolTabs.Controls.Add(this.Tab2Scales);
            this.ToolTabs.Controls.Add(this.Tab1Brush);
            this.ToolTabs.Controls.Add(this.tabPage1);
            this.ToolTabs.Location = new System.Drawing.Point(4, 29);
            this.ToolTabs.Margin = new System.Windows.Forms.Padding(0);
            this.ToolTabs.Name = "ToolTabs";
            this.ToolTabs.SelectedIndex = 0;
            this.ToolTabs.Size = new System.Drawing.Size(249, 443);
            this.ToolTabs.TabIndex = 0;
            // 
            // Tab2Scales
            // 
            this.Tab2Scales.BackColor = System.Drawing.SystemColors.Control;
            this.Tab2Scales.Controls.Add(this.scalesSettingsControl1);
            this.Tab2Scales.Location = new System.Drawing.Point(4, 24);
            this.Tab2Scales.Margin = new System.Windows.Forms.Padding(0);
            this.Tab2Scales.Name = "Tab2Scales";
            this.Tab2Scales.Size = new System.Drawing.Size(241, 415);
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
            // Tab1Brush
            // 
            this.Tab1Brush.BackColor = System.Drawing.SystemColors.Control;
            this.Tab1Brush.Controls.Add(this.labelBrushType);
            this.Tab1Brush.Controls.Add(this.labelBrushRadius);
            this.Tab1Brush.Controls.Add(this.sliderBrushRadius);
            this.Tab1Brush.Controls.Add(this.checkBox3);
            this.Tab1Brush.Controls.Add(this.checkBox1);
            this.Tab1Brush.Controls.Add(this.checkBox2);
            this.Tab1Brush.Location = new System.Drawing.Point(4, 24);
            this.Tab1Brush.Margin = new System.Windows.Forms.Padding(0);
            this.Tab1Brush.Name = "Tab1Brush";
            this.Tab1Brush.Size = new System.Drawing.Size(241, 415);
            this.Tab1Brush.TabIndex = 0;
            this.Tab1Brush.Text = "Brush";
            // 
            // labelBrushType
            // 
            this.labelBrushType.AutoSize = true;
            this.labelBrushType.Location = new System.Drawing.Point(3, 48);
            this.labelBrushType.Name = "labelBrushType";
            this.labelBrushType.Size = new System.Drawing.Size(33, 15);
            this.labelBrushType.TabIndex = 12;
            this.labelBrushType.Text = "type:";
            // 
            // labelBrushRadius
            // 
            this.labelBrushRadius.AutoSize = true;
            this.labelBrushRadius.Location = new System.Drawing.Point(3, 3);
            this.labelBrushRadius.Name = "labelBrushRadius";
            this.labelBrushRadius.Size = new System.Drawing.Size(42, 15);
            this.labelBrushRadius.TabIndex = 11;
            this.labelBrushRadius.Text = "radius:";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.checkBoxLockedLength);
            this.tabPage1.Controls.Add(this.checkBoxLockedWidth);
            this.tabPage1.Controls.Add(this.labelFixedSize);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.numWidth);
            this.tabPage1.Controls.Add(this.numLength);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(241, 415);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Editor";
            // 
            // checkBoxLockedLength
            // 
            this.checkBoxLockedLength.AutoSize = true;
            this.checkBoxLockedLength.Location = new System.Drawing.Point(68, 65);
            this.checkBoxLockedLength.Name = "checkBoxLockedLength";
            this.checkBoxLockedLength.Size = new System.Drawing.Size(60, 19);
            this.checkBoxLockedLength.TabIndex = 23;
            this.checkBoxLockedLength.Text = "length";
            this.checkBoxLockedLength.UseVisualStyleBackColor = true;
            // 
            // checkBoxLockedWidth
            // 
            this.checkBoxLockedWidth.AutoSize = true;
            this.checkBoxLockedWidth.Location = new System.Drawing.Point(6, 65);
            this.checkBoxLockedWidth.Name = "checkBoxLockedWidth";
            this.checkBoxLockedWidth.Size = new System.Drawing.Size(56, 19);
            this.checkBoxLockedWidth.TabIndex = 22;
            this.checkBoxLockedWidth.Text = "width";
            this.checkBoxLockedWidth.UseVisualStyleBackColor = true;
            // 
            // labelFixedSize
            // 
            this.labelFixedSize.AutoSize = true;
            this.labelFixedSize.Location = new System.Drawing.Point(6, 47);
            this.labelFixedSize.Name = "labelFixedSize";
            this.labelFixedSize.Size = new System.Drawing.Size(120, 15);
            this.labelFixedSize.TabIndex = 21;
            this.labelFixedSize.Text = "locked view table size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "table size:";
            // 
            // Graph3DEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToolTabs);
            this.Controls.Add(this.InputComboBox);
            this.Controls.Add(this.EditInputButton);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Graph3DEditor";
            this.Size = new System.Drawing.Size(875, 475);
            ((System.ComponentModel.ISupportInitialize)(this.sliderBrushRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            this.ToolTabs.ResumeLayout(false);
            this.Tab2Scales.ResumeLayout(false);
            this.Tab1Brush.ResumeLayout(false);
            this.Tab1Brush.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ComboBox InputComboBox;
        private System.Windows.Forms.TrackBar sliderBrushRadius;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.NumericUpDown numWidth;
        public System.Windows.Forms.NumericUpDown numLength;
        public System.Windows.Forms.Button EditInputButton;
        private System.Windows.Forms.TabPage Tab1Brush;
        private System.Windows.Forms.TabPage Tab2Scales;
        private GuiElement.ScalesSettingsControl scalesSettingsControl1;
        public System.Windows.Forms.TabControl ToolTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label labelBrushRadius;
        private System.Windows.Forms.Label labelBrushType;
        private System.Windows.Forms.CheckBox checkBoxLockedLength;
        private System.Windows.Forms.CheckBox checkBoxLockedWidth;
        private System.Windows.Forms.Label labelFixedSize;
    }
}
