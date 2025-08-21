using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantNurseryManagement.DAL.Entities;
using PlantNurseryManagement.DAL.Repositories;

namespace PlantNurseryManagement.BLL.Services
{
    public class PlantService
    {
        PlantRepository _repo = new();
        public List<Plant> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
