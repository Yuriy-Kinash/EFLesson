using Persistance.Repositories.Users;

namespace Persistance.Repositories.Tariffs
{
    public interface ITariffRepository
    {
        public Task AddAsync(TariffDto tariff);
        public Task UpdatePriceAsync(int tariffId, double price);
        public Task<double> GetPriceAsync(int tariffId);
        public Task<int> GetValidityPeriodAsync(int tariffId);
        public Task<TariffDescriptionDto> GetDescriptionByIdAsync(int tariffId);
        public Task<List<TariffDto>> GetByPriceRangeAsync(int startPrice, int endPrice);
        public Task<List<TariffDto>> GetAllAsync();
        public Task<List<UserProfileDto>> GetAllUsersAsync(int tariffId);
    }
}
