using Inventory.Models.Interfaces;
using Inventory.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Apis : IApis
    {
        public string Catalog { get; set; }

        private string Get(string uri)
        {
            WebRequest request = WebRequest.Create(uri);

            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();

            try
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    return new StreamReader(dataStream).ReadToEnd();
                }
            }
            finally
            {
                response?.Close();
            }
        }

        private string Post<T>(string uri, T content)
        {
            WebRequest request = WebRequest.Create(uri);
            request.Method = "POST";

            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();

            try
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    return new StreamReader(dataStream).ReadToEnd();
                }
            }
            finally
            {
                response?.Close();
            }
        }

        public void GetFromCatalog<T>(string path, Action<string, T> callback = null)
        {
            // Create a request for the URL.
            string uri = string.Concat(this.Catalog, path);
            string result = Get(uri);

            if (callback == null || callback == default)
            {
                return;
            }

            callback.Invoke(result, JsonConvert.DeserializeObject<T>(result));
        }
    }
}
