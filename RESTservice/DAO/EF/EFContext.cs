using DAO.Entities;
using System.Data.Entity;

namespace DAO.EF
{
    public class EFContext : DbContext
    {
        public EFContext() : base("name=TestSqlCompactDb")
        {
            Database.SetInitializer<EFContext>(new DbInitializer());
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(user => user.NickName);            

            base.OnModelCreating(modelBuilder);
        }
    }
}
