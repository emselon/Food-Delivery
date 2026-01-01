using DTO;
using FoodDeliveryAPI.DAL;
using Giao_đồ_ăn.DTO;

namespace Giao_đồ_ăn.BLL
{
    public class bll_User
    {
        private readonly UserDAL _dal = new UserDAL();

        public List<dto_User> GetAllUsers() => _dal.GetAllUsers();

        public bool CreateUser(dto_User user) => _dal.CreateUser(user);

        public bool UpdateUser(dto_User user) => _dal.UpdateUser(user);

        public bool DeleteUser(int id) => _dal.DeleteUser(id);
    }
}
