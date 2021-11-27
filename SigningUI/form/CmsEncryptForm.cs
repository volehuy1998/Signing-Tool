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
    public partial class CmsEncryptForm : Form
    {
        class ComboKeySizeItem
        {
            public int ID { get; set; }
            public int KeySize { get; set; }
        }

        private List<string> InputFiles { get; set; }
        public CmsEncryptForm(List<string> inputFiles, string outputFolder)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.InputFiles = inputFiles;
            this.outputFolderTextbox.Text = outputFolder;
            this.keySizeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.keySizeComboBox.DisplayMember = "KeySize";
            this.keySizeComboBox.DataSource = new ComboKeySizeItem[]
            {
                new ComboKeySizeItem{ ID = 1, KeySize = 128 },
                new ComboKeySizeItem{ ID = 2, KeySize = 192 },
                new ComboKeySizeItem{ ID = 3, KeySize = 256 }
            };

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

        private void cmsEncryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                Pkcs5S2ParametersGenerator gen = new Pkcs5S2ParametersGenerator(new Sha256Digest());
                gen.Init(Encoding.UTF8.GetBytes(passwordAesTextbox.Text), Encoding.UTF8.GetBytes("salt"), 4096);
                byte[] aesKey = (gen.GenerateDerivedParameters((keySizeComboBox.SelectedItem as ComboKeySizeItem).KeySize) as KeyParameter).GetKey();

                foreach (string inputFile in this.InputFiles)
                {
                    string inputFileName = Path.GetFileNameWithoutExtension(inputFile);
                    string inputFileExtension = Path.GetExtension(inputFile);
                    string outputFile = Path.Combine(this.outputFolderTextbox.Text, $"{inputFileName}_cms_encrypted{inputFileExtension}");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
                    SigningCore.Cms.BouncyCastle_EncryptCMS_Sym(inputFile, outputFile, aesKey);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
