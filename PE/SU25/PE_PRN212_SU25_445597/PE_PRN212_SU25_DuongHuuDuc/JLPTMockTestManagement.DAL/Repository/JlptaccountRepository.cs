using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLPTMockTestManagement.DAL.Entities;

namespace JLPTMockTestManagement.DAL.Repository
{
    public class JlptaccountRepository
    {
        private Su25jlptmockTestDbContext _context;

        public Jlptaccount? GetOne(string email, string password)
        {
            _context = new Su25jlptmockTestDbContext();
            return _context.Jlptaccounts.FirstOrDefault(e => e.Email.ToLower() == email.ToLower() && e.Password == password);
        }
    }
}
