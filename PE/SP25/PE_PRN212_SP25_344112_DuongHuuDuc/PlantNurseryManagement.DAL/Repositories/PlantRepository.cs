using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantNurseryManagement.DAL.Entities;

namespace PlantNurseryManagement.DAL.Repositories
{
    public class PlantRepository
    {
        Sp25PlantInventoryDbContext _context;

        public List<Plant> GetAll()
        {
            _context = new Sp25PlantInventoryDbContext();
            return _context.Plants.ToList();
        }
    }
}
