namespace OpusTool
{
    partial class CustomInputBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomInputBox));
            this.languageListOriginal = new System.Windows.Forms.ListBox();
            this.labelOriginalLanguage = new System.Windows.Forms.Label();
            this.textBoxLanguage = new System.Windows.Forms.TextBox();
            this.labelCommentLanguage = new System.Windows.Forms.Label();
            this.languageListComment = new System.Windows.Forms.ListBox();
            this.labelCodeLanguage = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.labelProjectID = new System.Windows.Forms.Label();
            this.textBoxProjectID = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // languageListOriginal
            // 
            this.languageListOriginal.FormattingEnabled = true;
            this.languageListOriginal.ItemHeight = 15;
            this.languageListOriginal.Items.AddRange(new object[] {
            "Chino (Taiwanés)",
            "Inglés",
            "Japonés",
            "Chino Simplificado",
            "Japonés (Switch)",
            "Coreano"});
            this.languageListOriginal.Location = new System.Drawing.Point(12, 27);
            this.languageListOriginal.Name = "languageListOriginal";
            this.languageListOriginal.Size = new System.Drawing.Size(271, 94);
            this.languageListOriginal.TabIndex = 0;
            // 
            // labelOriginalLanguage
            // 
            this.labelOriginalLanguage.AutoSize = true;
            this.labelOriginalLanguage.Location = new System.Drawing.Point(12, 9);
            this.labelOriginalLanguage.Name = "labelOriginalLanguage";
            this.labelOriginalLanguage.Size = new System.Drawing.Size(242, 15);
            this.labelOriginalLanguage.TabIndex = 1;
            this.labelOriginalLanguage.Text = "Selecciona el idioma del que quieres traducir";
            // 
            // textBoxLanguage
            // 
            this.textBoxLanguage.Location = new System.Drawing.Point(89, 392);
            this.textBoxLanguage.MaxLength = 8;
            this.textBoxLanguage.Name = "textBoxLanguage";
            this.textBoxLanguage.Size = new System.Drawing.Size(100, 23);
            this.textBoxLanguage.TabIndex = 2;
            this.textBoxLanguage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCommentLanguage
            // 
            this.labelCommentLanguage.AutoEllipsis = true;
            this.labelCommentLanguage.Location = new System.Drawing.Point(12, 124);
            this.labelCommentLanguage.Name = "labelCommentLanguage";
            this.labelCommentLanguage.Size = new System.Drawing.Size(271, 14);
            this.labelCommentLanguage.TabIndex = 4;
            this.labelCommentLanguage.Text = "Selecciona el idioma del que quieres traducir";
            // 
            // languageListComment
            // 
            this.languageListComment.FormattingEnabled = true;
            this.languageListComment.ItemHeight = 15;
            this.languageListComment.Items.AddRange(new object[] {
            "Chino (Taiwanés)",
            "Inglés",
            "Japonés",
            "Chino Simplificado",
            "Japonés (Switch)",
            "Coreano"});
            this.languageListComment.Location = new System.Drawing.Point(12, 150);
            this.languageListComment.Name = "languageListComment";
            this.languageListComment.Size = new System.Drawing.Size(271, 109);
            this.languageListComment.TabIndex = 3;
            // 
            // labelCodeLanguage
            // 
            this.labelCodeLanguage.Location = new System.Drawing.Point(4, 374);
            this.labelCodeLanguage.Name = "labelCodeLanguage";
            this.labelCodeLanguage.Size = new System.Drawing.Size(289, 15);
            this.labelCodeLanguage.TabIndex = 5;
            this.labelCodeLanguage.Text = "label1";
            this.labelCodeLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(4, 425);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "btnAccept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // labelProjectID
            // 
            this.labelProjectID.Location = new System.Drawing.Point(4, 262);
            this.labelProjectID.Name = "labelProjectID";
            this.labelProjectID.Size = new System.Drawing.Size(289, 15);
            this.labelProjectID.TabIndex = 8;
            this.labelProjectID.Text = "label1";
            this.labelProjectID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxProjectID
            // 
            this.textBoxProjectID.Location = new System.Drawing.Point(42, 280);
            this.textBoxProjectID.MaxLength = 8;
            this.textBoxProjectID.Name = "textBoxProjectID";
            this.textBoxProjectID.Size = new System.Drawing.Size(203, 23);
            this.textBoxProjectID.TabIndex = 7;
            this.textBoxProjectID.Text = "Opus: Rocket of Whispers";
            this.textBoxProjectID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelEmail
            // 
            this.labelEmail.Location = new System.Drawing.Point(4, 321);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(279, 15);
            this.labelEmail.TabIndex = 10;
            this.labelEmail.Text = "label2";
            this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(42, 339);
            this.textBoxEmail.MaxLength = 8;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(203, 23);
            this.textBoxEmail.TabIndex = 9;
            this.textBoxEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(218, 425);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // CustomInputBox
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(295, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelProjectID);
            this.Controls.Add(this.textBoxProjectID);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.labelCodeLanguage);
            this.Controls.Add(this.labelCommentLanguage);
            this.Controls.Add(this.languageListComment);
            this.Controls.Add(this.textBoxLanguage);
            this.Controls.Add(this.labelOriginalLanguage);
            this.Controls.Add(this.languageListOriginal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomInputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CustomInputBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox languageListOriginal;
        private Label labelOriginalLanguage;
        private TextBox textBoxLanguage;
        private Label labelCommentLanguage;
        private ListBox languageListComment;
        private Label labelCodeLanguage;
        private Button btnAccept;
        private Label labelProjectID;
        private TextBox textBoxProjectID;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Button btnCancel;
    }
}