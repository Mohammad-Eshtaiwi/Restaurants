using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restautants
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantsDto>> GetAllRestaurants();
        Task<RestaurantsDto?> GetById(int id);
    }
}