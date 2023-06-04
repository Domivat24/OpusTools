namespace OpusTool
{
    partial class UC_About
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
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            labelNoInternet = new Label();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            SuspendLayout();
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Dock = DockStyle.Fill;
            webView.Location = new Point(0, 0);
            webView.Name = "webView";
            webView.Size = new Size(640, 444);
            webView.TabIndex = 0;
            webView.Visible = false;
            webView.ZoomFactor = 1D;
            // 
            // labelNoInternet
            // 
            labelNoInternet.AutoEllipsis = true;
            labelNoInternet.Dock = DockStyle.Fill;
            labelNoInternet.Font = new Font("Noto Sans Cond", 21.7499962F, FontStyle.Regular, GraphicsUnit.Point);
            labelNoInternet.ForeColor = SystemColors.ButtonHighlight;
            labelNoInternet.Location = new Point(0, 0);
            labelNoInternet.Name = "labelNoInternet";
            labelNoInternet.Size = new Size(640, 444);
            labelNoInternet.TabIndex = 2;
            labelNoInternet.Text = "labelNoInternet";
            labelNoInternet.TextAlign = ContentAlignment.MiddleCenter;
            labelNoInternet.Visible = false;
            // 
            // UC_About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.button;
            Controls.Add(labelNoInternet);
            Controls.Add(webView);
            Name = "UC_About";
            Size = new Size(640, 444);
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private Label labelNoInternet;
    }
}
