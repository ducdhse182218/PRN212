using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using ResearchProjectManagement.DAL.Entities;
using ResearchProjectManagement.DAL.Repositories;

namespace ResearchProjectManagement.BLL.Services
{
    public class ResearchProjectService
    {
        ResearchProjectRepository _repo = new();

        public List<ResearchProject> GetAll()
        {
            return _repo.GetAll();
        }
        public void Save(ResearchProject project)
        {
            _repo.Save(project);
        }

        public void Update(ResearchProject project)
        {
            _repo.Update(project);
        }

        public void Delete(ResearchProject project)
        {
            _repo.Delete(project);
        }

        public List<ResearchProject> Search(string searchString)
        {
            var result = GetAll();
            if(searchString.IsNullOrEmpty())
            {
                return result;
            }
            else
            {
                return result.Where(e => e.ProjectTitle.ToLower().Contains(searchString.ToLower()) || e.ResearchField.ToLower().Contains(searchString.ToLower())).ToList();
            }
        }
    }
}
