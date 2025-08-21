using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamStore.DAL.Entities;
using SamStore.DAL.Repositories;

namespace SamStore.BLL.Services
{
    public class MemberService
    {
        MemberRepository _repo = new();
        public Member Authenticate(string email, string password)
        {
            return _repo.GetOne(email, password);
        }
    }
}
