namespace EntityFramework
{
    internal class Order
    {
        public Order()
        {
        }

        public int Quantity { get; internal set; }
        public Product Product { get; internal set; }
    }
}