using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLPTMockTestManagement.DAL.Entities;
using JLPTMockTestManagement.DAL.Repository;
using Microsoft.IdentityModel.Tokens;

namespace JLPTMockTestManagement.BLL.Services
{
    public class MockTestService
    {
        MockTestRepository _repo = new();
        public List<MockTest> GetAll()
        {
            return _repo.GetAll();
        }

        public void Save(MockTest project)
        {
            _repo.Save(project);
        }

        public void Update(MockTest project)
        {
            _repo.Update(project);
        }

        public void Delete(MockTest project)
        {
            _repo.Delete(project);
        }

        public List<MockTest> Search(string searchString)
        {
            var result = GetAll();
            if (searchString.IsNullOrEmpty())
            {
                return result;
            }
            else
            {
                return result.Where(e => e.TestTitle.ToLower().Contains(searchString.ToLower()) || e.SkillArea.ToLower().Contains(searchString.ToLower())).ToList();
            }
        }
    }
}
