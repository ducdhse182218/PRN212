using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantNurseryManagement.DAL.Entities;

namespace PlantNurseryManagement.DAL.Repositories
{
    public class SystemUserRepository
    {
        Sp25PlantInventoryDbContext _context;

        public SystemUser? GetOne(string email, string password)
        {
            _context = new Sp25PlantInventoryDbContext();
            return _context.SystemUsers.FirstOrDefault(e => e.UserEmail.ToLower() == email.ToLower() && e.UserPassword == password);
        }
    }
}
