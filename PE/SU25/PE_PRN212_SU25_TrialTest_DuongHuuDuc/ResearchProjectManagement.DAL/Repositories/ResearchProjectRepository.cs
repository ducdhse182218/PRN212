using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResearchProjectManagement.DAL.Entities;

namespace ResearchProjectManagement.DAL.Repositories
{
    public class ResearchProjectRepository
    {
        private Su25researchDbContext _context;

        public List<ResearchProject> GetAllResearchProjects()
        {
            _context = new Su25researchDbContext();
            return _context.ResearchProjects.Include("LeadResearcher").ToList();
        }

        public void AddResearchProject(ResearchProject project)
        {
            _context = new Su25researchDbContext();
            _context.ResearchProjects.Add(project);
            _context.SaveChanges();
        }

        public void UpdateResearchProject(ResearchProject project)
        {
            _context = new Su25researchDbContext();
            _context.ResearchProjects.Update(project);
            _context.SaveChanges();
        }

        public void Delete(ResearchProject project)
        {
            _context = new();
            _context.ResearchProjects.Remove(project);
            _context.SaveChanges();
        }
    }
}