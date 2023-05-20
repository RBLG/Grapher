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
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numLength = new System.Windows.Forms.NumericUpDown();
            this.EditInputButton = new System.Windows.Forms.Button();
            this.ToolTabs = new System.Windows.Forms.TabControl();
            this.Tab2Scales = new System.Windows.Forms.TabPage();
            this.scalesSettingsControl1 = new Grapher.GuiElement.ScalesSettingsControl();
            this.Tab1Brush = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.brushSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            this.ToolTabs.SuspendLayout();
            this.Tab2Scales.SuspendLayout();
            this.Tab1Brush.SuspendLayout();
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
            // numWidth
            // 
            this.numWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numWidth.BackColor = System.Drawing.SystemColors.Control;
            this.numWidth.Location = new System.Drawing.Point(750, 6);
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
            this.numLength.Location = new System.Drawing.Point(812, 6);
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
            this.scalesSettingsControl1.Name = "scalesSettingsControl1";
            this.scalesSettingsControl1.Size = new System.Drawing.Size(241, 380);
            this.scalesSettingsControl1.TabIndex = 0;
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
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(241, 441);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Editor";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Graph3DEditor";
            this.Size = new System.Drawing.Size(875, 475);
            ((System.ComponentModel.ISupportInitialize)(this.brushSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            this.ToolTabs.ResumeLayout(false);
            this.Tab2Scales.ResumeLayout(false);
            this.Tab1Brush.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TabPage Tab1Brush;
        private System.Windows.Forms.TabPage Tab2Scales;
        private GuiElement.ScalesSettingsControl scalesSettingsControl1;
        public System.Windows.Forms.TabControl ToolTabs;
        private System.Windows.Forms.TabPage tabPage1;
    }
}
