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
            labelVolume = new Label();
            btnCheckUpdates = new Button();
            labelLanguage = new Label();
            panel1 = new Panel();
            textBoxDirectory = new TextBox();
            labelDirectory = new Label();
            languageBox = new ComboBox();
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
            // labelVolume
            // 
            resources.ApplyResources(labelVolume, "labelVolume");
            labelVolume.ForeColor = SystemColors.ControlLightLight;
            labelVolume.Name = "labelVolume";
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
            // labelLanguage
            // 
            resources.ApplyResources(labelLanguage, "labelLanguage");
            labelLanguage.ForeColor = SystemColors.ControlLightLight;
            labelLanguage.Name = "labelLanguage";
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxDirectory);
            panel1.Controls.Add(labelDirectory);
            panel1.Controls.Add(languageBox);
            panel1.Controls.Add(labelLanguage);
            panel1.Controls.Add(btnCheckUpdates);
            panel1.Controls.Add(labelVolume);
            panel1.Controls.Add(volumeBar);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // textBoxDirectory
            // 
            textBoxDirectory.AllowDrop = true;
            textBoxDirectory.Cursor = Cursors.Cross;
            resources.ApplyResources(textBoxDirectory, "textBoxDirectory");
            textBoxDirectory.Name = "textBoxDirectory";
            textBoxDirectory.ReadOnly = true;
            textBoxDirectory.MouseClick += textBoxDirectory_MouseClick;
            textBoxDirectory.TextChanged += textBoxDirectory_TextChanged;
            textBoxDirectory.DragDrop += textBoxDirectory_DragDrop;
            textBoxDirectory.DragEnter += textBoxDirectory_DragEnter;
            textBoxDirectory.DragLeave += textBoxDirectory_DragLeave;
            textBoxDirectory.MouseEnter += textBoxDirectory_MouseEnter;
            textBoxDirectory.MouseLeave += textBoxDirectory_MouseLeave;
            // 
            // labelDirectory
            // 
            resources.ApplyResources(labelDirectory, "labelDirectory");
            labelDirectory.ForeColor = SystemColors.ControlLightLight;
            labelDirectory.Name = "labelDirectory";
            // 
            // languageBox
            // 
            resources.ApplyResources(languageBox, "languageBox");
            languageBox.DropDownStyle = ComboBoxStyle.DropDownList;
            languageBox.FormattingEnabled = true;
            languageBox.Name = "languageBox";
            languageBox.SelectedIndexChanged += languageBox_SelectedIndexChanged;
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
        private Label labelVolume;
        private Button btnCheckUpdates;
        private Label labelLanguage;
        private Panel panel1;
        private TextBox textBoxDirectory;
        private Label labelDirectory;
        private ComboBox languageBox;
    }
}
