string greeting = @"Welcome to thrown for a loop
Your one stop shop for used sporting equipment";

Console.WriteLine(greeting);

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
    Sold = false
  }
};

decimal totalValue = 0.0M;
foreach (Product product in products)
{
  if (!product.Sold)
  {
    totalValue += product.Price;
  }
}
Console.WriteLine($"Total inventory value: ${totalValue}");

Console.WriteLine("Products: ");

Console.WriteLine("Please enter a product number: ");

for (int i =  0; i < products.Count; i++)
{
  Console.WriteLine($"{i + 1}. {products[i].Name}");
}

// int response = int.Parse(Console.ReadLine().Trim());

// Product chosenProduct = products[response -1];

// while (response > products.Count || response < 1)
// {
//   Console.WriteLine("Choose an existing product number");
//   response = int.Parse(Console.ReadLine().Trim());
// }

Product chosenProduct = null;

while (chosenProduct == null)
{
  Console.WriteLine("Please enter a product number: ");
  try{
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
