using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JSONtoXML
{
    class APIrequest
    {
        public static string GET(string url)
        {
            WebClient client = new WebClient();
            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);

            string response = reader.ReadToEnd();

            data.Close();
            reader.Close();

            return response;
        }
    }
}
