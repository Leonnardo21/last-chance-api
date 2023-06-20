namespace LastChanceAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public string Lot { get; set; } = null!;
        public DateTime Expiration { get; set; }
        public int Quantity { get; set; }
    }
}
