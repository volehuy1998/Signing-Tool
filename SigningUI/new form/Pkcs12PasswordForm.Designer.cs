
namespace SigningUI.new_form
{
    partial class Pkcs12PasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pkcs12PasswordForm));
            this.pfxPwdLabel = new System.Windows.Forms.Label();
            this.pkcs12PasswordValueTextbox = new System.Windows.Forms.TextBox();
            this.enterPfxPwdButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pfxPwdLabel
            // 
            this.pfxPwdLabel.AutoSize = true;
            this.pfxPwdLabel.Location = new System.Drawing.Point(12, 19);
            this.pfxPwdLabel.Name = "pfxPwdLabel";
            this.pfxPwdLabel.Size = new System.Drawing.Size(82, 13);
            this.pfxPwdLabel.TabIndex = 0;
            this.pfxPwdLabel.Text = "PKCS#12 pass:";
            // 
            // pkcs12PasswordValueTextbox
            // 
            this.pkcs12PasswordValueTextbox.Location = new System.Drawing.Point(93, 16);
            this.pkcs12PasswordValueTextbox.Name = "pkcs12PasswordValueTextbox";
            this.pkcs12PasswordValueTextbox.Size = new System.Drawing.Size(157, 20);
            this.pkcs12PasswordValueTextbox.TabIndex = 1;
            // 
            // enterPfxPwdButton
            // 
            this.enterPfxPwdButton.Location = new System.Drawing.Point(93, 42);
            this.enterPfxPwdButton.Name = "enterPfxPwdButton";
            this.enterPfxPwdButton.Size = new System.Drawing.Size(75, 23);
            this.enterPfxPwdButton.TabIndex = 2;
            this.enterPfxPwdButton.Text = "Done";
            this.enterPfxPwdButton.UseVisualStyleBackColor = true;
            this.enterPfxPwdButton.Click += new System.EventHandler(this.enterPfxPwdButton_Click);
            // 
            // Pkcs12PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 73);
            this.Controls.Add(this.enterPfxPwdButton);
            this.Controls.Add(this.pkcs12PasswordValueTextbox);
            this.Controls.Add(this.pfxPwdLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Pkcs12PasswordForm";
            this.Text = "Nhập mật khẩu PKCS#12";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pfxPwdLabel;
        private System.Windows.Forms.TextBox pkcs12PasswordValueTextbox;
        private System.Windows.Forms.Button enterPfxPwdButton;
    }
}