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
        ResearchProjectRepository _repo;
        public List<ResearchProject> GetAllResearchProject()
        {
            _repo = new ResearchProjectRepository();
            return _repo.GetAllResearchProjects();
        }

        public void AddResearchProject(ResearchProject project)
        {
            _repo = new ResearchProjectRepository();
            _repo.AddResearchProject(project);
        }

        public void UpdateResearchProject(ResearchProject project)
        {
            _repo = new ResearchProjectRepository();
            _repo.UpdateResearchProject(project);
        }

        public void DeleteResearchProject(ResearchProject project)
        {
            _repo = new ResearchProjectRepository();
            _repo.Delete(project);
        }

        public List<ResearchProject> Search(string searchTerm)
        {
            var result = GetAllResearchProject();
            if (searchTerm.IsNullOrEmpty())
            {
                return result;
            }
            else
            {
                return result.Where(e => e.ProjectTitle.ToLower().Contains(searchTerm.ToLower()) || e.ResearchField.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
        }
    }
}
