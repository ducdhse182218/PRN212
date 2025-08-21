using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamStore.DAL.Entities;

namespace SamStore.DAL.Repositories
{
    public class SamPreOrderRepository
    {
        SamStoreContext _context;
        public List<SamPreOrder> GetAll()
        {
            _context = new SamStoreContext();
            return _context.SamPreOrders.Include("Product").ToList();
        }

        public void Save(SamPreOrder project)
        {
            _context = new();
            _context.SamPreOrders.Add(project);
            _context.SaveChanges();
        }

        public void Update(SamPreOrder project)
        {
            _context = new();
            _context.SamPreOrders.Update(project);
            _context.SaveChanges();
        }

        public void Delete(SamPreOrder project)
        {
            _context = new();
            _context.SamPreOrders.Remove(project);
            _context.SaveChanges();
        }
    }
}
