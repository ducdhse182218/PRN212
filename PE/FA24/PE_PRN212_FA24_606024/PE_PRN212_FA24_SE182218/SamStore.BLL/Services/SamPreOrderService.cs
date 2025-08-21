using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using SamStore.DAL.Entities;
using SamStore.DAL.Repositories;

namespace SamStore.BLL.Services
{
    public class SamPreOrderService
    {
        private SamPreOrderRepository _repo = new();

        public List<SamPreOrder> GetAll()
        {
            return _repo.GetAll();
        }

        public void Save(SamPreOrder order)
        {
            _repo.Save(order);
        }

        public void Update(SamPreOrder order)
        {
            _repo.Update(order);
        }

        public void Delete(SamPreOrder order)
        {
            _repo.Delete(order);
        }

        public List<SamPreOrder> Search(string searchString)
        {
            var result = GetAll();
            if (searchString.IsNullOrEmpty())
            {
                return result;
            }
            else
            {
                return result.Where(e => e.PreOrderNo.ToLower().Contains(searchString.ToLower()) || e.CustomerPhone.ToLower().Contains(searchString.ToLower())).ToList();
            }
        }
    }
}
