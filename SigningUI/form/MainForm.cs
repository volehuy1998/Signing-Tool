using SigningUI.form;
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

namespace SigningUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.CenterToScreen();
            ToolBoxHelper.ChangeActionValueLabel(this.actionToolStripMenuItem, this.actionValueLabel);
            ToolBoxHelper.ChangeActionValueLabel(this.modeToolStripMenuItem, this.modeValueLabel);
            this.outputFolderTextbox.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), this.modeValueLabel.Text, this.actionValueLabel.Text);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            inputFileDialog.Multiselect = true;
            inputFileDialog.Filter = ToolBoxHelper.GetFileFilterMode(this.modeValueLabel.Text);
            inputFileDialog.Title = $"Choose {this.modeValueLabel.Text} files to {this.actionValueLabel.Text}";
            if (inputFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.inputFileTextBox.Text = string.Join(";", inputFileDialog.FileNames);
            }
        }

        private void signToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolBoxHelper.UncheckOtherToolStripMenuItems(sender as ToolStripMenuItem);
            ToolBoxHelper.ChangeActionValueLabel(sender as ToolStripMenuItem, this.actionValueLabel);
            this.outputFolderTextbox.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), this.modeValueLabel.Text, this.actionValueLabel.Text);
        }

        private void verifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolBoxHelper.UncheckOtherToolStripMenuItems(sender as ToolStripMenuItem);
            ToolBoxHelper.ChangeActionValueLabel(sender as ToolStripMenuItem, this.actionValueLabel);
            this.outputFolderTextbox.Text = "Verify action don't need filled output path";
        }

        private void encryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolBoxHelper.UncheckOtherToolStripMenuItems(sender as ToolStripMenuItem);
            ToolBoxHelper.ChangeActionValueLabel(sender as ToolStripMenuItem, this.actionValueLabel);
            this.outputFolderTextbox.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), this.modeValueLabel.Text, this.actionValueLabel.Text);
        }

        private void decryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolBoxHelper.UncheckOtherToolStripMenuItems(sender as ToolStripMenuItem);
            ToolBoxHelper.ChangeActionValueLabel(sender as ToolStripMenuItem, this.actionValueLabel);
            this.outputFolderTextbox.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), this.modeValueLabel.Text, this.actionValueLabel.Text);
        }

        private void cMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolBoxHelper.UncheckOtherToolStripMenuItems(sender as ToolStripMenuItem);
            ToolBoxHelper.ChangeActionValueLabel(sender as ToolStripMenuItem, this.modeValueLabel);
            this.outputFolderTextbox.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), this.modeValueLabel.Text, this.actionValueLabel.Text);
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolBoxHelper.UncheckOtherToolStripMenuItems(sender as ToolStripMenuItem);
            ToolBoxHelper.ChangeActionValueLabel(sender as ToolStripMenuItem, this.modeValueLabel);
            this.outputFolderTextbox.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), this.modeValueLabel.Text, this.actionValueLabel.Text);
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolBoxHelper.UncheckOtherToolStripMenuItems(sender as ToolStripMenuItem);
            ToolBoxHelper.ChangeActionValueLabel(sender as ToolStripMenuItem, this.modeValueLabel);
            this.outputFolderTextbox.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), this.modeValueLabel.Text, this.actionValueLabel.Text);
        }

        private void inputFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            inputFileDialog.Multiselect = true;
            inputFileDialog.Filter = ToolBoxHelper.GetFileFilterMode(this.modeValueLabel.Text);
            inputFileDialog.Title = $"Choose {this.modeValueLabel.Text} files to {this.actionValueLabel.Text}";
            if (inputFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.inputFileTextBox.Text = string.Join(";", inputFileDialog.FileNames);
            }
        }

        private void outputFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog outputFolderBrowserDialog = new FolderBrowserDialog();
            outputFolderBrowserDialog.Description = $"Select output folder of {this.modeValueLabel.Text} {this.actionValueLabel.Text}";
            if (outputFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.outputFolderTextbox.Text = outputFolderBrowserDialog.SelectedPath;
            }
        }

        private void nextStepButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ToolBoxHelper.CheckValidInputMainForm(this.inputFileTextBox.Text))
                {
                    throw new Exception("Please fill all");
                }
                string action = this.actionValueLabel.Text.ToLower();
                string mode = this.modeValueLabel.Text.ToLower();
                if (ToolBoxHelper.CompareString(action, "sign") && ToolBoxHelper.CompareString(mode, "cms"))
                {
                    CmsSignForm cmsSignForm = new CmsSignForm(ToolBoxHelper.GetInputFiles(this.inputFileTextBox.Text), this.outputFolderTextbox.Text);
                    cmsSignForm.ShowDialog();
                }
                else if (ToolBoxHelper.CompareString(action, "verify") && ToolBoxHelper.CompareString(mode, "cms"))
                {
                    CmsVerifyForm cmsVerifyForm = new CmsVerifyForm(ToolBoxHelper.GetInputFiles(this.inputFileTextBox.Text));
                    cmsVerifyForm.ShowDialog();
                }
                else if (ToolBoxHelper.CompareString(action, "encrypt") && ToolBoxHelper.CompareString(mode, "cms"))
                {
                    CmsEncryptForm cmsEncryptForm = new CmsEncryptForm(ToolBoxHelper.GetInputFiles(this.inputFileTextBox.Text), this.outputFolderTextbox.Text);
                    cmsEncryptForm.ShowDialog();
                }
                else if (ToolBoxHelper.CompareString(action, "decrypt") && ToolBoxHelper.CompareString(mode, "cms"))
                {
                    CmsDecryptForm cmsDecryptForm = new CmsDecryptForm(ToolBoxHelper.GetInputFiles(this.inputFileTextBox.Text), this.outputFolderTextbox.Text);
                    cmsDecryptForm.ShowDialog();
                }
                else if (ToolBoxHelper.CompareString(action, "sign") && ToolBoxHelper.CompareString(mode, "xml"))
                {
                    XmlSignForm xmlSignForm = new XmlSignForm(ToolBoxHelper.GetInputFiles(this.inputFileTextBox.Text), this.outputFolderTextbox.Text);
                    xmlSignForm.ShowDialog();
                }
                else if (ToolBoxHelper.CompareString(action, "verify") && ToolBoxHelper.CompareString(mode, "xml"))
                {
                    XmlVerifyForm xmlVerifyForm = new XmlVerifyForm(ToolBoxHelper.GetInputFiles(this.inputFileTextBox.Text));
                    xmlVerifyForm.ShowDialog();
                }
                else if (ToolBoxHelper.CompareString(action, "encrypt") && ToolBoxHelper.CompareString(mode, "xml"))
                {
                    XmlEncryptForm xmlEncryptForm = new XmlEncryptForm(ToolBoxHelper.GetInputFiles(this.inputFileTextBox.Text), this.outputFolderTextbox.Text);
                    xmlEncryptForm.ShowDialog();
                }
                else if (ToolBoxHelper.CompareString(action, "decrypt") && ToolBoxHelper.CompareString(mode, "xml"))
                {
                    XmlDecryptForm xmlDecryptForm = new XmlDecryptForm(ToolBoxHelper.GetInputFiles(this.inputFileTextBox.Text), this.outputFolderTextbox.Text);
                    xmlDecryptForm.ShowDialog();
                }
                else if (ToolBoxHelper.CompareString(action, "sign") && ToolBoxHelper.CompareString(mode, "json"))
                {
                    JsonSignForm jsonSignForm = new JsonSignForm(ToolBoxHelper.GetInputFiles(this.inputFileTextBox.Text), this.outputFolderTextbox.Text);
                    jsonSignForm.ShowDialog();
                }
                else if (ToolBoxHelper.CompareString(action, "verify") && ToolBoxHelper.CompareString(mode, "json"))
                {
                    JsonVerifyForm jsonVerifyForm = new JsonVerifyForm(ToolBoxHelper.GetInputFiles(this.inputFileTextBox.Text));
                    jsonVerifyForm.ShowDialog();
                }
                else if (ToolBoxHelper.CompareString(action, "encrypt") && ToolBoxHelper.CompareString(mode, "json"))
                {
                    throw new Exception($"{this.modeValueLabel.Text} {this.actionValueLabel.Text} didn't support yet, please try another");
                }
                else if (ToolBoxHelper.CompareString(action, "decrypt") && ToolBoxHelper.CompareString(mode, "json"))
                {
                    throw new Exception($"{this.modeValueLabel.Text} {this.actionValueLabel.Text} didn't support yet, please try another");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
