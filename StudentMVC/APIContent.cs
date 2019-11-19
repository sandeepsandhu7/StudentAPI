using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace StudentMVC
{
    public static class APIContent
    {
        public static HttpClient WebApiClient = new HttpClient();
        static APIContent()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:61832/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}