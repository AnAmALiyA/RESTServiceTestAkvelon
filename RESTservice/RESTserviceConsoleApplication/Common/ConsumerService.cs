using RestService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RESTserviceConsoleApplication.Common
{
    public class ConsumerService
    {
        public IRestServiceImplementation ClientService()
        {
            var binding = new BasicHttpBinding();
            string temp = ConfigurationManager.AppSettings["baseAddress"];
            var endpoint = new EndpointAddress(ConfigurationManager.AppSettings["baseAddress"]);//"http://localhost:8000/RestService.svc"
            var myChannelFactory = new ChannelFactory<IRestServiceImplementation>(binding, endpoint);

            return myChannelFactory.CreateChannel();
        }
    }
}
