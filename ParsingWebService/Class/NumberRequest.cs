using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParsingWebService.Class
{
     class NumberRequest:Request
    {
        public HttpWebRequest request;
       // public string Responce { get; set; }
        public NumberRequest(string _adress) : base( _adress) { }
        public override Data Create()
        {
            return new NumberData();
        }

        //Метод парсинга
       override public void Run()
        {
            request = (HttpWebRequest)WebRequest.Create(adress);
            request.Method = "GET";


            try
            {
                HttpWebResponse _request = (HttpWebResponse)request.GetResponse();
                var stream = _request.GetResponseStream();
                if (stream != null)
                {
                    Responce = new StreamReader(stream).ReadToEnd();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
