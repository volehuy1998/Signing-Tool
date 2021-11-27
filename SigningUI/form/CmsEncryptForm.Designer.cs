
namespace SigningUI.form
{
    partial class CmsEncryptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CmsEncryptForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openOutputFolderButton = new System.Windows.Forms.Button();
            this.outputFolderTextbox = new System.Windows.Forms.TextBox();
            this.outputFolderLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inputFileListview = new System.Windows.Forms.ListView();
            this.IdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResultColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.passwordAesTextbox = new System.Windows.Forms.TextBox();
            this.passwordAesLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmsEncryptButton = new System.Windows.Forms.Button();
            this.keySizeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // openOutputFolderButton
            // 
            this.openOutputFolderButton.Location = new System.Drawing.Point(463, 103);
            this.openOutputFolderButton.Name = "openOutputFolderButton";
            this.openOutputFolderButton.Size = new System.Drawing.Size(75, 23);
            this.openOutputFolderButton.TabIndex = 21;
            this.openOutputFolderButton.Text = "Open folder";
            this.openOutputFolderButton.UseVisualStyleBackColor = true;
            this.openOutputFolderButton.Click += new System.EventHandler(this.openOutputFolderButton_Click);
            // 
            // outputFolderTextbox
            // 
            this.outputFolderTextbox.Location = new System.Drawing.Point(96, 104);
            this.outputFolderTextbox.Name = "outputFolderTextbox";
            this.outputFolderTextbox.Size = new System.Drawing.Size(351, 20);
            this.outputFolderTextbox.TabIndex = 19;
            // 
            // outputFolderLabel
            // 
            this.outputFolderLabel.AutoSize = true;
            this.outputFolderLabel.Location = new System.Drawing.Point(6, 108);
            this.outputFolderLabel.Name = "outputFolderLabel";
            this.outputFolderLabel.Size = new System.Drawing.Size(71, 13);
            this.outputFolderLabel.TabIndex = 18;
            this.outputFolderLabel.Text = "Output folder:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Input files:";
            // 
            // inputFileListview
            // 
            this.inputFileListview.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.inputFileListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdColumn,
            this.FileColumn,
            this.ResultColumn});
            this.inputFileListview.FullRowSelect = true;
            this.inputFileListview.HideSelection = false;
            this.inputFileListview.Location = new System.Drawing.Point(96, 158);
            this.inputFileListview.Name = "inputFileListview";
            this.inputFileListview.ShowItemToolTips = true;
            this.inputFileListview.Size = new System.Drawing.Size(351, 134);
            this.inputFileListview.TabIndex = 23;
            this.inputFileListview.UseCompatibleStateImageBehavior = false;
            this.inputFileListview.View = System.Windows.Forms.View.Details;
            // 
            // IdColumn
            // 
            this.IdColumn.Text = "ID";
            this.IdColumn.Width = 39;
            // 
            // FileColumn
            // 
            this.FileColumn.Text = "File";
            this.FileColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FileColumn.Width = 246;
            // 
            // ResultColumn
            // 
            this.ResultColumn.Text = "Result";
            this.ResultColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // passwordAesTextbox
            // 
            this.passwordAesTextbox.Location = new System.Drawing.Point(96, 15);
            this.passwordAesTextbox.Name = "passwordAesTextbox";
            this.passwordAesTextbox.Size = new System.Drawing.Size(351, 20);
            this.passwordAesTextbox.TabIndex = 26;
            this.passwordAesTextbox.Text = "~Default password~";
            // 
            // passwordAesLabel
            // 
            this.passwordAesLabel.AutoSize = true;
            this.passwordAesLabel.Location = new System.Drawing.Point(21, 19);
            this.passwordAesLabel.Name = "passwordAesLabel";
            this.passwordAesLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordAesLabel.TabIndex = 25;
            this.passwordAesLabel.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "AES key size:";
            // 
            // cmsEncryptButton
            // 
            this.cmsEncryptButton.Location = new System.Drawing.Point(243, 315);
            this.cmsEncryptButton.Name = "cmsEncryptButton";
            this.cmsEncryptButton.Size = new System.Drawing.Size(75, 23);
            this.cmsEncryptButton.TabIndex = 29;
            this.cmsEncryptButton.Text = "Encrypt";
            this.cmsEncryptButton.UseVisualStyleBackColor = true;
            this.cmsEncryptButton.Click += new System.EventHandler(this.cmsEncryptButton_Click);
            // 
            // keySizeComboBox
            // 
            this.keySizeComboBox.FormattingEnabled = true;
            this.keySizeComboBox.Location = new System.Drawing.Point(96, 61);
            this.keySizeComboBox.Name = "keySizeComboBox";
            this.keySizeComboBox.Size = new System.Drawing.Size(121, 21);
            this.keySizeComboBox.TabIndex = 30;
            // 
            // CmsEncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 350);
            this.Controls.Add(this.keySizeComboBox);
            this.Controls.Add(this.cmsEncryptButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordAesTextbox);
            this.Controls.Add(this.passwordAesLabel);
            this.Controls.Add(this.inputFileListview);
            this.Controls.Add(this.openOutputFolderButton);
            this.Controls.Add(this.outputFolderTextbox);
            this.Controls.Add(this.outputFolderLabel);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CmsEncryptForm";
            this.Text = "CMS Encrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button openOutputFolderButton;
        private System.Windows.Forms.TextBox outputFolderTextbox;
        private System.Windows.Forms.Label outputFolderLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView inputFileListview;
        private System.Windows.Forms.ColumnHeader IdColumn;
        private System.Windows.Forms.ColumnHeader FileColumn;
        private System.Windows.Forms.ColumnHeader ResultColumn;
        private System.Windows.Forms.TextBox passwordAesTextbox;
        private System.Windows.Forms.Label passwordAesLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmsEncryptButton;
        private System.Windows.Forms.ComboBox keySizeComboBox;
    }
}