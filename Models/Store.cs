using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class Store
    {
        public Store()
        {
            Customers = new HashSet<Customer>();
            Inventories = new HashSet<Inventory>();
            staff = new HashSet<staff>();
        }

        [Key]
        public long StoreId { get; set; }
        public long ManagerStaffId { get; set; }
        public long AddressId { get; set; }
        public byte[] LastUpdate { get; set; } = null!;

        public virtual Address Address { get; set; } = null!;
        public virtual staff ManagerStaff { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
