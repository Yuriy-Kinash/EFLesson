
namespace Persistance.Repositories.Users
{
    public class UserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Tariff { get; set; }
    }
}
