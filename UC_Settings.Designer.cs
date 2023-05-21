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
            volumeBar = new TrackBar();
            panel1 = new Panel();
            labelDirectory = new Label();
            textBoxDirectory = new TextBox();
            labelLanguage = new Label();
            languageBox = new ComboBox();
            btnCheckUpdates = new Button();
            labelVolume = new Label();
            ((System.ComponentModel.ISupportInitialize)volumeBar).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // volumeBar
            // 
            resources.ApplyResources(volumeBar, "volumeBar");
            volumeBar.LargeChange = 10;
            volumeBar.Maximum = 100;
            volumeBar.Name = "volumeBar";
            volumeBar.TickStyle = TickStyle.None;
            volumeBar.Value = 100;
            volumeBar.Scroll += volumeBar_Scroll;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelDirectory);
            panel1.Controls.Add(textBoxDirectory);
            panel1.Controls.Add(labelLanguage);
            panel1.Controls.Add(languageBox);
            panel1.Controls.Add(btnCheckUpdates);
            panel1.Controls.Add(labelVolume);
            panel1.Controls.Add(volumeBar);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // labelDirectory
            // 
            resources.ApplyResources(labelDirectory, "labelDirectory");
            labelDirectory.ForeColor = SystemColors.ControlLightLight;
            labelDirectory.Name = "labelDirectory";
            // 
            // textBoxDirectory
            // 
            resources.ApplyResources(textBoxDirectory, "textBoxDirectory");
            textBoxDirectory.Name = "textBoxDirectory";
            // 
            // labelLanguage
            // 
            resources.ApplyResources(labelLanguage, "labelLanguage");
            labelLanguage.ForeColor = SystemColors.ControlLightLight;
            labelLanguage.Name = "labelLanguage";
            // 
            // languageBox
            // 
            resources.ApplyResources(languageBox, "languageBox");
            languageBox.FormattingEnabled = true;
            languageBox.Name = "languageBox";
            languageBox.SelectedIndexChanged += languageBox_SelectedIndexChanged;
            // 
            // btnCheckUpdates
            // 
            btnCheckUpdates.BackColor = Color.FromArgb(128, 128, 255);
            resources.ApplyResources(btnCheckUpdates, "btnCheckUpdates");
            btnCheckUpdates.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 255);
            btnCheckUpdates.ForeColor = SystemColors.ButtonHighlight;
            btnCheckUpdates.Name = "btnCheckUpdates";
            btnCheckUpdates.UseVisualStyleBackColor = false;
            btnCheckUpdates.Click += checkUpdates_Click;
            // 
            // labelVolume
            // 
            resources.ApplyResources(labelVolume, "labelVolume");
            labelVolume.ForeColor = SystemColors.ControlLightLight;
            labelVolume.Name = "labelVolume";
            // 
            // UC_Settings
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            DoubleBuffered = true;
            Name = "UC_Settings";
            ((System.ComponentModel.ISupportInitialize)volumeBar).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TrackBar volumeBar;
        private Panel panel1;
        private Button btnCheckUpdates;
        private Label labelVolume;
        private ComboBox languageBox;
        private Label labelLanguage;
        private Label labelDirectory;
        private TextBox textBoxDirectory;
    }
}
