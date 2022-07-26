using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParsingWebService.Class
{
    public class GetRequest
    {
        HttpWebRequest _request;
        string _addres;

        public string Response { get; set; }

        public GetRequest(string addres)
        {
            _addres = addres;
        }
        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_addres);
            _request.Method = "GET";


            try
            {
                HttpWebResponse request = (HttpWebResponse)_request.GetResponse();
                var stream = request.GetResponseStream();
                if (stream != null)
                {
                    Response = new StreamReader(stream).ReadToEnd();
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
