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

int response = int.Parse(Console.ReadLine().Trim());

Product chosenProduct = products[response -1];

while (response > products.Count || response < 1)
{
  Console.WriteLine("Choose a number between 1 and 5");
  response = int.Parse(Console.ReadLine().Trim());
}
Console.WriteLine($"You chose: {chosenProduct.Name}, which costs {chosenProduct.Price} dollars and is {(chosenProduct.Sold ? "" : "not ")}sold.");

public class Product
{
  public string Name { get; set; }
  public decimal Price { get; set; }
  public bool Sold { get; set; }
  public DateTime StockDate { get; set; }
  public int ManufactureYear { get; set; }
  public double Condition { get; set; }
}
