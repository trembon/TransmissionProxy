using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TransmissionProxy
{
    public abstract class AddRequestData
    {
        #region Fields
        protected string torrentKey;
        protected string torrentValue;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AddRequestData"/> is autostart.
        /// </summary>
        /// <value>
        ///   <c>true</c> if autostart; otherwise, <c>false</c>.
        /// </value>
        public bool Autostart { get; set; }

        /// <summary>
        /// Gets or sets the download folder.
        /// </summary>
        /// <value>
        /// The download folder.
        /// </value>
        public string DownloadFolder { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AddRequestData"/> class.
        /// </summary>
        public AddRequestData()
        {
            this.DownloadFolder = RegistrySettings.DefaultFolder;
            this.Autostart = true;
        }

        /// <summary>
        /// Converts this instance to an json string for Transmission.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return new JsonAddRequestData(this).ToJson();
        }

        #region Json handler class
        private class JsonAddRequestData
        {
            private static int BYTES_20MB = 20971520;

            public string method { get; set; }

            public Dictionary<string, object> arguments { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="JsonAddRequestData"/> class.
            /// </summary>
            /// <param name="requestData">The request data.</param>
            public JsonAddRequestData(AddRequestData requestData)
            {
                // set method
                method = "torrent-add";

                // set arguments
                arguments = new Dictionary<string, object>();
                arguments.Add("paused", !requestData.Autostart);
                arguments.Add("download-dir", requestData.DownloadFolder);

                // set the torrent data
                arguments.Add(requestData.torrentKey, requestData.torrentValue);
            }

            /// <summary>
            /// Converts this instance to an json string for Transmission.
            /// </summary>
            /// <returns></returns>
            public string ToJson()
            {
                return new JavaScriptSerializer() { MaxJsonLength = BYTES_20MB }.Serialize(this);
            }
        }
        #endregion
    }
}
