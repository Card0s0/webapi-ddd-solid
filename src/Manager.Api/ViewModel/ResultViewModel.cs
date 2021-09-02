using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Api.ViewModel
{
    public class ResultViewModel
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
