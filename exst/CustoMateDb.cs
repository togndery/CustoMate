using CustoMate.entity;
using Microsoft.EntityFrameworkCore;

namespace CustoMate.exst
{
    public class CustoMateDb:DbContext
    {
        public CustoMateDb(DbContextOptions<CustoMateDb> options) :base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData
                (
                  new Role
                  {
                      Id = 1,
                      RoleName = "Admin"
                  },
                  new Role
                  {
                      Id = 2,
                      RoleName = "User"
                  }
                );
            SaveChangesAsync();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
       public DbSet<Role> Roles { get; set; }
       public DbSet<Customer> Customers { get; set; }

    }
}
