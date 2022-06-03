namespace Grapher.GuiElement
{
    partial class ScaleSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WidthAxisComboBox = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.HeightAxisComboBox = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.LengthAxisComboBox = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.DoneButton = new System.Windows.Forms.Button();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.InputLabel = new System.Windows.Forms.Label();
            this.ActionComboBox = new System.Windows.Forms.ComboBox();
            this.ActionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WidthAxisComboBox
            // 
            this.WidthAxisComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WidthAxisComboBox.FormattingEnabled = true;
            this.WidthAxisComboBox.Location = new System.Drawing.Point(53, 30);
            this.WidthAxisComboBox.Name = "WidthAxisComboBox";
            this.WidthAxisComboBox.Size = new System.Drawing.Size(121, 21);
            this.WidthAxisComboBox.TabIndex = 0;
            this.WidthAxisComboBox.SelectedIndexChanged += new System.EventHandler(this.WidthAxisComboBox_SelectedIndexChanged);
            this.WidthAxisComboBox.Enter += new System.EventHandler(this.WidthAxisComboBox_Enter);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(180, 30);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // HeightAxisComboBox
            // 
            this.HeightAxisComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HeightAxisComboBox.FormattingEnabled = true;
            this.HeightAxisComboBox.Location = new System.Drawing.Point(53, 119);
            this.HeightAxisComboBox.Name = "HeightAxisComboBox";
            this.HeightAxisComboBox.Size = new System.Drawing.Size(121, 21);
            this.HeightAxisComboBox.TabIndex = 2;
            this.HeightAxisComboBox.SelectedIndexChanged += new System.EventHandler(this.HeightAxisComboBox_SelectedIndexChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(180, 57);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 21);
            this.comboBox4.TabIndex = 3;
            // 
            // LengthAxisComboBox
            // 
            this.LengthAxisComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LengthAxisComboBox.FormattingEnabled = true;
            this.LengthAxisComboBox.Location = new System.Drawing.Point(53, 57);
            this.LengthAxisComboBox.Name = "LengthAxisComboBox";
            this.LengthAxisComboBox.Size = new System.Drawing.Size(121, 21);
            this.LengthAxisComboBox.TabIndex = 4;
            this.LengthAxisComboBox.SelectedIndexChanged += new System.EventHandler(this.LengthAxisComboBox_SelectedIndexChanged);
            this.LengthAxisComboBox.Enter += new System.EventHandler(this.LengthAxisComboBox_Enter);
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(180, 119);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(121, 21);
            this.comboBox6.TabIndex = 5;
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(254, 172);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(47, 23);
            this.DoneButton.TabIndex = 6;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(12, 33);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(35, 13);
            this.WidthLabel.TabIndex = 7;
            this.WidthLabel.Text = "Width";
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Location = new System.Drawing.Point(12, 60);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(40, 13);
            this.LengthLabel.TabIndex = 8;
            this.LengthLabel.Text = "Length";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(12, 122);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(38, 13);
            this.HeightLabel.TabIndex = 9;
            this.HeightLabel.Text = "Height";
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputLabel.Location = new System.Drawing.Point(22, 92);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(57, 15);
            this.OutputLabel.TabIndex = 10;
            this.OutputLabel.Text = "Output :";
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLabel.Location = new System.Drawing.Point(22, 9);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(47, 15);
            this.InputLabel.TabIndex = 11;
            this.InputLabel.Text = "Input :";
            // 
            // ActionComboBox
            // 
            this.ActionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ActionComboBox.FormattingEnabled = true;
            this.ActionComboBox.Location = new System.Drawing.Point(53, 146);
            this.ActionComboBox.Name = "ActionComboBox";
            this.ActionComboBox.Size = new System.Drawing.Size(121, 21);
            this.ActionComboBox.TabIndex = 12;
            // 
            // ActionLabel
            // 
            this.ActionLabel.AutoSize = true;
            this.ActionLabel.Location = new System.Drawing.Point(12, 149);
            this.ActionLabel.Name = "ActionLabel";
            this.ActionLabel.Size = new System.Drawing.Size(37, 13);
            this.ActionLabel.TabIndex = 13;
            this.ActionLabel.Text = "Action";
            // 
            // ScaleSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 205);
            this.Controls.Add(this.ActionLabel);
            this.Controls.Add(this.ActionComboBox);
            this.Controls.Add(this.InputLabel);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.LengthAxisComboBox);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.HeightAxisComboBox);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.WidthAxisComboBox);
            this.MaximumSize = new System.Drawing.Size(325, 244);
            this.MinimumSize = new System.Drawing.Size(325, 244);
            this.Name = "ScaleSettings";
            this.Text = "Axis settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox WidthAxisComboBox;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox HeightAxisComboBox;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox LengthAxisComboBox;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.ComboBox ActionComboBox;
        private System.Windows.Forms.Label ActionLabel;
    }
}