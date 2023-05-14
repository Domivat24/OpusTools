using System.Globalization;
using System.Resources;

namespace OpusTool
{
    partial class UC_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Settings));
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.languageBox = new System.Windows.Forms.ComboBox();
            this.btnCheckUpdates = new System.Windows.Forms.Button();
            this.labelVolume = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // volumeBar
            // 
            resources.ApplyResources(this.volumeBar, "volumeBar");
            this.volumeBar.LargeChange = 10;
            this.volumeBar.Maximum = 100;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeBar.Value = 100;
            this.volumeBar.Scroll += new System.EventHandler(this.volumeBar_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelLanguage);
            this.panel1.Controls.Add(this.languageBox);
            this.panel1.Controls.Add(this.btnCheckUpdates);
            this.panel1.Controls.Add(this.labelVolume);
            this.panel1.Controls.Add(this.volumeBar);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // labelLanguage
            // 
            resources.ApplyResources(this.labelLanguage, "labelLanguage");
            this.labelLanguage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelLanguage.Name = "labelLanguage";
            // 
            // languageBox
            // 
            resources.ApplyResources(this.languageBox, "languageBox");
            this.languageBox.FormattingEnabled = true;
            this.languageBox.Name = "languageBox";
            this.languageBox.SelectedIndexChanged += new System.EventHandler(this.languageBox_SelectedIndexChanged);
            // 
            // btnCheckUpdates
            // 
            this.btnCheckUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.btnCheckUpdates, "btnCheckUpdates");
            this.btnCheckUpdates.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCheckUpdates.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCheckUpdates.Name = "btnCheckUpdates";
            this.btnCheckUpdates.UseVisualStyleBackColor = false;
            this.btnCheckUpdates.Click += new System.EventHandler(this.checkUpdates_Click);
            // 
            // labelVolume
            // 
            resources.ApplyResources(this.labelVolume, "labelVolume");
            this.labelVolume.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelVolume.Name = "labelVolume";
            // 
            // UC_Settings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "UC_Settings";
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TrackBar volumeBar;
        private Panel panel1;
        private Button btnCheckUpdates;
        private Label labelVolume;
        private ComboBox languageBox;
        private Label labelLanguage;
    }
}
