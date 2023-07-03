namespace Test.Setup.TestData.Pizza;
using Common.Entities;
public static class PizzaTestData
{
    public static Faker faker = new Faker();

    public static Pizza Pizza = new Pizza()
    {
        Id = 1,
        Name = faker.PickRandom(pizzas),
        Description = string.Empty,
        Price = faker.Finance.Amount(),
        DateCreated = DateTime.Now,
    };

    public static PizzaModel PizzaModel = new PizzaModel()
    {
        Id = 1,
        Name = faker.PickRandom(pizzas),
        Description = string.Empty,
        Price = faker.Finance.Amount(),
        DateCreated = DateTime.Now

    };

    private static readonly List<string> pizzas = new()
    {
        "Veggie Pizza",
        "Pepperoni Pizza",
        "Meat Pizza",
        "Margherita Pizza",
        "BBQ Chicken Pizza",
        "Hawaiian Pizza"
    };
}