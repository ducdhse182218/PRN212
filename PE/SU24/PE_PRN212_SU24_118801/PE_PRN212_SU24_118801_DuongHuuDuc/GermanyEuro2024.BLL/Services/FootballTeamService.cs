using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GermanyEuro2024.DAL.Entities;
using GermanyEuro2024.DAL.Repositories;

namespace GermanyEuro2024.BLL.Services
{
    public class FootballTeamService
    {
        FootballTeamRepository _repo = new();
        public List<FootballTeam> GetAll()
        {
            _repo = new FootballTeamRepository();
            return _repo.GetAll();
        }
    }
}
