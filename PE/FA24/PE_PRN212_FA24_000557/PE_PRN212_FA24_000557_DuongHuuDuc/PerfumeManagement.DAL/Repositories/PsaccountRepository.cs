using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeManagement.DAL.Entities;

namespace PerfumeManagement.DAL.Repositories
{
    public class PsaccountRepository
    {
        private Fall24PerfumeStoreDbContext _context;

        public Psaccount GetOne(string email, string password)
        {
            _context = new Fall24PerfumeStoreDbContext();
            return _context.Psaccounts.FirstOrDefault(e => e.EmailAddress.ToLower() == email.ToLower() && e.Password == password);
        }
    }
}
