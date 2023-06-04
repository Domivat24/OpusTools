namespace OpusTool
{
    partial class UC_Patcher
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Patcher));
            btnaApplyPatch = new Button();
            SuspendLayout();
            // 
            // btnaApplyPatch
            // 
            btnaApplyPatch.BackgroundImage = Properties.Resources.art3;
            btnaApplyPatch.BackgroundImageLayout = ImageLayout.None;
            btnaApplyPatch.Font = new Font("Noto Sans", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnaApplyPatch.ForeColor = SystemColors.ControlLightLight;
            btnaApplyPatch.Image = Properties.Resources.button;
            btnaApplyPatch.Location = new Point(86, 0);
            btnaApplyPatch.Name = "btnaApplyPatch";
            btnaApplyPatch.Size = new Size(721, 150);
            btnaApplyPatch.TabIndex = 0;
            btnaApplyPatch.UseVisualStyleBackColor = true;
            btnaApplyPatch.Click += btnPatcher_Click;
            // 
            // UC_Patcher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(btnaApplyPatch);
            Name = "UC_Patcher";
            Size = new Size(1255, 744);
            ResumeLayout(false);
        }

        #endregion

        private Button btnaApplyPatch;
    }
}
