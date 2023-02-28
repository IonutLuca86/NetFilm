


namespace NetFilm.Database.Entitites
{
    public class FilmGenre : IReferenceEntity
    {
        public int FilmId { get; set; }
        public int GenreId { get; set; }

        public Genre Genre { get; set; } = null!;
        public Film? Film { get; set; }
    }
}
