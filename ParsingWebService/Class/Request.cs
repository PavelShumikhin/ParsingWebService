using ParsingWebService.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParsingWebService
{
    abstract class Request
    {
        
        public string adress;
        public string Responce { get; set; }

        public Request(string _adress)
        {           
            adress = _adress;
        }
        abstract public Data Create();
        abstract public void Run();
    }
}
