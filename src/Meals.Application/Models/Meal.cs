namespace Meals.Application.Models;

public class Meal
{
    public required Guid Id { get; init; }
    
    public required string Name { get; set; }
}