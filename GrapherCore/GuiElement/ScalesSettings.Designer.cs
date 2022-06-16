namespace Grapher.GuiElement
{
    partial class ScalesSettings
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
            this.WidthSocket = new Grapher.GuiElement.ScaleSettings.ScaleGuiSocket();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.WidthComboBox = new System.Windows.Forms.ComboBox();
            this.LengthComboBox = new System.Windows.Forms.ComboBox();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.LengthSocket = new Grapher.GuiElement.ScaleSettings.ScaleGuiSocket();
            this.HeightComboBox = new System.Windows.Forms.ComboBox();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.HeightSocket = new Grapher.GuiElement.ScaleSettings.ScaleGuiSocket();
            this.ModeComboBox = new System.Windows.Forms.ComboBox();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.ModeSocket = new Grapher.GuiElement.ScaleSettings.ScaleGuiSocket();
            this.SuspendLayout();
            // 
            // WidthSocket
            // 
            this.WidthSocket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WidthSocket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WidthSocket.Location = new System.Drawing.Point(5, 34);
            this.WidthSocket.MaximumSize = new System.Drawing.Size(235, 58);
            this.WidthSocket.MinimumSize = new System.Drawing.Size(235, 58);
            this.WidthSocket.Name = "WidthSocket";
            this.WidthSocket.Size = new System.Drawing.Size(235, 58);
            this.WidthSocket.TabIndex = 0;
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WidthLabel.Location = new System.Drawing.Point(5, 6);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(42, 15);
            this.WidthLabel.TabIndex = 2;
            this.WidthLabel.Text = "Width:";
            // 
            // WidthComboBox
            // 
            this.WidthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WidthComboBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WidthComboBox.FormattingEnabled = true;
            this.WidthComboBox.Location = new System.Drawing.Point(53, 4);
            this.WidthComboBox.Name = "WidthComboBox";
            this.WidthComboBox.Size = new System.Drawing.Size(186, 21);
            this.WidthComboBox.TabIndex = 3;
            this.WidthComboBox.SelectedIndexChanged += new System.EventHandler(this.WidthComboBox_SelectedIndexChanged);
            this.WidthComboBox.Enter += new System.EventHandler(this.WidthComboBox_Enter);
            // 
            // LengthComboBox
            // 
            this.LengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LengthComboBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LengthComboBox.FormattingEnabled = true;
            this.LengthComboBox.Location = new System.Drawing.Point(53, 99);
            this.LengthComboBox.Name = "LengthComboBox";
            this.LengthComboBox.Size = new System.Drawing.Size(186, 21);
            this.LengthComboBox.TabIndex = 6;
            this.LengthComboBox.SelectedIndexChanged += new System.EventHandler(this.LengthComboBox_SelectedIndexChanged);
            this.LengthComboBox.Enter += new System.EventHandler(this.LengthComboBox_Enter);
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LengthLabel.Location = new System.Drawing.Point(5, 101);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(47, 15);
            this.LengthLabel.TabIndex = 5;
            this.LengthLabel.Text = "Length:";
            // 
            // LengthSocket
            // 
            this.LengthSocket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LengthSocket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LengthSocket.Location = new System.Drawing.Point(5, 129);
            this.LengthSocket.MaximumSize = new System.Drawing.Size(235, 58);
            this.LengthSocket.MinimumSize = new System.Drawing.Size(235, 58);
            this.LengthSocket.Name = "LengthSocket";
            this.LengthSocket.Size = new System.Drawing.Size(235, 58);
            this.LengthSocket.TabIndex = 4;
            // 
            // HeightComboBox
            // 
            this.HeightComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HeightComboBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HeightComboBox.FormattingEnabled = true;
            this.HeightComboBox.Location = new System.Drawing.Point(53, 195);
            this.HeightComboBox.Name = "HeightComboBox";
            this.HeightComboBox.Size = new System.Drawing.Size(186, 21);
            this.HeightComboBox.TabIndex = 9;
            this.HeightComboBox.SelectedIndexChanged += new System.EventHandler(this.HeightComboBox_SelectedIndexChanged);
            this.HeightComboBox.Enter += new System.EventHandler(this.HeightComboBox_Enter);
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HeightLabel.Location = new System.Drawing.Point(5, 197);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(46, 15);
            this.HeightLabel.TabIndex = 8;
            this.HeightLabel.Text = "Height:";
            // 
            // HeightSocket
            // 
            this.HeightSocket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HeightSocket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeightSocket.Location = new System.Drawing.Point(5, 225);
            this.HeightSocket.MaximumSize = new System.Drawing.Size(235, 58);
            this.HeightSocket.MinimumSize = new System.Drawing.Size(235, 58);
            this.HeightSocket.Name = "HeightSocket";
            this.HeightSocket.Size = new System.Drawing.Size(235, 58);
            this.HeightSocket.TabIndex = 7;
            // 
            // ModeComboBox
            // 
            this.ModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeComboBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModeComboBox.FormattingEnabled = true;
            this.ModeComboBox.Location = new System.Drawing.Point(53, 290);
            this.ModeComboBox.Name = "ModeComboBox";
            this.ModeComboBox.Size = new System.Drawing.Size(186, 21);
            this.ModeComboBox.TabIndex = 12;
            this.ModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ModeComboBox_SelectedIndexChanged);
            this.ModeComboBox.Enter += new System.EventHandler(this.ModeComboBox_Enter);
            // 
            // ModeLabel
            // 
            this.ModeLabel.AutoSize = true;
            this.ModeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModeLabel.Location = new System.Drawing.Point(5, 292);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(41, 15);
            this.ModeLabel.TabIndex = 11;
            this.ModeLabel.Text = "Mode:";
            // 
            // ModeSocket
            // 
            this.ModeSocket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModeSocket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModeSocket.Location = new System.Drawing.Point(5, 320);
            this.ModeSocket.MaximumSize = new System.Drawing.Size(235, 58);
            this.ModeSocket.MinimumSize = new System.Drawing.Size(235, 58);
            this.ModeSocket.Name = "ModeSocket";
            this.ModeSocket.Size = new System.Drawing.Size(235, 58);
            this.ModeSocket.TabIndex = 10;
            // 
            // ScalesSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 391);
            this.Controls.Add(this.ModeComboBox);
            this.Controls.Add(this.ModeLabel);
            this.Controls.Add(this.ModeSocket);
            this.Controls.Add(this.HeightComboBox);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.HeightSocket);
            this.Controls.Add(this.LengthComboBox);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.LengthSocket);
            this.Controls.Add(this.WidthComboBox);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.WidthSocket);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(260, 430);
            this.MinimumSize = new System.Drawing.Size(260, 430);
            this.Name = "ScalesSettings";
            this.Text = "Axis settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScaleSettings.ScaleGuiSocket WidthSocket;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.ComboBox WidthComboBox;
        private System.Windows.Forms.ComboBox LengthComboBox;
        private System.Windows.Forms.Label LengthLabel;
        private ScaleSettings.ScaleGuiSocket LengthSocket;
        private System.Windows.Forms.ComboBox HeightComboBox;
        private System.Windows.Forms.Label HeightLabel;
        private ScaleSettings.ScaleGuiSocket HeightSocket;
        private System.Windows.Forms.ComboBox ModeComboBox;
        private System.Windows.Forms.Label ModeLabel;
        private ScaleSettings.ScaleGuiSocket ModeSocket;
    }
}