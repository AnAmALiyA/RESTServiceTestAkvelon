using RestService;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace RESTserviceConsoleApplication.Common
{
    public class ProviderService
    {
        public ServiceHost DeployServiceHost()
        {
            ServiceHost serviceHost = null;
            try
            {
                serviceHost = new ServiceHost(typeof(RestServiceImplementation));
                ServiceMetadataBehavior serviceBehavior = new ServiceMetadataBehavior();
                serviceBehavior.HttpGetEnabled = true;
                serviceHost.Description.Behaviors.Add(serviceBehavior);
                serviceHost.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during service deployment occurred: " + ex.Message);
            }
            return serviceHost;
        }
    }
}
