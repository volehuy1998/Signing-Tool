using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using SigningCore;
using SigningCore.test;
using SigningUI.form;
using SigningUI.help;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.ListViewItem;

namespace SigningUI.new_form
{
    public partial class MainForm : Form
    {
        private List<string> FilePaths { set; get; }
        private System.Security.Cryptography.X509Certificates.X509Certificate2 microsoftCert { get; set; }
        private Pkcs12Store pkcs12Store { get; set; }
        private Org.BouncyCastle.X509.X509Certificate bouncyCert { get; set; }

        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.CenterToScreen();

            ToolTip tooltip = new ToolTip();
            // cms sign
            tooltip.SetToolTip(this.pfxFileLabel, "Click to select PKCS#12 file");
            tooltip.SetToolTip(this.pfxFileTextbox, "Double click to select PKCS#12 file");
            tooltip.SetToolTip(this.pfxPasswordLabel, "Click to type PKCS#12 password");
            tooltip.SetToolTip(this.pfxPasswordTextbox, "Click to type PKCS#12 password");
            tooltip.SetToolTip(this.outputFolderLabel, "Click to select output folder");
            tooltip.SetToolTip(this.outputFolderTextbox, "Double click to select output folder");
            tooltip.InitialDelay = 10;
            tooltip.ReshowDelay = 10;
            tooltip.ShowAlways = true;
        }

        private void closeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chương trình ký số được thực hiện bởi sinh viên Võ Lê Huy nhằm đáp ứng đồ án tốt nghiệp tại Học viện Kỹ thuật mật mã",
                "Thông tin về chương trình",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void inputFileListview_DoubleClick(object sender, EventArgs e)
        {
            string caption = string.Empty;
            string content = string.Empty;
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Error;
            ListViewItem row = this.inputFileListview.SelectedItems[0];
            if (ToolBoxHelper.CompareString(row.SubItems[2].Text, "Signed") ||
                ToolBoxHelper.CompareString(row.SubItems[2].Text, "Verified") ||
                ToolBoxHelper.CompareString(row.SubItems[2].Text, "Encrypted") ||
                ToolBoxHelper.CompareString(row.SubItems[2].Text, "Decrypted"))
            {
                messageBoxIcon = MessageBoxIcon.Information;
                caption = $"{row.SubItems[2].Text} information";
                content = row.SubItems[2].Text + " " + row.SubItems[1].Text;
            }
            else
            {
                caption = $"{row.SubItems[2].Text} error";
                content = row.SubItems[2].Text;
            }

            MessageBox.Show(content, caption, MessageBoxButtons.OK, messageBoxIcon);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            if (ToolBoxHelper.CompareString(this.tabControl.SelectedTab.Text, "JSON Sign"))
                inputFileDialog.Filter = "JSON Files|*.json";
            inputFileDialog.Multiselect = true;
            inputFileDialog.Title = $"Choose input files";
            if (inputFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (this.FilePaths?.Count > 0)
                {
                    if (MessageBox.Show(
                    "Input view isn't empty, do you want to clear?",
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.FilePaths = inputFileDialog.FileNames.ToList();
                    }
                    else
                    {
                        this.FilePaths.AddRange(inputFileDialog.FileNames.ToList());
                    }
                }
                else
                {
                    this.FilePaths = inputFileDialog.FileNames.ToList();
                }
                this.inputFileListview.Items.Clear();

                for (int id = 0; id < this.FilePaths.Count; id++)
                {
                    ListViewItem eachRowFile = new ListViewItem((id + 1).ToString());
                    ListViewItem.ListViewSubItem fileColumn = new ListViewItem.ListViewSubItem(eachRowFile, this.FilePaths[id]);
                    ListViewItem.ListViewSubItem resultColumn = new ListViewItem.ListViewSubItem(eachRowFile, "");
                    eachRowFile.SubItems.Add(fileColumn);
                    eachRowFile.SubItems.Add(resultColumn);
                    this.inputFileListview.Items.Add(eachRowFile);
                }
            }
        }

        #region cms output folder
        private void openOutputFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(this.outputFolderTextbox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Open output folder error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void outputFolderTextbox_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog outputFolder = new FolderBrowserDialog();
            if (outputFolder.ShowDialog() == DialogResult.OK)
            {
                this.outputFolderTextbox.Text = outputFolder.SelectedPath;
            }
        }

        private void outputFolderLabel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog outputFolder = new FolderBrowserDialog();
            if (outputFolder.ShowDialog() == DialogResult.OK)
            {
                this.outputFolderTextbox.Text = outputFolder.SelectedPath;
            }
        }
        #endregion cms output folder

