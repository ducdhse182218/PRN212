using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeManagement.DAL.Entities;
using PerfumeManagement.DAL.Repositories;

namespace PerfumeManagement.BLL.Services
{
    public class ProductionCompanyService
    {
        ProductionCompanyRepository _repo = new();

        public List<ProductionCompany> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
