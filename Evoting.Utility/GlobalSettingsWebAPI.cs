using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Utility
{
    public class GlobalSettingsWebAPI
    {
        public static HttpClient WebApiClient = new HttpClient();
        static GlobalSettingsWebAPI()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44355/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
