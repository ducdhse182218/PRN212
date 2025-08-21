using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL.Models;
using AirConditionerShop.DAL.Repositories;

namespace AirConditionerShop.BLL.Services
{
    public class MemberService
    {
        private MemberRepository _repo = new();

        // mail và pass nhận từ màn hình LOGIN
        public StaffMember Authenticate(string email, string password)
        {
            return _repo.GetOne(email, password);
        }
    }
}
