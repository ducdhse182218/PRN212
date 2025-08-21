using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantNurseryManagement.DAL.Entities;
using PlantNurseryManagement.DAL.Repositories;

namespace PlantNurseryManagement.BLL.Services
{
    public class SystemUserService
    {
        SystemUserRepository _repo = new();

        public SystemUser? Authenticate(string email, string password)
        {
            return _repo.GetOne(email, password);
        }
    }
}
