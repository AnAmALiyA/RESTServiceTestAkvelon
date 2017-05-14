using DAO.Entities;
using System.Data.Entity;

namespace DAO.EF
{
    public class DbInitializer: CreateDatabaseIfNotExists<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            InitializeIdentities(context);
            base.Seed(context);
        }

        private static void InitializeIdentities(EFContext context)
        {
            context.Users.Add(new User { NickName = "nickName1", FullName = "fullName1" });
            context.Users.Add(new User { NickName = "nickName2", FullName = "fullName2" });
        }
    }
}
