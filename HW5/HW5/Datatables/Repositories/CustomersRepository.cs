using DataAcess.Datatables;
using DataAcess.Datatables.Repositories.interfaces;
using HW3.Models.DBTables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAcess.Datatables.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IDBShopContext _context;

        public CustomersRepository([FromServices] IDBShopContext context)
        {
            _context = context;
        }
        
        public void Add(DBCustomers customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Delete(DBCustomers customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public void Update(DBCustomers customer, string value, string column)
        {
            DBCustomers result = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);
            _context.Customers.Attach(result);

            switch (column)
            {
                case "Id": result.Id = Guid.Parse(value); break;
                case "Name": result.Name = value; break;
                case "Surename": result.Surename = value; break;
                case "Adress": result.Adress = value; break;
                default: return;
            }

            _context.SaveChanges();
        }

        public List<DBCustomers> Read(string value, string column)
        {
            List<DBCustomers> result = new();
            switch (column)
            {
                case "Id": result = _context.Customers.Where(x => x.Id == Guid.Parse(value)).ToList(); break;
                case "Name": result = _context.Customers.Where(x => x.Name == value).ToList(); break;
                case "Surename": result = _context.Customers.Where(x => x.Surename == value).ToList(); break;
                case "Adress": result = _context.Customers.Where(x => x.Adress == value).ToList(); break;
                default: return null;
            }
            return result;
        }
    }
}
