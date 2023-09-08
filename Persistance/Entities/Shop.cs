namespace Persistance
{
    public class Shop
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }
        public List<Product>? Products { get; set; }
    }
}
