using HW3.Models.DBTables;
using System.Collections.Generic;

namespace DataAcess.Datatables.Repositories.interfaces
{
    public interface IOrdersRepository
    {
        public void Add(DBOrders order);

        public void Delete(DBOrders order);

        public void Update(DBOrders order, string value, string column);

        public List<DBOrders> Read(string value, string column);
    }
}
