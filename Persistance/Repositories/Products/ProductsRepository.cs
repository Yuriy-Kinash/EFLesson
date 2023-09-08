using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Products
{
    public class ProductsRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ProductDto product)
        {
            Product addedProduct = new Product() {
                Name = product.Name,
                Price = product.Price,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId  
             };

            await _dbContext.Products.AddAsync(addedProduct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddAsync(params ProductDto[] product)
        {
            await _dbContext.Products.AddRangeAsync(
                product.Select(x => new Product()
                {
                    Name = x.Name,
                    Price = x.Price,
                    BrandId = x.BrandId,
                    CategoryId = x.CategoryId
                }));

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNameAsync(string name, int productId)
        {
            Product product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId);

            if (product != null)
            {
                product.Name = name;
                _dbContext.Products.Update(product);
            }
        }

        public async Task UpdatePictureAsync(int productId, string picture)
        {
            Product product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId);

            if (product != null)
            {
                product.Picture = picture;
                _dbContext.Products.Update(product);
            }
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            return await _dbContext.Products
                .AsNoTracking()
                .Select(x => new ProductDto()
                {
                    Name = x.Name,
                    Price = x.Price,
                    CategoryId = x.CategoryId,
                    BrandId = x.BrandId,
                })
                .ToListAsync();
        }

        public async Task<double> GetPriceAsync(int id)
        {
            Product product = await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return product.Price;
        }

        public async Task<List<ProductDto>> GetByBrandAsync(int brandId)
        {
            return await _dbContext.Products.Where(x => x.BrandId == brandId)
                .AsNoTracking()
                .Select(x => new ProductDto()
                {
                    Name = x.Name,
                    Price = x.Price,
                    CategoryId = x.CategoryId,
                    BrandId = x.BrandId,
                })
                .ToListAsync();
        }

        public async Task<List<ProductDto>> GetByCategoryAsync(int categoryId)
        {
            return await _dbContext.Products.Where(x => x.CategoryId == categoryId)
              .AsNoTracking()
              .Select(x => new ProductDto()
              {
                  Name = x.Name,
                  Price = x.Price,
                  CategoryId = x.CategoryId,
                  BrandId = x.BrandId,
              })
              .ToListAsync();
        }

        public async Task<List<ProductDto>> GetByPriceRangeAsync(double priceStart, double priceEnd)
        {
            return await _dbContext.Products.Where(x => x.Price >= priceStart && x.Price <= priceEnd)
               .AsNoTracking()
               .Select(x => new ProductDto()
               {
                   Name = x.Name,
                   Price = x.Price,
                   CategoryId = x.CategoryId,
                   BrandId = x.BrandId,
               })
               .ToListAsync();
        }
    }
}
