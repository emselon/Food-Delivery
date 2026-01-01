using DTO;
using FoodDeliveryAPI.DAL;
using Giao_đồ_ăn.DTO;

namespace Giao_đồ_ăn.BLL
{
    public class bll_OrderItem
    {
        private readonly OrderItemDAL _dal = new OrderItemDAL();

        public List<dto_OrderItem> GetAllOrderItems() => _dal.GetAllOrderItems();

        public bool CreateOrderItem(dto_OrderItem item) => _dal.CreateOrderItem(item);

        public bool UpdateOrderItem(dto_OrderItem item) => _dal.UpdateOrderItem(item);

        public bool DeleteOrderItem(int id) => _dal.DeleteOrderItem(id);
    }
}
