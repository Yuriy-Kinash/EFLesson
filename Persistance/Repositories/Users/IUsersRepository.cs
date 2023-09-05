
namespace Persistance.Repositories.Users
{
    public interface IUsersRepository
   {
        public Task AddAsync(UserDto user);
        public Task AddAsync(params UserDto[] users);
        public Task<bool> CheckPasswordAsync(string password, int userId);
        public Task<int> GetAgeAsync(int userId);
        public Task<UserFullNameDto> GetFullNameAsync(int userId);
        public Task<UserContactDto> GetContactAsync(int userId);
        public Task<UserProfileDto> GetProfileInformationAsync(int userId);
        public Task<string> GetTariffAsync(int userId);
        public Task<bool> CheckTariffPurchasedAsync(int userId);
        public Task<List<UserProfileDto>> GetByAgeRangeAsync(int startPrice, int endPrice);
        public Task<List<UserProfileDto>> GetByFirstNameAsync(string firstName);
        public Task<List<UserProfileDto>> GetByLastNameAsync(string lastName);
        public Task<List<UserProfileDto>> GetByTariffAsync(Tariff tariff);
        public Task<List<UserProfileDto>> GetAdultsAsync();
    }
}
