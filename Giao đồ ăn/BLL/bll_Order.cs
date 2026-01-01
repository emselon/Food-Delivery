using DTO;
using FoodDeliveryAPI.DAL;
using Giao_đồ_ăn.DTO;

namespace Giao_đồ_ăn.BLL
{
    public class bll_Order
    {
        private readonly OrderDAL _dal = new OrderDAL();

        public List<dto_Order> GetAllOrders() => _dal.GetAllOrders();

        public bool CreateOrder(dto_Order order) => _dal.CreateOrder(order);

        public bool UpdateOrder(dto_Order order) => _dal.UpdateOrder(order);

        public bool DeleteOrder(int id) => _dal.DeleteOrder(id);
    }
}
