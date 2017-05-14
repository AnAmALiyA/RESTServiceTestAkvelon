using DAO.Entities;
using System;

namespace ServiceTest.Helpers
{
    public class UserHelper
    {
        public static User CreateUser(string nickName, string fullName)
        {
            if (!String.IsNullOrWhiteSpace(nickName) && !String.IsNullOrWhiteSpace(fullName))
            {
                return new User() { NickName = nickName, FullName = fullName};
            }
            else throw new ArgumentException();
        }
    }
}
