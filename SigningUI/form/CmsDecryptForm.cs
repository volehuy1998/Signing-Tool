using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
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
    public partial class CmsDecryptForm : Form
    {
        class ComboKeySizeItem
        {
            public int ID { get; set; }
            public int KeySize { get; set; }
        }

        private List<string> EncryptedFiles { get; set; }

        public CmsDecryptForm(List<string> encryptedFiles, string outputFolder)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.EncryptedFiles = encryptedFiles;
            this.outputFolderTextbox.Text = outputFolder;
            this.keySizeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.keySizeComboBox.DisplayMember = "KeySize";
            this.keySizeComboBox.DataSource = new ComboKeySizeItem[]
            {
                 new ComboKeySizeItem{ ID = 1, KeySize = 128 },
                 new ComboKeySizeItem{ ID = 2, KeySize = 192 },
                 new ComboKeySizeItem{ ID = 3, KeySize = 256 }
            };

            for (int id = 0; id < this.EncryptedFiles.Count; id++)
            {
                ListViewItem eachRowFile = new ListViewItem((id + 1).ToString());
                ListViewItem.ListViewSubItem fileColumn = new ListViewItem.ListViewSubItem(eachRowFile, Path.GetFileName(this.EncryptedFiles[id]));
                ListViewItem.ListViewSubItem resultColumn = new ListViewItem.ListViewSubItem(eachRowFile, "");
                eachRowFile.SubItems.Add(fileColumn);
                eachRowFile.SubItems.Add(resultColumn);
                eachRowFile.BackColor = Color.LightGray;
                this.inputFileListview.Items.Add(eachRowFile);
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

        private void cmsDecryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                Pkcs5S2ParametersGenerator gen = new Pkcs5S2ParametersGenerator(new Sha256Digest());
                gen.Init(Encoding.UTF8.GetBytes(passwordAesTextbox.Text), Encoding.UTF8.GetBytes("salt"), 4096);
                byte[] aesKey = (gen.GenerateDerivedParameters((keySizeComboBox.SelectedItem as ComboKeySizeItem).KeySize) as KeyParameter).GetKey();

                for (int index = 0; index < this.EncryptedFiles.Count; index++)
                {
                    string rowResult = "NO";
                    Color rowColor = Color.IndianRed;
                    try
                    {
                        string inputFileName = Path.GetFileNameWithoutExtension(this.EncryptedFiles[index]);
                        string inputFileExtension = Path.GetExtension(this.EncryptedFiles[index]);
                        string outputFile = Path.Combine(this.outputFolderTextbox.Text, $"{inputFileName}_cms_encrypted{inputFileExtension}");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
                        SigningCore.Cms.BouncyCastle_DecryptCMS_Sym(this.EncryptedFiles[index], outputFile, aesKey);
                        rowResult = "Decrypted";
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

        private void inputFileListview_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem row = this.inputFileListview.SelectedItems[0];
            MessageBoxIcon messageBoxIcon = row.SubItems[2].Text.Equals("Decrypted", StringComparison.OrdinalIgnoreCase) ?
                MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(row.SubItems[2].Text, "Decrypted information", MessageBoxButtons.OK, messageBoxIcon);
        }
    }
}
