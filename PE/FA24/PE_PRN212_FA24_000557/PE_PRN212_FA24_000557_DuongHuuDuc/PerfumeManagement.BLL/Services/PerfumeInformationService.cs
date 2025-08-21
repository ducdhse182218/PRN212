using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using PerfumeManagement.DAL.Entities;
using PerfumeManagement.DAL.Repositories;

namespace PerfumeManagement.BLL.Services
{
    public class PerfumeInformationService
    {
        PerfumeInformationRepository _repo = new();

        public List<PerfumeInformation> GetAll()
        {
            return _repo.GetAll();
        }

        public void Save(PerfumeInformation perfume)
        {
            _repo.Save(perfume);
        }

        public void Update(PerfumeInformation perfume)
        {
            _repo.Update(perfume);
        }

        public void Delete(PerfumeInformation perfume)
        {
            _repo.Delete(perfume);
        }

        public List<PerfumeInformation> Search(string searchString)
        {
            var result = GetAll();
            if (searchString.IsNullOrEmpty())
            {
                return result;
            }
            else
            {
                return result.Where(e => e.Concentration.ToLower().Contains(searchString.ToLower()) || e.Ingredients.ToLower().Contains(searchString.ToLower())).ToList();
            }
        }
    }
}
