namespace tp4.Core.Entities
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float SignUpfee { get; set; }
        public int DurationInMonth { get; set; }
        public float discountRate { get; set; }
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();

    }
}
