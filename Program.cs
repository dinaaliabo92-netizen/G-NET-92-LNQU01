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
            #region Assignment01
            /*
             /1. Get all products from the "Seafood" category. Print each 
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
            
            //===========================================================================================
            //4. Get all products where UnitPrice is between 10 and 30
            /*
            var result03 = Soucre.ProductList
                .Where(p => p.UnitPrice >= 10m && p.UnitPrice <= 30m);

            foreach (var item in result03)
            {
                Console.WriteLine($"{item.ProductName} - {item.UnitPrice}");
            }
            
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
                 Position = index + 1
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
            */
            #endregion



            #region Assignment02
            #region Q01
            // 1. Get top 3 most expensive products
            {
                Console.WriteLine("===== Q1 =====");

                var result =Soucre. ProductList.OrderByDescending(p => p.UnitPrice)
                                        .Take(3);

                foreach (var p in result)
                    Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C2}");
            }


            #endregion

            #region Q02
            // 2. show page 2 of products, with page size = 5
            {
                Console.WriteLine("\n===== Q2 =====");

                int pageNumber = 2;
                int pageSize = 5;

                var result =Soucre. ProductList.Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize);

                foreach (var p in result)
                    Console.WriteLine(p);
            }

            #endregion

            #region Q03
            // 3. Take products from the list as long as Their UnitPrice is less than
            //    $25 (list is ordered by price).
            {
                Console.WriteLine("\n===== Q3 =====");

                var result =Soucre. ProductList.OrderBy(p => p.UnitPrice)
                                        .TakeWhile(p => p.UnitPrice < 25);

                foreach (var p in result)
                    Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C2}");
            }

            #endregion

            #region Q04

            // 4. Check if ALL products in the "Seafood" category are in stock
            {
                Console.WriteLine("\n===== Q4 =====");

                bool allSeafoodInStock =Soucre. ProductList.Where(p => p.Category == "Seafood")
                                                    .All(p => p.UnitsInStock > 0);

                Console.WriteLine($"Are all Seafood products in stock? {allSeafoodInStock}");
            }

            #endregion

            #region Q05
            // 5. Check if the ID list contains 9
            //    int[] ids = { 3, 9, 13, 18 };
            {
                Console.WriteLine("\n===== Q5 =====");

                int[] ids = { 3, 9, 13, 18 };

                bool contains9 = ids.Contains(9);

                Console.WriteLine($"Does the ID list contain 9? {contains9}");
            }

            #endregion

            #region Q06
            // 6. Group all products by Category and print each group with its
            //    product count.
            {
                Console.WriteLine("\n===== Q6 =====");

                var groups =Soucre. ProductList.GroupBy(p => p.Category);

                foreach (var group in groups)
                    Console.WriteLine($"{group.Key} : {group.Count()} products");
            }


            #endregion

            #region Q07
            // 7. Group products by Category and project only product names per
            //    group
            {
                Console.WriteLine("\n===== Q7 =====");

                var groups =Soucre. ProductList.GroupBy(p => p.Category, p => p.ProductName);

                foreach (var group in groups)
                {
                    Console.WriteLine($"{group.Key}:");
                    foreach (var name in group)
                        Console.WriteLine($"    {name}");
                }
            }

            #endregion

            #region Q08
            // 8. Find all categories that have MORE THAN 3 products
            {
                Console.WriteLine("\n===== Q8 =====");

                var categories =Soucre. ProductList.GroupBy(p => p.Category)
                                            .Where(g => g.Count() > 3)
                                            .Select(g => g.Key);

                foreach (var category in categories)
                    Console.WriteLine(category);
            }

            #endregion

            #region Q09
            // 9. Using QUERY SYNTAX, group customers by Country, and for each
            //    group select { Country, Count, TotalOrderValue }.
            {
                Console.WriteLine("\n===== Q9 =====");

                var result = from c in Soucre. CustomerList
                             group c by c.Country into g
                             select new
                             {
                                 Country = g.Key,
                                 Count = g.Count(),
                                 TotalOrderValue = g.Sum(c => c.Orders.Sum(o => o.Total))
                             };

                foreach (var item in result)
                    Console.WriteLine($"Country: {item.Country}, Count: {item.Count}, TotalOrderValue: {item.TotalOrderValue:C2}");
            }
            #endregion

            #region Q10
            // 10. Calculate the total number of units in stock across all products
            {
                Console.WriteLine("\n===== Q10 =====");

                int totalUnits =Soucre. ProductList.Sum(p => p.UnitsInStock);

                Console.WriteLine($"Total units in stock: {totalUnits}");
            }

            #endregion

            #region Q11
            // 11. Find the CHEAPEST and MOST EXPENSIVE product prices
            {
                Console.WriteLine("\n===== Q11 =====");

                decimal cheapest =Soucre. ProductList.Min(p => p.UnitPrice);
                decimal mostExpensive =Soucre. ProductList.Max(p => p.UnitPrice);

                Console.WriteLine($"Cheapest price      : {cheapest:C2}");
                Console.WriteLine($"Most expensive price: {mostExpensive:C2}");
            }
            #endregion

            #region Q12

            // 12. Get a distinct list of all product categories
            {
                Console.WriteLine("\n===== Q12 =====");

                var categories =Soucre. ProductList.Select(p => p.Category).Distinct();

                foreach (var category in categories)
                    Console.WriteLine(category);
            }
            #endregion

            #region Q13
            // 13. find product IDs that are in setA but NOT in setB
            //     int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            //     int[] setB = { 3, 6, 9, 12, 15, 13 };
            {
                Console.WriteLine("\n===== Q13 =====");

                int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
                int[] setB = { 3, 6, 9, 12, 15, 13 };

                var result = setA.Except(setB);

                Console.WriteLine(string.Join(", ", result));
            }
            #endregion
            #region Q14
            // 14. Find countries that appear in list1 but NOT in list2
            //     (case-insensitive).
            //     string[] list1 = { "Germany", "France", "UK", "Spain" };
            //     string[] list2 = { "france", "SPAIN", "Italy" };
            {
                Console.WriteLine("\n===== Q14 =====");

                string[] list1 = { "Germany", "France", "UK", "Spain" };
                string[] list2 = { "france", "SPAIN", "Italy" };

                var result = list1.Except(list2, StringComparer.OrdinalIgnoreCase);

                Console.WriteLine(string.Join(", ", result));
            }
            #endregion

            #region Q15
            // 15. Build a Dictionary<int, Product> keyed by ProductID. Then
            //     retrieve and print the product with ID = 18.
            {
                Console.WriteLine("\n===== Q15 =====");

                Dictionary<int, Product> productsById =Soucre. ProductList.ToDictionary(p => p.ProductID);

                Console.WriteLine(productsById[18]);
            }
            #endregion

            #region Q16
            // 16. Get the first product whose price is greater than $50.
            {
                Console.WriteLine("\n===== Q16 =====");

                var result =Soucre. ProductList.First(p => p.UnitPrice > 50);

                Console.WriteLine(result);
            }

            #endregion

            #region Q17
            // 17. Try to get the first product with a price > $500. it returns null
            //     instead of throwing.
            {
                Console.WriteLine("\n===== Q17 ====="); 
                Product? result =Soucre. ProductList.FirstOrDefault(p => p.UnitPrice > 500);

                Console.WriteLine(result is null ? "No product found (null returned)" : result.ToString());
            }

            #endregion

            #region Q18
            // 18. Generate a multiplication table row for 7
            {
                Console.WriteLine("\n===== Q18 =====");

                var result = Enumerable.Range(1, 10).Select(i => $"7 x {i} = {7 * i}");

                foreach (var line in result)
                    Console.WriteLine(line);
            }
            #endregion

            #region Q19
            // 19. Generate even numbers between 1 and 30.
            {
                Console.WriteLine("\n===== Q19 =====");

                var result = Enumerable.Range(1, 30).Where(n => n % 2 == 0);

                Console.WriteLine(string.Join(", ", result));
            }
            #endregion

            #region Q20

            // 20. Concatenate the first 3 product names with the first 3
            //     customer company names into a single sequence.
            
            {
                Console.WriteLine("\n===== Q20 =====");

                var result =Soucre. ProductList.Select(p => p.ProductName).Take(3)
                             .Concat(Soucre. CustomerList.Select(c => c.CustomerName).Take(3));

                foreach (var item in result)
                    Console.WriteLine(item);
            }

            #endregion


            #region Q21
            //21.Pair each product with a customer(by position) and produce
           // a string "ProductName sold to CompanyName".
            {
                Console.WriteLine("\n===== Q21 =====");

                var result =Soucre. ProductList.Zip(Soucre. CustomerList, (p, c) => $"{p.ProductName} sold to {c.CustomerName}");

                foreach (var item in result)
                    Console.WriteLine(item);
            }
            #endregion


            #endregion



        }


    }
}
