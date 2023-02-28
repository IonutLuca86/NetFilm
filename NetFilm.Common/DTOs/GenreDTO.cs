

namespace NetFilm.Common.DTOs
{

    public class GenreDTO: GenreBaseDTO
    {
        public List<FilmDTO>? Films { get; set; }
    }
    public class GenreBaseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
