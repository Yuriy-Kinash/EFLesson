
namespace Persistance.Repositories.Brands
{
    public interface IBrandRepository
    {
        public Task AddAsync(BrandDto brand);
        public Task<string> GetLinkAsync(int brandId);
        public Task<List<BrandDto>> GetAllAsync();
        public Task<BrandDto> GetByNameAsync(string name);
        public Task<BrandDto> GetByProductAsync(int productId);
    }
}
