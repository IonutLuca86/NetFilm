

namespace NetFilm.Common.DTOs
{
    
    public class FilmCreateDTO
    {        
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Released { get; set; }
        public string? Lenght { get; set; }
        public int DirectorId { get; set; }
        public string ImageURL { get; set; } = string.Empty;
        public string VideoURL { get; set; } = string.Empty;
        


    }
    public class FilmUpdateDTO : FilmCreateDTO
    {
        public int Id { get; set; }
    }
    public class FilmDTO : FilmUpdateDTO
    {
       
        public DirectorDTO Director { get; set; } = null!;
        public List<GenreBaseDTO>? FilmGenres { get; set; } = new();
        public List<SimilarFilmDTO> SimilarFilms { get; set; } = null!;
    }


}
