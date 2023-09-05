
namespace Persistance.Repositories.Tariffs
{
    public class TariffDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public ValidityPeriod Period { get; set; }
        public int TariffDescriptionId { get; set; }
    }
}
