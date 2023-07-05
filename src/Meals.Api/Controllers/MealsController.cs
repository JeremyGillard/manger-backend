using Meals.Application.Repositories;
using Meals.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using Meals.Api.Mapping;

namespace Meals.Api.Controllers;

[ApiController]
public class MealsController : ControllerBase
{
    private readonly IMealRepository _mealRepository;

    public MealsController(IMealRepository mealRepository)
    {
        _mealRepository = mealRepository;
    }

    [HttpPost(ApiEndpoints.Meals.Create)]
    public async Task<IActionResult> Create([FromBody]CreateMealRequest request)
    {
        var meal = request.MapToMeal();
        await _mealRepository.CreateAsync(meal);
        var response = meal.MapToResponse();
        return CreatedAtAction(nameof(Get), new { id = meal.Id }, response);
    }

    [HttpGet(ApiEndpoints.Meals.Get)]
    public async Task<IActionResult> Get([FromRoute]Guid id)
    {
        var meal = await _mealRepository.GetByIdAsync(id);
        if (meal is null)
        {
            return NotFound();
        }

        var response = meal.MapToResponse();
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Meals.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var meals = await _mealRepository.GetAllAsync();

        var mealsReponse = meals.MapToResponse();
        return Ok(mealsReponse);
    }

    [HttpPut(ApiEndpoints.Meals.Update)]
    public async Task<IActionResult> Update([FromRoute]Guid id,
        [FromBody]UpdateMealRequest request)
    {
        var meal = request.MapToMeal(id);
        var updated = await _mealRepository.UpdateAsync(meal);
        if (!updated)
        {
            return NotFound();
        }
        var response = meal.MapToResponse();
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Meals.Delete)]
    public async Task<IActionResult> Delete([FromRoute]Guid id)
    {
        var deleted = await _mealRepository.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return Ok();
    }
}