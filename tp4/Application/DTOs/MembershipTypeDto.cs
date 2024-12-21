namespace tp4.Application.DTOs
{
    public class MembershipTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float SignUpFee { get; set; }
        public int DurationInMonths { get; set; }
        public float DiscountRate { get; set; }
    }
}
