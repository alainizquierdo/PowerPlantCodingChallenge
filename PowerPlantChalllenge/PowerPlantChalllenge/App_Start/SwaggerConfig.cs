using System.Web.Http;
using WebActivatorEx;
using PowerPlantChalllenge;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace PowerPlantChalllenge
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
              .EnableSwagger(c => c.SingleApiVersion("v1", "PowerPlant"))
              .EnableSwaggerUi();
        }
    }
}
