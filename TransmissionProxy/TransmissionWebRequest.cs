using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TransmissionProxy
{
    public static class TransmissionWebRequest
    {
        #region Response class
        public class TransmissionWebRequestResponse
        {
            /// <summary>
            /// Gets a value indicating whether this <see cref="TransmissionWebRequestResponse"/> is success.
            /// </summary>
            /// <value>
            ///   <c>true</c> if success; otherwise, <c>false</c>.
            /// </value>
            public bool Success { get; private set; }

            /// <summary>
            /// Gets the message.
            /// </summary>
            /// <value>
            /// The message.
            /// </value>
            public string Message { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="TransmissionWebRequestResponse"/> class.
            /// </summary>
            /// <param name="message">The message.</param>
            public TransmissionWebRequestResponse(string message = null)
            {
                this.Success = message == "success";
                this.Message = message;
            }
        }
        #endregion

        #region Constants
        private const string REQUEST_PATH = "transmission/rpc";
        #endregion

        #region Private fields
        private static string session = null;
        #endregion

        /// <summary>
        /// Executes the request.
        /// </summary>
        /// <param name="requestData">The request data.</param>
        /// <returns></returns>
        public async static Task<TransmissionWebRequestResponse> ExecuteRequest(AddRequestData requestData)
        {
            try
            {
                // get url from registry
                string url = RegistrySettings.URL;
                if (!url.EndsWith("/"))
                    url += "/";

                // add path
                url += REQUEST_PATH;

                // get session
                if (session == null)
                    session = await GetSession(url);

                // create web request
                var request = CreateWebRequest(url);
                request.Headers["X-Transmission-Session-Id"] = session;

                // get data to send
                byte[] postData = Encoding.UTF8.GetBytes(requestData.ToJson());
                request.ContentLength = postData.Length;

                // send request data
                using (var sendStream = request.GetRequestStream())
                    await sendStream.WriteAsync(postData, 0, postData.Length);

                using (var response = request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        // get response data
                        byte[] responseData = new byte[response.ContentLength];
                        int bytesRead = await stream.ReadAsync(responseData, 0, Convert.ToInt32(response.ContentLength));
                        string responseJson = Encoding.UTF8.GetString(responseData);

                        // parse json response
                        var result = new JavaScriptSerializer().Deserialize<Dictionary<String, Object>>(responseJson);
                        return new TransmissionWebRequestResponse(result["result"].ToString()); // TODO: fetch error message
                    }
                }
            }
            catch(Exception e)
            {
                // catch exception and return false with message
                return new TransmissionWebRequestResponse(e.Message);
            }
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private async static Task<string> GetSession(string url)
        {
            // create web request
            var request = CreateWebRequest(url);

            // get data to send
            byte[] postData = Encoding.UTF8.GetBytes("{\"method\":\"session-get\"}");
            request.ContentLength = postData.Length;

            // send request data
            using (var sendStream = request.GetRequestStream())
                await sendStream.WriteAsync(postData, 0, postData.Length);

            try
            {
                // try get the response from the request
                using (var response = await request.GetResponseAsync())
                {
                    return response.Headers["X-Transmission-Session-Id"];
                }
            }
            catch (WebException wex)
            {
                // failed, get the response from the exception
                return wex.Response.Headers["X-Transmission-Session-Id"];
            }
        }

        /// <summary>
        /// Creates a web request.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private static HttpWebRequest CreateWebRequest(string url)
        {
            // create web request
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            // set request headers
            request.Method = "POST";
            request.Accept = "application/json";
            request.UserAgent = "TransmissionProxy-" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            request.ContentType = "json; charset=UTF-8";

            request.Headers["Pragma"] = "no-cache";
            request.Headers["Cache-Control"] = "no-cache";

            // return the request
            return request;
        }
    }
}
