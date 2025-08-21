using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResearchProjectManagement.DAL.Entities;
using ResearchProjectManagement.DAL.Repositories;

namespace ResearchProjectManagement.BLL.Services
{
    public class ResearcherService
    {
        ResearcherRepository _repo = new ResearcherRepository();

        public List<Researcher> GetAllResearchers()
        {
            _repo = new ResearcherRepository();
            return _repo.GetAllResearchers();
        }
    }
}
