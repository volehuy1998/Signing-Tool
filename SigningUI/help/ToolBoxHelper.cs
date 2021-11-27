using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SigningUI.help
{
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

        public static bool CheckValidInputMainForm(string outputFolder, string inputFiles)
        {
            return !string.IsNullOrWhiteSpace(inputFiles);
        }
    }
}