        #region action
        private void signButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.FilePaths == null || this.FilePaths.Count < 1)
                    throw new Exception("Not found any input files");

                foreach (string inputFile in this.FilePaths)
                {
                    string rowResult = "NO";
                    Color rowColor = Color.IndianRed;
                    try
                    {
                        string outputFile = ToolBoxHelper.GetOutputFile(
                            outputFolderTextbox.Text,
                            inputFile,
                            Mode.SIGN);
                        if (cMSToolStripMenuItem.Checked)
                        {
                            SigningCore.Cms.BouncyCastle_SignCMS(inputFile, outputFile, this.pkcs12Store);
                        }
                        else if (xMLToolStripMenuItem.Checked)
                        {
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.Load(inputFile);
                            SigningCore.Xml.Microsoft_SignXml(xmlDocument, this.pkcs12Store);
                            xmlDocument.Save(outputFile);
                        }
                        else if (jSONToolStripMenuItem.Checked)
                        {
                            JObject payloadObject = JObject.Parse(File.ReadAllText(inputFile));
                            string jwt = SigningCore.Json.Sign(payloadObject.ToString(), outputFile, this.pkcs12Store);
                            File.WriteAllText(outputFile, jwt);
                        }

                        rowResult = "Signed";
                        rowColor = Color.LightGreen;
                    }
                    catch (Exception ex)
                    {
                        rowResult = ex.Message;
                    }
                    ListViewItem row = ToolBoxHelper.GetListViewItemByName(this.inputFileListview, inputFile);
                    row.SubItems[2].Text = rowResult;
                    row.BackColor = rowColor;
                    row.ToolTipText = rowResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Sign error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void verifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.FilePaths == null || this.FilePaths.Count < 1)
                    throw new Exception("Not found any input files");

                foreach (string inputFile in this.FilePaths)
                {
                    string rowResult = "NO";
                    Color rowColor = Color.IndianRed;
                    try
                    {
                        if (cMSToolStripMenuItem.Checked)
                        {
                            SigningCore.Cms.BouncyCastle_VerifyCMS(inputFile, this.bouncyCert);
                        }
                        else if (xMLToolStripMenuItem.Checked)
                        {
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.Load(inputFile);
                            if (!SigningCore.Xml.Microsoft_VerifyXml(xmlDocument))
                                throw new Exception("Verify fail because your data or signature");
                        }
                        else if (jSONToolStripMenuItem.Checked)
                        {
                            SigningCore.Json.Decode(File.ReadAllText(inputFile));
                        }

                        rowResult = "Verified";
                        rowColor = Color.LightGreen;
                    }
                    catch (Exception ex)
                    {
                        rowResult = ex.Message;
                    }
                    ListViewItem row = ToolBoxHelper.GetListViewItemByName(this.inputFileListview, inputFile);
                    row.SubItems[2].Text = rowResult;
                    row.BackColor = rowColor;
                    row.ToolTipText = rowResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Sign error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            Crypt(isEncrypt: true);
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            Crypt(isEncrypt: false);
        }
        #endregion

        private void pfxFileButton_Click(object sender, EventArgs e)
        {
            this.SetupPfxFile();
        }

        private void pfxFileTextbox_DoubleClick(object sender, EventArgs e)
        {
            this.SetupPfxFile();
        }

        private void pfxFileLabel_Click(object sender, EventArgs e)
        {
            this.SetupPfxFile();
        }

        private void pfxPasswordLabel_Click(object sender, EventArgs e)
        {
            this.SetupPfxPwd();
        }

        private void pfxPasswordTextbox_Click(object sender, EventArgs e)
        {
            this.SetupPfxPwd();
        }

        private void SetupPfxFile()
        {
            try
            {
                OpenFileDialog pfxFileDialog = new OpenFileDialog();
                pfxFileDialog.Title = "Please choose PKCS#12 file to sign";
                pfxFileDialog.Multiselect = false;
                pfxFileDialog.Filter = "PKCS#12 Files|*.pfx;*.p12";
                if (pfxFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.pfxFileTextbox.Text = pfxFileDialog.FileName;
                    Pkcs12PasswordForm pkcs12PasswordForm = new Pkcs12PasswordForm();
                    DialogResult pkcs12PwdFormResult = pkcs12PasswordForm.ShowDialog();
                    if (pkcs12PwdFormResult == DialogResult.OK)
                    {
                        // get microsoft certificate from pfx
                        this.pfxPasswordTextbox.Text = pkcs12PasswordForm.Pkcs12Password;
                        microsoftCert = new System.Security.Cryptography.X509Certificates.X509Certificate2(
                            this.pfxFileTextbox.Text,
                            this.pfxPasswordTextbox.Text
                        );
                        // update cms pfx data
                        ToolBoxHelper.UpdateLabelData(this.pfxVersionLabel, microsoftCert.Version.ToString());
                        ToolBoxHelper.UpdateLabelData(this.pfxIssuerLabel, microsoftCert.Issuer);
                        ToolBoxHelper.UpdateLabelData(this.pfxSerialNumberLabel, microsoftCert.SerialNumber);
                        ToolBoxHelper.UpdateLabelData(this.pfxThumbprintLabel, microsoftCert.Thumbprint);
                        ToolBoxHelper.UpdateLabelData(this.pfxSignatureAlgoLabel, microsoftCert.SignatureAlgorithm.FriendlyName);
                        ToolBoxHelper.UpdateLabelData(this.pfxValidFromLabel, microsoftCert.NotBefore.ToString());
                        ToolBoxHelper.UpdateLabelData(this.pfxExpireLabel, microsoftCert.NotAfter.ToString());
                        // get bouncy castle certificate from pfx
                        pkcs12Store = Helper.GetPkcs12Store(
                            this.pfxFileTextbox.Text,
                            this.pfxPasswordTextbox.Text);
                    }
                }
                this.pfxFileTextbox.Text = pfxFileDialog.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Open output folder error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SetupPfxPwd()
        {
            try
            {
                if (Common.CheckString(this.pfxFileTextbox.Text))
                    throw new Exception("Not found any PKCS#12 file");

                Pkcs12PasswordForm pkcs12PasswordForm = new Pkcs12PasswordForm();
                if (pkcs12PasswordForm.ShowDialog() == DialogResult.OK)
                {
                    // get microsoft certificate from pfx
                    this.pfxPasswordTextbox.Text = pkcs12PasswordForm.Pkcs12Password;
                    microsoftCert = new System.Security.Cryptography.X509Certificates.X509Certificate2(
                        this.pfxFileTextbox.Text,
                        this.pfxPasswordTextbox.Text
                    );
                    // update cms pfx data
                    ToolBoxHelper.UpdateLabelData(this.pfxVersionLabel, microsoftCert.Version.ToString());
                    ToolBoxHelper.UpdateLabelData(this.pfxIssuerLabel, microsoftCert.Issuer);
                    ToolBoxHelper.UpdateLabelData(this.pfxSerialNumberLabel, microsoftCert.SerialNumber);
                    ToolBoxHelper.UpdateLabelData(this.pfxThumbprintLabel, microsoftCert.Thumbprint);
                    ToolBoxHelper.UpdateLabelData(this.pfxSignatureAlgoLabel, microsoftCert.SignatureAlgorithm.FriendlyName);
                    ToolBoxHelper.UpdateLabelData(this.pfxValidFromLabel, microsoftCert.NotBefore.ToString());
                    ToolBoxHelper.UpdateLabelData(this.pfxExpireLabel, microsoftCert.NotAfter.ToString());
                    // get bouncy castle certificate from pfx
                    pkcs12Store = Helper.GetPkcs12Store(
                        this.pfxFileTextbox.Text,
                        this.pfxPasswordTextbox.Text);
                }
            }
            catch (Exception ex)
            {
                pkcs12Store = null;
                MessageBox.Show(
                    ex.Message,
                    "Error message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SetupPfxFromKeyStore()
        {
            try
            {
                this.microsoftCert = Helper.GetMicrosoftCert();
                if (this.microsoftCert != null)
                {
                    // update cms pfx data
                    ToolBoxHelper.UpdateLabelData(this.cmsVerifyPfxVersionLabel, microsoftCert.Version.ToString());
                    ToolBoxHelper.UpdateLabelData(this.cmsVerifyPfxIssuerLabel, microsoftCert.Issuer);
                    ToolBoxHelper.UpdateLabelData(this.cmsVerifyPfxSerialNumberLabel, microsoftCert.SerialNumber);
                    ToolBoxHelper.UpdateLabelData(this.cmsVerifyPfxThumbprintLabel, microsoftCert.Thumbprint);
                    ToolBoxHelper.UpdateLabelData(this.cmsVerifyPfxSignatureAlgoLabel, microsoftCert.SignatureAlgorithm.FriendlyName);
                    ToolBoxHelper.UpdateLabelData(this.cmsVerifyPfxValidFromLabel, microsoftCert.NotBefore.ToString());
                    ToolBoxHelper.UpdateLabelData(this.cmsVerifyPfxExpireLabel, microsoftCert.NotAfter.ToString());
                    this.verifyMicrosoftCertThumbprintTextbox.Text = microsoftCert.Thumbprint;
                    this.bouncyCert = DotNetUtilities.FromX509Certificate(this.microsoftCert);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                   ex.Message,
                   "Select certificate error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }


        #region cms hover
        private void outputFolderTextbox_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void outputFolderTextbox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void pfxPasswordTextbox_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pfxPasswordTextbox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void outputFolderLabel_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void outputFolderLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
        private void pfxFileLabel_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pfxFileLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void pfxPasswordLabel_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pfxPasswordLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void pfxFileTextbox_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pfxFileTextbox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
        #endregion cms hover

        #region json hover
        private void jsonPfxFileLabel_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void jsonPfxFileLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void jsonPfxFileTextbox_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void jsonPfxFileTextbox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void jsonPfxPwdLabel_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void jsonPfxPwdLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void jsonPfxPwdTextbox_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void jsonPfxPwdTextbox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void jsonOutputFolderLabel_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void jsonOutputFolderLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void jsonOutputFolderTextbox_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void jsonOutputFolderTextbox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
        #endregion json hover

        #region xml hover
        private void xmlPfxFileLabel_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void XmlPfxPasswordLabel_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void xmlPfxFileTextbox_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void xmlPfxPasswordTextbox_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void xmlOutputFolderTextbox_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void xmlOutputFolderLabel_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void xmlPfxFileLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void xmlPfxFileTextbox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void XmlPfxPasswordLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void xmlPfxPasswordTextbox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void xmlOutputFolderTextbox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void xmlOutputFolderLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        #endregion xml hover

        private void jsonPfxFileLabel_Click(object sender, EventArgs e)
        {
            this.SetupPfxFile();
        }

        private void jsonPfxFileTextbox_DoubleClick(object sender, EventArgs e)
        {
            this.SetupPfxFile();
        }

        private void jsonPfxFileBrowserButton_Click(object sender, EventArgs e)
        {
            this.SetupPfxFile();
        }

        private void jsonPfxPwdLabel_Click(object sender, EventArgs e)
        {
            this.SetupPfxPwd();
        }

        private void jsonPfxPwdTextbox_Click(object sender, EventArgs e)
        {
            this.SetupPfxPwd();
        }

        private void xmlPfxButton_Click(object sender, EventArgs e)
        {
            this.SetupPfxFile();
        }

        private void xmlPfxFileTextbox_DoubleClick(object sender, EventArgs e)
        {
            this.SetupPfxFile();
        }

        private void xmlPfxFileLabel_Click(object sender, EventArgs e)
        {
            this.SetupPfxFile();
        }

        private void xmlPfxPasswordTextbox_DoubleClick(object sender, EventArgs e)
        {
            this.SetupPfxPwd();
        }

        private void XmlPfxPasswordLabel_Click(object sender, EventArgs e)
        {
            this.SetupPfxPwd();
        }

        private void cmsMicrosoftCertThumbprintTextbox_DoubleClick(object sender, EventArgs e)
        {
            this.SetupPfxFromKeyStore();
        }

        private void cmsMicrosoftCertSelectButton_Click(object sender, EventArgs e)
        {
            this.SetupPfxFromKeyStore();
        }

        private void cMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolBoxHelper.UncheckOtherToolStripMenuItems(sender as ToolStripMenuItem);
            this.verifyMicrosoftCertThumbprintTextbox.Enabled = true;
            this.cmsMicrosoftCertSelectButton.Enabled = true;
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolBoxHelper.UncheckOtherToolStripMenuItems(sender as ToolStripMenuItem);
            this.verifyMicrosoftCertThumbprintTextbox.Enabled = false;
            this.cmsMicrosoftCertSelectButton.Enabled = false;
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolBoxHelper.UncheckOtherToolStripMenuItems(sender as ToolStripMenuItem);
            this.verifyMicrosoftCertThumbprintTextbox.Enabled = false;
            this.cmsMicrosoftCertSelectButton.Enabled = false;
        }

        private void cryptOutputButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(this.cryptOutputTextbox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Open output folder error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cryptOutputTextbox_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog outputFolder = new FolderBrowserDialog();
            if (outputFolder.ShowDialog() == DialogResult.OK)
            {
                this.cryptOutputTextbox.Text = outputFolder.SelectedPath;
            }
        }

        private void Crypt(bool isEncrypt = true)
        {
            try
            {
                if (this.FilePaths == null || this.FilePaths.Count < 1)
                    throw new Exception("Not found any input files");
                if (keySizeComboBox.SelectedItem == null)
                    throw new Exception("Please choose key size");

                int keySize = int.Parse(keySizeComboBox.SelectedItem.ToString());
                byte[] aesKey = Helper.GetAesKeyByPassword(passwordAesTextbox.Text, keySize);
               
                foreach (string inputFile in this.FilePaths)
                {
                    string rowResult = "NO";
                    Color rowColor = Color.IndianRed;
                    try
                    {
                        string outputFile = ToolBoxHelper.GetOutputFile(
                               cryptOutputTextbox.Text,
                               inputFile,
                               Mode.CRYPT);
                        if (cMSToolStripMenuItem.Checked)
                        {
                            if (isEncrypt)
                            {
                                SigningCore.Cms.BouncyCastle_EncryptCMS_Sym(inputFile, outputFile, aesKey);
                                rowResult = "Encrypted";
                            }
                            else
                            {
                                outputFile = ToolBoxHelper.GetOutputFile(cryptOutputTextbox.Text, inputFile, Mode.CRYPT, false);
                                SigningCore.Cms.BouncyCastle_DecryptCMS_Sym(inputFile, outputFile, aesKey);
                                rowResult = "Decrypted";
                            }
                        }
                        else if (xMLToolStripMenuItem.Checked)
                        {
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.Load(inputFile);
                            Aes aes = Aes.Create();
                            aes.KeySize = keySize;
                            aes.GenerateIV();
                            aes.Key = aesKey;
                            aes.Mode = CipherMode.ECB;
                            if (isEncrypt)
                            {
                                List<string> tagNames = new List<string>();
                                foreach (var name in XDocument.Load(inputFile).Root.DescendantNodes().OfType<XElement>()
                                    .Select(x => x.Name).Distinct())
                                {
                                    tagNames.Add(name.LocalName);
                                }
                                XmlDocument encryptedDoc = SigningCore.Xml.Microsoft_EncryptXML_Sym(xmlDocument, tagNames, aes);
                                encryptedDoc.Save(outputFile);
                                rowResult = "Encrypted";
                            }
                            else
                            {
                                outputFile = ToolBoxHelper.GetOutputFile(cryptOutputTextbox.Text, inputFile, Mode.CRYPT, false);
                                XmlDocument decryptedDoc = SigningCore.Xml.Microsoft_DecryptXML_Sym(xmlDocument, aes);
                                decryptedDoc.Save(outputFile);
                                rowResult = "Decrypted";
                            }
                        }
                        else if (jSONToolStripMenuItem.Checked)
                        {
                            throw new Exception("JSON crypt don't support yet");
                            if (isEncrypt)
                            {
                                UserInfo user = new UserInfo
                                {
                                    UserName = "jschmoe",
                                    UserPassword = "Hunter2",
                                    FavoriteColor = "atomic tangerine",
                                    CreditCardNumber = "1234567898765432",
                                };

                                SigningCore.Json.Encrypt(user, null);
                                rowResult = "Encrypted";
                            }
                            else
                            {
                                rowResult = "Decrypted";
                            }
                        }
                        rowColor = Color.LightGreen;
                    }
                    catch (Exception ex)
                    {
                        rowResult = ex.Message;
                    }
                    ListViewItem row = ToolBoxHelper.GetListViewItemByName(this.inputFileListview, inputFile);
                    row.SubItems[2].Text = rowResult;
                    row.BackColor = rowColor;
                    row.ToolTipText = rowResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void passwordAesTextbox_DoubleClick(object sender, EventArgs e)
        {
        }
    }
}
