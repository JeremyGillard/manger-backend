using Meals.Application.Models;

namespace Meals.Application.Repositories;

public interface IMealRepository
{
    Task<bool> CreateAsync(Meal meal);

    Task<Meal?> GetByIdAsync(Guid id);

    Task<IEnumerable<Meal>> GetAllAsync();

    Task<bool> UpdateAsync(Meal meal);

    Task<bool> DeleteAsync(Guid id);
}