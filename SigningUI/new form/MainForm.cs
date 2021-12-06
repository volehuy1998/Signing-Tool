using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Pkcs;
using SigningCore;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.ListViewItem;

namespace SigningUI.new_form
{
    public partial class MainForm : Form
    {
        private List<string> FilePaths { set; get; }
        private System.Security.Cryptography.X509Certificates.X509Certificate2 microsoftCert { get; set; }
        private Pkcs12Store pkcs12Store { get; set; }
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
            // json sign
            tooltip.SetToolTip(this.jsonPfxFileLabel, "Click to select PKCS#12 file");
            tooltip.SetToolTip(this.jsonPfxFileTextbox, "Double click to select PKCS#12 file");
            tooltip.SetToolTip(this.jsonPfxPasswordLabel, "Click to type PKCS#12 password");
            tooltip.SetToolTip(this.jsonPfxPasswordTextbox, "Click to type PKCS#12 password");
            tooltip.SetToolTip(this.jsonOutputFolderLabel, "Click to select output folder");
            tooltip.SetToolTip(this.jsonOutputFolderTextbox, "Double click to select output folder");
            // xml sign
            tooltip.SetToolTip(this.xmlPfxFileLabel, "Click to select PKCS#12 file");
            tooltip.SetToolTip(this.xmlPfxFileTextbox, "Double click to select PKCS#12 file");
            tooltip.SetToolTip(this.XmlPfxPasswordLabel, "Click to type PKCS#12 password");
            tooltip.SetToolTip(this.xmlPfxPasswordTextbox, "Click to type PKCS#12 password");
            tooltip.SetToolTip(this.xmlOutputFolderLabel, "Click to select output folder");
            tooltip.SetToolTip(this.xmlOutputFolderTextbox, "Double click to select output folder");
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
                this.FilePaths = inputFileDialog.FileNames.ToList();
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

        #region json output folder
        private void jsonOutputFolderLabel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog outputFolder = new FolderBrowserDialog();
            if (outputFolder.ShowDialog() == DialogResult.OK)
            {
                this.jsonOutputFolderTextbox.Text = outputFolder.SelectedPath;
            }
        }

