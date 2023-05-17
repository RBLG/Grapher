namespace Grapher.GuiElement
{
    partial class TableModule2Editor
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            this.neo3dEditor1 = new Grapher.GuiElement.Neo3DEditor();
            this.SuspendLayout();
            // 
            // neo3dEditor1
            // 
            this.neo3dEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.neo3dEditor1.Location = new System.Drawing.Point(0, 3);
            this.neo3dEditor1.Name = "neo3dEditor1";
            this.neo3dEditor1.Size = new System.Drawing.Size(758, 472);
            this.neo3dEditor1.TabIndex = 0;
            this.neo3dEditor1.Text = "neo3dEditor1";
            // 
            // TableModule2Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neo3dEditor1);
            this.Name = "TableModule2Editor";
            this.Size = new System.Drawing.Size(761, 478);
            this.ResumeLayout(false);

        }

        #endregion

        private Neo3DEditor neo3dEditor1;
    }
}
