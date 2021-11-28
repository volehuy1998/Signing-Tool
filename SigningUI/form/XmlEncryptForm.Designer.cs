
namespace SigningUI.form
{
    partial class XmlEncryptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XmlEncryptForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.inputFileListview = new System.Windows.Forms.ListView();
            this.IdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResultColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openOutputFolderButton = new System.Windows.Forms.Button();
            this.outputFolderTextbox = new System.Windows.Forms.TextBox();
            this.outputFolderLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.keySizeComboBox = new System.Windows.Forms.ComboBox();
            this.xmlEncryptButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordAesTextbox = new System.Windows.Forms.TextBox();
            this.passwordAesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.inputFileListview.Location = new System.Drawing.Point(99, 157);
            this.inputFileListview.Name = "inputFileListview";
            this.inputFileListview.ShowItemToolTips = true;
            this.inputFileListview.Size = new System.Drawing.Size(351, 134);
            this.inputFileListview.TabIndex = 35;
            this.inputFileListview.UseCompatibleStateImageBehavior = false;
            this.inputFileListview.View = System.Windows.Forms.View.Details;
            this.inputFileListview.DoubleClick += new System.EventHandler(this.inputFileListview_DoubleClick);
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
            // openOutputFolderButton
            // 
            this.openOutputFolderButton.Location = new System.Drawing.Point(466, 102);
            this.openOutputFolderButton.Name = "openOutputFolderButton";
            this.openOutputFolderButton.Size = new System.Drawing.Size(75, 23);
            this.openOutputFolderButton.TabIndex = 34;
            this.openOutputFolderButton.Text = "Open folder";
            this.openOutputFolderButton.UseVisualStyleBackColor = true;
            this.openOutputFolderButton.Click += new System.EventHandler(this.openOutputFolderButton_Click);
            // 
            // outputFolderTextbox
            // 
            this.outputFolderTextbox.Location = new System.Drawing.Point(99, 103);
            this.outputFolderTextbox.Name = "outputFolderTextbox";
            this.outputFolderTextbox.Size = new System.Drawing.Size(351, 20);
            this.outputFolderTextbox.TabIndex = 33;
            // 
            // outputFolderLabel
            // 
            this.outputFolderLabel.AutoSize = true;
            this.outputFolderLabel.Location = new System.Drawing.Point(9, 107);
            this.outputFolderLabel.Name = "outputFolderLabel";
            this.outputFolderLabel.Size = new System.Drawing.Size(71, 13);
            this.outputFolderLabel.TabIndex = 32;
            this.outputFolderLabel.Text = "Output folder:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Input files:";
            // 
            // keySizeComboBox
            // 
            this.keySizeComboBox.FormattingEnabled = true;
            this.keySizeComboBox.Location = new System.Drawing.Point(99, 60);
            this.keySizeComboBox.Name = "keySizeComboBox";
            this.keySizeComboBox.Size = new System.Drawing.Size(121, 21);
            this.keySizeComboBox.TabIndex = 40;
            // 
            // xmlEncryptButton
            // 
            this.xmlEncryptButton.Location = new System.Drawing.Point(246, 314);
            this.xmlEncryptButton.Name = "xmlEncryptButton";
            this.xmlEncryptButton.Size = new System.Drawing.Size(75, 23);
            this.xmlEncryptButton.TabIndex = 39;
            this.xmlEncryptButton.Text = "Encrypt";
            this.xmlEncryptButton.UseVisualStyleBackColor = true;
            this.xmlEncryptButton.Click += new System.EventHandler(this.xmlEncryptButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "AES key size:";
            // 
            // passwordAesTextbox
            // 
            this.passwordAesTextbox.Location = new System.Drawing.Point(99, 14);
            this.passwordAesTextbox.Name = "passwordAesTextbox";
            this.passwordAesTextbox.Size = new System.Drawing.Size(351, 20);
            this.passwordAesTextbox.TabIndex = 37;
            this.passwordAesTextbox.Text = "~Default password~";
            // 
            // passwordAesLabel
            // 
            this.passwordAesLabel.AutoSize = true;
            this.passwordAesLabel.Location = new System.Drawing.Point(24, 18);
            this.passwordAesLabel.Name = "passwordAesLabel";
            this.passwordAesLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordAesLabel.TabIndex = 36;
            this.passwordAesLabel.Text = "Password:";
            // 
            // XmlEncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 350);
            this.Controls.Add(this.inputFileListview);
            this.Controls.Add(this.openOutputFolderButton);
            this.Controls.Add(this.outputFolderTextbox);
            this.Controls.Add(this.outputFolderLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keySizeComboBox);
            this.Controls.Add(this.xmlEncryptButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordAesTextbox);
            this.Controls.Add(this.passwordAesLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XmlEncryptForm";
            this.Text = "XML Encrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListView inputFileListview;
        private System.Windows.Forms.ColumnHeader IdColumn;
        private System.Windows.Forms.ColumnHeader FileColumn;
        private System.Windows.Forms.ColumnHeader ResultColumn;
        private System.Windows.Forms.Button openOutputFolderButton;
        private System.Windows.Forms.TextBox outputFolderTextbox;
        private System.Windows.Forms.Label outputFolderLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox keySizeComboBox;
        private System.Windows.Forms.Button xmlEncryptButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordAesTextbox;
        private System.Windows.Forms.Label passwordAesLabel;
    }
}