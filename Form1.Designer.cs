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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panelAbout = new System.Windows.Forms.Panel();
            this.btnAbout = new System.Windows.Forms.Button();
            this.panelPatcher = new System.Windows.Forms.Panel();
            this.btnPatcher = new System.Windows.Forms.Button();
            this.panelTools = new System.Windows.Forms.Panel();
            this.btnTools = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.panelAbout.SuspendLayout();
            this.panelPatcher.SuspendLayout();
            this.panelTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            resources.ApplyResources(this.panelHeader, "panelHeader");
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Name = "panelHeader";
            // 
            // labelHeader
            // 
            resources.ApplyResources(this.labelHeader, "labelHeader");
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Click += new System.EventHandler(this.label1_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panelSettings, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelAbout, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelPatcher, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelTools, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panelSettings
            // 
            this.panelSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(147)))));
            this.panelSettings.Controls.Add(this.btnSettings);
            resources.ApplyResources(this.panelSettings, "panelSettings");
            this.panelSettings.Name = "panelSettings";
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.tab_Click);
            // 
            // panelAbout
            // 
            this.panelAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(147)))));
            this.panelAbout.Controls.Add(this.btnAbout);
            resources.ApplyResources(this.panelAbout, "panelAbout");
            this.panelAbout.Name = "panelAbout";
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.btnAbout, "btnAbout");
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.tab_Click);
            // 
            // panelPatcher
            // 
            this.panelPatcher.BackColor = System.Drawing.Color.Cyan;
            this.panelPatcher.Controls.Add(this.btnPatcher);
            resources.ApplyResources(this.panelPatcher, "panelPatcher");
            this.panelPatcher.Name = "panelPatcher";
            // 
            // btnPatcher
            // 
            this.btnPatcher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.btnPatcher, "btnPatcher");
            this.btnPatcher.FlatAppearance.BorderSize = 0;
            this.btnPatcher.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPatcher.Name = "btnPatcher";
            this.btnPatcher.UseVisualStyleBackColor = false;
            this.btnPatcher.Click += new System.EventHandler(this.tab_Click);
            // 
            // panelTools
            // 
            this.panelTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(147)))));
            this.panelTools.Controls.Add(this.btnTools);
            resources.ApplyResources(this.panelTools, "panelTools");
            this.panelTools.Name = "panelTools";
            // 
            // btnTools
            // 
            this.btnTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.btnTools, "btnTools");
            this.btnTools.FlatAppearance.BorderSize = 0;
            this.btnTools.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTools.Name = "btnTools";
            this.btnTools.UseVisualStyleBackColor = false;
            this.btnTools.Click += new System.EventHandler(this.tab_Click);
            // 
            // panelContent
            // 
            resources.ApplyResources(this.panelContent, "panelContent");
            this.panelContent.Name = "panelContent";
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(147)))));
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelAbout.ResumeLayout(false);
            this.panelPatcher.ResumeLayout(false);
            this.panelTools.ResumeLayout(false);
            this.ResumeLayout(false);

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