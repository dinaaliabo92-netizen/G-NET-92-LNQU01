using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;

namespace ConsoleApp1
{
   
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public override string ToString() => $"ProductID={ProductID}, ProductName={ProductName}, Category={Category}, UnitPrice={UnitPrice:C2}, UnitsInStock={UnitsInStock}";
    }
}
