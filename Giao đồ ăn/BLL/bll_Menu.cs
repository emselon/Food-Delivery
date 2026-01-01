using DTO;
using FoodDeliveryAPI.DAL;
using Giao_đồ_ăn.DTO;

namespace Giao_đồ_ăn.BLL
{
    public class bll_MenuItem
    {
        private readonly MenuItemDAL _dal = new MenuItemDAL();

        public List<dto_MenuItem> GetAllMenuItems() => _dal.GetAllMenuItems();

        public bool CreateMenuItem(dto_MenuItem item) => _dal.CreateMenuItem(item);

        public bool UpdateMenuItem(dto_MenuItem item) => _dal.UpdateMenuItem(item);

        public bool DeleteMenuItem(int id) => _dal.DeleteMenuItem(id);
    }
}
