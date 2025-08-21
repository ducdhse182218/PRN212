using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using PlantNurseryManagement.DAL.Entities;
using PlantNurseryManagement.DAL.Repositories;

namespace PlantNurseryManagement.BLL.Services
{
    public class InventoryService
    {
        InventoryRepository _repo = new();

        public List<Inventory> GetAll()
        {
            return _repo.GetAll();
        }

        public void Save(Inventory inventory)
        {
            _repo.Save(inventory);
        }

        public void Update(Inventory inventory)
        {
            _repo.Update(inventory);
        }

        public void Delete(Inventory inventory)
        {
            _repo.Delete(inventory);
        }
        public List<Inventory> Search(string searchString)
        {
            var result = GetAll();
            if (searchString.IsNullOrEmpty())
            {
                return result;
            }
            else
            {
                return result.Where(e => e.Supplier.ToLower().Contains(searchString.ToLower()) || e.Quantity.ToString().Contains(searchString)).ToList();
            }
        }
    }
}
