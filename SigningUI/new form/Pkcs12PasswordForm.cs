using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SigningUI.new_form
{
    public partial class Pkcs12PasswordForm : Form
    {
        public string Pkcs12Password { get; private set; }
        public Pkcs12PasswordForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.CenterToScreen();
        }

        private void enterPfxPwdButton_Click(object sender, EventArgs e)
        {
            this.Pkcs12Password = this.pkcs12PasswordValueTextbox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
