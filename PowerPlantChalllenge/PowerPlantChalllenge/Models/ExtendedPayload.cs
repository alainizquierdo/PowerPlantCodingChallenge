using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerPlantChalllenge.Models
{
    public class ExtendedPayload : PayLoad
    {
        public List<ExtendedPowerplant> plants;
        public ExtendedPayload()
        {
            plants = new List<ExtendedPowerplant>();
        }
        public void FillExtendedProps()
        {
            this.plants = new List<ExtendedPowerplant>();
            foreach (var item in powerplants)
            {
                ExtendedPowerplant p = new ExtendedPowerplant() { efficiency = item.efficiency, name = item.name, pmax = item.pmax, pmin = item.pmin, type = item.type };

                switch (item.type)
                {
                    case "windturbine":
                        p.generation = item.pmax * this.fuels["wind(%)"] / 100;
                        break;
                    case "turbojet":
                        p.cost = this.fuels["kerosine(euro/MWh)"] * p.efficiency;
                        p.generation = p.pmax;
                        break;
                    case "gasfired":
                        p.cost = this.fuels["gas(euro/MWh)"] * p.efficiency;
                        p.generation = p.pmax;
                        break;
                }
                plants.Add(p);
            }
        }
    }

    public class ExtendedPowerplant
    {
        public string name { get; set; }
        public string type { get; set; }
        public float efficiency { get; set; }
        public int pmin { get; set; }   
        public int pmax { get; set; }
        public float generation { get; set; }
        public float cost { get; set; }

    }
}