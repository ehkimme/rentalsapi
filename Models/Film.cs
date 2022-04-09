using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class Film
    {
        public Film()
        {
            FilmActors = new HashSet<FilmActor>();
            FilmCategories = new HashSet<FilmCategory>();
            Inventories = new HashSet<Inventory>();
        }

        [Key]
        public long FilmId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? ReleaseYear { get; set; }
        public long LanguageId { get; set; }
        public long? OriginalLanguageId { get; set; }
        public long RentalDuration { get; set; }
        public byte[] RentalRate { get; set; } = null!;
        public long? Length { get; set; }
        public byte[] ReplacementCost { get; set; } = null!;
        public string? Rating { get; set; }
        public string? SpecialFeatures { get; set; }
        public byte[] LastUpdate { get; set; } = null!;

        public virtual Language Language { get; set; } = null!;
        public virtual Language? OriginalLanguage { get; set; }
        public virtual ICollection<FilmActor> FilmActors { get; set; }
        public virtual ICollection<FilmCategory> FilmCategories { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
