using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlantNurseryManagement.DAL.Entities;

namespace PlantNurseryManagement.DAL.Repositories
{
    public class InventoryRepository
    {
        Sp25PlantInventoryDbContext _context;

        public List<Inventory> GetAll()
        {
            _context = new Sp25PlantInventoryDbContext();
            return _context.Inventories.Include("Plant").ToList();
        }

        public void Save(Inventory inventory)
        {
            _context = new Sp25PlantInventoryDbContext();
            _context.Inventories.Add(inventory);
            _context.SaveChanges();
        }

        public void Update(Inventory inventory)
        {
            _context = new Sp25PlantInventoryDbContext();
            _context.Inventories.Update(inventory);
            _context.SaveChanges();
        }

        public void Delete(Inventory inventory)
        {
            _context = new Sp25PlantInventoryDbContext();
            _context.Inventories.Remove(inventory);
            _context.SaveChanges();
        }
    }
}
