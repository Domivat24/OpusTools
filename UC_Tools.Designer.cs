namespace OpusTool
{
    partial class UC_Tools
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
            this.btnExportPo = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnModifyDll = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImportPo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportPo
            // 
            this.btnExportPo.BackgroundImage = global::OpusTool.Properties.Resources.art2;
            this.btnExportPo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportPo.Font = new System.Drawing.Font("Noto Sans Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExportPo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExportPo.Location = new System.Drawing.Point(0, 0);
            this.btnExportPo.Name = "btnExportPo";
            this.btnExportPo.Size = new System.Drawing.Size(901, 110);
            this.btnExportPo.TabIndex = 3;
            this.btnExportPo.Text = "export";
            this.btnExportPo.UseVisualStyleBackColor = true;
            this.btnExportPo.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // btnModifyDll
            // 
            this.btnModifyDll.BackColor = System.Drawing.Color.Transparent;
            this.btnModifyDll.BackgroundImage = global::OpusTool.Properties.Resources.art2;
            this.btnModifyDll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnModifyDll.Font = new System.Drawing.Font("Noto Sans Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModifyDll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModifyDll.Location = new System.Drawing.Point(0, 0);
            this.btnModifyDll.Name = "btnModifyDll";
            this.btnModifyDll.Size = new System.Drawing.Size(145, 110);
            this.btnModifyDll.TabIndex = 4;
            this.btnModifyDll.Text = "Modify Assembly";
            this.btnModifyDll.UseVisualStyleBackColor = false;
            this.btnModifyDll.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnImportPo);
            this.panel1.Controls.Add(this.btnModifyDll);
            this.panel1.Controls.Add(this.btnExportPo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 375);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 110);
            this.panel1.TabIndex = 6;
            // 
            // btnImportPo
            // 
            this.btnImportPo.BackgroundImage = global::OpusTool.Properties.Resources.art2;
            this.btnImportPo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImportPo.Font = new System.Drawing.Font("Noto Sans Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnImportPo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImportPo.Location = new System.Drawing.Point(145, 0);
            this.btnImportPo.Name = "btnImportPo";
            this.btnImportPo.Size = new System.Drawing.Size(129, 110);
            this.btnImportPo.TabIndex = 5;
            this.btnImportPo.Text = "import";
            this.btnImportPo.UseVisualStyleBackColor = true;
            this.btnImportPo.Click += new System.EventHandler(this.btnImportPo_Click);
            // 
            // UC_Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OpusTool.Properties.Resources.art2;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "UC_Tools";
            this.Size = new System.Drawing.Size(901, 485);
            this.Load += new System.EventHandler(this.UC_Tools_Load_1);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnExportPo;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private Button btnModifyDll;
        private FolderBrowserDialog folderBrowserDialog1;
        private Panel panel1;
        private Button btnImportPo;
    }
}
