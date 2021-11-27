using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
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

namespace SigningUI.form
{
    public partial class CmsVerifyForm : Form
    {
        private X509Certificate bouncycastleCert = null;
        private List<string> signedInputFiles = null;
        public CmsVerifyForm(List<string> signedInputFiles)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.signedInputFiles = signedInputFiles;

            for (int id = 0; id < this.signedInputFiles.Count; id++)
            {
                ListViewItem eachRowFile = new ListViewItem((id+1).ToString());
                ListViewItem.ListViewSubItem fileColumn = new ListViewItem.ListViewSubItem(eachRowFile, Path.GetFileName(this.signedInputFiles[id]));
                ListViewItem.ListViewSubItem resultColumn = new ListViewItem.ListViewSubItem(eachRowFile, "");
                eachRowFile.SubItems.Add(fileColumn);
                eachRowFile.SubItems.Add(resultColumn);
                eachRowFile.BackColor = Color.LightGray;
                this.signedInputFileListview.Items.Add(eachRowFile);
            }
        }

        private void selectMicrosoftCertButton_Click(object sender, EventArgs e)
        {
            System.Security.Cryptography.X509Certificates.X509Certificate2 microsoftCert = Helper.GetMicrosoftCert();
            bouncycastleCert = DotNetUtilities.FromX509Certificate(microsoftCert);
            this.microsoftCertThumprintTextBox.Text = microsoftCert.Thumbprint;
            this.microsoftCertThumprintTextBox.BackColor = Color.LightGreen;
        }

        private void cmsVerifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.bouncycastleCert == null)
                    throw new Exception("Please select certificate");

                for (int index = 0; index < this.signedInputFileListview.Items.Count; index++)
                {
                    bool result = false;
                    string rowResult = "NO";
                    Color rowColor = Color.IndianRed;
                    try
                    {
                        result = SigningCore.Cms.BouncyCastle_VerifyCMS(this.signedInputFiles[index], this.bouncycastleCert);
                        if (result)
                        {
                            rowResult = "YES";
                            rowColor = Color.LightGreen;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    this.signedInputFileListview.Items[index].SubItems[2].Text = rowResult;
                    this.signedInputFileListview.Items[index].BackColor = rowColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
