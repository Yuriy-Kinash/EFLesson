using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .Select(c => new CategoryDto() { Name = c.Name })
                .ToListAsync();
        }

        public async Task<CategoryDto> GetByNameAsync(string name)
        {
            Category category = await _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
            return new CategoryDto() { Name = category.Name };
        }

        public async Task<CategoryDto> GetByProductAsync(int productId)
        {
            Product product = await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == productId);
            Brand brand = new Brand() { Id = product.BrandId };  
            return new CategoryDto() { Name = brand.Name };
        }
    }
}
