using Meals.Application.Models;

namespace Meals.Application.Repositories;

public class MealRepository : IMealRepository
{
    private readonly List<Meal> _meals = new();

    public Task<bool> CreateAsync(Meal meal)
    {
        _meals.Add(meal);
        return Task.FromResult(true);
    }

    public Task<Meal?> GetByIdAsync(Guid id)
    {
        var meal = _meals.SingleOrDefault(x => x.Id == id);
        return Task.FromResult(meal);
    }

    public Task<IEnumerable<Meal>> GetAllAsync()
    {
        return Task.FromResult(_meals.AsEnumerable());
    }

    public Task<bool> UpdateAsync(Meal meal)
    {
        var mealIndex = _meals.FindIndex(x => x.Id == meal.Id);
        if (mealIndex == -1)
        {
            return Task.FromResult(false);
        }

        _meals[mealIndex] = meal;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var removedCount = _meals.RemoveAll(x => x.Id == id);
        var mealRemoved = removedCount > 0;
        return Task.FromResult(mealRemoved);
    }
}