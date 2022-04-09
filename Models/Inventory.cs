using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class Inventory
    {
        public Inventory()
        {
            Rentals = new HashSet<Rental>();
        }
[Key]
        public long InventoryId { get; set; }
        public long FilmId { get; set; }
        public long StoreId { get; set; }
        public byte[] LastUpdate { get; set; } = null!;

        public virtual Film Film { get; set; } = null!;
        public virtual Store Store { get; set; } = null!;
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
