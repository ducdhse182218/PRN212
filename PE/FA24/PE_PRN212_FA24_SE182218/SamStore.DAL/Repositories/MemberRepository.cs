using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamStore.DAL.Entities;

namespace SamStore.DAL.Repositories
{
    public class MemberRepository
    {
        SamStoreContext _context = new();

        public Member GetOne(string email, string password)
        {
            _context = new();
            return _context.Members.FirstOrDefault(e => e.Email.ToLower() == email.ToLower() && e.Password == password);
        }
    }
}
