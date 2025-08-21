using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeManagement.DAL.Entities;
using PerfumeManagement.DAL.Repositories;

namespace PerfumeManagement.BLL.Services
{
    public class PsaccountService
    {
        PsaccountRepository _repo = new();

        public Psaccount? Authenticate(string email, string password)
        {
            return _repo.GetOne(email, password);
        }
    }
}
