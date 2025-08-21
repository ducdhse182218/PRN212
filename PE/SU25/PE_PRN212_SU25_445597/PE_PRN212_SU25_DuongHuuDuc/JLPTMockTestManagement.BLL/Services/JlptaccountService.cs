using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLPTMockTestManagement.DAL.Entities;
using JLPTMockTestManagement.DAL.Repository;

namespace JLPTMockTestManagement.BLL.Services
{
    public class JlptaccountService
    {
        JlptaccountRepository _repo = new();

        public Jlptaccount Authenticate(string email, string password)
        {
            return _repo.GetOne(email, password);
        }
    }
}
