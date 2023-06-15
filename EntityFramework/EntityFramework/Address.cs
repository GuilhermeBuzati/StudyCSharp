namespace EntityFramework
{
    public class Address
    {
        public int Number { get; internal set; }
        public string Street { get; internal set; }
        public string Complement { get; internal set; }
        public string Neighborhood { get; internal set; }
        public string City { get; internal set; }
    }
}