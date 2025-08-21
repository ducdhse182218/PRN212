using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResearchProjectManagement.DAL.Contexts;
using ResearchProjectManagement.DAL.Entities;

namespace ResearchProjectManagement.DAL.Repositories
{
    public class ResearchProjectRepository
    {
        Su25researchDbContext _context;

        public List<ResearchProject> GetAll()
        {
            _context = new Su25researchDbContext();
            return _context.ResearchProjects.Include("LeadResearcher").ToList();
        }

        public void Save(ResearchProject project)
        {
            _context = new();
            _context.ResearchProjects.Add(project);
            _context.SaveChanges();
        }

        public void Update(ResearchProject project)
        {
            _context = new();
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
