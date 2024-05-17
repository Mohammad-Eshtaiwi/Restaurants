using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restautants;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsService : IRestaurantService
    {
        private readonly ILogger<RestaurantsService> _logger;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public RestaurantsService(ILogger<RestaurantsService> logger,
            IRestaurantRepository restaurantRepository,
            IMapper mapper)
        {
            _logger = logger;
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RestaurantsDto>> GetAllRestaurants()
        {
            _logger.LogInformation("Getting all restaurants");
            var restaurants = await _restaurantRepository.GetAllAsync();
            var restaurantsDto = _mapper.Map<IEnumerable<RestaurantsDto>>(restaurants);
            return restaurantsDto!;
        }

        public async Task<RestaurantsDto?> GetById(int id)
        {
            _logger.LogInformation($"Getting restaurant {id}");
            var restaurant = await _restaurantRepository.GetByIdAsync(id);
            var restaurantDto = _mapper.Map<RestaurantsDto?>(restaurant);
            return restaurantDto;
        }
    }
}