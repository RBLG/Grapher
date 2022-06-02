﻿namespace Grapher
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
            this.label1 = new System.Windows.Forms.Label();
            this.brushSize = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numLength = new System.Windows.Forms.NumericUpDown();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.AxisSettingsButton = new System.Windows.Forms.Button();
            this.EditInputButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.brushSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // InputComboBox
            // 
            this.InputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InputComboBox.FormattingEnabled = true;
            this.InputComboBox.Location = new System.Drawing.Point(84, 19);
            this.InputComboBox.Name = "InputComboBox";
            this.InputComboBox.Size = new System.Drawing.Size(75, 21);
            this.InputComboBox.TabIndex = 4;
            this.InputComboBox.SelectedIndexChanged += new System.EventHandler(this.InputComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Brush :";
            // 
            // brushSize
            // 
            this.brushSize.AutoSize = false;
            this.brushSize.Location = new System.Drawing.Point(3, 62);
            this.brushSize.Maximum = 10000;
            this.brushSize.Name = "brushSize";
            this.brushSize.Size = new System.Drawing.Size(75, 23);
            this.brushSize.TabIndex = 6;
            this.brushSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.brushSize.Scroll += new System.EventHandler(this.brushSizeX_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBox1.BackgroundImage")));
            this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(0, 91);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(22, 22);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBox2.BackgroundImage")));
            this.checkBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(26, 91);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(22, 22);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBox3.BackgroundImage")));
            this.checkBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(52, 91);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(22, 22);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "length";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "duration (ms)";
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(233, 20);
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(64, 20);
            this.numWidth.TabIndex = 18;
            this.numWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWidth.ValueChanged += new System.EventHandler(this.numWidth_ValueChanged);
            // 
            // numLength
            // 
            this.numLength.Location = new System.Drawing.Point(303, 20);
            this.numLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLength.Name = "numLength";
            this.numLength.Size = new System.Drawing.Size(64, 20);
            this.numLength.TabIndex = 19;
            this.numLength.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numLength.ValueChanged += new System.EventHandler(this.numLength_ValueChanged);
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(373, 20);
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
            this.numDuration.Size = new System.Drawing.Size(64, 20);
            this.numDuration.TabIndex = 20;
            this.numDuration.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDuration.ValueChanged += new System.EventHandler(this.numDuration_ValueChanged);
            // 
            // AxisSettingsButton
            // 
            this.AxisSettingsButton.Location = new System.Drawing.Point(3, 18);
            this.AxisSettingsButton.Name = "AxisSettingsButton";
            this.AxisSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.AxisSettingsButton.TabIndex = 21;
            this.AxisSettingsButton.Text = "Axis Settings";
            this.AxisSettingsButton.UseVisualStyleBackColor = true;
            this.AxisSettingsButton.Click += new System.EventHandler(this.AxisSettingsButton_Click);
            // 
            // EditInputButton
            // 
            this.EditInputButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditInputButton.BackgroundImage")));
            this.EditInputButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditInputButton.Location = new System.Drawing.Point(165, 19);
            this.EditInputButton.Name = "EditInputButton";
            this.EditInputButton.Size = new System.Drawing.Size(22, 21);
            this.EditInputButton.TabIndex = 22;
            this.EditInputButton.UseVisualStyleBackColor = true;
            this.EditInputButton.Click += new System.EventHandler(this.EditInputButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "input";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Graph3DEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EditInputButton);
            this.Controls.Add(this.AxisSettingsButton);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.numLength);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.brushSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputComboBox);
            this.Name = "Graph3DEditor";
            this.Size = new System.Drawing.Size(909, 560);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Graph3DEditor_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Graph3DEditor_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.brushSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox InputComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar brushSize;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.NumericUpDown numLength;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Button AxisSettingsButton;
        private System.Windows.Forms.Button EditInputButton;
        private System.Windows.Forms.Label label5;

    }
}