using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransmissionProxy
{
    public class TorrentAddRequestData : AddRequestData
    {
        private List<object> torrentInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="TorrentAddRequestData"/> class.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        public TorrentAddRequestData(string filepath)
            : base()
        {
            // read torrent file into memory
            byte[] data = File.ReadAllBytes(filepath);

            // base64 encode the torrent file to prepare to send to transmission
            torrentKey = "metainfo";
            torrentValue = Convert.ToBase64String(data, Base64FormattingOptions.InsertLineBreaks);

            // dencode torrent file and get name of torrent
            torrentInfo = BEncode.Decode(Encoding.Default.GetString(data));
            base.Name = ((torrentInfo[0] as Dictionary<string, object>)["info"] as Dictionary<string, object>)["name"].ToString();
        }
    }
}
