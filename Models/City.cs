using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }
        
        [Key]
        public long CityId { get; set; }
        public string City1 { get; set; } = null!;
        public long CountryId { get; set; }
        public byte[] LastUpdate { get; set; } = null!;

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
