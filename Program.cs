using ConsoleApp1;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
namespace ConsoleApp1

{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            //1. Get all products from the "Seafood" category. Print each 
            //product's name and price. 
            /*
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
            */
            //=========================================================================================
            //2. Get a list of only the product names from ProductList. Print 
            //each name. 
            /*
            var result01 = Soucre.ProductList
                .Select(p => p.ProductName);
   

            foreach (var name in result01)
            {
                Console.WriteLine(name);

            }
            */
            //====================================================================================
            //3. Sort all products by UnitPrice (ascending). Print each 
            //product's name and price.
            /*
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
            */
            //===========================================================================================
            //4. Get all products where UnitPrice is between 10 and 30
            /*
            var result03 = Soucre.ProductList
                .Where(p => p.UnitPrice >= 10m && p.UnitPrice <= 30m);

            foreach (var item in result03)
            {
                Console.WriteLine($"{item.ProductName} - {item.UnitPrice}");
            }
            */
            //=========================================================
            //5. Get all products that are in stock (UnitsInStock > 0) and 
            //  belong to the "Condiments" category.
            var result05 = Soucre.ProductList
      .Where(p => p.UnitsInStock > 0 &&
                  p.Category == "Condiments");

            foreach (var item in result05)
            {
                Console.WriteLine(item);
            }
            //6. Create a new anonymous type with three properties: 
            //● Name → the product name
            //● Price → the unit price
            //● StockStatus → a string: "Available" if UnitsInStock > 0, 
            //otherwise "Out of Stock"
            //● Print the result.
            var result06 = Soucre.ProductList
                .Select(p => new
                {
                  Name = p.ProductName,
                     Price = p.UnitPrice,

                     StockStatus = p.UnitsInStock > 0
                  ? "Available"
                  : "Out of Stock"
                    });

                 foreach (var item in result06)
                {
                    Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Status: {item.StockStatus}");
            }
            //===============================================================================================
            //Print each product's name along with its position (1-based) 
            //in the list. Expected format: 1.Chai, 2.Chang, etc.
            var result07 = Soucre.ProductList


             .Select((p, index) => new
                {
                    Name = p.ProductName,
                    Position= index + 1
                });

            foreach (var item in result07)
            {
                Console.WriteLine($"{item.Position}. {item.Name}");
            }


            /////////////////////////////////////////////////////////////////////////////////////////////
            //8. Sort ProductList by Category ascending, then within each 
            //category, sort by UnitPrice descending. 
            var result08 = Soucre.ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);

            foreach (var item in result08)
            {
                Console.WriteLine($"Category: {item.Category}, Name: {item.ProductName}, Price: {item.UnitPrice}");
            }
            ///==============================================================================
            //9.Get all products from the "Beverages" category, sorted by
            //UnitsInStock descending. Print name and stock. 
                var result09 = Soucre.ProductList
                        .Where(p => p.Category == "Beverages")
                        .OrderByDescending(p => p.UnitsInStock)
                        .Select(p => new
                        {
                            p.ProductName,
                            p.UnitsInStock
                        });

                foreach (var item in result09)
                {
                    Console.WriteLine($"Name: {item.ProductName}, Stock: {item.UnitsInStock}");
                }
            //=======================================================================================
            //10. Using QUERY SYNTAX with a compound from clause, list 
            //all orders placed in 1997 or later showing CustomerID and
            //OrderDate.
            /*
            var result10 =
            from order in Order
            from customer in CustomerList
            where order.CustomerID == customer.CustomerID
                  && order.OrderDate >= new DateTime(1997, 1, 1)
            select new
            {
                order.CustomerID,
                order.OrderDate
            };

            foreach (var item in result10)
            {
                Console.WriteLine($"CustomerID: {item.CustomerID}, OrderDate: {item.OrderDate}");
            }
            */
            //==================================================================================
            //11. Show position number alongside ProductName 
            var result11 = Soucre.ProductList
            .Select((p, index) => new
            {
                Position = index + 1,
                ProductName = p.ProductName
            });

            foreach (var item in result11)
            {
                Console.WriteLine($"{item.Position}. {item.ProductName}");
            }
            //=============================================================================
            //Q11
            String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var result12 = Arr
                .OrderBy(word => word.Length)
                .ThenBy(word => word, StringComparer.OrdinalIgnoreCase);

            foreach (var word in result12)
            {
                Console.WriteLine(word);
            }
            //======================================================================
            String[] Arr0 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var result13 = Arr
                .Where(word => word.Length >= 2 && char.ToLower(word[1]) == 'i')
                .Reverse()
                .ToList();

            foreach (var word in result13)
            {
                Console.WriteLine(word);
            }
        }


    }
}
