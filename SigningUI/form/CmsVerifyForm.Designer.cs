
namespace SigningUI.form
{
    partial class CmsVerifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CmsVerifyForm));
            this.cmsVerifyButton = new System.Windows.Forms.Button();
            this.selectMicrosoftCertButton = new System.Windows.Forms.Button();
            this.microsoftCertThumprintTextBox = new System.Windows.Forms.TextBox();
            this.microsoftCertLabel = new System.Windows.Forms.Label();
            this.signedInputFilesLabel = new System.Windows.Forms.Label();
            this.signedInputFileListview = new System.Windows.Forms.ListView();
            this.IdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResultColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // cmsVerifyButton
            // 
            this.cmsVerifyButton.Location = new System.Drawing.Point(254, 211);
            this.cmsVerifyButton.Name = "cmsVerifyButton";
            this.cmsVerifyButton.Size = new System.Drawing.Size(75, 23);
            this.cmsVerifyButton.TabIndex = 18;
            this.cmsVerifyButton.Text = "Verify";
            this.cmsVerifyButton.UseVisualStyleBackColor = true;
            this.cmsVerifyButton.Click += new System.EventHandler(this.cmsVerifyButton_Click);
            // 
            // selectMicrosoftCertButton
            // 
            this.selectMicrosoftCertButton.Location = new System.Drawing.Point(471, 11);
            this.selectMicrosoftCertButton.Name = "selectMicrosoftCertButton";
            this.selectMicrosoftCertButton.Size = new System.Drawing.Size(75, 23);
            this.selectMicrosoftCertButton.TabIndex = 17;
            this.selectMicrosoftCertButton.Text = "Select ...";
            this.selectMicrosoftCertButton.UseVisualStyleBackColor = true;
            this.selectMicrosoftCertButton.Click += new System.EventHandler(this.selectMicrosoftCertButton_Click);
            // 
            // microsoftCertThumprintTextBox
            // 
            this.microsoftCertThumprintTextBox.AccessibleName = "signedFileListView";
            this.microsoftCertThumprintTextBox.Location = new System.Drawing.Point(140, 12);
            this.microsoftCertThumprintTextBox.Name = "microsoftCertThumprintTextBox";
            this.microsoftCertThumprintTextBox.Size = new System.Drawing.Size(312, 20);
            this.microsoftCertThumprintTextBox.TabIndex = 16;
            // 
            // microsoftCertLabel
            // 
            this.microsoftCertLabel.AutoSize = true;
            this.microsoftCertLabel.Location = new System.Drawing.Point(19, 16);
            this.microsoftCertLabel.Name = "microsoftCertLabel";
            this.microsoftCertLabel.Size = new System.Drawing.Size(103, 13);
            this.microsoftCertLabel.TabIndex = 15;
            this.microsoftCertLabel.Text = "Certificate thumprint:";
            // 
            // signedInputFilesLabel
            // 
            this.signedInputFilesLabel.AutoSize = true;
            this.signedInputFilesLabel.Location = new System.Drawing.Point(58, 58);
            this.signedInputFilesLabel.Name = "signedInputFilesLabel";
            this.signedInputFilesLabel.Size = new System.Drawing.Size(64, 13);
            this.signedInputFilesLabel.TabIndex = 13;
            this.signedInputFilesLabel.Text = "Signed files:";
            // 
            // signedInputFileListview
            // 
            this.signedInputFileListview.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.signedInputFileListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdColumn,
            this.FileColumn,
            this.ResultColumn});
            this.signedInputFileListview.FullRowSelect = true;
            this.signedInputFileListview.HideSelection = false;
            this.signedInputFileListview.Location = new System.Drawing.Point(140, 58);
            this.signedInputFileListview.Name = "signedInputFileListview";
            this.signedInputFileListview.ShowItemToolTips = true;
            this.signedInputFileListview.Size = new System.Drawing.Size(312, 134);
            this.signedInputFileListview.TabIndex = 19;
            this.signedInputFileListview.UseCompatibleStateImageBehavior = false;
            this.signedInputFileListview.View = System.Windows.Forms.View.Details;
            this.signedInputFileListview.DoubleClick += new System.EventHandler(this.signedInputFileListview_DoubleClick);
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
            this.FileColumn.Width = 208;
            // 
            // ResultColumn
            // 
            this.ResultColumn.Text = "Result";
            this.ResultColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CmsVerifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 257);
            this.Controls.Add(this.signedInputFileListview);
            this.Controls.Add(this.cmsVerifyButton);
            this.Controls.Add(this.selectMicrosoftCertButton);
            this.Controls.Add(this.microsoftCertThumprintTextBox);
            this.Controls.Add(this.microsoftCertLabel);
            this.Controls.Add(this.signedInputFilesLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CmsVerifyForm";
            this.Text = "Cms Verify";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmsVerifyButton;
        private System.Windows.Forms.Button selectMicrosoftCertButton;
        private System.Windows.Forms.TextBox microsoftCertThumprintTextBox;
        private System.Windows.Forms.Label microsoftCertLabel;
        private System.Windows.Forms.Label signedInputFilesLabel;
        private System.Windows.Forms.ListView signedInputFileListview;
        private System.Windows.Forms.ColumnHeader IdColumn;
        private System.Windows.Forms.ColumnHeader FileColumn;
        private System.Windows.Forms.ColumnHeader ResultColumn;
    }
}