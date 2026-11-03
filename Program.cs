using ConsoleApp1;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Get all products from the "Seafood" category. Print each 
            //product's name and price. 

            var result = Soucre.ProductList
                .Where(p => p.Category == "Seafood")
                .Select(p => new
                {
                    p.ProductName,
                    p.UnitPrice
                }
                );
            foreach(var item in result ) 
            {
                Console.WriteLine($"Name: {item.ProductName}, Price: {item.UnitPrice}");

            }
            //=========================================================================================
            //2. Get a list of only the product names from ProductList. Print 
            //each name. 
            var result01 = Soucre.ProductList
                .Select(p => p.ProductName);
   

            foreach (var name in result01)
            {
                Console.WriteLine(name);

            }
            //====================================================================================
            //3. Sort all products by UnitPrice (ascending). Print each 
            //product's name and price. 
            var result02 = Soucre.ProductList
                .OrderBy(p => p.UnitPrice)
                .Select(p => new
                {
                    p.ProductName,
                    p.UnitPrice
                });
            foreach (var item in result02)
            {
                Console.WriteLine($"Name: {item.ProductName}, Price: {item.UnitPrice}");

            }
            //===========================================================================================

        }
       
    }
}
