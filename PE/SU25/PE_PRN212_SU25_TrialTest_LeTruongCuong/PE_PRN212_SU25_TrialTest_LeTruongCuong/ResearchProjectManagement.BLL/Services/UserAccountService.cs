using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResearchProjectManagement.DAL.Entities;
using ResearchProjectManagement.DAL.Repositories;

namespace ResearchProjectManagement.BLL.Services
{
    public class UserAccountService
    {
        UserAccountRepository _repo = new();

        public UserAccount? Authenticate(string email, string password)
        {
            return _repo.GetOne(email, password);
        }
    }
}
