using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AirConditionerShop.DAL.Repositories
{
    //GUI UI <--> SERVICES <--> REPOSITORIES <--> DAL/DBContext <--> TABLE IN SQL
    //  L1           L2              L3                
    //  UI           BLL             DAL   
    public class AirConRepository
    {
        public AirConditionerShop2024DbContext _context; // Khi dùng mới new()

        // CRUD 
        // Tên hàm gần với DB 

        public List<AirConditioner> GetAllAirConditioners()
        {
            _context = new AirConditionerShop2024DbContext();
            //return _context.AirConditioners.ToList(); //SELECT * FROM AirConditioner
            return _context.AirConditioners.Include("Supplier").ToList();
            //                              JOIN VÀ LẤY HẾT CỘT TỪ Supplier 
        }

        public void AddAirConditioner(AirConditioner x)
        {
            _context = new AirConditionerShop2024DbContext();
            _context.AirConditioners.Add(x); // INSERT INTO AirConditioner
            _context.SaveChanges(); // Lưu thay đổi vào DB
            //TODO: Trùng PK ?
            //TODO: KEY tự tăng
        }

        public void UpdateAirConditioner(AirConditioner x)
        {
            _context = new AirConditionerShop2024DbContext();
            _context.AirConditioners.Update(x); // RAM
            _context.SaveChanges(); // Lưu thay đổi vào DB
        }

        public void DeleteAirConditioner(AirConditioner x)
        {
            _context = new AirConditionerShop2024DbContext();
            _context.AirConditioners.Remove(x); // RAM
            _context.SaveChanges();             // DB
        }
    }
}
