using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerPlantChalllenge.Models
{

    public class PayLoad
    {
        public int load { get; set; }
        public Dictionary<string, float> fuels { get; set; }
        public Powerplant[] powerplants { get; set; }
    }

    public class Fuels
    {
        public float gaseuroMWh { get; set; }
        public float kerosineeuroMWh { get; set; }
        public int co2euroton { get; set; }
        public int wind { get; set; }
    }

    public class Powerplant
    {
        public string name { get; set; }
        public string type { get; set; }
        public float efficiency { get; set; }
        public int pmin { get; set; }
        public int pmax { get; set; }
    }

}