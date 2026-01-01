using FoodDeliveryAPI.DAL;
using Giao_đồ_ăn.DTO;

public class bll_Restaurant
{
    private readonly RestaurantDAL _dal = new RestaurantDAL();

    public List<dto_restaurant> GetAllRestaurants()
    => _dal.GetAllRestaurants();

    public bool CreateRestaurant(dto_restaurant restaurant)
    => _dal.CreateRestaurant(restaurant);

    public bool UpdateRestaurant(dto_restaurant restaurant)
        => _dal.UpdateRestaurant(restaurant);

    public bool DeleteRestaurant(int id)
        => _dal.DeleteRestaurant(id);
}
