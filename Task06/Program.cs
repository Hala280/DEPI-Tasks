public class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }

   



}

public class Program
{
    public static void Main()
    {
        var products = new List<Product>
        {
            new Product { Name = "Tea", Category = "Beverages", UnitPrice = 2.00m, UnitsInStock = 10 },
            new Product { Name = "Coffee", Category = "Beverages", UnitPrice = 5.50m, UnitsInStock = 0 },
            new Product { Name = "Laptop", Category = "Electronics", UnitPrice = 1500.00m, UnitsInStock = 5 },
            new Product { Name = "Mouse", Category = "Electronics", UnitPrice = 25.00m, UnitsInStock = 2 },
            new Product { Name = "Sugar", Category = "Condiments", UnitPrice = 1.50m, UnitsInStock = 20 },
        };
        var outOfStockProducts = products.Where(p => p.UnitsInStock == 0);
        Console.WriteLine("Out of Stock Products:");
        foreach (var product in outOfStockProducts)
        {
            Console.WriteLine($"- {product.Name} ({product.Category})");
        }

        var InStockProducts = products.Where(p => p.UnitPrice > 3.00m && p.UnitsInStock>0);
        Console.WriteLine("Products in stock and greater than 3.00m");
        foreach (var product in InStockProducts)
        {
            Console.WriteLine($"- {product.Name} ({product.Category})");
        }


        var FirstOutOfStockProduct = products.FirstOrDefault(p => p.UnitsInStock == 0);
        Console.WriteLine($" First product out of stock: {FirstOutOfStockProduct.Name} ");

        var FirstInStockProduct = products.FirstOrDefault(p => p.UnitPrice > 1000m);
        Console.WriteLine($"first product greater than 1000m: {FirstInStockProduct.Name}");
        int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var FirstGreaterThanNumber = Arr.FirstOrDefault(n => n > 5);
        Console.WriteLine($"First number greater than 5: {FirstGreaterThanNumber}");

    }


}

