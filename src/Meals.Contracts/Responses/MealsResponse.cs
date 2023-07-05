namespace Meals.Contracts.Responses;

public class MealsResponse
{
    public required IEnumerable<MealResponse> Items { get; init; } = Enumerable.Empty<MealResponse>();
}