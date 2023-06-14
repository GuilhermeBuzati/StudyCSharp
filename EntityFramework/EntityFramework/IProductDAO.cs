using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    internal interface IProductDAO
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        IList<Product> Products();
    }
}
