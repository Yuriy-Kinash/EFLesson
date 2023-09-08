using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Brands
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BrandRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(BrandDto brand)
        {
            Brand addedBrand = new Brand() { Name = brand.Name, Link = brand.Link };

            await _dbContext.Brands.AddAsync(addedBrand);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> GetLinkAsync(int brandId)
        {
            Brand brand = await _dbContext.Brands.AsNoTracking().FirstOrDefaultAsync(x => x.Id == brandId);

            return brand.Link;
        }

        public async Task<List<BrandDto>> GetAllAsync()
        {
            return await _dbContext.Brands
                .AsNoTracking()
                .Select(x => new BrandDto()
                    {
                        Name = x.Name,
                        Link = x.Link,
                    })
                .ToListAsync();
        }

        public async Task<BrandDto> GetByProductAsync(int productId)
        {
            Product product = await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == productId);
            Brand brand = new Brand() { Id = product.BrandId};

            return new BrandDto() { Name = brand.Name,  Link = brand.Link };
        }

        public async Task<BrandDto> GetByNameAsync(string name)
        {
            Brand brand = await _dbContext.Brands.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);

            if (brand != null)
                return new BrandDto() { Name = brand.Name, Link = brand.Link};
            else return null;
        }
    }
}
