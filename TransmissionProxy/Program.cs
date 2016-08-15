using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace TransmissionProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            bool valid = false;

            if (args.Length == 1)
            {
                // get the argument
                string arg = args[0];

                // try to create request data from the argument
                AddRequestData requestData = null;
                try
                {
                    if (arg.StartsWith("magnet:?xt")) // its a magnet url
                    {
                        requestData = new MagnetAddRequestData(arg);
                    }
                    else if (File.Exists(arg) && new FileInfo(arg).Extension == ".torrent") // its a torrent file
                    {
                        requestData = new TorrentAddRequestData(arg);
                    }
                }
                catch{ /* failed, then valid should stay false */ }

                if (requestData != null)
                {
                    // successfully created request data
                    valid = true;

                    // run the main form
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm(requestData));
                }
            }

            // if failed, then show error message
            if (!valid)
                MessageBox.Show("Invalid torrent/magnet parameter", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
