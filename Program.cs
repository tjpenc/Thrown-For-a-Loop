  List<Product> products = new List<Product>()
  {
    new Product()
    {
      Name = "Football",
      Price = 15.00M,
      Sold = false,
      StockDate = new DateTime(2022, 10, 20),
      ManufactureYear = 2010,
      Condition = 4.2
    },
    new Product()
    {
      Name = "Hockey Stick",
      Price = 12.00M,
      Sold = false,
      StockDate = new DateTime(2023, 7, 1),
      ManufactureYear = 2010,
      Condition = 1.2
    },
    new Product()
    {
      Name = "Sportsball",
      Price = 16.00M,
      Sold = false,
      StockDate = new DateTime(2023, 6, 20),
      ManufactureYear = 2010,
      Condition = 2.2
    },
    new Product()
    {
      Name = "Old Shoe",
      Price = 19.00M,
      Sold = false,
      StockDate = new DateTime(2023, 5, 30),
      ManufactureYear = 2010,
      Condition = 3.2
    },
    new Product()
    {
      Name = "Consolation Prize",
      Price = 120.00M,
      Sold = true,
      StockDate = new DateTime(2023, 7, 1),
      ManufactureYear = 2010,
      Condition = 5.2
    },
  };

string greeting = @"Welcome to thrown for a loop
Your one stop shop for used sporting equipment";
Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
  Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View product details
                        2. List all products
                        3. View latest products");
  choice = Console.ReadLine();
  if (choice == "0")
  {
    Console.WriteLine("Goodbye!");
  }
  else if (choice == "1")
  {
    ViewProductDetails();
  }
  else if (choice == "2")
  {
    ListProducts();
  }
  else if (choice == "3")
  {
    ViewLatestProducts();
  }
}

void ViewProductDetails()
{
  ListProducts();

  Product chosenProduct = null;
  while (chosenProduct == null)
  {
    Console.WriteLine("Please enter a product number: ");
    try
    {
      int response = int.Parse(Console.ReadLine().Trim());
      chosenProduct = products[response -1];
    }
    catch (FormatException)
    {
      Console.WriteLine("Integers Only");
    }
    catch (ArgumentOutOfRangeException)
    {
      Console.WriteLine("Choose an existing item");
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
      Console.WriteLine("Do better");
    }
  }
  Console.WriteLine($"You chose: {chosenProduct.Name}, which costs {chosenProduct.Price} dollars and is {(chosenProduct.Sold ? "" : "not ")}sold.");
}

void ListProducts()
{
  decimal totalValue = 0.0M;
  foreach (Product product in products)
  {
    if (!product.Sold)
    {
      totalValue += product.Price;
    }
  }
  Console.WriteLine($"Total inventory value: ${totalValue}");
  Console.WriteLine("Products:");
  for (int i = 0; i < products.Count; i++)
  {
    Console.WriteLine($"{i + 1}. {products[i].Name}");
  }
}

void ViewLatestProducts()
{
  List<Product> latestProducts = new List<Product>();
  DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
  foreach (Product product in products)
  {
    if (product.StockDate > threeMonthsAgo && !product.Sold)
    {
      latestProducts.Add(product);
    }
  }
  for (int i = 0; i < latestProducts.Count; i++)
  {
    Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
  }
}
