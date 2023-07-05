using Meals.Application.Models;
using Meals.Contracts.Requests;
using Meals.Contracts.Responses;

namespace Meals.Api.Mapping;

public static class ContractMapping
{
    public static Meal MapToMeal(this CreateMealRequest request)
    {
        return new Meal
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };
    }

    public static MealResponse MapToResponse(this Meal meal)
    {
        return new MealResponse
        {
            Id = meal.Id,
            Name = meal.Name
        };
    }

    public static MealsResponse MapToResponse(this IEnumerable<Meal> meals)
    {
        return new MealsResponse
        {
            Items = meals.Select(MapToResponse)
        };
    }
    public static Meal MapToMeal(this UpdateMealRequest request, Guid id)
    {
        return new Meal
        {
            Id = id,
            Name = request.Name
        };
    }
}