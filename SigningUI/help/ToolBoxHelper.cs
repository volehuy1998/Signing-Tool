using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace SigningUI.help
{
    public enum Mode
    {
        SIGN,
        CRYPT
    }
    public class ToolBoxHelper
    {
        /// <summary>
        /// Copy from https://stackoverflow.com/questions/13603654/check-only-one-toolstripmenuitem
        /// </summary>
        /// <param name="selectedMenuItem"></param>
        public static void UncheckOtherToolStripMenuItems(ToolStripMenuItem selectedMenuItem)
        {
            selectedMenuItem.Checked = true;

            // Select the other MenuItens from the ParentMenu(OwnerItens) and unchecked this,
            // The current Linq Expression verify if the item is a real ToolStripMenuItem
            // and if the item is a another ToolStripMenuItem to uncheck this.
            foreach (var ltoolStripMenuItem in (from object
                                                    item in selectedMenuItem.Owner.Items
                                                let ltoolStripMenuItem = item as ToolStripMenuItem
                                                where ltoolStripMenuItem != null
                                                where !item.Equals(selectedMenuItem)
                                                select ltoolStripMenuItem))
                (ltoolStripMenuItem).Checked = false;

            // This line is optional, for show the mainMenu after click
            selectedMenuItem.Owner.Show();
        }

        public static void ChangeActionValueLabel(ToolStripMenuItem actionSelectedMenuItem, Label valueLabel)
        {
            if (!actionSelectedMenuItem.Text.Equals("Action") && !actionSelectedMenuItem.Text.Equals("Mode"))
            {
                valueLabel.Text = actionSelectedMenuItem.Text;

            }
            else
            {
                foreach (ToolStripMenuItem actionItem in actionSelectedMenuItem.DropDownItems)
                {
                    if (actionItem.Checked)
                    {
                        valueLabel.Text = actionItem.Text;
                        break;
                    }
                }
            }
        }

        public static string GetFileFilterMode(string modeValueLabel)
        {
            string result = string.Empty;

            if (modeValueLabel.Equals("cms", StringComparison.OrdinalIgnoreCase))
            {
                result = "All Files|*.*";
            }
            else if (modeValueLabel.Equals("xml", StringComparison.OrdinalIgnoreCase))
            {
                result = "XML Files|*.xml";
            }
            else if (modeValueLabel.Equals("json", StringComparison.OrdinalIgnoreCase))
            {
                result = "JSON Files|*.json";
            }

            return result;
        }

        public static List<string> GetInputFiles(string inputFilesTextbox)
        {
            List<string> result = new List<string>();
            result = inputFilesTextbox.Split(';').ToList();

            return result;
        }

        public static bool CompareString(string input, string expect)
        {
            return input.Equals(expect, StringComparison.OrdinalIgnoreCase);
        }

        public static bool CheckValidInputMainForm(string inputFiles)
        {
            return !string.IsNullOrWhiteSpace(inputFiles);
        }

        public static void AdjustTemplateForm(Form form)
        {
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.TopMost = true;
            form.FormBorderStyle = FormBorderStyle.None;
        }

        public static void UpdateLabelData(Label label, string data)
        {
            string padding = new string(' ', 6);
            string original = label.Text.Substring(0, label.Text.IndexOf(':') + 1) + padding + data;            
            int limit = 150;
            if (original.Length > limit)
            {
                label.Text = original.Substring(0, limit - 3);
                label.Text += "...";
                ToolTip toolTip = new ToolTip();
                toolTip.InitialDelay = 0; // instant appear
                toolTip.ReshowDelay = 0;
                toolTip.ShowAlways = true;
                toolTip.SetToolTip(label, original);
            }
            else
            {
                label.Text = original;
            }
        }

        public static ListViewItem GetListViewItemByName(ListView listview, string path)
        {
            foreach (ListViewItem item in listview.Items)
            {
                if (item.SubItems[1].Text.Equals(path, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }

            return null;
        }

        public static string GetOutputFile(string outputFolder, string inputFile, Mode mode)
        {
            string outputFile = string.Empty;

            string fileNameWithoutExten = Path.GetFileNameWithoutExtension(inputFile);

            if (mode == Mode.SIGN)
            {
                fileNameWithoutExten += ".sig";
            }
            else
            {
                fileNameWithoutExten += ".enc";
            }

            outputFile = Path.Combine(outputFolder, fileNameWithoutExten);

            return outputFile;
        }
    }
}
