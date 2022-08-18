using HW3.Models.DBTables;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.Datatables
{
    public interface IDBShopContext
    {
        public DbSet<DBProviders> Providers { get; set; }

        public DbSet<DBItems> Items { get; set; }

        public DbSet<DBCustomers> Customers { get; set; }

        public DbSet<DBOrders> Orders { get; set; }

        public void SaveChanges();
    }
}
