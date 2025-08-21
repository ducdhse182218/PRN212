using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamStore.DAL.Entities;

namespace SamStore.DAL.Repositories
{
    public class SamProductRepository
    {
        SamStoreContext _context;

        public List<SamProduct> GetAll()
        {
            _context = new SamStoreContext();
            return _context.SamProducts.ToList();
        }
    }
}
