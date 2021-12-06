using Org.BouncyCastle.Pkcs;
using SigningCore;
using SigningUI.help;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SigningUI.new_form
{
    public partial class NewCmsSignForm : Form
    {
        public List<string> InputFiles { get; set; }
        public NewCmsSignForm(List<string> input)
        {
            InitializeComponent();
            this.CenterToScreen();
            ToolBoxHelper.AdjustTemplateForm(this);
            this.InputFiles = input;
        }

        private void pfxFileTextbox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog pfxFileDialog = new OpenFileDialog();
            pfxFileDialog.Title = "Please choose PKCS#12 file to sign";
            pfxFileDialog.Multiselect = false;
            if (pfxFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.pfxFileTextbox.Text = pfxFileDialog.FileName;
            }
        }

        private void loadPfxButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(
                    File.ReadAllBytes(this.pfxFileTextbox.Text),
                    this.pfxPwdTextbox.Text);
                ToolBoxHelper.UpdateLabelData(this.pfxVersionLabel, cert.Version.ToString());
                ToolBoxHelper.UpdateLabelData(this.pfxIssuerLabel, cert.Issuer);
                ToolBoxHelper.UpdateLabelData(this.pfxSerialNumberLabel, cert.SerialNumber);
                ToolBoxHelper.UpdateLabelData(this.pfxThumbprintLabel, cert.Thumbprint);
                ToolBoxHelper.UpdateLabelData(this.pfxSignatureAlgoLabel, cert.SignatureAlgorithm.FriendlyName);
                ToolBoxHelper.UpdateLabelData(this.pfxValidFromLabel, cert.NotBefore.ToString());
                ToolBoxHelper.UpdateLabelData(this.pfxExpireLabel, cert.NotAfter.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void cmsSignButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.InputFiles == null || this.InputFiles.Count < 1)
                    throw new Exception("Input file null to sign");
                if (Common.CheckString(this.outputFolderLabel.Text))
                    throw new Exception("Output folder null to sign");

                for (int index = 0; index < this.InputFiles.Count; index++)
                {
                    string rowResult = "NO";
                    Color rowColor = Color.IndianRed;
                    try
                    {
                        string inputFileName = Path.GetFileNameWithoutExtension(this.InputFiles[index]);
                        string inputFileExtension = Path.GetExtension(this.InputFiles[index]);
                        string outputFile = Path.Combine(this.outputFolderLabel.Text, $"{inputFileName}_cms_signed{inputFileExtension}");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
                        SigningCore.Cms.BouncyCastle_SignCMS(this.InputFiles[index], outputFile, this.pfxFileTextbox.Text, this.pfxPwdTextbox.Text);
                        rowResult = "Signed";
                        rowColor = Color.LightGreen;
                    }
                    catch (Exception ex)
                    {
                        rowResult = ex.Message;
                    }
                    this.outputFilesListView.Items[index].SubItems[2].Text = rowResult;
                    this.outputFilesListView.Items[index].BackColor = rowColor;
                    this.outputFilesListView.Items[index].ToolTipText = rowResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog outputFolderBrowserDialog = new FolderBrowserDialog();
            outputFolderBrowserDialog.Description = $"Select output folder of sign action for CMS mode";
            if (outputFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.outputFolderTextbox.Text = outputFolderBrowserDialog.SelectedPath;
            }
        }
    }
}
