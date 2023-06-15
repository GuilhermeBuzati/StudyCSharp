namespace EntityFramework
{
    internal class SalePromotion
    {
        public int Id { get; set; } 
        public string Description { get; internal set; }
        public DateTime DateInit { get; internal set; }
        public DateTime DateEnd { get; internal set; }
        public IList<Product> Products { get; internal set; }
    }

}