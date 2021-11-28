
namespace SigningUI.form
{
    partial class XmlVerifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XmlVerifyForm));
            this.signedInputFileListview = new System.Windows.Forms.ListView();
            this.IdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResultColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.xmlVerifyButton = new System.Windows.Forms.Button();
            this.signedInputFilesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.signedInputFileListview.Location = new System.Drawing.Point(100, 12);
            this.signedInputFileListview.Name = "signedInputFileListview";
            this.signedInputFileListview.ShowItemToolTips = true;
            this.signedInputFileListview.Size = new System.Drawing.Size(312, 134);
            this.signedInputFileListview.TabIndex = 25;
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
            // xmlVerifyButton
            // 
            this.xmlVerifyButton.Location = new System.Drawing.Point(184, 167);
            this.xmlVerifyButton.Name = "xmlVerifyButton";
            this.xmlVerifyButton.Size = new System.Drawing.Size(75, 23);
            this.xmlVerifyButton.TabIndex = 24;
            this.xmlVerifyButton.Text = "Verify";
            this.xmlVerifyButton.UseVisualStyleBackColor = true;
            this.xmlVerifyButton.Click += new System.EventHandler(this.xmlVerifyButton_Click);
            // 
            // signedInputFilesLabel
            // 
            this.signedInputFilesLabel.AutoSize = true;
            this.signedInputFilesLabel.Location = new System.Drawing.Point(18, 12);
            this.signedInputFilesLabel.Name = "signedInputFilesLabel";
            this.signedInputFilesLabel.Size = new System.Drawing.Size(64, 13);
            this.signedInputFilesLabel.TabIndex = 20;
            this.signedInputFilesLabel.Text = "Signed files:";
            // 
            // XmlVerifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 202);
            this.Controls.Add(this.signedInputFileListview);
            this.Controls.Add(this.xmlVerifyButton);
            this.Controls.Add(this.signedInputFilesLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XmlVerifyForm";
            this.Text = "XML Verify";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView signedInputFileListview;
        private System.Windows.Forms.ColumnHeader IdColumn;
        private System.Windows.Forms.ColumnHeader FileColumn;
        private System.Windows.Forms.ColumnHeader ResultColumn;
        private System.Windows.Forms.Button xmlVerifyButton;
        private System.Windows.Forms.Label signedInputFilesLabel;
    }
}