


namespace NetFilm.Database.Entitites
{
    public class Film : IEntity
    {
        public Film()
        {
            SimilarFilms = new List<SimilarFilm>();
            FilmGenres = new List<Genre>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(1024)]
        public string Description { get; set; } = string.Empty;
        public int Released { get; set; }
        [MaxLength(10)]
        public string? Lenght { get; set; }
        public int DirectorId { get; set; }      
        public string ImageURL { get; set; } = string.Empty;
        public string VideoURL { get; set; } = string.Empty;
        

        public virtual Director Director { get; set; } = null!;
        public virtual ICollection<Genre> FilmGenres { get; set; } 
        public virtual ICollection<SimilarFilm> SimilarFilms { get; set; } = null!;
    }
}
