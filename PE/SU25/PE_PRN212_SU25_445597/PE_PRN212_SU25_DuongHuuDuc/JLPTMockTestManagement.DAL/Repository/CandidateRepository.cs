using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLPTMockTestManagement.DAL.Entities;

namespace JLPTMockTestManagement.DAL.Repository
{
    public class CandidateRepository
    {
        private Su25jlptmockTestDbContext _context;

        public List<Candidate> GetAll()
        {
            _context = new Su25jlptmockTestDbContext();
            return _context.Candidates.ToList();
        }
    }
}
