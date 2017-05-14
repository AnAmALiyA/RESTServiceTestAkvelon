using DAO.Entities;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace RestService
{
    [ServiceContract]
    public interface IRestServiceImplementation
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/Services/TestService/Users")]
        List<User> ReturnListOfUsers();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/Services/TestService/Users/{NickName}")]
        User GetUserInformation(string NickName);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/Services/TestService/Users")]

        string AddUser(string NickName, string FullName);

        [OperationContract]
        [WebInvoke(Method = "PUT",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped,
           UriTemplate = "/Services/TestService/Users/{NickName}")]
        string UpdateUser(string NickName, string FullName);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped,
           UriTemplate = "/Services/TestService/Users/{NickName}")]
        string DeleteUser(string NickName);
    }
}
