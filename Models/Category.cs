using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class Category
    {
        public Category()
        {
            FilmCategories = new HashSet<FilmCategory>();
        }

        [Key]
        public long CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public byte[] LastUpdate { get; set; } = null!;

        public virtual ICollection<FilmCategory> FilmCategories { get; set; }
    }
}
