namespace Grapher.GuiElement
{
    partial class ScalesSettingsControl
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
            this.ModeComboBox = new System.Windows.Forms.ComboBox();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.ModeSocket = new Grapher.GuiElement.ScaleSettings.ScaleGuiSocket();
            this.HeightComboBox = new System.Windows.Forms.ComboBox();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.HeightSocket = new Grapher.GuiElement.ScaleSettings.ScaleGuiSocket();
            this.LengthComboBox = new System.Windows.Forms.ComboBox();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.LengthSocket = new Grapher.GuiElement.ScaleSettings.ScaleGuiSocket();
            this.WidthComboBox = new System.Windows.Forms.ComboBox();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.WidthSocket = new Grapher.GuiElement.ScaleSettings.ScaleGuiSocket();
            this.SuspendLayout();
            // 
            // ModeComboBox
            // 
            this.ModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeComboBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModeComboBox.FormattingEnabled = true;
            this.ModeComboBox.Location = new System.Drawing.Point(52, 289);
            this.ModeComboBox.Name = "ModeComboBox";
            this.ModeComboBox.Size = new System.Drawing.Size(186, 21);
            this.ModeComboBox.TabIndex = 24;
            this.ModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ModeComboBox_SelectedIndexChanged);
            this.ModeComboBox.Enter += new System.EventHandler(this.ModeComboBox_Enter);
            // 
            // ModeLabel
            // 
            this.ModeLabel.AutoSize = true;
            this.ModeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModeLabel.Location = new System.Drawing.Point(4, 291);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(41, 15);
            this.ModeLabel.TabIndex = 23;
            this.ModeLabel.Text = "Mode:";
            // 
            // ModeSocket
            // 
            this.ModeSocket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModeSocket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModeSocket.Location = new System.Drawing.Point(4, 319);
            this.ModeSocket.MaximumSize = new System.Drawing.Size(235, 58);
            this.ModeSocket.MinimumSize = new System.Drawing.Size(235, 58);
            this.ModeSocket.Name = "ModeSocket";
            this.ModeSocket.Size = new System.Drawing.Size(235, 58);
            this.ModeSocket.TabIndex = 22;
            // 
            // HeightComboBox
            // 
            this.HeightComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HeightComboBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HeightComboBox.FormattingEnabled = true;
            this.HeightComboBox.Location = new System.Drawing.Point(52, 194);
            this.HeightComboBox.Name = "HeightComboBox";
            this.HeightComboBox.Size = new System.Drawing.Size(186, 21);
            this.HeightComboBox.TabIndex = 21;
            this.HeightComboBox.SelectedIndexChanged += new System.EventHandler(this.HeightComboBox_SelectedIndexChanged);
            this.HeightComboBox.Enter += new System.EventHandler(this.HeightComboBox_Enter);
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HeightLabel.Location = new System.Drawing.Point(4, 196);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(46, 15);
            this.HeightLabel.TabIndex = 20;
            this.HeightLabel.Text = "Height:";
            // 
            // HeightSocket
            // 
            this.HeightSocket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HeightSocket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeightSocket.Location = new System.Drawing.Point(4, 224);
            this.HeightSocket.MaximumSize = new System.Drawing.Size(235, 58);
            this.HeightSocket.MinimumSize = new System.Drawing.Size(235, 58);
            this.HeightSocket.Name = "HeightSocket";
            this.HeightSocket.Size = new System.Drawing.Size(235, 58);
            this.HeightSocket.TabIndex = 19;
            // 
            // LengthComboBox
            // 
            this.LengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LengthComboBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LengthComboBox.FormattingEnabled = true;
            this.LengthComboBox.Location = new System.Drawing.Point(52, 98);
            this.LengthComboBox.Name = "LengthComboBox";
            this.LengthComboBox.Size = new System.Drawing.Size(186, 21);
            this.LengthComboBox.TabIndex = 18;
            this.LengthComboBox.SelectedIndexChanged += new System.EventHandler(this.LengthComboBox_SelectedIndexChanged);
            this.LengthComboBox.Enter += new System.EventHandler(this.LengthComboBox_Enter);
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LengthLabel.Location = new System.Drawing.Point(4, 100);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(47, 15);
            this.LengthLabel.TabIndex = 17;
            this.LengthLabel.Text = "Length:";
            // 
            // LengthSocket
            // 
            this.LengthSocket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LengthSocket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LengthSocket.Location = new System.Drawing.Point(4, 128);
            this.LengthSocket.MaximumSize = new System.Drawing.Size(235, 58);
            this.LengthSocket.MinimumSize = new System.Drawing.Size(235, 58);
            this.LengthSocket.Name = "LengthSocket";
            this.LengthSocket.Size = new System.Drawing.Size(235, 58);
            this.LengthSocket.TabIndex = 16;
            // 
            // WidthComboBox
            // 
            this.WidthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WidthComboBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WidthComboBox.FormattingEnabled = true;
            this.WidthComboBox.Location = new System.Drawing.Point(52, 3);
            this.WidthComboBox.Name = "WidthComboBox";
            this.WidthComboBox.Size = new System.Drawing.Size(186, 21);
            this.WidthComboBox.TabIndex = 15;
            this.WidthComboBox.SelectedIndexChanged += new System.EventHandler(this.WidthComboBox_SelectedIndexChanged);
            this.WidthComboBox.Enter += new System.EventHandler(this.WidthComboBox_Enter);
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WidthLabel.Location = new System.Drawing.Point(4, 5);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(42, 15);
            this.WidthLabel.TabIndex = 14;
            this.WidthLabel.Text = "Width:";
            // 
            // WidthSocket
            // 
            this.WidthSocket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WidthSocket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WidthSocket.Location = new System.Drawing.Point(4, 33);
            this.WidthSocket.MaximumSize = new System.Drawing.Size(235, 58);
            this.WidthSocket.MinimumSize = new System.Drawing.Size(235, 58);
            this.WidthSocket.Name = "WidthSocket";
            this.WidthSocket.Size = new System.Drawing.Size(235, 58);
            this.WidthSocket.TabIndex = 13;
            // 
            // ScalesSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.MaximumSize = new System.Drawing.Size(241, 380);
            this.MinimumSize = new System.Drawing.Size(241, 380);
            this.Name = "ScalesSettingsControl";
            this.Size = new System.Drawing.Size(241, 380);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ModeComboBox;
        private System.Windows.Forms.Label ModeLabel;
        private ScaleSettings.ScaleGuiSocket ModeSocket;
        private System.Windows.Forms.ComboBox HeightComboBox;
        private System.Windows.Forms.Label HeightLabel;
        private ScaleSettings.ScaleGuiSocket HeightSocket;
        private System.Windows.Forms.ComboBox LengthComboBox;
        private System.Windows.Forms.Label LengthLabel;
        private ScaleSettings.ScaleGuiSocket LengthSocket;
        private System.Windows.Forms.ComboBox WidthComboBox;
        private System.Windows.Forms.Label WidthLabel;
        private ScaleSettings.ScaleGuiSocket WidthSocket;
    }
}
