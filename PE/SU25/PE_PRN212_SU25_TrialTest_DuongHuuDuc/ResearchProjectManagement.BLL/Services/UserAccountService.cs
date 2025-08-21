using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResearchProjectManagement.DAL.Repositories;
using ResearchProjectManagement.DAL.Entities;

namespace ResearchProjectManagement.BLL.Services
{
    public class UserAccountService
    {
        private UserAccountRepository _repo = new();
        public UserAccount? Authenticate(string email, string password)
        {
            return _repo.GetOne(email, password);
        }
    }
}