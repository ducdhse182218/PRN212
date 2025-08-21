using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResearchProjectManagement.DAL.Entities;

namespace ResearchProjectManagement.DAL.Repositories
{
    public class ResearcherRepository
    {
        private Su25researchDbContext _context;

        public List<Researcher> GetAllResearchers()
        {
            _context = new Su25researchDbContext();
            return _context.Researchers.ToList();
        }
    }
}
