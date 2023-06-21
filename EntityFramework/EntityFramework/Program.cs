﻿
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            AddPromotion();
        }

        private static void AddPromotion()
        {
            using (var context = new StoreContext())
            {
                var promotion = new SalePromotion();
                promotion.Description = "Queima estoque";
                promotion.DateInit = new DateTime(2017, 1, 1);
                promotion.DateEnd = new DateTime(2017, 1, 31);

                var products = context.Products.Where(p => p.Category == "Alimentos").ToList();

                foreach (var product in products)
                {
                    promotion.AddProduct(product);
                }

                context.SalePromotion.Add(promotion);

                context.SaveChanges();

            }
        }

        private static void OneToOne()
        {
            var client = new Client();
            client.Name = "João";
            client.Address = new Address()
            {
                Number = 12,
                Street = "Rua do João",
                Complement = "",
                Neighborhood = "Bairro dos João",
                City = "São João",
            };

            using (var context = new StoreContext())
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }

        private static void ManyToMany()
        {
            var salePromotion = new SalePromotion();
            var product1 = new Product() { Name = "Suco", Category = "Bebidas", CostUnit = 8.72, Unit = "LT" };
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
                foreach (var e in context.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.Entity.ToString() + " - " + e.State);
                }

                context.SaveChanges();

            }
        }
    }
}
