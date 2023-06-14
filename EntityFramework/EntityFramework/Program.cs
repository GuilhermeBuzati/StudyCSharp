
namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            RecordUsingEntity();
            //GetListProduct();
            RemoveProduct();
            //GetListProduct();
            UpdateProduct();
        }

        private static void UpdateProduct()
        {
            GetListProduct();

            using (var context = new StoreContext())
            {
                Product product = context.Products.First();
                product.Name = "Product updated!";
                context.Products.Update(product);
                context.SaveChanges();
            }

            GetListProduct();
        }

        private static void RemoveProduct()
        {
            using (var context = new StoreContext())
            {
                IList<Product> products = context.Products.ToList();

                foreach(Product product in products)
                {
                    context.Products.Remove(product);                    
                }

                context.SaveChanges();
            }
        }

        private static void GetListProduct()
        {
            using (var context = new StoreContext())
            {
                IList<Product> products = context.Products.ToList();
                Console.WriteLine("Foram encontrados {0} produtos(s).", products.Count);

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
