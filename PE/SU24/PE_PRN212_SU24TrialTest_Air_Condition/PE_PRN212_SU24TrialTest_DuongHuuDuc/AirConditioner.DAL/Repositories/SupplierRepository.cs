using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL.Models;

namespace AirConditionerShop.DAL.Repositories
{
    public class SupplierRepository
    {
        private AirConditionerShop2024DbContext _context;

        public List<SupplierCompany> GetAll()
        {
            _context = new AirConditionerShop2024DbContext();
            return _context.SupplierCompanies.ToList(); // SELECT * FROM SupplierCompany
        }
    }
}
