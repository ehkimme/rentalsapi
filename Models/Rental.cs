using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class Rental
    {
        public Rental()
        {
            Payments = new HashSet<Payment>();
        }
[Key]
        public long RentalId { get; set; }
        public byte[] RentalDate { get; set; } = null!;
        public long InventoryId { get; set; }
        public long CustomerId { get; set; }
        public byte[]? ReturnDate { get; set; }
        public long StaffId { get; set; }
        public byte[] LastUpdate { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
        public virtual Inventory Inventory { get; set; } = null!;
        public virtual staff Staff { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
