using DTO;
using FoodDeliveryAPI.DAL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Giao_đồ_ăn.BLL
{
    public class bll_Shipper
    {
        private readonly ShipperDAL _dal;


        public bll_Shipper(ShipperDAL dal)
        {
            _dal = dal;
        }
        public List<dto_Shipper> GetAllShippers()
        {
            return _dal.GetAllShippers();
        }
        public bool CreateShipper(dto_Shipper shipper)
        {
            return _dal.CreateShipper(shipper);
        }
        public bool XoaShipper(int id)
        {
            return _dal.DeleteShipper(id);
        }
        public bool UpdateShipper(dto_Shipper shipper)
        {
            return _dal.UpdateShipper(shipper);
        }
    }
}
