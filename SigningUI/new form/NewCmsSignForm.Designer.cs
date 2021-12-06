
namespace SigningUI.new_form
{
    partial class NewCmsSignForm
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
            this.pfxFileLabel = new System.Windows.Forms.Label();
            this.pfxFileTextbox = new System.Windows.Forms.TextBox();
            this.pfxPwdLabel = new System.Windows.Forms.Label();
            this.pfxPwdTextbox = new System.Windows.Forms.TextBox();
            this.outputFilesListView = new System.Windows.Forms.ListView();
            this.IDColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loadPfxButton = new System.Windows.Forms.Button();
            this.pfxVersionLabel = new System.Windows.Forms.Label();
            this.pfxIssuerLabel = new System.Windows.Forms.Label();
            this.pfxValidFromLabel = new System.Windows.Forms.Label();
            this.pfxExpireLabel = new System.Windows.Forms.Label();
            this.pfxSerialNumberLabel = new System.Windows.Forms.Label();
            this.pfxThumbprintLabel = new System.Windows.Forms.Label();
            this.pfxSignatureAlgoLabel = new System.Windows.Forms.Label();
            this.cmsSignButton = new System.Windows.Forms.Button();
            this.outputFolderLabel = new System.Windows.Forms.Label();
            this.outputFolderTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pfxFileLabel
            // 
            this.pfxFileLabel.AutoSize = true;
            this.pfxFileLabel.Location = new System.Drawing.Point(13, 17);
            this.pfxFileLabel.Name = "pfxFileLabel";
            this.pfxFileLabel.Size = new System.Drawing.Size(73, 13);
            this.pfxFileLabel.TabIndex = 0;
            this.pfxFileLabel.Text = "PKCS#12 file:";
            // 
            // pfxFileTextbox
            // 
            this.pfxFileTextbox.Location = new System.Drawing.Point(93, 13);
            this.pfxFileTextbox.Name = "pfxFileTextbox";
            this.pfxFileTextbox.Size = new System.Drawing.Size(695, 20);
            this.pfxFileTextbox.TabIndex = 1;
            this.pfxFileTextbox.DoubleClick += new System.EventHandler(this.pfxFileTextbox_DoubleClick);
            // 
            // pfxPwdLabel
            // 
            this.pfxPwdLabel.AutoSize = true;
            this.pfxPwdLabel.Location = new System.Drawing.Point(13, 51);
            this.pfxPwdLabel.Name = "pfxPwdLabel";
            this.pfxPwdLabel.Size = new System.Drawing.Size(73, 13);
            this.pfxPwdLabel.TabIndex = 2;
            this.pfxPwdLabel.Text = "Pfx password:";
            // 
            // pfxPwdTextbox
            // 
            this.pfxPwdTextbox.Location = new System.Drawing.Point(93, 46);
            this.pfxPwdTextbox.Name = "pfxPwdTextbox";
            this.pfxPwdTextbox.Size = new System.Drawing.Size(115, 20);
            this.pfxPwdTextbox.TabIndex = 3;
            // 
            // outputFilesListView
            // 
            this.outputFilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDColumn,
            this.NameColumn});
            this.outputFilesListView.FullRowSelect = true;
            this.outputFilesListView.HideSelection = false;
            this.outputFilesListView.Location = new System.Drawing.Point(13, 285);
            this.outputFilesListView.Name = "outputFilesListView";
            this.outputFilesListView.ShowItemToolTips = true;
            this.outputFilesListView.Size = new System.Drawing.Size(775, 299);
            this.outputFilesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.outputFilesListView.TabIndex = 4;
            this.outputFilesListView.UseCompatibleStateImageBehavior = false;
            this.outputFilesListView.View = System.Windows.Forms.View.Details;
            // 
            // IDColumn
            // 
            this.IDColumn.Text = "ID";
            this.IDColumn.Width = 26;
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NameColumn.Width = 680;
            // 
            // loadPfxButton
            // 
            this.loadPfxButton.Location = new System.Drawing.Point(225, 45);
            this.loadPfxButton.Name = "loadPfxButton";
            this.loadPfxButton.Size = new System.Drawing.Size(75, 23);
            this.loadPfxButton.TabIndex = 5;
            this.loadPfxButton.Text = "Load";
            this.loadPfxButton.UseVisualStyleBackColor = true;
            this.loadPfxButton.Click += new System.EventHandler(this.loadPfxButton_Click);
            // 
            // pfxVersionLabel
            // 
            this.pfxVersionLabel.AutoSize = true;
            this.pfxVersionLabel.Location = new System.Drawing.Point(13, 85);
            this.pfxVersionLabel.Name = "pfxVersionLabel";
            this.pfxVersionLabel.Size = new System.Drawing.Size(105, 13);
            this.pfxVersionLabel.TabIndex = 6;
            this.pfxVersionLabel.Text = "Version: {##data##}";
            // 
            // pfxIssuerLabel
            // 
            this.pfxIssuerLabel.AutoSize = true;
            this.pfxIssuerLabel.Location = new System.Drawing.Point(13, 119);
            this.pfxIssuerLabel.Name = "pfxIssuerLabel";
            this.pfxIssuerLabel.Size = new System.Drawing.Size(98, 13);
            this.pfxIssuerLabel.TabIndex = 7;
            this.pfxIssuerLabel.Text = "Issuer: {##data##}";
            // 
            // pfxValidFromLabel
            // 
            this.pfxValidFromLabel.AutoSize = true;
            this.pfxValidFromLabel.Location = new System.Drawing.Point(515, 85);
            this.pfxValidFromLabel.Name = "pfxValidFromLabel";
            this.pfxValidFromLabel.Size = new System.Drawing.Size(116, 13);
            this.pfxValidFromLabel.TabIndex = 8;
            this.pfxValidFromLabel.Text = "Valid from: {##data##}";
            // 
            // pfxExpireLabel
            // 
            this.pfxExpireLabel.AutoSize = true;
            this.pfxExpireLabel.Location = new System.Drawing.Point(515, 119);
            this.pfxExpireLabel.Name = "pfxExpireLabel";
            this.pfxExpireLabel.Size = new System.Drawing.Size(111, 13);
            this.pfxExpireLabel.TabIndex = 9;
            this.pfxExpireLabel.Text = "Expire to: {##data##}";
            // 
            // pfxSerialNumberLabel
            // 
            this.pfxSerialNumberLabel.AutoSize = true;
            this.pfxSerialNumberLabel.Location = new System.Drawing.Point(13, 153);
            this.pfxSerialNumberLabel.Name = "pfxSerialNumberLabel";
            this.pfxSerialNumberLabel.Size = new System.Drawing.Size(134, 13);
            this.pfxSerialNumberLabel.TabIndex = 10;
            this.pfxSerialNumberLabel.Text = "Serial number: {##data##}";
            // 
            // pfxThumbprintLabel
            // 
            this.pfxThumbprintLabel.AutoSize = true;
            this.pfxThumbprintLabel.Location = new System.Drawing.Point(13, 187);
            this.pfxThumbprintLabel.Name = "pfxThumbprintLabel";
            this.pfxThumbprintLabel.Size = new System.Drawing.Size(123, 13);
            this.pfxThumbprintLabel.TabIndex = 11;
            this.pfxThumbprintLabel.Text = "Thumbprint: {##data##}";
            // 
            // pfxSignatureAlgoLabel
            // 
            this.pfxSignatureAlgoLabel.AutoSize = true;
            this.pfxSignatureAlgoLabel.Location = new System.Drawing.Point(13, 221);
            this.pfxSignatureAlgoLabel.Name = "pfxSignatureAlgoLabel";
            this.pfxSignatureAlgoLabel.Size = new System.Drawing.Size(160, 13);
            this.pfxSignatureAlgoLabel.TabIndex = 12;
            this.pfxSignatureAlgoLabel.Text = "Signature algorithm: {##data##}";
            // 
            // cmsSignButton
            // 
            this.cmsSignButton.Location = new System.Drawing.Point(385, 590);
            this.cmsSignButton.Name = "cmsSignButton";
            this.cmsSignButton.Size = new System.Drawing.Size(75, 23);
            this.cmsSignButton.TabIndex = 13;
            this.cmsSignButton.Text = "Sign";
            this.cmsSignButton.UseVisualStyleBackColor = true;
            this.cmsSignButton.Click += new System.EventHandler(this.cmsSignButton_Click);
            // 
            // outputFolderLabel
            // 
            this.outputFolderLabel.AutoSize = true;
            this.outputFolderLabel.Location = new System.Drawing.Point(16, 251);
            this.outputFolderLabel.Name = "outputFolderLabel";
            this.outputFolderLabel.Size = new System.Drawing.Size(71, 13);
            this.outputFolderLabel.TabIndex = 14;
            this.outputFolderLabel.Text = "Output folder:";
            // 
            // outputFolderTextbox
            // 
            this.outputFolderTextbox.Location = new System.Drawing.Point(93, 251);
            this.outputFolderTextbox.Name = "outputFolderTextbox";
            this.outputFolderTextbox.Size = new System.Drawing.Size(695, 20);
            this.outputFolderTextbox.TabIndex = 15;
            this.outputFolderTextbox.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // NewCmsSignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 656);
            this.Controls.Add(this.outputFolderTextbox);
            this.Controls.Add(this.outputFolderLabel);
            this.Controls.Add(this.cmsSignButton);
            this.Controls.Add(this.pfxSignatureAlgoLabel);
            this.Controls.Add(this.pfxThumbprintLabel);
            this.Controls.Add(this.pfxSerialNumberLabel);
            this.Controls.Add(this.pfxExpireLabel);
            this.Controls.Add(this.pfxValidFromLabel);
            this.Controls.Add(this.pfxIssuerLabel);
            this.Controls.Add(this.pfxVersionLabel);
            this.Controls.Add(this.loadPfxButton);
            this.Controls.Add(this.outputFilesListView);
            this.Controls.Add(this.pfxPwdTextbox);
            this.Controls.Add(this.pfxPwdLabel);
            this.Controls.Add(this.pfxFileTextbox);
            this.Controls.Add(this.pfxFileLabel);
            this.Name = "NewCmsSignForm";
            this.Text = "NewCmsSignForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pfxFileLabel;
        private System.Windows.Forms.TextBox pfxFileTextbox;
        private System.Windows.Forms.Label pfxPwdLabel;
        private System.Windows.Forms.TextBox pfxPwdTextbox;
        private System.Windows.Forms.ListView outputFilesListView;
        private System.Windows.Forms.ColumnHeader IDColumn;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.Button loadPfxButton;
        private System.Windows.Forms.Label pfxVersionLabel;
        private System.Windows.Forms.Label pfxIssuerLabel;
        private System.Windows.Forms.Label pfxValidFromLabel;
        private System.Windows.Forms.Label pfxExpireLabel;
        private System.Windows.Forms.Label pfxSerialNumberLabel;
        private System.Windows.Forms.Label pfxThumbprintLabel;
        private System.Windows.Forms.Label pfxSignatureAlgoLabel;
        private System.Windows.Forms.Button cmsSignButton;
        private System.Windows.Forms.Label outputFolderLabel;
        private System.Windows.Forms.TextBox outputFolderTextbox;
    }
}