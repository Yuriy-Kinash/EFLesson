namespace Persistance.Repositories.Products
{
    public class ProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}