using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Entities;
using System.ComponentModel.DataAnnotations;

namespace Persistance
{
    public class User
    {
        public int Id { get; set; }
        [MinLength(5)]
        public string Login { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
        public UserProfile? Profile { get; set; }
        public List<Product> UserProducts { get; set; }
        public int? TariffId { get; set; }
        public Tariff? Tariff { get; set; }
    }
}
