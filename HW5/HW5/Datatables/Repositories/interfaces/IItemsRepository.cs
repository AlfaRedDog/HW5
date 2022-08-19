using HW3.Models.DBTables;
using System.Collections.Generic;

namespace DataAcess.Datatables.Repositories.interfaces
{
    public interface IItemsRepository
    {
        public void Add(DBItems item);

        public void Delete(DBItems item);

        public void Update(DBItems item, string value, string column);

        public List<DBItems> Read(string value, string column);
    }
}
