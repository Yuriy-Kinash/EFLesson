using Microsoft.EntityFrameworkCore;
using Persistance.Repositories.Users;

namespace Persistance.Repositories.Tariffs
{
    public class TariffRepository : ITariffRepository
    {
        private readonly ApplicationDbContext _dbContext;
        
        public TariffRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(TariffDto tariff)
        {
           Tariff addedTariff = new Tariff()
           {
               Name = tariff.Name,
               Price = tariff.Price,
               ValidityPeriod = tariff.Period,
               TariffDescriptionId = tariff.TariffDescriptionId,
           };
           await _dbContext.AddAsync(addedTariff);
           await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePriceAsync(int tariffId, double price)
        {
            Tariff tariff = await _dbContext.Tariffs.FirstOrDefaultAsync(x => x.Id == tariffId);
            tariff.Price = price;
            _dbContext.Update(tariff);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<double> GetPriceAsync(int tariffId)
        {
            Tariff tariff = await _dbContext.Tariffs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == tariffId);
            return tariff.Price;
        }

        public async Task<int> GetValidityPeriodAsync(int tariffId)
        {
            Tariff tariff = await _dbContext.Tariffs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == tariffId);
            return (int)tariff.ValidityPeriod;
        }

        public async Task<TariffDescriptionDto> GetDescriptionByIdAsync(int tariffId)
        {
            Tariff tariff = await _dbContext.Tariffs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == tariffId);
            return new TariffDescriptionDto()
            {
                CountOfChecks = tariff.TariffDescription.CountOfChecks,
                CountOfLinks = tariff.TariffDescription.CountOfLinks,
                CountOfMonitoring = tariff.TariffDescription.CountOfMonitoring
            };
        }

        public async Task<List<TariffDto>> GetByPriceRangeAsync(int startPrice, int endPrice)
        {
            return await _dbContext.Tariffs.Where(x => x.Price >= startPrice && x.Price <= endPrice)
                .AsNoTracking()
                .Select(x => new TariffDto()
                    {
                        Name = x.Name,
                        Price = x.Price,
                        TariffDescriptionId = x.TariffDescriptionId,
                        Period = x.ValidityPeriod
                    })
                .ToListAsync();
        }

        public async Task<List<TariffDto>> GetAllAsync()
        {
           return await _dbContext.Tariffs
                .AsNoTracking()
                .Select(x => new TariffDto()
                    {
                        Name = x.Name,
                        Price = x.Price,
                        TariffDescriptionId= x.TariffDescriptionId,
                        Period = x.ValidityPeriod
                    })
                .ToListAsync();
        }

        public async Task<List<UserProfileDto>> GetAllUsersAsync(int tariffId)
        {
            return await _dbContext.Users.Where(x => x.TariffId == tariffId)
                .AsNoTracking()
                .Select(x => new UserProfileDto()
                    {
                        FirstName = x.Profile.FirstName,
                        LastName = x.Profile.LastName,
                        Age = x.Profile.Age,
                        Email = x.Profile.Email,
                        Phone = x.Profile.Phone,
                    })
                .ToListAsync();
        }
    }
}
