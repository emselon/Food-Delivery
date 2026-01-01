using Giao_đồ_ăn.DTO;
using FoodDeliveryAPI.DAL;
using System.Collections.Generic;

namespace Giao_đồ_ăn.BLL
{
    public class bll_TaiKhoan
    {
        private readonly TaiKhoanDAL _dal = new TaiKhoanDAL();

        public List<TaiKhoanDTO> GetAllTaiKhoan() => _dal.GetAll();

        public bool CreateTaiKhoan(TaiKhoanDTO tk) => _dal.Create(tk);

        public bool UpdateTaiKhoan(TaiKhoanDTO tk) => _dal.Update(tk);

        public bool DeleteTaiKhoan(int id) => _dal.Delete(id);
    }
}
