



namespace NetFilm.Database.Entitites
{
    public class SimilarFilm : IReferenceEntity
    {
        public int ParentFilmId { get; set; }
        public int SimilarFilmId { get; set; }

        public Film Film { get; set; } = null!;
        [ForeignKey("SimilarFilmId")]
        public Film Similar { get; set; } = null!;
    }
}
