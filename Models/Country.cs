using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }
        
        [Key]
        public long CountryId { get; set; }
        public string Country1 { get; set; } = null!;
        public byte[]? LastUpdate { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
