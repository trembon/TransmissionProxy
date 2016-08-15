using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransmissionProxy
{
    public static class RegistrySettings
    {
        private const string REGISTRY_ROOT = "HKEY_LOCAL_MACHINE\\Software";

        /// <summary>
        /// Gets the URL of Transmission.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public static string URL
        {
            get
            {
                return ReadValue("URL");
            }
        }

        /// <summary>
        /// Gets the default folder.
        /// </summary>
        /// <value>
        /// The default folder.
        /// </value>
        public static string DefaultFolder
        {
            get { return ReadValue("DefaultFolder"); }
        }

        /// <summary>
        /// Reads a value from the registry.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private static string ReadValue(string key)
        {
            string regFolder = String.Format("{0}\\{1}", REGISTRY_ROOT, Application.ProductName);
            return Registry.GetValue(regFolder, key, String.Empty).ToString();
        }
    }
}
