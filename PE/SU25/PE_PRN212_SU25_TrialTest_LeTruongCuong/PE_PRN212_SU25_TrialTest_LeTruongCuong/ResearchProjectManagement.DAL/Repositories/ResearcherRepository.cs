using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResearchProjectManagement.DAL.Contexts;
using ResearchProjectManagement.DAL.Entities;

namespace ResearchProjectManagement.DAL.Repositories
{
    public class ResearcherRepository
    {
        Su25researchDbContext _context;

        public List<Researcher> GetAll()
        {
            _context = new Su25researchDbContext();
            return _context.Researchers.ToList();
        }
    }
}
