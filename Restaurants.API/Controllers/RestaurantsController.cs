using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restautants;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IRestaurantService restaurantsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restaurantsService.GetAllRestaurants();
        return Ok(restaurants);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await restaurantsService.GetById(id);
        if (restaurant is null)
        {
            return NotFound(); // Return 404 Not Found if restaurant with given ID is not found
        }
        return Ok(restaurant);
    }

}


