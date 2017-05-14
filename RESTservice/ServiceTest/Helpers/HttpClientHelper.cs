using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using System.Net;
using TechTalk.SpecFlow;

namespace ServiceTest.Helpers
{
    public class HttpClientHelper
    {
        private HttpWebRequest httpWebRequest;
        private readonly string _userkey = "user";
        private readonly string _testString = "test";

        public HttpClientHelper(string method = "GET", string endpoint = "/Services/TestService/Users", string contentType = "application/json")
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["endpoint"] + endpoint);
            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = method;
        }

        public void AttachAddUserMessage(string nickName, string fullName)
        {
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var user = UserHelper.CreateUser(nickName, fullName);
                string json = JsonConvert.SerializeObject(user);
                streamWriter.Write(json);
            }
        }

        public void AttachAddUserWrongMessage(string nickName, string fullName)
        {
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new { Nick = nickName, FullName = fullName });
                streamWriter.Write(json);
            }
        }

        public string SendRequest()
        {
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (WebException exception)
            {
                return exception.Message;
            }
        }
    }
}
