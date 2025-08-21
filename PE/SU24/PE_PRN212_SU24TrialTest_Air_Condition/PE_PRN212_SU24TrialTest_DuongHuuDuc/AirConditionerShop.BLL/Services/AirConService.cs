using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL.Models;
using AirConditionerShop.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace AirConditionerShop.BLL.Services
{
    //GUI UI <--> SERVICES <--> REPOSITORIES <--> DAL/DBContext <--> TABLE IN SQL
    //  L1           L2              L3                
    //  UI           BLL             DAL  
    public class AirConService
    {
        private AirConRepository _repo = new();  
        // CRUD++, Tên hàm dễ hiểu, gần hơn với USER
        public List<AirConditioner> GetAllAirConditioners()
        {
            return _repo.GetAllAirConditioners();
        }

        // Từ GUI UI phải gửi x cho hàm này
        public void AddAirConditioner(AirConditioner x)
        {
            _repo.AddAirConditioner(x);
        }

        public void UpdateAirConditioner(AirConditioner x)
        {
            _repo.UpdateAirConditioner(x);
        }

        public void DeleteAirConditioner(AirConditioner x)
        {
            _repo.DeleteAirConditioner(x);
        }

        // SEARCH theo tiêu
        // Tìm kiếm theo FutureFunction && || Quantity
        public List<AirConditioner> SearchAirConsByFeatureAndQuantity(string feature, int? quantity)
        {
            //1. Cả 2 rỗng
            List<AirConditioner> result = _repo.GetAllAirConditioners();
            if (feature.IsNullOrEmpty() && quantity == null)
            {
                return result;
            }

            //2. Chỉ feature có giá trị
            if (!feature.IsNullOrEmpty() && quantity == null)
            {
                result = result.Where(x => x.FeatureFunction.ToLower().Contains(feature.ToLower())).ToList();
            }

            //3. Chỉ quantity có giá trị
            if (feature.IsNullOrEmpty() && quantity != null)
            {
                result = result.Where(x => x.Quantity == quantity).ToList();
            }

            //4. Cả 2 đều có giá trị
            if (!feature.IsNullOrEmpty() && quantity != null)
            {
                result = result.Where(x => x.FeatureFunction.ToLower().Contains(feature.ToLower()) && x.Quantity == quantity).ToList();
            }

            return result;
        }
    }
}
