using Giao_đồ_ăn.DTO;
using FoodDeliveryAPI.DAL;
using System.Collections.Generic;

namespace Giao_đồ_ăn.BLL
{
    public class bll_LoaiTaiKhoan
    {
        private readonly LoaiTaiKhoanDAL _dal = new LoaiTaiKhoanDAL();

        public List<LoaiTaiKhoanDTO> GetAllLoaiTaiKhoan() => _dal.GetAll();

        public bool CreateLoaiTaiKhoan(LoaiTaiKhoanDTO loai) => _dal.Create(loai);

        public bool UpdateLoaiTaiKhoan(LoaiTaiKhoanDTO loai) => _dal.Update(loai);

        public bool DeleteLoaiTaiKhoan(int id) => _dal.Delete(id);
    }
}
