
namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new StoreContext())
            {
                var products = context.Products.ToList();

                foreach(var product in products)
                {
                    Console.WriteLine(product);
                }

                foreach(var e in context.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.State);
                }

                var product1 = products.Last();
                product1.Name = "Teste de Livros";

                //context.SaveChanges();

                foreach (var e in context.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.State);
                }

            }

        }
    }
}
