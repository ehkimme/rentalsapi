using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class Language
    {
        public Language()
        {
            FilmLanguages = new HashSet<Film>();
            FilmOriginalLanguages = new HashSet<Film>();
        }

        [Key]
        public long LanguageId { get; set; }
        public string Name { get; set; } = null!;
        public byte[] LastUpdate { get; set; } = null!;

        public virtual ICollection<Film> FilmLanguages { get; set; }
        public virtual ICollection<Film> FilmOriginalLanguages { get; set; }
    }
}
