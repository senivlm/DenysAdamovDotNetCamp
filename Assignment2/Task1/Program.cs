using Assignment2;

try
{
    Storage storage = new Storage();

    storage.Fill(new Meat("1 - meat", 10, 120, MeatCategory.Highest, MeatType.Veal),
                new Product("product 2", 200, 222),
                new DairyProduct("3 - dp", 333, 2333, 10),
                new Meat("4 - meat", 44.4, 420, MeatCategory.First, MeatType.Veal)
                );
    storage.PrintDetails();

    storage.FillInByHand();
    storage.PrintDetails();

    Product[] meat = storage.GetMeatProducts();

    storage.ChangePrice(100);
    storage.PrintDetails();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}