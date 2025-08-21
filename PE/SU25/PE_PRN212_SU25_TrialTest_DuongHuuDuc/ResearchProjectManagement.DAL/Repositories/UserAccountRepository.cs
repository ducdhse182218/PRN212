using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResearchProjectManagement.DAL.Entities;

namespace ResearchProjectManagement.DAL.Repositories
{
    public class UserAccountRepository
    {
        private Su25researchDbContext _context;

        public UserAccount GetOne(string email, string password)
        {
            _context = new Su25researchDbContext();
            return _context.UserAccounts.FirstOrDefault(e => e.Email.ToLower() == email.ToLower() && e.Password == password);   
        }
    }
}
