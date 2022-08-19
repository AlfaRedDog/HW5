using HW3.Models;
using DataAcess.Datatables;
using HW3.Models.DBTables;
using System.Collections.Generic;
using System.Linq;
using System;
using DataAcess.Datatables.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DataAcess.Datatables.Repositories
{
    public class ProvidersRepository : IProvidersRepository
    {
        private readonly IDBShopContext _context;

        public ProvidersRepository([FromServices] IDBShopContext context)
        {
            _context = context;
        }

        public void Add(DBProviders provider)
        {
            _context.Providers.Add(provider);
            _context.SaveChanges();
        }

        public void Delete(DBProviders provider)
        {
            _context.Providers.Remove(provider);
            _context.SaveChanges();
        }

        public void Update(DBProviders provider, string value, string column)
        {
            DBProviders result = _context.Providers.FirstOrDefault(c => c.Id == provider.Id);
            _context.Providers.Attach(result);

            switch (column)
            {
                case "Id": result.Id = Guid.Parse(value); break;
                case "Name": result.Name = value; break;
                case "Adress": result.Adress = value; break;
                default: return;
            }

            _context.SaveChanges();
        }

        public List<DBProviders> Read(string value, string column)
        {
            List<DBProviders> result = new();
            switch (column)
            {
                case "Id": result = _context.Providers.Where(x => x.Id == Guid.Parse(value)).ToList(); break;
                case "Name": result = _context.Providers.Where(x => x.Name == value).ToList(); break;
                case "Adress": result = _context.Providers.Where(x => x.Adress == value).ToList(); break;
                default: return null;
            }
            return result;
        }
    }
}
