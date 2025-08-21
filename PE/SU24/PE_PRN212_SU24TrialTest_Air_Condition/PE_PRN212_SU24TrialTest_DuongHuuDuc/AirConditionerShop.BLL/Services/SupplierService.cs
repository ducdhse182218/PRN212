using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL.Models;
using AirConditionerShop.DAL.Repositories;

namespace AirConditionerShop.BLL.Services
{
    public class SupplierService
    {
        private SupplierRepository _repo = new();
        // Lấy danh sách nhà cung cấp
        public List<SupplierCompany> GetAllSuppliers()
        {
            return _repo.GetAll();
        }
    }
}
