using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class FilmText
    {
        [Key]
        public long FilmId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }
}
