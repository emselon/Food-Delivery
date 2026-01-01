using DTO;
using FoodDeliveryAPI.DAL;
using Giao_đồ_ăn.DTO;

namespace Giao_đồ_ăn.BLL
{
    public class bll_Delivery
    {
        private readonly DeliveryDAL _dal = new DeliveryDAL();

        public List<dto_Delivery> GetAllDeliveries() => _dal.GetAllDeliveries();

        public bool CreateDelivery(dto_Delivery delivery) => _dal.CreateDelivery(delivery);

        public bool UpdateDelivery(dto_Delivery delivery) => _dal.UpdateDelivery(delivery);

        public bool DeleteDelivery(int id) => _dal.DeleteDelivery(id);
    }
}
