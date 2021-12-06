
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.cmsSignPage = new System.Windows.Forms.TabPage();
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
            this.outputFolderLabel = new System.Windows.Forms.Label();
            this.pfxPasswordTextbox = new System.Windows.Forms.TextBox();
            this.pfxButton = new System.Windows.Forms.Button();
            this.pfxFileTextbox = new System.Windows.Forms.TextBox();
            this.pfxPasswordLabel = new System.Windows.Forms.Label();
            this.pfxFileLabel = new System.Windows.Forms.Label();
            this.cmsVerifyPage = new System.Windows.Forms.TabPage();
            this.cmsEncryptPage = new System.Windows.Forms.TabPage();
            this.cmsDecryptPage = new System.Windows.Forms.TabPage();
            this.xmlSignPage = new System.Windows.Forms.TabPage();
            this.xmlSignButton = new System.Windows.Forms.Button();
            this.xmlPfxSignatureAlgoLabel = new System.Windows.Forms.Label();
            this.xmlPfxThumbprintLabel = new System.Windows.Forms.Label();
            this.xmlPfxSerialNumberLabel = new System.Windows.Forms.Label();
            this.xmlPfxExpireLabel = new System.Windows.Forms.Label();
            this.xmlPfxValidFromLabel = new System.Windows.Forms.Label();
            this.xmlPfxIssuerLabel = new System.Windows.Forms.Label();
            this.xmlPfxVersionLabel = new System.Windows.Forms.Label();
            this.xmlOpenOutputFolderButton = new System.Windows.Forms.Button();
            this.xmlOutputFolderTextbox = new System.Windows.Forms.TextBox();
            this.xmlOutputFolderLabel = new System.Windows.Forms.Label();
            this.xmlPfxPasswordTextbox = new System.Windows.Forms.TextBox();
            this.xmlPfxButton = new System.Windows.Forms.Button();
            this.xmlPfxFileTextbox = new System.Windows.Forms.TextBox();
            this.XmlPfxPasswordLabel = new System.Windows.Forms.Label();
            this.xmlPfxFileLabel = new System.Windows.Forms.Label();
            this.xmlVerifyPage = new System.Windows.Forms.TabPage();
            this.xmlEncryptPage = new System.Windows.Forms.TabPage();
            this.xmlDecryptPage = new System.Windows.Forms.TabPage();
            this.jsonSignPage = new System.Windows.Forms.TabPage();
            this.jsonSignButton = new System.Windows.Forms.Button();
            this.jsonPfxSignatureAlgoLabel = new System.Windows.Forms.Label();
            this.jsonPfxThumbprintLabel = new System.Windows.Forms.Label();
            this.jsonPfxSerialNumberLabel = new System.Windows.Forms.Label();
            this.jsonPfxExpireLabel = new System.Windows.Forms.Label();
            this.jsonPfxValidFromLabel = new System.Windows.Forms.Label();
            this.jsonPfxIssuerLabel = new System.Windows.Forms.Label();
            this.jsonPfxVersionLabel = new System.Windows.Forms.Label();
            this.jsonOpenOutputFolderButton = new System.Windows.Forms.Button();
            this.jsonOutputFolderTextbox = new System.Windows.Forms.TextBox();
            this.jsonOutputFolderLabel = new System.Windows.Forms.Label();
            this.jsonPfxPasswordTextbox = new System.Windows.Forms.TextBox();
            this.jsonPfxFileBrowserButton = new System.Windows.Forms.Button();
            this.jsonPfxFileTextbox = new System.Windows.Forms.TextBox();
            this.jsonPfxPasswordLabel = new System.Windows.Forms.Label();
            this.jsonPfxFileLabel = new System.Windows.Forms.Label();
            this.jsonVerifyPage = new System.Windows.Forms.TabPage();
            this.jsonEncryptPage = new System.Windows.Forms.TabPage();
            this.jsonDecryptPage = new System.Windows.Forms.TabPage();
            this.inputFileListview = new System.Windows.Forms.ListView();
            this.IdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResultColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.cmsSignPage.SuspendLayout();
            this.xmlSignPage.SuspendLayout();
            this.jsonSignPage.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.cmsSignPage);
            this.tabControl.Controls.Add(this.cmsVerifyPage);
            this.tabControl.Controls.Add(this.cmsEncryptPage);
            this.tabControl.Controls.Add(this.cmsDecryptPage);
            this.tabControl.Controls.Add(this.xmlSignPage);
            this.tabControl.Controls.Add(this.xmlVerifyPage);
            this.tabControl.Controls.Add(this.xmlEncryptPage);
            this.tabControl.Controls.Add(this.xmlDecryptPage);
            this.tabControl.Controls.Add(this.jsonSignPage);
            this.tabControl.Controls.Add(this.jsonVerifyPage);
            this.tabControl.Controls.Add(this.jsonEncryptPage);
            this.tabControl.Controls.Add(this.jsonDecryptPage);
            this.tabControl.Location = new System.Drawing.Point(13, 222);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(838, 441);
            this.tabControl.TabIndex = 0;
            // 
            // cmsSignPage
            // 
            this.cmsSignPage.Controls.Add(this.cmsSignButton);
            this.cmsSignPage.Controls.Add(this.pfxSignatureAlgoLabel);
            this.cmsSignPage.Controls.Add(this.pfxThumbprintLabel);
            this.cmsSignPage.Controls.Add(this.pfxSerialNumberLabel);
            this.cmsSignPage.Controls.Add(this.pfxExpireLabel);
            this.cmsSignPage.Controls.Add(this.pfxValidFromLabel);
            this.cmsSignPage.Controls.Add(this.pfxIssuerLabel);
            this.cmsSignPage.Controls.Add(this.pfxVersionLabel);
            this.cmsSignPage.Controls.Add(this.openOutputFolderButton);
            this.cmsSignPage.Controls.Add(this.outputFolderTextbox);
            this.cmsSignPage.Controls.Add(this.outputFolderLabel);
            this.cmsSignPage.Controls.Add(this.pfxPasswordTextbox);
            this.cmsSignPage.Controls.Add(this.pfxButton);
            this.cmsSignPage.Controls.Add(this.pfxFileTextbox);
            this.cmsSignPage.Controls.Add(this.pfxPasswordLabel);
            this.cmsSignPage.Controls.Add(this.pfxFileLabel);
            this.cmsSignPage.Location = new System.Drawing.Point(4, 22);
            this.cmsSignPage.Name = "cmsSignPage";
            this.cmsSignPage.Padding = new System.Windows.Forms.Padding(3);
            this.cmsSignPage.Size = new System.Drawing.Size(830, 415);
            this.cmsSignPage.TabIndex = 0;
            this.cmsSignPage.Text = "CMS Sign";
            this.cmsSignPage.UseVisualStyleBackColor = true;
            // 
            // cmsSignButton
            // 
            this.cmsSignButton.Location = new System.Drawing.Point(405, 386);
            this.cmsSignButton.Name = "cmsSignButton";
            this.cmsSignButton.Size = new System.Drawing.Size(75, 23);
            this.cmsSignButton.TabIndex = 26;
            this.cmsSignButton.Text = "Sign";
            this.cmsSignButton.UseVisualStyleBackColor = true;
            this.cmsSignButton.Click += new System.EventHandler(this.cmsSignButton_Click);
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
            // cmsVerifyPage
            // 
            this.cmsVerifyPage.Location = new System.Drawing.Point(4, 22);
            this.cmsVerifyPage.Name = "cmsVerifyPage";
            this.cmsVerifyPage.Padding = new System.Windows.Forms.Padding(3);
            this.cmsVerifyPage.Size = new System.Drawing.Size(830, 415);
            this.cmsVerifyPage.TabIndex = 1;
            this.cmsVerifyPage.Text = "CMS Verify";
            this.cmsVerifyPage.UseVisualStyleBackColor = true;
            // 
            // cmsEncryptPage
            // 
            this.cmsEncryptPage.Location = new System.Drawing.Point(4, 22);
            this.cmsEncryptPage.Name = "cmsEncryptPage";
            this.cmsEncryptPage.Padding = new System.Windows.Forms.Padding(3);
            this.cmsEncryptPage.Size = new System.Drawing.Size(830, 415);
            this.cmsEncryptPage.TabIndex = 2;
            this.cmsEncryptPage.Text = "CMS Encrypt";
            this.cmsEncryptPage.UseVisualStyleBackColor = true;
            // 
            // cmsDecryptPage
            // 
            this.cmsDecryptPage.Location = new System.Drawing.Point(4, 22);
            this.cmsDecryptPage.Name = "cmsDecryptPage";
            this.cmsDecryptPage.Padding = new System.Windows.Forms.Padding(3);
            this.cmsDecryptPage.Size = new System.Drawing.Size(830, 415);
            this.cmsDecryptPage.TabIndex = 3;
            this.cmsDecryptPage.Text = "CMS Decrypt";
            this.cmsDecryptPage.UseVisualStyleBackColor = true;
            // 
            // xmlSignPage
            // 
            this.xmlSignPage.Controls.Add(this.xmlSignButton);
            this.xmlSignPage.Controls.Add(this.xmlPfxSignatureAlgoLabel);
            this.xmlSignPage.Controls.Add(this.xmlPfxThumbprintLabel);
            this.xmlSignPage.Controls.Add(this.xmlPfxSerialNumberLabel);
            this.xmlSignPage.Controls.Add(this.xmlPfxExpireLabel);
            this.xmlSignPage.Controls.Add(this.xmlPfxValidFromLabel);
            this.xmlSignPage.Controls.Add(this.xmlPfxIssuerLabel);
            this.xmlSignPage.Controls.Add(this.xmlPfxVersionLabel);
            this.xmlSignPage.Controls.Add(this.xmlOpenOutputFolderButton);
            this.xmlSignPage.Controls.Add(this.xmlOutputFolderTextbox);
            this.xmlSignPage.Controls.Add(this.xmlOutputFolderLabel);
            this.xmlSignPage.Controls.Add(this.xmlPfxPasswordTextbox);
            this.xmlSignPage.Controls.Add(this.xmlPfxButton);
            this.xmlSignPage.Controls.Add(this.xmlPfxFileTextbox);
            this.xmlSignPage.Controls.Add(this.XmlPfxPasswordLabel);
            this.xmlSignPage.Controls.Add(this.xmlPfxFileLabel);
            this.xmlSignPage.Location = new System.Drawing.Point(4, 22);
            this.xmlSignPage.Name = "xmlSignPage";
            this.xmlSignPage.Padding = new System.Windows.Forms.Padding(3);
            this.xmlSignPage.Size = new System.Drawing.Size(830, 415);
            this.xmlSignPage.TabIndex = 4;
            this.xmlSignPage.Text = "XMl Sign";
            this.xmlSignPage.UseVisualStyleBackColor = true;
            // 
            // xmlSignButton
            // 
            this.xmlSignButton.Location = new System.Drawing.Point(405, 386);
            this.xmlSignButton.Name = "xmlSignButton";
            this.xmlSignButton.Size = new System.Drawing.Size(75, 23);
            this.xmlSignButton.TabIndex = 42;
            this.xmlSignButton.Text = "Sign";
            this.xmlSignButton.UseVisualStyleBackColor = true;
            this.xmlSignButton.Click += new System.EventHandler(this.xmlSignButton_Click);
            // 
            // xmlPfxSignatureAlgoLabel
            // 
            this.xmlPfxSignatureAlgoLabel.AutoSize = true;
            this.xmlPfxSignatureAlgoLabel.Location = new System.Drawing.Point(19, 269);
            this.xmlPfxSignatureAlgoLabel.Name = "xmlPfxSignatureAlgoLabel";
            this.xmlPfxSignatureAlgoLabel.Size = new System.Drawing.Size(164, 13);
            this.xmlPfxSignatureAlgoLabel.TabIndex = 41;
            this.xmlPfxSignatureAlgoLabel.Text = "Signature algorithm:      Unknown";
            // 
            // xmlPfxThumbprintLabel
            // 
            this.xmlPfxThumbprintLabel.AutoSize = true;
            this.xmlPfxThumbprintLabel.Location = new System.Drawing.Point(56, 232);
            this.xmlPfxThumbprintLabel.Name = "xmlPfxThumbprintLabel";
            this.xmlPfxThumbprintLabel.Size = new System.Drawing.Size(127, 13);
            this.xmlPfxThumbprintLabel.TabIndex = 40;
            this.xmlPfxThumbprintLabel.Text = "Thumbprint:      Unknown";
            // 
            // xmlPfxSerialNumberLabel
            // 
            this.xmlPfxSerialNumberLabel.AutoSize = true;
            this.xmlPfxSerialNumberLabel.Location = new System.Drawing.Point(45, 195);
            this.xmlPfxSerialNumberLabel.Name = "xmlPfxSerialNumberLabel";
            this.xmlPfxSerialNumberLabel.Size = new System.Drawing.Size(138, 13);
            this.xmlPfxSerialNumberLabel.TabIndex = 39;
            this.xmlPfxSerialNumberLabel.Text = "Serial number:      Unknown";
            // 
            // xmlPfxExpireLabel
            // 
            this.xmlPfxExpireLabel.AutoSize = true;
            this.xmlPfxExpireLabel.Location = new System.Drawing.Point(65, 343);
            this.xmlPfxExpireLabel.Name = "xmlPfxExpireLabel";
            this.xmlPfxExpireLabel.Size = new System.Drawing.Size(115, 13);
            this.xmlPfxExpireLabel.TabIndex = 38;
            this.xmlPfxExpireLabel.Text = "Expire to:      Unknown";
            // 
            // xmlPfxValidFromLabel
            // 
            this.xmlPfxValidFromLabel.AutoSize = true;
            this.xmlPfxValidFromLabel.Location = new System.Drawing.Point(63, 306);
            this.xmlPfxValidFromLabel.Name = "xmlPfxValidFromLabel";
            this.xmlPfxValidFromLabel.Size = new System.Drawing.Size(120, 13);
            this.xmlPfxValidFromLabel.TabIndex = 37;
            this.xmlPfxValidFromLabel.Text = "Valid from:      Unknown";
            // 
            // xmlPfxIssuerLabel
            // 
            this.xmlPfxIssuerLabel.AutoSize = true;
            this.xmlPfxIssuerLabel.Location = new System.Drawing.Point(81, 158);
            this.xmlPfxIssuerLabel.Name = "xmlPfxIssuerLabel";
            this.xmlPfxIssuerLabel.Size = new System.Drawing.Size(102, 13);
            this.xmlPfxIssuerLabel.TabIndex = 36;
            this.xmlPfxIssuerLabel.Text = "Issuer:      Unknown";
            // 
            // xmlPfxVersionLabel
            // 
            this.xmlPfxVersionLabel.AutoSize = true;
            this.xmlPfxVersionLabel.Location = new System.Drawing.Point(74, 121);
            this.xmlPfxVersionLabel.Name = "xmlPfxVersionLabel";
            this.xmlPfxVersionLabel.Size = new System.Drawing.Size(109, 13);
            this.xmlPfxVersionLabel.TabIndex = 35;
            this.xmlPfxVersionLabel.Text = "Version:      Unknown";
            // 
            // xmlOpenOutputFolderButton
            // 
            this.xmlOpenOutputFolderButton.Location = new System.Drawing.Point(737, 79);
            this.xmlOpenOutputFolderButton.Name = "xmlOpenOutputFolderButton";
            this.xmlOpenOutputFolderButton.Size = new System.Drawing.Size(75, 23);
            this.xmlOpenOutputFolderButton.TabIndex = 34;
            this.xmlOpenOutputFolderButton.Text = "Open folder";
            this.xmlOpenOutputFolderButton.UseVisualStyleBackColor = true;
            this.xmlOpenOutputFolderButton.Click += new System.EventHandler(this.xmlOpenOutputFolderButton_Click);
            // 
            // xmlOutputFolderTextbox
            // 
            this.xmlOutputFolderTextbox.Location = new System.Drawing.Point(135, 80);
            this.xmlOutputFolderTextbox.Name = "xmlOutputFolderTextbox";
            this.xmlOutputFolderTextbox.Size = new System.Drawing.Size(596, 20);
            this.xmlOutputFolderTextbox.TabIndex = 33;
            this.xmlOutputFolderTextbox.Text = "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\Common7\\IDE";
            this.xmlOutputFolderTextbox.DoubleClick += new System.EventHandler(this.xmlOutputFolderTextbox_DoubleClick);
            this.xmlOutputFolderTextbox.MouseLeave += new System.EventHandler(this.xmlOutputFolderTextbox_MouseLeave);
            this.xmlOutputFolderTextbox.MouseHover += new System.EventHandler(this.xmlOutputFolderTextbox_MouseHover);
            // 
            // xmlOutputFolderLabel
            // 
            this.xmlOutputFolderLabel.AutoSize = true;
            this.xmlOutputFolderLabel.Location = new System.Drawing.Point(48, 84);
            this.xmlOutputFolderLabel.Name = "xmlOutputFolderLabel";
            this.xmlOutputFolderLabel.Size = new System.Drawing.Size(71, 13);
            this.xmlOutputFolderLabel.TabIndex = 32;
            this.xmlOutputFolderLabel.Text = "Output folder:";
            this.xmlOutputFolderLabel.Click += new System.EventHandler(this.xmlOutputFolderLabel_Click);
            this.xmlOutputFolderLabel.MouseLeave += new System.EventHandler(this.xmlOutputFolderLabel_MouseLeave);
            this.xmlOutputFolderLabel.MouseHover += new System.EventHandler(this.xmlOutputFolderLabel_MouseHover);
            // 
            // xmlPfxPasswordTextbox
            // 
            this.xmlPfxPasswordTextbox.Location = new System.Drawing.Point(135, 43);
            this.xmlPfxPasswordTextbox.Name = "xmlPfxPasswordTextbox";
            this.xmlPfxPasswordTextbox.ReadOnly = true;
            this.xmlPfxPasswordTextbox.Size = new System.Drawing.Size(100, 20);
            this.xmlPfxPasswordTextbox.TabIndex = 31;
            this.xmlPfxPasswordTextbox.UseSystemPasswordChar = true;
            this.xmlPfxPasswordTextbox.DoubleClick += new System.EventHandler(this.jsonPfxPwdTextbox_Click);
            this.xmlPfxPasswordTextbox.MouseLeave += new System.EventHandler(this.xmlPfxPasswordTextbox_MouseLeave);
            this.xmlPfxPasswordTextbox.MouseHover += new System.EventHandler(this.xmlPfxPasswordTextbox_MouseHover);
            // 
            // xmlPfxButton
            // 
            this.xmlPfxButton.Location = new System.Drawing.Point(737, 4);
            this.xmlPfxButton.Name = "xmlPfxButton";
            this.xmlPfxButton.Size = new System.Drawing.Size(75, 23);
            this.xmlPfxButton.TabIndex = 30;
            this.xmlPfxButton.Text = "Browse ...";
            this.xmlPfxButton.UseVisualStyleBackColor = true;
            this.xmlPfxButton.Click += new System.EventHandler(this.xmlPfxButton_Click);
            // 
            // xmlPfxFileTextbox
            // 
            this.xmlPfxFileTextbox.Location = new System.Drawing.Point(135, 6);
            this.xmlPfxFileTextbox.Name = "xmlPfxFileTextbox";
            this.xmlPfxFileTextbox.Size = new System.Drawing.Size(596, 20);
            this.xmlPfxFileTextbox.TabIndex = 28;
            this.xmlPfxFileTextbox.DoubleClick += new System.EventHandler(this.xmlPfxFileTextbox_DoubleClick);
            this.xmlPfxFileTextbox.MouseLeave += new System.EventHandler(this.xmlPfxFileTextbox_MouseLeave);
            this.xmlPfxFileTextbox.MouseHover += new System.EventHandler(this.xmlPfxFileTextbox_MouseHover);
            // 
            // XmlPfxPasswordLabel
            // 
            this.XmlPfxPasswordLabel.AutoSize = true;
            this.XmlPfxPasswordLabel.Location = new System.Drawing.Point(63, 47);
            this.XmlPfxPasswordLabel.Name = "XmlPfxPasswordLabel";
            this.XmlPfxPasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.XmlPfxPasswordLabel.TabIndex = 29;
            this.XmlPfxPasswordLabel.Text = "Password:";
            this.XmlPfxPasswordLabel.Click += new System.EventHandler(this.XmlPfxPasswordLabel_Click);
            this.XmlPfxPasswordLabel.MouseLeave += new System.EventHandler(this.XmlPfxPasswordLabel_MouseLeave);
            this.XmlPfxPasswordLabel.MouseHover += new System.EventHandler(this.XmlPfxPasswordLabel_MouseHover);
            // 
            // xmlPfxFileLabel
            // 
            this.xmlPfxFileLabel.AutoSize = true;
            this.xmlPfxFileLabel.Location = new System.Drawing.Point(46, 10);
            this.xmlPfxFileLabel.Name = "xmlPfxFileLabel";
            this.xmlPfxFileLabel.Size = new System.Drawing.Size(73, 13);
            this.xmlPfxFileLabel.TabIndex = 27;
            this.xmlPfxFileLabel.Text = "PKCS#12 file:";
            this.xmlPfxFileLabel.Click += new System.EventHandler(this.xmlPfxFileLabel_Click);
            this.xmlPfxFileLabel.MouseLeave += new System.EventHandler(this.xmlPfxFileLabel_MouseLeave);
            this.xmlPfxFileLabel.MouseHover += new System.EventHandler(this.xmlPfxFileLabel_MouseHover);
            // 
            // xmlVerifyPage
            // 
            this.xmlVerifyPage.Location = new System.Drawing.Point(4, 22);
            this.xmlVerifyPage.Name = "xmlVerifyPage";
            this.xmlVerifyPage.Padding = new System.Windows.Forms.Padding(3);
            this.xmlVerifyPage.Size = new System.Drawing.Size(830, 415);
            this.xmlVerifyPage.TabIndex = 5;
            this.xmlVerifyPage.Text = "XML Verify";
            this.xmlVerifyPage.UseVisualStyleBackColor = true;
            // 
            // xmlEncryptPage
            // 
            this.xmlEncryptPage.Location = new System.Drawing.Point(4, 22);
            this.xmlEncryptPage.Name = "xmlEncryptPage";
            this.xmlEncryptPage.Padding = new System.Windows.Forms.Padding(3);
            this.xmlEncryptPage.Size = new System.Drawing.Size(830, 415);
            this.xmlEncryptPage.TabIndex = 6;
            this.xmlEncryptPage.Text = "XML Encrypt";
            this.xmlEncryptPage.UseVisualStyleBackColor = true;
            // 
            // xmlDecryptPage
            // 
            this.xmlDecryptPage.Location = new System.Drawing.Point(4, 22);
            this.xmlDecryptPage.Name = "xmlDecryptPage";
            this.xmlDecryptPage.Padding = new System.Windows.Forms.Padding(3);
            this.xmlDecryptPage.Size = new System.Drawing.Size(830, 415);
            this.xmlDecryptPage.TabIndex = 7;
            this.xmlDecryptPage.Text = "XML Decrypt";
            this.xmlDecryptPage.UseVisualStyleBackColor = true;
            // 
            // jsonSignPage
            // 
            this.jsonSignPage.Controls.Add(this.jsonSignButton);
            this.jsonSignPage.Controls.Add(this.jsonPfxSignatureAlgoLabel);
            this.jsonSignPage.Controls.Add(this.jsonPfxThumbprintLabel);
            this.jsonSignPage.Controls.Add(this.jsonPfxSerialNumberLabel);
            this.jsonSignPage.Controls.Add(this.jsonPfxExpireLabel);
            this.jsonSignPage.Controls.Add(this.jsonPfxValidFromLabel);
            this.jsonSignPage.Controls.Add(this.jsonPfxIssuerLabel);
            this.jsonSignPage.Controls.Add(this.jsonPfxVersionLabel);
            this.jsonSignPage.Controls.Add(this.jsonOpenOutputFolderButton);
            this.jsonSignPage.Controls.Add(this.jsonOutputFolderTextbox);
            this.jsonSignPage.Controls.Add(this.jsonOutputFolderLabel);
            this.jsonSignPage.Controls.Add(this.jsonPfxPasswordTextbox);
            this.jsonSignPage.Controls.Add(this.jsonPfxFileBrowserButton);
            this.jsonSignPage.Controls.Add(this.jsonPfxFileTextbox);
            this.jsonSignPage.Controls.Add(this.jsonPfxPasswordLabel);
            this.jsonSignPage.Controls.Add(this.jsonPfxFileLabel);
            this.jsonSignPage.Location = new System.Drawing.Point(4, 22);
            this.jsonSignPage.Name = "jsonSignPage";
            this.jsonSignPage.Padding = new System.Windows.Forms.Padding(3);
            this.jsonSignPage.Size = new System.Drawing.Size(830, 415);
            this.jsonSignPage.TabIndex = 8;
            this.jsonSignPage.Text = "JSON Sign";
            this.jsonSignPage.UseVisualStyleBackColor = true;
            // 
            // jsonSignButton
            // 
            this.jsonSignButton.Location = new System.Drawing.Point(405, 386);
            this.jsonSignButton.Name = "jsonSignButton";
            this.jsonSignButton.Size = new System.Drawing.Size(75, 23);
            this.jsonSignButton.TabIndex = 42;
            this.jsonSignButton.Text = "Sign";
            this.jsonSignButton.UseVisualStyleBackColor = true;
            this.jsonSignButton.Click += new System.EventHandler(this.jsonSignButton_Click);
            // 
            // jsonPfxSignatureAlgoLabel
            // 
            this.jsonPfxSignatureAlgoLabel.AutoSize = true;
            this.jsonPfxSignatureAlgoLabel.Location = new System.Drawing.Point(19, 269);
            this.jsonPfxSignatureAlgoLabel.Name = "jsonPfxSignatureAlgoLabel";
            this.jsonPfxSignatureAlgoLabel.Size = new System.Drawing.Size(164, 13);
            this.jsonPfxSignatureAlgoLabel.TabIndex = 41;
            this.jsonPfxSignatureAlgoLabel.Text = "Signature algorithm:      Unknown";
            // 
            // jsonPfxThumbprintLabel
            // 
            this.jsonPfxThumbprintLabel.AutoSize = true;
            this.jsonPfxThumbprintLabel.Location = new System.Drawing.Point(56, 232);
            this.jsonPfxThumbprintLabel.Name = "jsonPfxThumbprintLabel";
            this.jsonPfxThumbprintLabel.Size = new System.Drawing.Size(127, 13);
            this.jsonPfxThumbprintLabel.TabIndex = 40;
            this.jsonPfxThumbprintLabel.Text = "Thumbprint:      Unknown";
            // 
            // jsonPfxSerialNumberLabel
            // 
            this.jsonPfxSerialNumberLabel.AutoSize = true;
            this.jsonPfxSerialNumberLabel.Location = new System.Drawing.Point(45, 195);
            this.jsonPfxSerialNumberLabel.Name = "jsonPfxSerialNumberLabel";
            this.jsonPfxSerialNumberLabel.Size = new System.Drawing.Size(138, 13);
            this.jsonPfxSerialNumberLabel.TabIndex = 39;
            this.jsonPfxSerialNumberLabel.Text = "Serial number:      Unknown";
            // 
            // jsonPfxExpireLabel
            // 
            this.jsonPfxExpireLabel.AutoSize = true;
            this.jsonPfxExpireLabel.Location = new System.Drawing.Point(65, 343);
            this.jsonPfxExpireLabel.Name = "jsonPfxExpireLabel";
            this.jsonPfxExpireLabel.Size = new System.Drawing.Size(115, 13);
            this.jsonPfxExpireLabel.TabIndex = 38;
            this.jsonPfxExpireLabel.Text = "Expire to:      Unknown";
            // 
            // jsonPfxValidFromLabel
            // 
            this.jsonPfxValidFromLabel.AutoSize = true;
            this.jsonPfxValidFromLabel.Location = new System.Drawing.Point(63, 306);
            this.jsonPfxValidFromLabel.Name = "jsonPfxValidFromLabel";
            this.jsonPfxValidFromLabel.Size = new System.Drawing.Size(120, 13);
            this.jsonPfxValidFromLabel.TabIndex = 37;
            this.jsonPfxValidFromLabel.Text = "Valid from:      Unknown";
            // 
            // jsonPfxIssuerLabel
            // 
            this.jsonPfxIssuerLabel.AutoSize = true;
            this.jsonPfxIssuerLabel.Location = new System.Drawing.Point(81, 158);
            this.jsonPfxIssuerLabel.Name = "jsonPfxIssuerLabel";
            this.jsonPfxIssuerLabel.Size = new System.Drawing.Size(102, 13);
            this.jsonPfxIssuerLabel.TabIndex = 36;
            this.jsonPfxIssuerLabel.Text = "Issuer:      Unknown";
            // 
            // jsonPfxVersionLabel
            // 
            this.jsonPfxVersionLabel.AutoSize = true;
            this.jsonPfxVersionLabel.Location = new System.Drawing.Point(74, 121);
            this.jsonPfxVersionLabel.Name = "jsonPfxVersionLabel";
            this.jsonPfxVersionLabel.Size = new System.Drawing.Size(109, 13);
            this.jsonPfxVersionLabel.TabIndex = 35;
            this.jsonPfxVersionLabel.Text = "Version:      Unknown";
            // 
            // jsonOpenOutputFolderButton
            // 
            this.jsonOpenOutputFolderButton.Location = new System.Drawing.Point(737, 79);
            this.jsonOpenOutputFolderButton.Name = "jsonOpenOutputFolderButton";
            this.jsonOpenOutputFolderButton.Size = new System.Drawing.Size(75, 23);
            this.jsonOpenOutputFolderButton.TabIndex = 34;
            this.jsonOpenOutputFolderButton.Text = "Open folder";
            this.jsonOpenOutputFolderButton.UseVisualStyleBackColor = true;
            this.jsonOpenOutputFolderButton.Click += new System.EventHandler(this.jsonOpenOutputFolderButton_Click);
            // 
            // jsonOutputFolderTextbox
            // 
            this.jsonOutputFolderTextbox.Location = new System.Drawing.Point(135, 80);
            this.jsonOutputFolderTextbox.Name = "jsonOutputFolderTextbox";
            this.jsonOutputFolderTextbox.Size = new System.Drawing.Size(596, 20);
            this.jsonOutputFolderTextbox.TabIndex = 33;
            this.jsonOutputFolderTextbox.Text = "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\Common7\\IDE";
            this.jsonOutputFolderTextbox.DoubleClick += new System.EventHandler(this.jsonOutputFolderTextbox_DoubleClick);
            this.jsonOutputFolderTextbox.MouseLeave += new System.EventHandler(this.jsonOutputFolderTextbox_MouseLeave);
            this.jsonOutputFolderTextbox.MouseHover += new System.EventHandler(this.jsonOutputFolderTextbox_MouseHover);
            // 
            // jsonOutputFolderLabel
            // 
            this.jsonOutputFolderLabel.AutoSize = true;
            this.jsonOutputFolderLabel.Location = new System.Drawing.Point(48, 84);
            this.jsonOutputFolderLabel.Name = "jsonOutputFolderLabel";
            this.jsonOutputFolderLabel.Size = new System.Drawing.Size(71, 13);
            this.jsonOutputFolderLabel.TabIndex = 32;
            this.jsonOutputFolderLabel.Text = "Output folder:";
            this.jsonOutputFolderLabel.Click += new System.EventHandler(this.jsonOutputFolderLabel_Click);
            this.jsonOutputFolderLabel.MouseLeave += new System.EventHandler(this.jsonOutputFolderLabel_MouseLeave);
            this.jsonOutputFolderLabel.MouseHover += new System.EventHandler(this.jsonOutputFolderLabel_MouseHover);
            // 
            // jsonPfxPasswordTextbox
            // 
            this.jsonPfxPasswordTextbox.Location = new System.Drawing.Point(135, 43);
            this.jsonPfxPasswordTextbox.Name = "jsonPfxPasswordTextbox";
            this.jsonPfxPasswordTextbox.ReadOnly = true;
            this.jsonPfxPasswordTextbox.Size = new System.Drawing.Size(100, 20);
            this.jsonPfxPasswordTextbox.TabIndex = 31;
            this.jsonPfxPasswordTextbox.UseSystemPasswordChar = true;
            this.jsonPfxPasswordTextbox.Click += new System.EventHandler(this.jsonPfxPwdTextbox_Click);
            this.jsonPfxPasswordTextbox.MouseLeave += new System.EventHandler(this.jsonPfxPwdTextbox_MouseLeave);
            this.jsonPfxPasswordTextbox.MouseHover += new System.EventHandler(this.jsonPfxPwdTextbox_MouseHover);
            // 
            // jsonPfxFileBrowserButton
            // 
            this.jsonPfxFileBrowserButton.Location = new System.Drawing.Point(737, 4);
            this.jsonPfxFileBrowserButton.Name = "jsonPfxFileBrowserButton";
            this.jsonPfxFileBrowserButton.Size = new System.Drawing.Size(75, 23);
            this.jsonPfxFileBrowserButton.TabIndex = 30;
            this.jsonPfxFileBrowserButton.Text = "Browse ...";
            this.jsonPfxFileBrowserButton.UseVisualStyleBackColor = true;
            this.jsonPfxFileBrowserButton.Click += new System.EventHandler(this.jsonPfxFileBrowserButton_Click);
            // 
            // jsonPfxFileTextbox
            // 
            this.jsonPfxFileTextbox.Location = new System.Drawing.Point(135, 6);
            this.jsonPfxFileTextbox.Name = "jsonPfxFileTextbox";
            this.jsonPfxFileTextbox.Size = new System.Drawing.Size(596, 20);
            this.jsonPfxFileTextbox.TabIndex = 28;
            this.jsonPfxFileTextbox.DoubleClick += new System.EventHandler(this.jsonPfxFileTextbox_DoubleClick);
            this.jsonPfxFileTextbox.MouseLeave += new System.EventHandler(this.jsonPfxFileTextbox_MouseLeave);
            this.jsonPfxFileTextbox.MouseHover += new System.EventHandler(this.jsonPfxFileTextbox_MouseHover);
            // 
            // jsonPfxPasswordLabel
            // 
            this.jsonPfxPasswordLabel.AutoSize = true;
            this.jsonPfxPasswordLabel.Location = new System.Drawing.Point(63, 47);
            this.jsonPfxPasswordLabel.Name = "jsonPfxPasswordLabel";
            this.jsonPfxPasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.jsonPfxPasswordLabel.TabIndex = 29;
            this.jsonPfxPasswordLabel.Text = "Password:";
            this.jsonPfxPasswordLabel.Click += new System.EventHandler(this.jsonPfxPwdLabel_Click);
            this.jsonPfxPasswordLabel.MouseLeave += new System.EventHandler(this.jsonPfxPwdLabel_MouseLeave);
            this.jsonPfxPasswordLabel.MouseHover += new System.EventHandler(this.jsonPfxPwdLabel_MouseHover);
            // 
            // jsonPfxFileLabel
            // 
            this.jsonPfxFileLabel.AutoSize = true;
            this.jsonPfxFileLabel.Location = new System.Drawing.Point(46, 10);
            this.jsonPfxFileLabel.Name = "jsonPfxFileLabel";
            this.jsonPfxFileLabel.Size = new System.Drawing.Size(73, 13);
            this.jsonPfxFileLabel.TabIndex = 27;
            this.jsonPfxFileLabel.Text = "PKCS#12 file:";
            this.jsonPfxFileLabel.Click += new System.EventHandler(this.jsonPfxFileLabel_Click);
            this.jsonPfxFileLabel.MouseLeave += new System.EventHandler(this.jsonPfxFileLabel_MouseLeave);
            this.jsonPfxFileLabel.MouseHover += new System.EventHandler(this.jsonPfxFileLabel_MouseHover);
            // 
            // jsonVerifyPage
            // 
            this.jsonVerifyPage.Location = new System.Drawing.Point(4, 22);
            this.jsonVerifyPage.Name = "jsonVerifyPage";
            this.jsonVerifyPage.Padding = new System.Windows.Forms.Padding(3);
            this.jsonVerifyPage.Size = new System.Drawing.Size(830, 415);
            this.jsonVerifyPage.TabIndex = 9;
            this.jsonVerifyPage.Text = "JSON Verify";
            this.jsonVerifyPage.UseVisualStyleBackColor = true;
            // 
            // jsonEncryptPage
            // 
            this.jsonEncryptPage.Location = new System.Drawing.Point(4, 22);
            this.jsonEncryptPage.Name = "jsonEncryptPage";
            this.jsonEncryptPage.Padding = new System.Windows.Forms.Padding(3);
            this.jsonEncryptPage.Size = new System.Drawing.Size(830, 415);
            this.jsonEncryptPage.TabIndex = 10;
            this.jsonEncryptPage.Text = "JSON Encrypt";
            this.jsonEncryptPage.UseVisualStyleBackColor = true;
            // 
            // jsonDecryptPage
            // 
            this.jsonDecryptPage.Location = new System.Drawing.Point(4, 22);
            this.jsonDecryptPage.Name = "jsonDecryptPage";
            this.jsonDecryptPage.Padding = new System.Windows.Forms.Padding(3);
            this.jsonDecryptPage.Size = new System.Drawing.Size(830, 415);
            this.jsonDecryptPage.TabIndex = 11;
            this.jsonDecryptPage.Text = "JSON Decrypt";
            this.jsonDecryptPage.UseVisualStyleBackColor = true;
            // 
            // inputFileListview
            // 
            this.inputFileListview.Alignment = System.Windows.Forms.ListViewAlignment.Left;
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
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveAsToolStripMenuItem.Text = "Save as ...";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click_1);
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
            this.tabControl.ResumeLayout(false);
            this.cmsSignPage.ResumeLayout(false);
            this.cmsSignPage.PerformLayout();
            this.xmlSignPage.ResumeLayout(false);
            this.xmlSignPage.PerformLayout();
            this.jsonSignPage.ResumeLayout(false);
            this.jsonSignPage.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage cmsSignPage;
        private System.Windows.Forms.TabPage cmsVerifyPage;
        private System.Windows.Forms.TabPage cmsEncryptPage;
        private System.Windows.Forms.TabPage cmsDecryptPage;
        private System.Windows.Forms.TabPage xmlSignPage;
        private System.Windows.Forms.TabPage xmlVerifyPage;
        private System.Windows.Forms.TabPage xmlEncryptPage;
        private System.Windows.Forms.TabPage xmlDecryptPage;
        private System.Windows.Forms.TabPage jsonSignPage;
        private System.Windows.Forms.TabPage jsonVerifyPage;
        private System.Windows.Forms.TabPage jsonEncryptPage;
        private System.Windows.Forms.TabPage jsonDecryptPage;
        private System.Windows.Forms.ListView inputFileListview;
        private System.Windows.Forms.ColumnHeader IdColumn;
        private System.Windows.Forms.ColumnHeader FileColumn;
        private System.Windows.Forms.ColumnHeader ResultColumn;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button openOutputFolderButton;
        private System.Windows.Forms.TextBox outputFolderTextbox;
        private System.Windows.Forms.Label outputFolderLabel;
        private System.Windows.Forms.TextBox pfxPasswordTextbox;
        private System.Windows.Forms.Button pfxButton;
        private System.Windows.Forms.TextBox pfxFileTextbox;
        private System.Windows.Forms.Label pfxPasswordLabel;
        private System.Windows.Forms.Label pfxFileLabel;
        private System.Windows.Forms.Label pfxSignatureAlgoLabel;
        private System.Windows.Forms.Label pfxThumbprintLabel;
        private System.Windows.Forms.Label pfxSerialNumberLabel;
        private System.Windows.Forms.Label pfxExpireLabel;
        private System.Windows.Forms.Label pfxValidFromLabel;
        private System.Windows.Forms.Label pfxIssuerLabel;
        private System.Windows.Forms.Label pfxVersionLabel;
        private System.Windows.Forms.Button cmsSignButton;
        private System.Windows.Forms.Button jsonSignButton;
        private System.Windows.Forms.Label jsonPfxSignatureAlgoLabel;
        private System.Windows.Forms.Label jsonPfxThumbprintLabel;
        private System.Windows.Forms.Label jsonPfxSerialNumberLabel;
        private System.Windows.Forms.Label jsonPfxExpireLabel;
        private System.Windows.Forms.Label jsonPfxValidFromLabel;
        private System.Windows.Forms.Label jsonPfxIssuerLabel;
        private System.Windows.Forms.Label jsonPfxVersionLabel;
        private System.Windows.Forms.Button jsonOpenOutputFolderButton;
        private System.Windows.Forms.TextBox jsonOutputFolderTextbox;
        private System.Windows.Forms.Label jsonOutputFolderLabel;
        private System.Windows.Forms.TextBox jsonPfxPasswordTextbox;
        private System.Windows.Forms.Button jsonPfxFileBrowserButton;
        private System.Windows.Forms.TextBox jsonPfxFileTextbox;
        private System.Windows.Forms.Label jsonPfxPasswordLabel;
        private System.Windows.Forms.Label jsonPfxFileLabel;
        private System.Windows.Forms.Button xmlSignButton;
        private System.Windows.Forms.Label xmlPfxSignatureAlgoLabel;
        private System.Windows.Forms.Label xmlPfxThumbprintLabel;
        private System.Windows.Forms.Label xmlPfxSerialNumberLabel;
        private System.Windows.Forms.Label xmlPfxExpireLabel;
        private System.Windows.Forms.Label xmlPfxValidFromLabel;
        private System.Windows.Forms.Label xmlPfxIssuerLabel;
        private System.Windows.Forms.Label xmlPfxVersionLabel;
        private System.Windows.Forms.Button xmlOpenOutputFolderButton;
        private System.Windows.Forms.TextBox xmlOutputFolderTextbox;
        private System.Windows.Forms.Label xmlOutputFolderLabel;
        private System.Windows.Forms.TextBox xmlPfxPasswordTextbox;
        private System.Windows.Forms.Button xmlPfxButton;
        private System.Windows.Forms.TextBox xmlPfxFileTextbox;
        private System.Windows.Forms.Label XmlPfxPasswordLabel;
        private System.Windows.Forms.Label xmlPfxFileLabel;
    }
}