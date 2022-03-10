using PowerPlantChalllenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PowerPlantChalllenge.Controllers
{
    [Route("productionplan")]
    public class PowerPlantController : ApiController
    {
        int load = 0;
        
        [HttpPost]
        [Route("productionplan")]
        public Class1[] Productionplan([FromBody] PayLoad input)
        {
            ExtendedPayload ep = new ExtendedPayload() { fuels = input.fuels, load = input.load, powerplants = input.powerplants };
            ep.FillExtendedProps();
            List<Class1> resp = new List<Class1>();
          
            work(ep, ep.load, 0, resp);
        
            return resp.ToArray();
        }
        
        private void work(ExtendedPayload ep, int load, int position, List<Class1> resp)
        {
            ep.plants = ep.plants.OrderBy(x => x.cost).ToList();
            if (ep.plants[position].generation > load)
            {
                resp.Add(new Class1() { name = ep.plants[position].name, p = load });
                return;
            }
            else
            {
                resp.Add(new Class1() { name = ep.plants[position].name, p = (int)ep.plants[position].generation });
                load = load - (int)ep.plants[position].generation;
                work(ep, load, position + 1, resp);
            }
        }
    }
}
