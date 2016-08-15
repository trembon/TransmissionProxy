namespace TransmissionProxy
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblDownloadFolder = new System.Windows.Forms.Label();
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.lblTorrentName = new System.Windows.Forms.Label();
            this.txtTorrentName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkAutostart = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblDownloadFolder
            // 
            this.lblDownloadFolder.AutoSize = true;
            this.lblDownloadFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadFolder.Location = new System.Drawing.Point(9, 65);
            this.lblDownloadFolder.Name = "lblDownloadFolder";
            this.lblDownloadFolder.Size = new System.Drawing.Size(99, 13);
            this.lblDownloadFolder.TabIndex = 30;
            this.lblDownloadFolder.Text = "Download folder";
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.Location = new System.Drawing.Point(12, 85);
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.Size = new System.Drawing.Size(260, 20);
            this.txtDownloadFolder.TabIndex = 1;
            // 
            // lblTorrentName
            // 
            this.lblTorrentName.AutoSize = true;
            this.lblTorrentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTorrentName.Location = new System.Drawing.Point(9, 9);
            this.lblTorrentName.Name = "lblTorrentName";
            this.lblTorrentName.Size = new System.Drawing.Size(82, 13);
            this.lblTorrentName.TabIndex = 10;
            this.lblTorrentName.Text = "Torrent name";
            // 
            // txtTorrentName
            // 
            this.txtTorrentName.Location = new System.Drawing.Point(12, 29);
            this.txtTorrentName.Name = "txtTorrentName";
            this.txtTorrentName.ReadOnly = true;
            this.txtTorrentName.Size = new System.Drawing.Size(260, 20);
            this.txtTorrentName.TabIndex = 20;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(196, 120);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Download";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(115, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkAutostart
            // 
            this.chkAutostart.AutoSize = true;
            this.chkAutostart.Location = new System.Drawing.Point(12, 124);
            this.chkAutostart.Name = "chkAutostart";
            this.chkAutostart.Size = new System.Drawing.Size(68, 17);
            this.chkAutostart.TabIndex = 2;
            this.chkAutostart.Text = "Autostart";
            this.chkAutostart.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 153);
            this.Controls.Add(this.chkAutostart);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTorrentName);
            this.Controls.Add(this.lblTorrentName);
            this.Controls.Add(this.txtDownloadFolder);
            this.Controls.Add(this.lblDownloadFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download with Transmission";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDownloadFolder;
        private System.Windows.Forms.TextBox txtDownloadFolder;
        private System.Windows.Forms.Label lblTorrentName;
        private System.Windows.Forms.TextBox txtTorrentName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkAutostart;
    }
}