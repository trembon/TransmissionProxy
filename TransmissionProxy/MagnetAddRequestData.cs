using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TransmissionProxy
{
    public class MagnetAddRequestData : AddRequestData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MagnetAddRequestData"/> class.
        /// </summary>
        /// <param name="magnet">The magnet.</param>
        public MagnetAddRequestData(string magnet)
            : base()
        {
            // add url from magnet to parameter to transmission
            torrentKey = "filename";
            torrentValue = magnet;

            // parse the name from the magnet url
            Uri uri = new Uri(magnet);
            base.Name = HttpUtility.ParseQueryString(uri.Query).Get("dn");
        }
    }
}
