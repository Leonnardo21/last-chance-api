namespace LastChance.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Lot { get; set; }
        public string? CodeBar { get; set; }
        public DateTime Expiration { get; set; }
        public int Quantity { get; set; }
    }
}
