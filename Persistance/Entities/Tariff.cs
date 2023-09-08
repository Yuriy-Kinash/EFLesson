namespace Persistance
{
    public class Tariff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ValidityPeriod ValidityPeriod { get; set; }
        public int TariffDescriptionId { get; set; }
        public TariffDescription? TariffDescription { get; set; }
        public List<User>? Users { get; set; }  
    }
}
