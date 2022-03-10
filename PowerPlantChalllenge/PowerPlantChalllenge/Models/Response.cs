using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerPlantChalllenge.Models
{

    public class Response
    {
        public Class1[] Responses { get; set; }
    }

    public class Class1
    {
        public string name { get; set; }
        public int p { get; set; }
    }

}