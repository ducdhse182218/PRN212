using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfumeManagement.DAL.Entities;

namespace PerfumeManagement.DAL.Repositories
{
    public class PerfumeInformationRepository
    {
        private Fall24PerfumeStoreDbContext _context;

        public List<PerfumeInformation> GetAll()
        {
            _context = new Fall24PerfumeStoreDbContext();
            return _context.PerfumeInformations.Include("ProductionCompany").ToList();
        }

        public void Save(PerfumeInformation perfume)
        {
            _context = new();
            _context.PerfumeInformations.Add(perfume);
            _context.SaveChanges();
        }

        public void Update(PerfumeInformation perfume)
        {
            _context = new();
            _context.PerfumeInformations.Update(perfume);
            _context.SaveChanges();
        }

        public void Delete(PerfumeInformation perfume)
        {
            _context = new();
            _context.PerfumeInformations.Remove(perfume);
            _context.SaveChanges();
        }
    }
}
