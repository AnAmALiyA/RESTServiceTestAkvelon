using RESTserviceConsoleApplication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTserviceConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ProviderService providerService = new ProviderService();
            providerService.DeployServiceHost();

            ConsumerService consumerService = new ConsumerService();
            consumerService.ClientService();
        }
    }
}
