using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class Address
    {
        public Address()
        {
            Customers = new HashSet<Customer>();
            Stores = new HashSet<Store>();
            staff = new HashSet<staff>();
        }

        [Key]
        public long AddressId { get; set; }
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string District { get; set; } = null!;
        public long CityId { get; set; }
        public string? PostalCode { get; set; }
        public string Phone { get; set; } = null!;
        public byte[] LastUpdate { get; set; } = null!;

        public virtual City City { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
