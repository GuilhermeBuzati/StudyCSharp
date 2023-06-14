
namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoveProduct();
            RecordUsingEntity();
            GetListProduct();
            UpdateProduct();
        }

        private static void UpdateProduct()
        {
            GetListProduct();

            using (var context = new ProductDAOEntity())
            {
                Product product = context.Products().First();
                product.Name = "Product updated!";
                context.Update(product);
            }

            GetListProduct();
        }

        private static void RemoveProduct()
        {
            using (var context = new ProductDAOEntity())
            {
                IList<Product> products = context.Products();

                foreach(Product product in products)
                {
                    context.Delete(product);
                }

            }
        }

        private static void GetListProduct()
        {
            using (var context = new ProductDAOEntity())
            {
                IList<Product> products = context.Products();
                Console.WriteLine("It was found {0} product(s).", products.Count);

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

            using (var context = new ProductDAOEntity())
            {
                context.Add(p);
            }

            Console.WriteLine("Saved!");
        }
    }
}
