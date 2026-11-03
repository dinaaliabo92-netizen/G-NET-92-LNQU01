using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
namespace ConsoleApp1
{
   public class Order
    {

        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public override string ToString() => $"{OrderID}: {OrderDate:d} for {Total:C2}";
    }
}
