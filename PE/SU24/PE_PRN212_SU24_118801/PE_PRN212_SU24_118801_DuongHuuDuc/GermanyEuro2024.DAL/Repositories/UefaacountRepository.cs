using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GermanyEuro2024.DAL.Entities;

namespace GermanyEuro2024.DAL.Repositories
{
    public class UefaacountRepository
    {
        GermanyEuro2024DbContext _context;
        public Uefaaccount GetOne(string email, string password)
        {
            _context = new();
            return _context.Uefaaccounts.FirstOrDefault(e => e.AccountEmail.ToLower() == email.ToLower() && e.AccountPassword == password);
        }
    }
}
