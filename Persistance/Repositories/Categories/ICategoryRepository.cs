
namespace Persistance.Repositories.Categories
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryDto>> GetAllAsync();
        public Task<CategoryDto> GetByProductAsync(int productId);  
        public Task<CategoryDto> GetByNameAsync(string name);
    }
}
