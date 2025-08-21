using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamStore.DAL.Entities;
using SamStore.DAL.Repositories;

namespace SamStore.BLL.Services
{
    public class SamProductService
    {
        private SamProductRepository _repo = new();

        public List<SamProduct> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
