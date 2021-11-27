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

namespace SigningUI.form
{
    public partial class CmsSignForm : Form
    {
        public List<string> InputFiles { get; set; }
        public CmsSignForm(List<string> inputFiles, string outputFolder)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.InputFiles = inputFiles;
            this.outputFolderTextbox.Text = outputFolder;
            this.inputFilesListBox.Items.AddRange(this.InputFiles.ToArray());
        }

        private void pfxButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog pfxFileDialog = new OpenFileDialog();
            pfxFileDialog.Title = "Please choose PKCS#12 file to sign";
            pfxFileDialog.Multiselect = false;
            pfxFileDialog.Filter = ToolBoxHelper.GetFileFilterMode("cms");
            if (pfxFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.pfxFileTextbox.Text = pfxFileDialog.FileName;
            }
        }

        private void cmsSignButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string inputFile in this.InputFiles)
                {
                    string inputFileName = Path.GetFileNameWithoutExtension(inputFile);
                    string inputFileExtension = Path.GetExtension(inputFile);
                    string outputFile = Path.Combine(this.outputFolderTextbox.Text, $"{inputFileName}_ cms_signed{inputFileExtension}");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
                    SigningCore.Cms.BouncyCastle_SignCMS(inputFile, outputFile, this.pfxFileTextbox.Text, this.pfxPasswordTextbox.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openOutputFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(this.outputFolderTextbox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
