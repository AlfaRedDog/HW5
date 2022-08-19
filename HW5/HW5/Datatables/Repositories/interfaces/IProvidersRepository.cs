using HW3.Models.DBTables;
using System.Collections.Generic;

namespace DataAcess.Datatables.Repositories.interfaces
{
    public interface IProvidersRepository
    {
        public void Add(DBProviders provider);

        public void Delete(DBProviders provider);

        public void Update(DBProviders provider, string value, string column);

        public List<DBProviders> Read(string value, string column);
    }
}