        private void jsonOutputFolderTextbox_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog outputFolder = new FolderBrowserDialog();
            if (outputFolder.ShowDialog() == DialogResult.OK)
            {
                this.jsonOutputFolderTextbox.Text = outputFolder.SelectedPath;
            }
        }

        private void jsonOpenOutputFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(this.jsonOutputFolderTextbox.Text);
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
        #endregion json output folder

        #region xml output folder
        private void xmlOpenOutputFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(this.xmlOutputFolderTextbox.Text);
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

        private void xmlOutputFolderTextbox_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog outputFolder = new FolderBrowserDialog();
            if (outputFolder.ShowDialog() == DialogResult.OK)
            {
                this.xmlOutputFolderTextbox.Text = outputFolder.SelectedPath;
            }
        }

        private void xmlOutputFolderLabel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog outputFolder = new FolderBrowserDialog();
            if (outputFolder.ShowDialog() == DialogResult.OK)
            {
                this.xmlOutputFolderTextbox.Text = outputFolder.SelectedPath;
            }
        }
        #endregion xml output folder

        #region action
        private void cmsSignButton_Click(object sender, EventArgs e)
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
                        SigningCore.Cms.BouncyCastle_SignCMS(inputFile, outputFile, this.pkcs12Store);
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

        private void jsonSignButton_Click(object sender, EventArgs e)
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
                        JObject payloadObject = JObject.Parse(File.ReadAllText(inputFile));
                        string outputFile = ToolBoxHelper.GetOutputFile(
                            jsonOutputFolderTextbox.Text,
                            inputFile,
                            Mode.SIGN);
                        SigningCore.Json.Sign(payloadObject.ToString(), outputFile, this.pkcs12Store);
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

        private void xmlSignButton_Click(object sender, EventArgs e)
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
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(inputFile);
                        string outputFile = ToolBoxHelper.GetOutputFile(
                            xmlOutputFolderTextbox.Text,
                            inputFile,
                            Mode.SIGN);
                        SigningCore.Xml.Microsoft_SignXml(xmlDocument, this.pkcs12Store);
                        xmlDocument.Save(outputFile);
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
                    this.jsonPfxFileTextbox.Text = pfxFileDialog.FileName;
                    this.xmlPfxFileTextbox.Text = pfxFileDialog.FileName;
                    Pkcs12PasswordForm pkcs12PasswordForm = new Pkcs12PasswordForm();
                    DialogResult pkcs12PwdFormResult = pkcs12PasswordForm.ShowDialog();
                    if (pkcs12PwdFormResult == DialogResult.OK)
                    {
                        // get microsoft certificate from pfx
                        this.pfxPasswordTextbox.Text = pkcs12PasswordForm.Pkcs12Password;
                        this.jsonPfxPasswordTextbox.Text = pkcs12PasswordForm.Pkcs12Password;
                        this.xmlPfxPasswordTextbox.Text = pkcs12PasswordForm.Pkcs12Password;
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
                        // update json pfx data
                        ToolBoxHelper.UpdateLabelData(this.jsonPfxVersionLabel, microsoftCert.Version.ToString());
                        ToolBoxHelper.UpdateLabelData(this.jsonPfxIssuerLabel, microsoftCert.Issuer);
                        ToolBoxHelper.UpdateLabelData(this.jsonPfxSerialNumberLabel, microsoftCert.SerialNumber);
                        ToolBoxHelper.UpdateLabelData(this.jsonPfxThumbprintLabel, microsoftCert.Thumbprint);
                        ToolBoxHelper.UpdateLabelData(this.jsonPfxSignatureAlgoLabel, microsoftCert.SignatureAlgorithm.FriendlyName);
                        ToolBoxHelper.UpdateLabelData(this.jsonPfxValidFromLabel, microsoftCert.NotBefore.ToString());
                        ToolBoxHelper.UpdateLabelData(this.jsonPfxExpireLabel, microsoftCert.NotAfter.ToString());
                        // update xml pfx data
                        ToolBoxHelper.UpdateLabelData(this.xmlPfxVersionLabel, microsoftCert.Version.ToString());
                        ToolBoxHelper.UpdateLabelData(this.xmlPfxIssuerLabel, microsoftCert.Issuer);
                        ToolBoxHelper.UpdateLabelData(this.xmlPfxSerialNumberLabel, microsoftCert.SerialNumber);
                        ToolBoxHelper.UpdateLabelData(this.xmlPfxThumbprintLabel, microsoftCert.Thumbprint);
                        ToolBoxHelper.UpdateLabelData(this.xmlPfxSignatureAlgoLabel, microsoftCert.SignatureAlgorithm.FriendlyName);
                        ToolBoxHelper.UpdateLabelData(this.xmlPfxValidFromLabel, microsoftCert.NotBefore.ToString());
                        ToolBoxHelper.UpdateLabelData(this.xmlPfxExpireLabel, microsoftCert.NotAfter.ToString());
                        // get bouncy castle certificate from pfx
                        pkcs12Store = Helper.GetPkcs12Store(
                            this.pfxFileTextbox.Text,
                            this.pfxPasswordTextbox.Text);
                    }
                }
                this.pfxFileTextbox.Text = pfxFileDialog.FileName;
                this.jsonPfxFileTextbox.Text = pfxFileDialog.FileName;
                this.xmlPfxFileTextbox.Text = pfxFileDialog.FileName;
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
                if (Common.CheckString(this.pfxFileTextbox.Text) &&
                    Common.CheckString(this.jsonPfxFileTextbox.Text))
                    throw new Exception("Not found any PKCS#12 file");

                Pkcs12PasswordForm pkcs12PasswordForm = new Pkcs12PasswordForm();
                if (pkcs12PasswordForm.ShowDialog() == DialogResult.OK)
                {
                    // get microsoft certificate from pfx
                    this.pfxPasswordTextbox.Text = pkcs12PasswordForm.Pkcs12Password;
                    this.jsonPfxPasswordTextbox.Text = pkcs12PasswordForm.Pkcs12Password;
                    this.xmlPfxPasswordTextbox.Text = pkcs12PasswordForm.Pkcs12Password;
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
                    // update json pfx data
                    ToolBoxHelper.UpdateLabelData(this.jsonPfxVersionLabel, microsoftCert.Version.ToString());
                    ToolBoxHelper.UpdateLabelData(this.jsonPfxIssuerLabel, microsoftCert.Issuer);
                    ToolBoxHelper.UpdateLabelData(this.jsonPfxSerialNumberLabel, microsoftCert.SerialNumber);
                    ToolBoxHelper.UpdateLabelData(this.jsonPfxThumbprintLabel, microsoftCert.Thumbprint);
                    ToolBoxHelper.UpdateLabelData(this.jsonPfxSignatureAlgoLabel, microsoftCert.SignatureAlgorithm.FriendlyName);
                    ToolBoxHelper.UpdateLabelData(this.jsonPfxValidFromLabel, microsoftCert.NotBefore.ToString());
                    ToolBoxHelper.UpdateLabelData(this.jsonPfxExpireLabel, microsoftCert.NotAfter.ToString());
                    // update xml pfx data
                    ToolBoxHelper.UpdateLabelData(this.xmlPfxVersionLabel, microsoftCert.Version.ToString());
                    ToolBoxHelper.UpdateLabelData(this.xmlPfxIssuerLabel, microsoftCert.Issuer);
                    ToolBoxHelper.UpdateLabelData(this.xmlPfxSerialNumberLabel, microsoftCert.SerialNumber);
                    ToolBoxHelper.UpdateLabelData(this.xmlPfxThumbprintLabel, microsoftCert.Thumbprint);
                    ToolBoxHelper.UpdateLabelData(this.xmlPfxSignatureAlgoLabel, microsoftCert.SignatureAlgorithm.FriendlyName);
                    ToolBoxHelper.UpdateLabelData(this.xmlPfxValidFromLabel, microsoftCert.NotBefore.ToString());
                    ToolBoxHelper.UpdateLabelData(this.xmlPfxExpireLabel, microsoftCert.NotAfter.ToString());
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
    }
}
