using HW3.Models.DBTables;
using System.Collections.Generic;

namespace DataAcess.Datatables.Repositories.interfaces
{
    public interface ICustomerRepository
    {
        public void Add(DBCustomers customer);

        public void Delete(DBCustomers customer);

        public void Update(DBCustomers customer, string value, string column);

        public List<DBCustomers> Read(string value, string column);
    }
}
