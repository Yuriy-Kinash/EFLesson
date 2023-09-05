
namespace Persistance
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Link { get; set; }
        public List<Product>? Products { get; set; }
    }
}
