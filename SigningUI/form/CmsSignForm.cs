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

            for (int id = 0; id < this.InputFiles.Count; id++)
            {
                ListViewItem eachRowFile = new ListViewItem((id + 1).ToString());
                ListViewItem.ListViewSubItem fileColumn = new ListViewItem.ListViewSubItem(eachRowFile, Path.GetFileName(this.InputFiles[id]));
                ListViewItem.ListViewSubItem resultColumn = new ListViewItem.ListViewSubItem(eachRowFile, "");
                eachRowFile.SubItems.Add(fileColumn);
                eachRowFile.SubItems.Add(resultColumn);
                eachRowFile.BackColor = Color.LightGray;
                this.inputFileListview.Items.Add(eachRowFile);
            }
        }

        private void pfxButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog pfxFileDialog = new OpenFileDialog();
            pfxFileDialog.Title = "Please choose PKCS#12 file to sign";
            pfxFileDialog.Multiselect = false;
            if (pfxFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.pfxFileTextbox.Text = pfxFileDialog.FileName;
            }
        }

        private void cmsSignButton_Click(object sender, EventArgs e)
        {
            try
            {
                for (int index = 0; index < this.InputFiles.Count; index++)
                {
                    string rowResult = "NO";
                    Color rowColor = Color.IndianRed;
                    try
                    {
                        string inputFileName = Path.GetFileNameWithoutExtension(this.InputFiles[index]);
                        string inputFileExtension = Path.GetExtension(this.InputFiles[index]);
                        string outputFile = Path.Combine(this.outputFolderTextbox.Text, $"{inputFileName}_cms_signed{inputFileExtension}");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
                        SigningCore.Cms.BouncyCastle_SignCMS(this.InputFiles[index], outputFile, this.pfxFileTextbox.Text, this.pfxPasswordTextbox.Text);
                        rowResult = "Signed";
                        rowColor = Color.LightGreen;
                    }
                    catch (Exception ex)
                    {
                        rowResult = ex.Message;
                    }
                    this.inputFileListview.Items[index].SubItems[2].Text = rowResult;
                    this.inputFileListview.Items[index].BackColor = rowColor;
                    this.inputFileListview.Items[index].ToolTipText = rowResult;
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

        private void inputFileListview_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem row = this.inputFileListview.SelectedItems[0];
            MessageBoxIcon messageBoxIcon = row.SubItems[2].Text.Equals("Signed", StringComparison.OrdinalIgnoreCase) ?
                MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(row.SubItems[2].Text, "Sign information", MessageBoxButtons.OK, messageBoxIcon);
        }
    }
}
