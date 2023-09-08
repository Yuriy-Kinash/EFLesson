namespace Persistance.Repositories.Products
{
    public interface IProductRepository
    {
        public Task AddAsync(ProductDto product);
        public Task AddAsync(params ProductDto[] product);
        public Task UpdateNameAsync(string name, int productId);
        public Task UpdatePictureAsync(int productId, string image);       
        public Task<double> GetPriceAsync(int id);
        public Task<List<ProductDto>> GetAllAsync();
        public Task<List<ProductDto>> GetByBrandAsync(int brandId);
        public Task<List<ProductDto>> GetByCategoryAsync(int categoryId);
        public Task<List<ProductDto>> GetByPriceRangeAsync(double priceStart, double priceEnd);
    }
}
