using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class Customer
    {
        public Customer()
        {
            Payments = new HashSet<Payment>();
            Rentals = new HashSet<Rental>();
        }
        
        [Key]
        public long CustomerId { get; set; }
        public long StoreId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public long AddressId { get; set; }
        public string Active { get; set; } = null!;
        public byte[] CreateDate { get; set; } = null!;
        public byte[] LastUpdate { get; set; } = null!;

        public virtual Address Address { get; set; } = null!;
        public virtual Store Store { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
