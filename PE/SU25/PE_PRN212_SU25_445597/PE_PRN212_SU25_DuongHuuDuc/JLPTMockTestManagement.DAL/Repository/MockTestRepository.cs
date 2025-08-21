using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLPTMockTestManagement.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace JLPTMockTestManagement.DAL.Repository
{
    public class MockTestRepository
    {
        private Su25jlptmockTestDbContext _context;

        public List<MockTest> GetAll()
        {
            _context = new Su25jlptmockTestDbContext();
            return _context.MockTests.Include("Candidate").ToList();
        }

        public void Save(MockTest project)
        {
            _context = new();
            _context.MockTests.Add(project);
            _context.SaveChanges();
        }

        public void Update(MockTest project)
        {
            _context = new();
            _context.MockTests.Update(project);
            _context.SaveChanges();
        }

        public void Delete(MockTest project)
        {
            _context = new();
            _context.MockTests.Remove(project);
            _context.SaveChanges();
        }
    }
}
