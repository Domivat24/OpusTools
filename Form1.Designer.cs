using System.Globalization;
using System.Resources;

namespace OpusTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelHeader = new Panel();
            labelHeader = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelSettings = new Panel();
            btnSettings = new Button();
            panelAbout = new Panel();
            btnAbout = new Button();
            panelPatcher = new Panel();
            btnPatcher = new Button();
            panelTools = new Panel();
            btnTools = new Button();
            panelContent = new Panel();
            panelHeader.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelSettings.SuspendLayout();
            panelAbout.SuspendLayout();
            panelPatcher.SuspendLayout();
            panelTools.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            resources.ApplyResources(panelHeader, "panelHeader");
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Name = "panelHeader";
            // 
            // labelHeader
            // 
            resources.ApplyResources(labelHeader, "labelHeader");
            labelHeader.BackColor = Color.Transparent;
            labelHeader.ForeColor = SystemColors.ButtonHighlight;
            labelHeader.Name = "labelHeader";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(panelSettings, 0, 0);
            tableLayoutPanel1.Controls.Add(panelAbout, 0, 0);
            tableLayoutPanel1.Controls.Add(panelPatcher, 0, 0);
            tableLayoutPanel1.Controls.Add(panelTools, 0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panelSettings
            // 
            panelSettings.BackColor = Color.FromArgb(114, 117, 147);
            panelSettings.Controls.Add(btnSettings);
            resources.ApplyResources(panelSettings, "panelSettings");
            panelSettings.Name = "panelSettings";
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(114, 117, 147);
            resources.ApplyResources(btnSettings, "btnSettings");
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.ForeColor = SystemColors.ButtonHighlight;
            btnSettings.Name = "btnSettings";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += tab_Click;
            // 
            // panelAbout
            // 
            panelAbout.BackColor = Color.FromArgb(114, 117, 147);
            panelAbout.Controls.Add(btnAbout);
            resources.ApplyResources(panelAbout, "panelAbout");
            panelAbout.Name = "panelAbout";
            // 
            // btnAbout
            // 
            btnAbout.BackColor = Color.FromArgb(114, 117, 147);
            resources.ApplyResources(btnAbout, "btnAbout");
            btnAbout.FlatAppearance.BorderSize = 0;
            btnAbout.ForeColor = SystemColors.ButtonHighlight;
            btnAbout.Name = "btnAbout";
            btnAbout.UseVisualStyleBackColor = false;
            btnAbout.Click += tab_Click;
            // 
            // panelPatcher
            // 
            panelPatcher.BackColor = Color.Cyan;
            panelPatcher.Controls.Add(btnPatcher);
            resources.ApplyResources(panelPatcher, "panelPatcher");
            panelPatcher.Name = "panelPatcher";
            // 
            // btnPatcher
            // 
            btnPatcher.BackColor = Color.FromArgb(114, 117, 147);
            resources.ApplyResources(btnPatcher, "btnPatcher");
            btnPatcher.FlatAppearance.BorderSize = 0;
            btnPatcher.ForeColor = SystemColors.ButtonHighlight;
            btnPatcher.Name = "btnPatcher";
            btnPatcher.UseVisualStyleBackColor = false;
            btnPatcher.Click += tab_Click;
            // 
            // panelTools
            // 
            panelTools.BackColor = Color.FromArgb(114, 117, 147);
            panelTools.Controls.Add(btnTools);
            resources.ApplyResources(panelTools, "panelTools");
            panelTools.Name = "panelTools";
            // 
            // btnTools
            // 
            btnTools.BackColor = Color.FromArgb(114, 117, 147);
            resources.ApplyResources(btnTools, "btnTools");
            btnTools.FlatAppearance.BorderSize = 0;
            btnTools.ForeColor = SystemColors.ButtonHighlight;
            btnTools.Name = "btnTools";
            btnTools.UseVisualStyleBackColor = false;
            btnTools.Click += tab_Click;
            // 
            // panelContent
            // 
            resources.ApplyResources(panelContent, "panelContent");
            panelContent.Name = "panelContent";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(114, 117, 147);
            Controls.Add(panelContent);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            FormClosing += Form1_FormClosing_1;
            Load += Form1_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panelSettings.ResumeLayout(false);
            panelAbout.ResumeLayout(false);
            panelPatcher.ResumeLayout(false);
            panelTools.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelHeader;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelTools;
        private Button btnTools;
        private Label labelHeader;
        private Panel panelSettings;
        private Button btnSettings;
        private Panel panelAbout;
        private Button btnAbout;
        private Panel panelPatcher;
        private Button btnPatcher;
        private Panel panelContent;
    }
}