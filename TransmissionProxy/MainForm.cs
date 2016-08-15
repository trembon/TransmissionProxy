using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransmissionProxy
{
    public partial class MainForm : Form
    {
        private AddRequestData requestData;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        /// <param name="requestData">The request data.</param>
        public MainForm(AddRequestData requestData)
        {
            InitializeComponent();

            // set request data
            this.requestData = requestData;

            // set default values
            txtTorrentName.Text = requestData.Name;
            txtDownloadFolder.Text = requestData.DownloadFolder;
            chkAutostart.Checked = requestData.Autostart;
        }

        #region Control events
        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // close form
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btnOK_Click(object sender, EventArgs e)
        {
            // disable controls
            chkAutostart.Enabled = false;
            txtDownloadFolder.Enabled = false;
            btnCancel.Enabled = false;
            btnOK.Enabled = false;

            // update request values
            requestData.Autostart = chkAutostart.Checked;
            requestData.DownloadFolder = txtDownloadFolder.Text;

            // send request to transmission
            var result = await TransmissionWebRequest.ExecuteRequest(requestData);

            if (result.Success)
            {
                // ask if user wants to open an browser to transmission
                if (MessageBox.Show("Torrent successfully added!\nDo you want to open Transmission?", "Open Transmission", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // run url as a system command
                    Process.Start(RegistrySettings.URL);
                }

                // close form
                this.Close();
            }
            else
            {
                // display error and let the user retry
                MessageBox.Show(String.Format("Unable to send to Transmission ({0}).\nError: {1}.", RegistrySettings.URL, result.Message), "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
