


namespace NetFilm.Database.Entitites
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; } 

        public virtual ICollection<Film>? Films { get; set; }
    }
}
