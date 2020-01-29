using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_autoupdate.Classes
{
    public class CallRequest
    {
        public static string callRequest(string req)
        {
            System.Net.WebRequest REQUEST = System.Net.WebRequest.Create(req);
            REQUEST.Proxy = null;
            System.Net.WebResponse RESPONSE = REQUEST.GetResponse();
            System.IO.Stream DATASTREAM = RESPONSE.GetResponseStream();
            System.IO.StreamReader READER = new System.IO.StreamReader(DATASTREAM);
            string STREAMCONTENT = READER.ReadToEnd();

            return STREAMCONTENT.ToString();
        }
    }
}
