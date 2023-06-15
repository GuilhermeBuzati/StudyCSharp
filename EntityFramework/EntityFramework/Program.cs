
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            var salePromotion = new SalePromotion();

            salePromotion.Description = "Happy New Year";
            salePromotion.DateInit = DateTime.Now;
            salePromotion.DateEnd = DateTime.Now.AddMonths(3);
            salePromotion.Products.Add(new Product());
            salePromotion.Products.Add(new Product());
            salePromotion.Products.Add(new Product());

            using (var context = new StoreContext())
            {

                foreach(var e in context.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.Entity.ToString() + " - " + e.State);
                }

                context.SaveChanges();
            }


        }
    }
}
