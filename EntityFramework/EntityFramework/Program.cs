using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RecordUsingEntity();
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
        }
    }
}
