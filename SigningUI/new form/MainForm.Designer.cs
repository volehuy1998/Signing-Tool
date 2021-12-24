
namespace SigningUI.new_form
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.inputFileListview = new System.Windows.Forms.ListView();
            this.IdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResultColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cryptPage = new System.Windows.Forms.TabPage();
            this.decryptButton = new System.Windows.Forms.Button();
            this.encryptOutputButton = new System.Windows.Forms.Button();
            this.cryptOutputTextbox = new System.Windows.Forms.TextBox();
            this.encryptOutputLabel = new System.Windows.Forms.Label();
            this.encryptButton = new System.Windows.Forms.Button();
            this.keySizeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordAesTextbox = new System.Windows.Forms.TextBox();
            this.passwordAesLabel = new System.Windows.Forms.Label();
            this.verifyPage = new System.Windows.Forms.TabPage();
            this.cmsVerifyButton = new System.Windows.Forms.Button();
            this.cmsVerifyPfxSignatureAlgoLabel = new System.Windows.Forms.Label();
            this.cmsVerifyPfxThumbprintLabel = new System.Windows.Forms.Label();
            this.cmsVerifyPfxSerialNumberLabel = new System.Windows.Forms.Label();
            this.cmsVerifyPfxExpireLabel = new System.Windows.Forms.Label();
            this.cmsVerifyPfxValidFromLabel = new System.Windows.Forms.Label();
            this.cmsVerifyPfxIssuerLabel = new System.Windows.Forms.Label();
            this.cmsVerifyPfxVersionLabel = new System.Windows.Forms.Label();
            this.cmsMicrosoftCertSelectButton = new System.Windows.Forms.Button();
            this.verifyMicrosoftCertThumbprintTextbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.signPage = new System.Windows.Forms.TabPage();
            this.cmsSignButton = new System.Windows.Forms.Button();
            this.pfxSignatureAlgoLabel = new System.Windows.Forms.Label();
            this.pfxThumbprintLabel = new System.Windows.Forms.Label();
            this.pfxSerialNumberLabel = new System.Windows.Forms.Label();
            this.pfxExpireLabel = new System.Windows.Forms.Label();
            this.pfxValidFromLabel = new System.Windows.Forms.Label();
            this.pfxIssuerLabel = new System.Windows.Forms.Label();
            this.pfxVersionLabel = new System.Windows.Forms.Label();
            this.openOutputFolderButton = new System.Windows.Forms.Button();
            this.outputFolderTextbox = new System.Windows.Forms.TextBox();
            this.pfxFileTextbox = new System.Windows.Forms.TextBox();
            this.outputFolderLabel = new System.Windows.Forms.Label();
            this.pfxPasswordTextbox = new System.Windows.Forms.TextBox();
            this.pfxButton = new System.Windows.Forms.Button();
            this.pfxPasswordLabel = new System.Windows.Forms.Label();
            this.pfxFileLabel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.menuStrip.SuspendLayout();
            this.cryptPage.SuspendLayout();
            this.verifyPage.SuspendLayout();
            this.signPage.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputFileListview
            // 
            this.inputFileListview.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.inputFileListview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFileListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdColumn,
            this.FileColumn,
            this.ResultColumn});
            this.inputFileListview.FullRowSelect = true;
            this.inputFileListview.HideSelection = false;
            this.inputFileListview.Location = new System.Drawing.Point(13, 27);
            this.inputFileListview.Name = "inputFileListview";
            this.inputFileListview.ShowItemToolTips = true;
            this.inputFileListview.Size = new System.Drawing.Size(838, 189);
            this.inputFileListview.TabIndex = 21;
            this.inputFileListview.UseCompatibleStateImageBehavior = false;
            this.inputFileListview.View = System.Windows.Forms.View.Details;
            this.inputFileListview.DoubleClick += new System.EventHandler(this.inputFileListview_DoubleClick);
            // 
            // IdColumn
            // 
            this.IdColumn.Text = "ID";
            this.IdColumn.Width = 39;
            // 
            // FileColumn
            // 
            this.FileColumn.Text = "File";
            this.FileColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FileColumn.Width = 734;
            // 
            // ResultColumn
            // 
            this.ResultColumn.Text = "Result";
            this.ResultColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ResultColumn.Width = 58;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(863, 24);
            this.menuStrip.TabIndex = 22;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click_1);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMSToolStripMenuItem,
            this.xMLToolStripMenuItem,
            this.jSONToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // cMSToolStripMenuItem
            // 
            this.cMSToolStripMenuItem.Checked = true;
            this.cMSToolStripMenuItem.CheckOnClick = true;
            this.cMSToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cMSToolStripMenuItem.Name = "cMSToolStripMenuItem";
            this.cMSToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.cMSToolStripMenuItem.Text = "CMS";
            this.cMSToolStripMenuItem.Click += new System.EventHandler(this.cMSToolStripMenuItem_Click);
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.CheckOnClick = true;
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.xMLToolStripMenuItem.Text = "XML";
            this.xMLToolStripMenuItem.Click += new System.EventHandler(this.xMLToolStripMenuItem_Click);
            // 
            // jSONToolStripMenuItem
            // 
            this.jSONToolStripMenuItem.CheckOnClick = true;
            this.jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            this.jSONToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.jSONToolStripMenuItem.Text = "JSON";
            this.jSONToolStripMenuItem.Click += new System.EventHandler(this.jSONToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // cryptPage
            // 
            this.cryptPage.Controls.Add(this.decryptButton);
            this.cryptPage.Controls.Add(this.encryptOutputButton);
            this.cryptPage.Controls.Add(this.cryptOutputTextbox);
            this.cryptPage.Controls.Add(this.encryptOutputLabel);
            this.cryptPage.Controls.Add(this.encryptButton);
            this.cryptPage.Controls.Add(this.keySizeComboBox);
            this.cryptPage.Controls.Add(this.label2);
            this.cryptPage.Controls.Add(this.passwordAesTextbox);
            this.cryptPage.Controls.Add(this.passwordAesLabel);
            this.cryptPage.Location = new System.Drawing.Point(4, 22);
            this.cryptPage.Name = "cryptPage";
            this.cryptPage.Padding = new System.Windows.Forms.Padding(3);
            this.cryptPage.Size = new System.Drawing.Size(830, 415);
            this.cryptPage.TabIndex = 2;
            this.cryptPage.Text = "Crypt";
            this.cryptPage.UseVisualStyleBackColor = true;
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(459, 196);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(75, 23);
            this.decryptButton.TabIndex = 49;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // encryptOutputButton
            // 
            this.encryptOutputButton.Location = new System.Drawing.Point(740, 103);
            this.encryptOutputButton.Name = "encryptOutputButton";
            this.encryptOutputButton.Size = new System.Drawing.Size(75, 23);
            this.encryptOutputButton.TabIndex = 48;
            this.encryptOutputButton.Text = "Open folder";
            this.encryptOutputButton.UseVisualStyleBackColor = true;
            this.encryptOutputButton.Click += new System.EventHandler(this.cryptOutputButton_Click);
            // 
            // cryptOutputTextbox
            // 
            this.cryptOutputTextbox.Location = new System.Drawing.Point(138, 104);
            this.cryptOutputTextbox.Name = "cryptOutputTextbox";
            this.cryptOutputTextbox.Size = new System.Drawing.Size(596, 20);
            this.cryptOutputTextbox.TabIndex = 47;
            this.cryptOutputTextbox.Text = "C:\\Users\\voleh\\Desktop";
            this.cryptOutputTextbox.DoubleClick += new System.EventHandler(this.cryptOutputTextbox_DoubleClick);
            // 
            // encryptOutputLabel
            // 
            this.encryptOutputLabel.AutoSize = true;
            this.encryptOutputLabel.Location = new System.Drawing.Point(51, 108);
            this.encryptOutputLabel.Name = "encryptOutputLabel";
            this.encryptOutputLabel.Size = new System.Drawing.Size(71, 13);
            this.encryptOutputLabel.TabIndex = 46;
            this.encryptOutputLabel.Text = "Output folder:";
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(378, 196);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(75, 23);
            this.encryptButton.TabIndex = 45;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // keySizeComboBox
            // 
            this.keySizeComboBox.FormattingEnabled = true;
            this.keySizeComboBox.Items.AddRange(new object[] {
            "128",
            "256"});
            this.keySizeComboBox.Location = new System.Drawing.Point(138, 52);
            this.keySizeComboBox.Name = "keySizeComboBox";
            this.keySizeComboBox.Size = new System.Drawing.Size(121, 21);
            this.keySizeComboBox.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "AES key size:";
            // 
            // passwordAesTextbox
            // 
            this.passwordAesTextbox.Location = new System.Drawing.Point(138, 6);
            this.passwordAesTextbox.Name = "passwordAesTextbox";
            this.passwordAesTextbox.Size = new System.Drawing.Size(351, 20);
            this.passwordAesTextbox.TabIndex = 42;
            this.passwordAesTextbox.Text = "~Default password~";
            this.passwordAesTextbox.DoubleClick += new System.EventHandler(this.passwordAesTextbox_DoubleClick);
            // 
            // passwordAesLabel
            // 
            this.passwordAesLabel.AutoSize = true;
            this.passwordAesLabel.Location = new System.Drawing.Point(63, 10);
            this.passwordAesLabel.Name = "passwordAesLabel";
            this.passwordAesLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordAesLabel.TabIndex = 41;
            this.passwordAesLabel.Text = "Password:";
            // 
            // verifyPage
            // 
            this.verifyPage.Controls.Add(this.cmsVerifyButton);
            this.verifyPage.Controls.Add(this.cmsVerifyPfxSignatureAlgoLabel);
            this.verifyPage.Controls.Add(this.cmsVerifyPfxThumbprintLabel);
            this.verifyPage.Controls.Add(this.cmsVerifyPfxSerialNumberLabel);
            this.verifyPage.Controls.Add(this.cmsVerifyPfxExpireLabel);
            this.verifyPage.Controls.Add(this.cmsVerifyPfxValidFromLabel);
            this.verifyPage.Controls.Add(this.cmsVerifyPfxIssuerLabel);
            this.verifyPage.Controls.Add(this.cmsVerifyPfxVersionLabel);
            this.verifyPage.Controls.Add(this.cmsMicrosoftCertSelectButton);
            this.verifyPage.Controls.Add(this.verifyMicrosoftCertThumbprintTextbox);
            this.verifyPage.Controls.Add(this.label10);
            this.verifyPage.Location = new System.Drawing.Point(4, 22);
            this.verifyPage.Name = "verifyPage";
            this.verifyPage.Padding = new System.Windows.Forms.Padding(3);
            this.verifyPage.Size = new System.Drawing.Size(830, 415);
            this.verifyPage.TabIndex = 1;
            this.verifyPage.Text = "Verify";
            this.verifyPage.UseVisualStyleBackColor = true;
            // 
            // cmsVerifyButton
            // 
            this.cmsVerifyButton.Location = new System.Drawing.Point(405, 386);
            this.cmsVerifyButton.Name = "cmsVerifyButton";
            this.cmsVerifyButton.Size = new System.Drawing.Size(75, 23);
            this.cmsVerifyButton.TabIndex = 42;
            this.cmsVerifyButton.Text = "Verify";
            this.cmsVerifyButton.UseVisualStyleBackColor = true;
            this.cmsVerifyButton.Click += new System.EventHandler(this.verifyButton_Click);
            // 
            // cmsVerifyPfxSignatureAlgoLabel
            // 
            this.cmsVerifyPfxSignatureAlgoLabel.AutoSize = true;
            this.cmsVerifyPfxSignatureAlgoLabel.Location = new System.Drawing.Point(19, 195);
            this.cmsVerifyPfxSignatureAlgoLabel.Name = "cmsVerifyPfxSignatureAlgoLabel";
            this.cmsVerifyPfxSignatureAlgoLabel.Size = new System.Drawing.Size(164, 13);
            this.cmsVerifyPfxSignatureAlgoLabel.TabIndex = 41;
            this.cmsVerifyPfxSignatureAlgoLabel.Text = "Signature algorithm:      Unknown";
            // 
            // cmsVerifyPfxThumbprintLabel
            // 
            this.cmsVerifyPfxThumbprintLabel.AutoSize = true;
            this.cmsVerifyPfxThumbprintLabel.Location = new System.Drawing.Point(56, 158);
            this.cmsVerifyPfxThumbprintLabel.Name = "cmsVerifyPfxThumbprintLabel";
            this.cmsVerifyPfxThumbprintLabel.Size = new System.Drawing.Size(127, 13);
            this.cmsVerifyPfxThumbprintLabel.TabIndex = 40;
            this.cmsVerifyPfxThumbprintLabel.Text = "Thumbprint:      Unknown";
            // 
            // cmsVerifyPfxSerialNumberLabel
            // 
            this.cmsVerifyPfxSerialNumberLabel.AutoSize = true;
            this.cmsVerifyPfxSerialNumberLabel.Location = new System.Drawing.Point(45, 121);
            this.cmsVerifyPfxSerialNumberLabel.Name = "cmsVerifyPfxSerialNumberLabel";
            this.cmsVerifyPfxSerialNumberLabel.Size = new System.Drawing.Size(138, 13);
            this.cmsVerifyPfxSerialNumberLabel.TabIndex = 39;
            this.cmsVerifyPfxSerialNumberLabel.Text = "Serial number:      Unknown";
            // 
            // cmsVerifyPfxExpireLabel
            // 
            this.cmsVerifyPfxExpireLabel.AutoSize = true;
            this.cmsVerifyPfxExpireLabel.Location = new System.Drawing.Point(67, 269);
            this.cmsVerifyPfxExpireLabel.Name = "cmsVerifyPfxExpireLabel";
            this.cmsVerifyPfxExpireLabel.Size = new System.Drawing.Size(115, 13);
            this.cmsVerifyPfxExpireLabel.TabIndex = 38;
            this.cmsVerifyPfxExpireLabel.Text = "Expire to:      Unknown";
            // 
            // cmsVerifyPfxValidFromLabel
            // 
            this.cmsVerifyPfxValidFromLabel.AutoSize = true;
            this.cmsVerifyPfxValidFromLabel.Location = new System.Drawing.Point(63, 232);
            this.cmsVerifyPfxValidFromLabel.Name = "cmsVerifyPfxValidFromLabel";
            this.cmsVerifyPfxValidFromLabel.Size = new System.Drawing.Size(120, 13);
            this.cmsVerifyPfxValidFromLabel.TabIndex = 37;
            this.cmsVerifyPfxValidFromLabel.Text = "Valid from:      Unknown";
            // 
            // cmsVerifyPfxIssuerLabel
            // 
            this.cmsVerifyPfxIssuerLabel.AutoSize = true;
            this.cmsVerifyPfxIssuerLabel.Location = new System.Drawing.Point(81, 84);
            this.cmsVerifyPfxIssuerLabel.Name = "cmsVerifyPfxIssuerLabel";
            this.cmsVerifyPfxIssuerLabel.Size = new System.Drawing.Size(102, 13);
            this.cmsVerifyPfxIssuerLabel.TabIndex = 36;
            this.cmsVerifyPfxIssuerLabel.Text = "Issuer:      Unknown";
            // 
            // cmsVerifyPfxVersionLabel
            // 
            this.cmsVerifyPfxVersionLabel.AutoSize = true;
            this.cmsVerifyPfxVersionLabel.Location = new System.Drawing.Point(74, 47);
            this.cmsVerifyPfxVersionLabel.Name = "cmsVerifyPfxVersionLabel";
            this.cmsVerifyPfxVersionLabel.Size = new System.Drawing.Size(109, 13);
            this.cmsVerifyPfxVersionLabel.TabIndex = 35;
            this.cmsVerifyPfxVersionLabel.Text = "Version:      Unknown";
            // 
            // cmsMicrosoftCertSelectButton
            // 
            this.cmsMicrosoftCertSelectButton.Location = new System.Drawing.Point(737, 4);
            this.cmsMicrosoftCertSelectButton.Name = "cmsMicrosoftCertSelectButton";
            this.cmsMicrosoftCertSelectButton.Size = new System.Drawing.Size(75, 23);
            this.cmsMicrosoftCertSelectButton.TabIndex = 30;
            this.cmsMicrosoftCertSelectButton.Text = "Select ...";
            this.cmsMicrosoftCertSelectButton.UseVisualStyleBackColor = true;
            this.cmsMicrosoftCertSelectButton.Click += new System.EventHandler(this.cmsMicrosoftCertSelectButton_Click);
            // 
            // verifyMicrosoftCertThumbprintTextbox
            // 
            this.verifyMicrosoftCertThumbprintTextbox.Location = new System.Drawing.Point(135, 6);
            this.verifyMicrosoftCertThumbprintTextbox.Name = "verifyMicrosoftCertThumbprintTextbox";
            this.verifyMicrosoftCertThumbprintTextbox.Size = new System.Drawing.Size(596, 20);
            this.verifyMicrosoftCertThumbprintTextbox.TabIndex = 28;
            this.verifyMicrosoftCertThumbprintTextbox.DoubleClick += new System.EventHandler(this.cmsMicrosoftCertThumbprintTextbox_DoubleClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(65, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Key store:";
            // 
            // signPage
            // 
            this.signPage.Controls.Add(this.cmsSignButton);
            this.signPage.Controls.Add(this.pfxSignatureAlgoLabel);
            this.signPage.Controls.Add(this.pfxThumbprintLabel);
            this.signPage.Controls.Add(this.pfxSerialNumberLabel);
            this.signPage.Controls.Add(this.pfxExpireLabel);
            this.signPage.Controls.Add(this.pfxValidFromLabel);
            this.signPage.Controls.Add(this.pfxIssuerLabel);
            this.signPage.Controls.Add(this.pfxVersionLabel);
            this.signPage.Controls.Add(this.openOutputFolderButton);
            this.signPage.Controls.Add(this.outputFolderTextbox);
            this.signPage.Controls.Add(this.pfxFileTextbox);
            this.signPage.Controls.Add(this.outputFolderLabel);
            this.signPage.Controls.Add(this.pfxPasswordTextbox);
            this.signPage.Controls.Add(this.pfxButton);
            this.signPage.Controls.Add(this.pfxPasswordLabel);
            this.signPage.Controls.Add(this.pfxFileLabel);
            this.signPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signPage.Location = new System.Drawing.Point(4, 22);
            this.signPage.Name = "signPage";
            this.signPage.Padding = new System.Windows.Forms.Padding(3);
            this.signPage.Size = new System.Drawing.Size(830, 415);
            this.signPage.TabIndex = 0;
            this.signPage.Text = "Sign";
            this.signPage.ToolTipText = "Sign page (CMS, XML, JSON)";
            this.signPage.UseVisualStyleBackColor = true;
            // 
            // cmsSignButton
            // 
            this.cmsSignButton.Location = new System.Drawing.Point(405, 386);
            this.cmsSignButton.Name = "cmsSignButton";
            this.cmsSignButton.Size = new System.Drawing.Size(75, 23);
            this.cmsSignButton.TabIndex = 26;
            this.cmsSignButton.Text = "Sign";
            this.cmsSignButton.UseVisualStyleBackColor = true;
            this.cmsSignButton.Click += new System.EventHandler(this.signButton_Click);
            // 
            // pfxSignatureAlgoLabel
            // 
            this.pfxSignatureAlgoLabel.AutoSize = true;
            this.pfxSignatureAlgoLabel.Location = new System.Drawing.Point(19, 269);
            this.pfxSignatureAlgoLabel.Name = "pfxSignatureAlgoLabel";
            this.pfxSignatureAlgoLabel.Size = new System.Drawing.Size(164, 13);
            this.pfxSignatureAlgoLabel.TabIndex = 25;
            this.pfxSignatureAlgoLabel.Text = "Signature algorithm:      Unknown";
            // 
            // pfxThumbprintLabel
            // 
            this.pfxThumbprintLabel.AutoSize = true;
            this.pfxThumbprintLabel.Location = new System.Drawing.Point(56, 232);
            this.pfxThumbprintLabel.Name = "pfxThumbprintLabel";
            this.pfxThumbprintLabel.Size = new System.Drawing.Size(127, 13);
            this.pfxThumbprintLabel.TabIndex = 24;
            this.pfxThumbprintLabel.Text = "Thumbprint:      Unknown";
            // 
            // pfxSerialNumberLabel
            // 
            this.pfxSerialNumberLabel.AutoSize = true;
            this.pfxSerialNumberLabel.Location = new System.Drawing.Point(45, 195);
            this.pfxSerialNumberLabel.Name = "pfxSerialNumberLabel";
            this.pfxSerialNumberLabel.Size = new System.Drawing.Size(138, 13);
            this.pfxSerialNumberLabel.TabIndex = 23;
            this.pfxSerialNumberLabel.Text = "Serial number:      Unknown";
            // 
            // pfxExpireLabel
            // 
            this.pfxExpireLabel.AutoSize = true;
            this.pfxExpireLabel.Location = new System.Drawing.Point(65, 343);
            this.pfxExpireLabel.Name = "pfxExpireLabel";
            this.pfxExpireLabel.Size = new System.Drawing.Size(115, 13);
            this.pfxExpireLabel.TabIndex = 22;
            this.pfxExpireLabel.Text = "Expire to:      Unknown";
            // 
            // pfxValidFromLabel
            // 
            this.pfxValidFromLabel.AutoSize = true;
            this.pfxValidFromLabel.Location = new System.Drawing.Point(63, 306);
            this.pfxValidFromLabel.Name = "pfxValidFromLabel";
            this.pfxValidFromLabel.Size = new System.Drawing.Size(120, 13);
            this.pfxValidFromLabel.TabIndex = 21;
            this.pfxValidFromLabel.Text = "Valid from:      Unknown";
            // 
            // pfxIssuerLabel
            // 
            this.pfxIssuerLabel.AutoSize = true;
            this.pfxIssuerLabel.Location = new System.Drawing.Point(81, 158);
            this.pfxIssuerLabel.Name = "pfxIssuerLabel";
            this.pfxIssuerLabel.Size = new System.Drawing.Size(102, 13);
            this.pfxIssuerLabel.TabIndex = 20;
            this.pfxIssuerLabel.Text = "Issuer:      Unknown";
            // 
            // pfxVersionLabel
            // 
            this.pfxVersionLabel.AutoSize = true;
            this.pfxVersionLabel.Location = new System.Drawing.Point(74, 121);
            this.pfxVersionLabel.Name = "pfxVersionLabel";
            this.pfxVersionLabel.Size = new System.Drawing.Size(109, 13);
            this.pfxVersionLabel.TabIndex = 19;
            this.pfxVersionLabel.Text = "Version:      Unknown";
            // 
            // openOutputFolderButton
            // 
            this.openOutputFolderButton.Location = new System.Drawing.Point(737, 79);
            this.openOutputFolderButton.Name = "openOutputFolderButton";
            this.openOutputFolderButton.Size = new System.Drawing.Size(75, 23);
            this.openOutputFolderButton.TabIndex = 18;
            this.openOutputFolderButton.Text = "Open folder";
            this.openOutputFolderButton.UseVisualStyleBackColor = true;
            this.openOutputFolderButton.Click += new System.EventHandler(this.openOutputFolderButton_Click);
            // 
            // outputFolderTextbox
            // 
            this.outputFolderTextbox.Location = new System.Drawing.Point(135, 80);
            this.outputFolderTextbox.Name = "outputFolderTextbox";
            this.outputFolderTextbox.Size = new System.Drawing.Size(596, 20);
            this.outputFolderTextbox.TabIndex = 17;
            this.outputFolderTextbox.Text = "C:\\Users\\voleh\\Desktop";
            this.outputFolderTextbox.DoubleClick += new System.EventHandler(this.outputFolderTextbox_DoubleClick);
            this.outputFolderTextbox.MouseLeave += new System.EventHandler(this.outputFolderTextbox_MouseLeave);
            this.outputFolderTextbox.MouseHover += new System.EventHandler(this.outputFolderTextbox_MouseHover);
            // 
            // pfxFileTextbox
            // 
            this.pfxFileTextbox.Location = new System.Drawing.Point(135, 6);
            this.pfxFileTextbox.Name = "pfxFileTextbox";
            this.pfxFileTextbox.Size = new System.Drawing.Size(596, 20);
            this.pfxFileTextbox.TabIndex = 12;
            this.pfxFileTextbox.DoubleClick += new System.EventHandler(this.pfxFileTextbox_DoubleClick);
            this.pfxFileTextbox.MouseLeave += new System.EventHandler(this.pfxFileTextbox_MouseLeave);
            this.pfxFileTextbox.MouseHover += new System.EventHandler(this.pfxFileTextbox_MouseHover);
            // 
            // outputFolderLabel
            // 
            this.outputFolderLabel.AutoSize = true;
            this.outputFolderLabel.Location = new System.Drawing.Point(48, 84);
            this.outputFolderLabel.Name = "outputFolderLabel";
            this.outputFolderLabel.Size = new System.Drawing.Size(71, 13);
            this.outputFolderLabel.TabIndex = 16;
            this.outputFolderLabel.Text = "Output folder:";
            this.outputFolderLabel.Click += new System.EventHandler(this.outputFolderLabel_Click);
            this.outputFolderLabel.MouseLeave += new System.EventHandler(this.outputFolderLabel_MouseLeave);
            this.outputFolderLabel.MouseHover += new System.EventHandler(this.outputFolderLabel_MouseHover);
            // 
            // pfxPasswordTextbox
            // 
            this.pfxPasswordTextbox.Location = new System.Drawing.Point(135, 43);
            this.pfxPasswordTextbox.Name = "pfxPasswordTextbox";
            this.pfxPasswordTextbox.ReadOnly = true;
            this.pfxPasswordTextbox.Size = new System.Drawing.Size(100, 20);
            this.pfxPasswordTextbox.TabIndex = 15;
            this.pfxPasswordTextbox.UseSystemPasswordChar = true;
            this.pfxPasswordTextbox.Click += new System.EventHandler(this.pfxPasswordTextbox_Click);
            this.pfxPasswordTextbox.MouseLeave += new System.EventHandler(this.pfxPasswordTextbox_MouseLeave);
            this.pfxPasswordTextbox.MouseHover += new System.EventHandler(this.pfxPasswordTextbox_MouseHover);
            // 
            // pfxButton
            // 
            this.pfxButton.Location = new System.Drawing.Point(737, 4);
            this.pfxButton.Name = "pfxButton";
            this.pfxButton.Size = new System.Drawing.Size(75, 23);
            this.pfxButton.TabIndex = 14;
            this.pfxButton.Text = "Browse ...";
            this.pfxButton.UseVisualStyleBackColor = true;
            this.pfxButton.Click += new System.EventHandler(this.pfxFileButton_Click);
            // 
            // pfxPasswordLabel
            // 
            this.pfxPasswordLabel.AutoSize = true;
            this.pfxPasswordLabel.Location = new System.Drawing.Point(63, 47);
            this.pfxPasswordLabel.Name = "pfxPasswordLabel";
            this.pfxPasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.pfxPasswordLabel.TabIndex = 13;
            this.pfxPasswordLabel.Text = "Password:";
            this.pfxPasswordLabel.Click += new System.EventHandler(this.pfxPasswordLabel_Click);
            this.pfxPasswordLabel.MouseLeave += new System.EventHandler(this.pfxPasswordLabel_MouseLeave);
            this.pfxPasswordLabel.MouseHover += new System.EventHandler(this.pfxPasswordLabel_MouseHover);
            // 
            // pfxFileLabel
            // 
            this.pfxFileLabel.AutoSize = true;
            this.pfxFileLabel.Location = new System.Drawing.Point(46, 10);
            this.pfxFileLabel.Name = "pfxFileLabel";
            this.pfxFileLabel.Size = new System.Drawing.Size(73, 13);
            this.pfxFileLabel.TabIndex = 11;
            this.pfxFileLabel.Text = "PKCS#12 file:";
            this.pfxFileLabel.Click += new System.EventHandler(this.pfxFileLabel_Click);
            this.pfxFileLabel.MouseLeave += new System.EventHandler(this.pfxFileLabel_MouseLeave);
            this.pfxFileLabel.MouseHover += new System.EventHandler(this.pfxFileLabel_MouseHover);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.signPage);
            this.tabControl.Controls.Add(this.verifyPage);
            this.tabControl.Controls.Add(this.cryptPage);
            this.tabControl.Location = new System.Drawing.Point(13, 222);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(838, 441);
            this.tabControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 672);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.inputFileListview);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Chương trình ký số";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.cryptPage.ResumeLayout(false);
            this.cryptPage.PerformLayout();
            this.verifyPage.ResumeLayout(false);
            this.verifyPage.PerformLayout();
            this.signPage.ResumeLayout(false);
            this.signPage.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView inputFileListview;
        private System.Windows.Forms.ColumnHeader IdColumn;
        private System.Windows.Forms.ColumnHeader FileColumn;
        private System.Windows.Forms.ColumnHeader ResultColumn;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jSONToolStripMenuItem;
        private System.Windows.Forms.TabPage cryptPage;
        private System.Windows.Forms.TabPage verifyPage;
        private System.Windows.Forms.Button cmsVerifyButton;
        private System.Windows.Forms.Label cmsVerifyPfxSignatureAlgoLabel;
        private System.Windows.Forms.Label cmsVerifyPfxThumbprintLabel;
        private System.Windows.Forms.Label cmsVerifyPfxSerialNumberLabel;
        private System.Windows.Forms.Label cmsVerifyPfxExpireLabel;
        private System.Windows.Forms.Label cmsVerifyPfxValidFromLabel;
        private System.Windows.Forms.Label cmsVerifyPfxIssuerLabel;
        private System.Windows.Forms.Label cmsVerifyPfxVersionLabel;
        private System.Windows.Forms.Button cmsMicrosoftCertSelectButton;
        private System.Windows.Forms.TextBox verifyMicrosoftCertThumbprintTextbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage signPage;
        private System.Windows.Forms.Button cmsSignButton;
        private System.Windows.Forms.Label pfxSignatureAlgoLabel;
        private System.Windows.Forms.Label pfxThumbprintLabel;
        private System.Windows.Forms.Label pfxSerialNumberLabel;
        private System.Windows.Forms.Label pfxExpireLabel;
        private System.Windows.Forms.Label pfxValidFromLabel;
        private System.Windows.Forms.Label pfxIssuerLabel;
        private System.Windows.Forms.Label pfxVersionLabel;
        private System.Windows.Forms.Button openOutputFolderButton;
        private System.Windows.Forms.TextBox outputFolderTextbox;
        private System.Windows.Forms.TextBox pfxFileTextbox;
        private System.Windows.Forms.Label outputFolderLabel;
        private System.Windows.Forms.TextBox pfxPasswordTextbox;
        private System.Windows.Forms.Button pfxButton;
        private System.Windows.Forms.Label pfxPasswordLabel;
        private System.Windows.Forms.Label pfxFileLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ComboBox keySizeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordAesTextbox;
        private System.Windows.Forms.Label passwordAesLabel;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button encryptOutputButton;
        private System.Windows.Forms.TextBox cryptOutputTextbox;
        private System.Windows.Forms.Label encryptOutputLabel;
        private System.Windows.Forms.Button decryptButton;
    }
}