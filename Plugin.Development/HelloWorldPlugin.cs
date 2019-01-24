using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Development
{
    public class HelloWorldPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            
            Entity entity = (Entity)context.InputParameters["Target"];
            string name = (string)entity["ita_name"];
            if ("Test".Equals(name))
            {
                throw new InvalidPluginExecutionException("Cannot use this name");
            }

            //Organizational service 
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
        }
    }
}
