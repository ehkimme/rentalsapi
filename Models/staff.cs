using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class staff
    {
        public staff()
        {
            Payments = new HashSet<Payment>();
            Rentals = new HashSet<Rental>();
            Stores = new HashSet<Store>();
        }
        
        [Key]
        public long StaffId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public long AddressId { get; set; }
        public byte[]? Picture { get; set; }
        public string? Email { get; set; }
        public long StoreId { get; set; }
        public long Active { get; set; }
        public string Username { get; set; } = null!;
        public string? Password { get; set; }
        public byte[] LastUpdate { get; set; } = null!;

        public virtual Address Address { get; set; } = null!;
        public virtual Store Store { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
