
namespace SigningUI.form
{
    partial class CmsSignForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CmsSignForm));
            this.pfxPasswordLabel = new System.Windows.Forms.Label();
            this.pfxFileLabel = new System.Windows.Forms.Label();
            this.pfxFileTextbox = new System.Windows.Forms.TextBox();
            this.pfxButton = new System.Windows.Forms.Button();
            this.pfxPasswordTextbox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.outputFolderLabel = new System.Windows.Forms.Label();
            this.outputFolderTextbox = new System.Windows.Forms.TextBox();
            this.cmsSignButton = new System.Windows.Forms.Button();
            this.openOutputFolderButton = new System.Windows.Forms.Button();
            this.inputFileListview = new System.Windows.Forms.ListView();
            this.IdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResultColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // pfxPasswordLabel
            // 
            this.pfxPasswordLabel.AutoSize = true;
            this.pfxPasswordLabel.Location = new System.Drawing.Point(29, 54);
            this.pfxPasswordLabel.Name = "pfxPasswordLabel";
            this.pfxPasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.pfxPasswordLabel.TabIndex = 1;
            this.pfxPasswordLabel.Text = "Password:";
            // 
            // pfxFileLabel
            // 
            this.pfxFileLabel.AutoSize = true;
            this.pfxFileLabel.Location = new System.Drawing.Point(12, 9);
            this.pfxFileLabel.Name = "pfxFileLabel";
            this.pfxFileLabel.Size = new System.Drawing.Size(73, 13);
            this.pfxFileLabel.TabIndex = 0;
            this.pfxFileLabel.Text = "PKCS#12 file:";
            // 
            // pfxFileTextbox
            // 
            this.pfxFileTextbox.Location = new System.Drawing.Point(101, 5);
            this.pfxFileTextbox.Name = "pfxFileTextbox";
            this.pfxFileTextbox.Size = new System.Drawing.Size(351, 20);
            this.pfxFileTextbox.TabIndex = 1;
            // 
            // pfxButton
            // 
            this.pfxButton.Location = new System.Drawing.Point(468, 4);
            this.pfxButton.Name = "pfxButton";
            this.pfxButton.Size = new System.Drawing.Size(75, 23);
            this.pfxButton.TabIndex = 2;
            this.pfxButton.Text = "Browse ...";
            this.pfxButton.UseVisualStyleBackColor = true;
            this.pfxButton.Click += new System.EventHandler(this.pfxButton_Click);
            // 
            // pfxPasswordTextbox
            // 
            this.pfxPasswordTextbox.Location = new System.Drawing.Point(101, 50);
            this.pfxPasswordTextbox.Name = "pfxPasswordTextbox";
            this.pfxPasswordTextbox.Size = new System.Drawing.Size(100, 20);
            this.pfxPasswordTextbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input files:";
            // 
            // outputFolderLabel
            // 
            this.outputFolderLabel.AutoSize = true;
            this.outputFolderLabel.Location = new System.Drawing.Point(14, 99);
            this.outputFolderLabel.Name = "outputFolderLabel";
            this.outputFolderLabel.Size = new System.Drawing.Size(71, 13);
            this.outputFolderLabel.TabIndex = 7;
            this.outputFolderLabel.Text = "Output folder:";
            // 
            // outputFolderTextbox
            // 
            this.outputFolderTextbox.Enabled = false;
            this.outputFolderTextbox.Location = new System.Drawing.Point(101, 95);
            this.outputFolderTextbox.Name = "outputFolderTextbox";
            this.outputFolderTextbox.Size = new System.Drawing.Size(351, 20);
            this.outputFolderTextbox.TabIndex = 8;
            // 
            // cmsSignButton
            // 
            this.cmsSignButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmsSignButton.Location = new System.Drawing.Point(243, 284);
            this.cmsSignButton.Name = "cmsSignButton";
            this.cmsSignButton.Size = new System.Drawing.Size(75, 23);
            this.cmsSignButton.TabIndex = 9;
            this.cmsSignButton.Text = "Sign";
            this.cmsSignButton.UseVisualStyleBackColor = true;
            this.cmsSignButton.Click += new System.EventHandler(this.cmsSignButton_Click);
            // 
            // openOutputFolderButton
            // 
            this.openOutputFolderButton.Location = new System.Drawing.Point(468, 94);
            this.openOutputFolderButton.Name = "openOutputFolderButton";
            this.openOutputFolderButton.Size = new System.Drawing.Size(75, 23);
            this.openOutputFolderButton.TabIndex = 10;
            this.openOutputFolderButton.Text = "Open folder";
            this.openOutputFolderButton.UseVisualStyleBackColor = true;
            this.openOutputFolderButton.Click += new System.EventHandler(this.openOutputFolderButton_Click);
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
            this.inputFileListview.Location = new System.Drawing.Point(101, 144);
            this.inputFileListview.Name = "inputFileListview";
            this.inputFileListview.ShowItemToolTips = true;
            this.inputFileListview.Size = new System.Drawing.Size(351, 134);
            this.inputFileListview.TabIndex = 20;
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
            // CmsSignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 319);
            this.Controls.Add(this.inputFileListview);
            this.Controls.Add(this.openOutputFolderButton);
            this.Controls.Add(this.cmsSignButton);
            this.Controls.Add(this.outputFolderTextbox);
            this.Controls.Add(this.outputFolderLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pfxPasswordTextbox);
            this.Controls.Add(this.pfxButton);
            this.Controls.Add(this.pfxFileTextbox);
            this.Controls.Add(this.pfxPasswordLabel);
            this.Controls.Add(this.pfxFileLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CmsSignForm";
            this.Text = "CMS Sign";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label pfxPasswordLabel;
        private System.Windows.Forms.Label pfxFileLabel;
        private System.Windows.Forms.TextBox pfxFileTextbox;
        private System.Windows.Forms.Button pfxButton;
        private System.Windows.Forms.TextBox pfxPasswordTextbox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label outputFolderLabel;
        private System.Windows.Forms.TextBox outputFolderTextbox;
        private System.Windows.Forms.Button cmsSignButton;
        private System.Windows.Forms.Button openOutputFolderButton;
        private System.Windows.Forms.ListView inputFileListview;
        private System.Windows.Forms.ColumnHeader IdColumn;
        private System.Windows.Forms.ColumnHeader FileColumn;
        private System.Windows.Forms.ColumnHeader ResultColumn;
    }
}