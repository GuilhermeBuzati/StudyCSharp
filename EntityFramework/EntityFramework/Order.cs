namespace EntityFramework
{
    internal class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; internal set; }
        public Product Product { get; internal set; }
        public double Value { get; internal set; }
    }
}