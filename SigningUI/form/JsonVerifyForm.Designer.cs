
namespace SigningUI.form
{
    partial class JsonVerifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JsonVerifyForm));
            this.jwtVerifyButton = new System.Windows.Forms.Button();
            this.jwtInputFilesLabel = new System.Windows.Forms.Label();
            this.IdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResultColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.signedInputFileListview = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // jwtVerifyButton
            // 
            this.jwtVerifyButton.Location = new System.Drawing.Point(184, 167);
            this.jwtVerifyButton.Name = "jwtVerifyButton";
            this.jwtVerifyButton.Size = new System.Drawing.Size(75, 23);
            this.jwtVerifyButton.TabIndex = 27;
            this.jwtVerifyButton.Text = "Verify";
            this.jwtVerifyButton.UseVisualStyleBackColor = true;
            this.jwtVerifyButton.Click += new System.EventHandler(this.jwtVerifyButton_Click);
            // 
            // jwtInputFilesLabel
            // 
            this.jwtInputFilesLabel.AutoSize = true;
            this.jwtInputFilesLabel.Location = new System.Drawing.Point(28, 12);
            this.jwtInputFilesLabel.Name = "jwtInputFilesLabel";
            this.jwtInputFilesLabel.Size = new System.Drawing.Size(54, 13);
            this.jwtInputFilesLabel.TabIndex = 26;
            this.jwtInputFilesLabel.Text = "JWT files:";
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
            this.signedInputFileListview.TabIndex = 28;
            this.signedInputFileListview.UseCompatibleStateImageBehavior = false;
            this.signedInputFileListview.View = System.Windows.Forms.View.Details;
            this.signedInputFileListview.DoubleClick += new System.EventHandler(this.signedInputFileListview_DoubleClick);
            // 
            // JsonVerifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 202);
            this.Controls.Add(this.signedInputFileListview);
            this.Controls.Add(this.jwtVerifyButton);
            this.Controls.Add(this.jwtInputFilesLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JsonVerifyForm";
            this.Text = "JSON Verify";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button jwtVerifyButton;
        private System.Windows.Forms.Label jwtInputFilesLabel;
        private System.Windows.Forms.ColumnHeader IdColumn;
        private System.Windows.Forms.ColumnHeader FileColumn;
        private System.Windows.Forms.ColumnHeader ResultColumn;
        private System.Windows.Forms.ListView signedInputFileListview;
    }
}