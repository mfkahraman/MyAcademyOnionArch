namespace Onion.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public IList<Product>? Products { get; set; }
    }
}
