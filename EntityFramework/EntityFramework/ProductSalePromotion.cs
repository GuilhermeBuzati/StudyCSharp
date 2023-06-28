using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class ProductSalePromotion
    {
        public int ProductsId { get; set; }
        public int SalePromotionsId { get; set; }
        public Product Product { get; set; }
        public SalePromotion SalePromotion { get; set; }
    }
}
