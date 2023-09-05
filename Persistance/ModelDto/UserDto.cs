
namespace Persistance.Repositories.Users
{
    public class UserDto
    {        
       public string Password { get; set; }
       public string Login { get; set; }
       public UserProfileDto Profile { get; set; }
    }
}
