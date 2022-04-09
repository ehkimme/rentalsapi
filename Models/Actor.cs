using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class Actor
    {
        [Key]
        public int ActorId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public byte[] LastUpdate { get; set; } = null!;
    }
}
