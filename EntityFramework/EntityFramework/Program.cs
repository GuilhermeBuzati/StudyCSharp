
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            var bread = new Product();
            bread.Name = "Bread";
            bread.CostUnit = 0.25;
            bread.Unit = "UN";
            bread.Category = "Bakery";

            var order = new Order();
            order.Quantity = 6;
            order.Product = bread;
            order.Value = bread.CostUnit * order.Quantity;



        }
    }
}
