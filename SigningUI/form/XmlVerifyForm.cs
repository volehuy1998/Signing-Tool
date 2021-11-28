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
using System.Xml;

namespace SigningUI.form
{
    public partial class XmlVerifyForm : Form
    {
        private List<string> signedInputFiles = null;
        public XmlVerifyForm(List<string> signedInputFiles)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.signedInputFiles = signedInputFiles;

            for (int id = 0; id < this.signedInputFiles.Count; id++)
            {
                ListViewItem eachRowFile = new ListViewItem((id + 1).ToString());
                ListViewItem.ListViewSubItem fileColumn = new ListViewItem.ListViewSubItem(eachRowFile, Path.GetFileName(this.signedInputFiles[id]));
                ListViewItem.ListViewSubItem resultColumn = new ListViewItem.ListViewSubItem(eachRowFile, "");
                eachRowFile.SubItems.Add(fileColumn);
                eachRowFile.SubItems.Add(resultColumn);
                eachRowFile.BackColor = Color.LightGray;
                this.signedInputFileListview.Items.Add(eachRowFile);
            }
        }

        private void xmlVerifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                for (int index = 0; index < this.signedInputFileListview.Items.Count; index++)
                {
                    bool result = false;
                    string rowResult = "Data or signature was modified";
                    Color rowColor = Color.IndianRed;
                    try
                    {
                        XmlDocument signedXmlDoc = new XmlDocument();
                        signedXmlDoc.Load(this.signedInputFiles[index]);
                        result = SigningCore.Xml.Microsoft_VerifyXml(signedXmlDoc);
                        if (result)
                        {
                            rowResult = "Verified";
                            rowColor = Color.LightGreen;
                        }
                    }
                    catch (Exception ex)
                    {
                        rowResult = ex.Message;
                    }
                    this.signedInputFileListview.Items[index].SubItems[2].Text = rowResult;
                    this.signedInputFileListview.Items[index].BackColor = rowColor;
                    this.signedInputFileListview.Items[index].ToolTipText = rowResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void signedInputFileListview_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem row = this.signedInputFileListview.SelectedItems[0];
            MessageBoxIcon messageBoxIcon = row.SubItems[2].Text.Equals("Verified", StringComparison.OrdinalIgnoreCase) ?
                MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(row.SubItems[2].Text, "Verify information", MessageBoxButtons.OK, messageBoxIcon);
        }
    }
}
