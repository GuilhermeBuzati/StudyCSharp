
namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //RecordUsingEntity();
            GetListProduct();
        }

        private static void GetListProduct()
        {
            using (var context = new StoreContext())
            {
                IList<Product> products = context.Products.ToList();

                foreach (var item in products)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        private static void RecordUsingEntity()
        {
            Product p = new Product();
            p.Name = "Harry Potter e a Ordem da Fênix";
            p.Category = "Livros";
            p.Value = 19.89;

            using (var context = new StoreContext())
            {
                context.Products.Add(p);
                context.SaveChanges();
            }

            Console.WriteLine("Saved!");
        }
    }
}
