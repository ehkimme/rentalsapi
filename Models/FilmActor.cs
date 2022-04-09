using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class FilmActor
    {
        [Key]
        public long ActorId { get; set; }
        public long FilmId { get; set; }
        public byte[] LastUpdate { get; set; } = null!;

        public virtual Film Film { get; set; } = null!;
    }
}
