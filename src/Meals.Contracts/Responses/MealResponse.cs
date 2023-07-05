namespace Meals.Contracts.Responses;

public class MealResponse
{
    public required Guid Id { get; init; }
    
    public required string Name { get; init; }
}