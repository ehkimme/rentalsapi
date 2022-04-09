using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class FilmCategory
    {

        [Key]
        public long FilmId { get; set; }
        public long CategoryId { get; set; }
        public byte[] LastUpdate { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
        public virtual Film Film { get; set; } = null!;
    }
}
