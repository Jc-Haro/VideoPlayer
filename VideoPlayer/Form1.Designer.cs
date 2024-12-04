using System.Security.Principal;

namespace VideoPlayer
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.ftpUrl = new System.Windows.Forms.TextBox();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.listLog = new System.Windows.Forms.ListBox();
            this.openFileDialogFolderPicker = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ftpUrl
            // 
            this.ftpUrl.Location = new System.Drawing.Point(12, 135);
            this.ftpUrl.Name = "ftpUrl";
            this.ftpUrl.Size = new System.Drawing.Size(167, 20);
            this.ftpUrl.TabIndex = 3;
            // 
            // buttonUpload
            // 
            this.buttonUpload.Location = new System.Drawing.Point(11, 198);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(75, 23);
            this.buttonUpload.TabIndex = 4;
            this.buttonUpload.Text = "Upload";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(11, 227);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 23);
            this.buttonDownload.TabIndex = 5;
            this.buttonDownload.Text = "Dowload";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // listLog
            // 
            this.listLog.FormattingEnabled = true;
            this.listLog.Location = new System.Drawing.Point(261, 198);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(227, 238);
            this.listLog.TabIndex = 6;
            // 
            // openFileDialogFolderPicker
            // 
            this.openFileDialogFolderPicker.FileName = "openFileDialog1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(588, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 424);
            this.flowLayoutPanel1.TabIndex = 7;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.listLog);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.ftpUrl);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "scrollbarTry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ftpUrl;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.OpenFileDialog openFileDialogFolderPicker;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

