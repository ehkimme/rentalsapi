using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class Payment
    {
        [Key] 
        public long PaymentId { get; set; }
        public long CustomerId { get; set; }
        public long StaffId { get; set; }
        public long? RentalId { get; set; }
        public byte[] Amount { get; set; } = null!;
        public byte[] PaymentDate { get; set; } = null!;
        public byte[] LastUpdate { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
        public virtual Rental? Rental { get; set; }
        public virtual staff Staff { get; set; } = null!;
    }
}
