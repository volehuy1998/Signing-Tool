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
    public partial class JsonVerifyForm : Form
    {
        private List<string> signedInputFiles = null;

        public JsonVerifyForm(List<string> signedInputFiles)
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

        private void jwtVerifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                for (int index = 0; index < this.signedInputFileListview.Items.Count; index++)
                {
                    string payload = string.Empty;
                    Color rowColor = Color.IndianRed;
                    try
                    {
                        string jwt = File.ReadAllText(this.signedInputFiles[index]);
                        payload = SigningCore.Json.Decode(jwt);
                        if (!string.IsNullOrWhiteSpace(payload))
                        {
                            rowColor = Color.LightGreen;
                        }
                    }
                    catch (Exception ex)
                    {
                        payload = ex.Message;
                    }
                    this.signedInputFileListview.Items[index].SubItems[2].Text = payload;
                    this.signedInputFileListview.Items[index].BackColor = rowColor;
                    this.signedInputFileListview.Items[index].ToolTipText = payload;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void signedInputFileListview_DoubleClick(object sender, EventArgs e)
        {
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Information;
            try
            {
                // try parse
                Newtonsoft.Json.Linq.JObject.Parse(this.signedInputFileListview.SelectedItems[0].SubItems[2].Text);
            }
            catch (Exception ex)
            {
                messageBoxIcon = MessageBoxIcon.Error;
            }
            ListViewItem row = this.signedInputFileListview.SelectedItems[0];
            MessageBox.Show(row.SubItems[2].Text, "Payload information", MessageBoxButtons.OK, messageBoxIcon);
        }
    }
}
