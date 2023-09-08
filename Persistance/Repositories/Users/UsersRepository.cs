using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UsersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(UserDto user)
        {
            User addedUser = new User()
            {
                Password = user.Password,
                Login = user.Login,
                Profile = new UserProfile()
                {
                    FirstName = user.Profile.FirstName,
                    LastName = user.Profile.LastName,
                    Email = user.Profile.Email,
                    Phone = user.Profile.Phone,
                    Age = user.Profile.Age
                }
            };

            await _dbContext.Users.AddAsync(addedUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddAsync(params UserDto[] users)
        {
            await _dbContext.Users.AddRangeAsync(
                users.Select(user => new User()
                {
                    Password = user.Password,
                    Login = user.Login,
                    Profile = new UserProfile()
                    {
                        FirstName = user.Profile.FirstName,
                        LastName = user.Profile.LastName,
                        Email = user.Profile.Email,
                        Phone = user.Profile.Phone,
                        Age = user.Profile.Age
                    }
            }));

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckPasswordAsync(string password, int userId)
        {
           User user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);

           return user.Password == password;
        }

        public async Task<int> GetAgeAsync(int userId)
        {
            UserProfile user = await _dbContext.UserProfiles.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);

            return user.Age;
        }

        public async Task<UserFullNameDto> GetFullNameAsync(int userId)
        {
            UserProfile userProfile = await _dbContext.UserProfiles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);

            return new UserFullNameDto()
            {
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
            };
        }

        public async Task<UserContactDto> GetContactAsync(int userId)
        {
            UserProfile userProfile = await _dbContext.UserProfiles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);

            return new UserContactDto()
            {
                Email = userProfile.Email,
                Phone = userProfile.Phone,
            };
        }

        public async Task<UserProfileDto> GetProfileInformationAsync(int userId)
        {
            UserProfile userProfile = await _dbContext.UserProfiles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);

            return new UserProfileDto()
            {
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                Age = userProfile.Age,
                Email = userProfile.Email,
                Phone = userProfile.Phone
            };
        }

        public async Task<string> GetTariffAsync(int userId)
        {
            User user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);

            return user.Tariff.Name;
        }

        public async Task<bool> CheckTariffPurchasedAsync(int userId)
        {
            User user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);

            if (user.TariffId >= 0) return true;
            else return false;
        }

        public async Task<List<UserProfileDto>> GetByAgeRangeAsync(int startPrice, int endPrice)
        {
            return await _dbContext.UserProfiles
                .Where(x => x.Age >= startPrice && x.Age <= endPrice)
                .AsNoTracking()
                .Select(x => new UserProfileDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    Email = x.Email,
                    Phone = x.Phone
                })
                .ToListAsync();
        }

        public async Task<List<UserProfileDto>> GetByFirstNameAsync(string firstName)
        {
            return await _dbContext.UserProfiles
                .Where(x => x.FirstName == firstName)
                .AsNoTracking()
                .Select(x => new UserProfileDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    Email = x.Email,
                    Phone = x.Phone
                })
                .ToListAsync();
        }

        public async Task<List<UserProfileDto>> GetByLastNameAsync(string lastName)
        {
            return await _dbContext.UserProfiles
               .Where(x => x.LastName == lastName)
               .AsNoTracking()
               .Select(x => new UserProfileDto()
               {
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   Age = x.Age,
                   Email = x.Email,
                   Phone = x.Phone
               })
               .ToListAsync();
        }

        public async Task<List<UserProfileDto>> GetByTariffAsync(Tariff tariff)
        {
            return await _dbContext.Users
                .Where(x => x.TariffId == tariff.Id)
                .AsNoTracking()
                .Select(x => new UserProfileDto()
                {
                    FirstName = x.Profile.FirstName,
                    LastName = x.Profile.LastName,
                    Age = x.Profile.Age,
                    Email = x.Profile.Email,
                    Phone = x.Profile.Phone
                })
                .ToListAsync();
        }

        public async Task<List<UserProfileDto>> GetAdultsAsync()
        {
            return await _dbContext.UserProfiles.Where(x => x.Age > 17)
                .AsNoTracking()
                .Select(x => new UserProfileDto()
                {
                    Age = x.Age,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Phone = x.Phone
                })
                .ToListAsync();
        }
    }
}
