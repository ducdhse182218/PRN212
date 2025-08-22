using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GermanyEuro2024.DAL.Entities;
using GermanyEuro2024.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace GermanyEuro2024.BLL.Services
{
    public class FootballPlayerService
    {
        FootballPlayerRepository _repo = new();
        public List<FootballPlayer> GetAll()
        {
            return _repo.GetAll();
        }

        public void Save(FootballPlayer footballPlayer)
        {
            _repo.Save(footballPlayer);
        }

        public void Update(FootballPlayer footballPlayer)
        {
            _repo.Update(footballPlayer);
        }

        public void Delete(FootballPlayer footballPlayer)
        {
            _repo.Delete(footballPlayer);
        }

        public List<FootballPlayer> Search(string searchString)
        {
            var result = GetAll();
            if (searchString.IsNullOrEmpty())
            {
                return result;
            }
            else
            {
                return result.Where(e => e.Achievements.ToLower().Contains(searchString.ToLower()) || e.PlayerName.ToLower().Contains(searchString.ToLower())).ToList();
            }
        }
    }
}
