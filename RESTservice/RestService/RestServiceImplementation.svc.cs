using DAO.EF;
using DAO.Entities;
using DAO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;

namespace RestService
{
    public class RestServiceImplementation : IRestServiceImplementation
    {
        private readonly UserRepository _userRepositiry;

        public RestServiceImplementation()
        {
            _userRepositiry = new UserRepository(new EFContext());
        }

        public List<User> ReturnListOfUsers()
        {
            var result = _userRepositiry.GetAll();

            if (result.Count() != 0)
            {
                return result;
            }

            throw new WebFaultException<string>("No users currently in Data Base.", HttpStatusCode.NoContent);
        }

        public User GetUserInformation(string nickName)
        {
            var result = _userRepositiry.FindBy(nickName);

            if (result != null)
            {
                return result;
            }

            throw new WebFaultException<string>(String.Format("{0} user not found.", nickName), HttpStatusCode.NotFound);
        }

        public string AddUser(string nickName, string fullName)
        {
            var result = _userRepositiry.FindBy(nickName);
            if (result != null)
            {
                var user = new User { NickName = nickName, FullName = fullName };
                _userRepositiry.Add(user);
                return String.Format("User {0} successfully addded.", nickName);
            }

            throw new WebFaultException<string>(String.Format("User {0} not added."), HttpStatusCode.NotImplemented);
        }

        public string UpdateUser(string nickName, string fullName)
        {
            var user = new User { NickName = nickName, FullName = fullName };
            bool result = _userRepositiry.Edit(user);

            if (result)
            {
                return String.Format("User {0} successfully updated.", nickName);
            }

            throw new WebFaultException<string>(String.Format("{0} user not found.", nickName), HttpStatusCode.NotModified);
        }

        public string DeleteUser(string nickName)
        {
            bool result = _userRepositiry.Delete(nickName);
            if (result)
            {
                return String.Format("User {0} was deleted.", nickName);
            }

            throw new WebFaultException<string>(String.Format("{0} user not found.", nickName), HttpStatusCode.NoContent);
        }

    }
}
