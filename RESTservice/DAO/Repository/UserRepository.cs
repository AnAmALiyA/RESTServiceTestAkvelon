using DAO.EF;
using DAO.Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO.Repository
{
    public class UserRepository
    {
        private readonly EFContext _dbContext;

        public UserRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList<User>();
        }

        public User FindBy(string nickName)
        {
            return _dbContext.Users.SingleOrDefault<User>(user => user.NickName == nickName);
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            Save();
        }

        public bool Edit(User user)
        {
            bool isSuccess = false;
            var result = FindBy(user.NickName);

            if (result != null)
            {
                _dbContext.Users.AddOrUpdate(user);
                Save();
                isSuccess = true;
            }

            return isSuccess;
        }

        public bool Delete(string nickName)
        {
            bool isSuccess = false;
            var result = FindBy(nickName);

            if (result != null)
            {
                _dbContext.Users.Remove(result);
                Save();
                isSuccess = true;
            }

            return isSuccess;
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
