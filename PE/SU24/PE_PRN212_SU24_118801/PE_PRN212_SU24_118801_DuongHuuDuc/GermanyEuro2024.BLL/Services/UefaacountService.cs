using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GermanyEuro2024.DAL.Entities;
using GermanyEuro2024.DAL.Repositories;

namespace GermanyEuro2024.BLL.Services
{
    public class UefaacountService
    {
        UefaacountRepository _repo = new();

        public Uefaaccount Authenticate(string email, string password)
        {
            return _repo.GetOne(email, password);
        }
    }
}
