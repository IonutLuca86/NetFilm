


namespace NetFilm.Database.Entitites
{
    public class Director : IEntity
    {
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string? Name { get; set; }
        public string? Avatar { get; set; }
        [MaxLength(1024)]
        public string? Description { get; set; }
        public virtual ICollection<Film>? Films { get; set; }
    }

}
