namespace Onion.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}
