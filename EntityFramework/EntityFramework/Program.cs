
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            var salePromotion = new SalePromotion();
            var product1 = new Product() { Name = "Suco", Category = "Bebidas", CostUnit = 8.72, Unit = "LT"};
            var product2 = new Product() { Name = "Café", Category = "Bebidas", CostUnit = 14, Unit = "GR" };
            var product3 = new Product() { Name = "Macarrão", Category = "Alimentos", CostUnit = 3.21, Unit = "KG" };
            

            salePromotion.Description = "Happy New Year";
            salePromotion.DateInit = DateTime.Now;
            salePromotion.DateEnd = DateTime.Now.AddMonths(3);
            salePromotion.AddProduct(product1);
            salePromotion.AddProduct(product2);
            salePromotion.AddProduct(product3);

            using (var context = new StoreContext())
            {
                context.SalePromotion.Add(salePromotion);
                foreach(var e in context.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.Entity.ToString() + " - " + e.State);
                }

                context.SaveChanges();

            }


        }
    }
}
