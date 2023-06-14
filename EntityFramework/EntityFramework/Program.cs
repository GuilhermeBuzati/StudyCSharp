
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new StoreContext())
            {
                var products = context.Products.ToList();

                ShowEntries(context.ChangeTracker.Entries());

                var newProduct = new Product()
                {
                    Name = "Coca-Cola",
                    Category = "Refrigerante",
                    Value = 7.99
                };

                context.Products.Add(newProduct);

                ShowEntries(context.ChangeTracker.Entries());

                context.SaveChanges();

                ShowEntries(context.ChangeTracker.Entries());

            }

        }

        private static void ShowEntries(IEnumerable<EntityEntry> entries)
        {
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }
    }
}
