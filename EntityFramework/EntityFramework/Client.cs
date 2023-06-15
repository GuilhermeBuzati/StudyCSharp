namespace EntityFramework
{
    internal class Client
    {
        public int Id { get; set; }
        public string Name { get; internal set; }
        public Address Address { get; set; }
    }
}