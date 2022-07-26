using ParsingWebService.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParsingWebService
{
   public abstract class MyRequest
    {
        
        public string adress;
        public string Responce { get; set; }
        public DateTime thisTime { get; set; }

        public MyRequest(string _adress)
        {           
            adress = _adress;
        }
        abstract public abstractData Create(string adress);
        abstract public void Run();
    }
}
