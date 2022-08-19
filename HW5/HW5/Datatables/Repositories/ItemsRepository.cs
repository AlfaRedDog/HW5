using DataAcess.Datatables;
using DataAcess.Datatables.Repositories.interfaces;
using HW3.Models.DBTables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAcess.Datatables.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly IDBShopContext _context;

        public ItemsRepository([FromServices] IDBShopContext context)
        {
            _context = context;
        }

         public void Add(DBItems item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void Delete(DBItems item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }

        public void Update(DBItems item, string value, string column)
        {
            DBItems result = _context.Items.FirstOrDefault(c => c.Id == item.Id);
            _context.Items.Attach(result);

            switch (column)
            {
                case "Id": result.Id = Guid.Parse(value); break;
                case "Id_provider": result.Id_provider = Guid.Parse(value); break;
                case "Amount": result.Amount = Int32.Parse(value); break;
                case "Price": result.Price = Int32.Parse(value); break;
                case "Expiration_date": result.Expiration_date = DateTime.Parse(value); break;
                default: return;
            }

            _context.SaveChanges();
        }

        public List<DBItems> Read(string value, string column)
        {
            List<DBItems> result = new();

            switch (column)
            {
                case "Id": result = _context.Items.Where(x => x.Id == Guid.Parse(value)).ToList(); break;
                case "Id_provider": result = _context.Items.Where(x => x.Id_provider == Guid.Parse(value)).ToList(); break;
                case "Amount": result = _context.Items.Where(x => x.Amount == Int32.Parse(value)).ToList(); break;
                case "Price": result = _context.Items.Where(x => x.Price == Int32.Parse(value)).ToList(); break;
                case "Expiration_date": result = _context.Items.Where(x => x.Expiration_date == DateTime.Parse(value)).ToList(); break;
                default: return null;
            }

            return result;
        }
    }
}
