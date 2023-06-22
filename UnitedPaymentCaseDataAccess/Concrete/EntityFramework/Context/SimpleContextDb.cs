using Microsoft.EntityFrameworkCore;
using UnitedPaymentCaseEntity.Concrete;

namespace UnitedPaymentCaseDataAccess.Concrete.EntityFramework.Context
{
    public class SimpleContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=TestDb;Integrated Security=True");
        }

        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Transaction>? Transactions { get; set; }
    }
}
