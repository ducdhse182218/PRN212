using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLPTMockTestManagement.DAL.Entities;
using JLPTMockTestManagement.DAL.Repository;

namespace JLPTMockTestManagement.BLL.Services
{
    public class CandidateService
    {
        CandidateRepository _repo = new();

        public List<Candidate> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
