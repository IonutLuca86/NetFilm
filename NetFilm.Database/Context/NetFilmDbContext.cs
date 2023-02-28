


using Microsoft.EntityFrameworkCore;
using NetFilm.Database.Entitites;
using System.Reflection.Emit;

namespace NetFilm.Database.Context
{
    public class NetFilmDbContext : DbContext
    {
        public NetFilmDbContext(DbContextOptions<NetFilmDbContext> options) : base(options) { }

        public DbSet<Film> Films { get; set; } = null!;
        public DbSet<SimilarFilm> SimilarFilms { get; set; } = null!;
        public DbSet<Director> Directors { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<FilmGenre> FilmGenres { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            builder.Entity<FilmGenre>().HasKey(p => new { p.FilmId, p.GenreId });
            builder.Entity<SimilarFilm>().HasKey(p => new { p.ParentFilmId, p.SimilarFilmId });
            //builder.Entity<FilmGenre>()
            //    .HasOne<Film>(f => f.Film)
            //    .WithMany(g => g.FilmGenres)
            //    .HasForeignKey(f => f.FilmId);
            //builder.Entity<FilmGenre>()
            //    .HasOne<Genre>(g => g.Genre)
            //    .WithMany(f => f.Films)
            //    .HasForeignKey(f => f.GenreId);
            builder.Entity<Film>(entity =>
            {
                entity
                    // For each film in the Film Entity,
                    // reference relatred films in the SimilarFilms entity
                    // with the ICollection<SimilarFilms>
                    .HasMany(d => d.SimilarFilms)
                    .WithOne(p => p.Film)
                    .HasForeignKey(d => d.ParentFilmId)
                    // To prevent cycles or multiple cascade paths.
                    // Neded when seeding similar films data.
                    .OnDelete(DeleteBehavior.ClientSetNull);

                // Configure a many-to-many realtionship between genres
                // and films using the FilmGenre connection entity.
                entity.HasMany(d => d.FilmGenres)
                      .WithMany(p => p.Films)
                      .UsingEntity<FilmGenre>()
                       //Specify the table name for the connection table
                       //to avoid duplicate tables(FilmGenre and FilmGenres)
                       //in the database.
                      .ToTable("FilmGenres");
            });

            /* Seed Data */
            //builder.Entity<Director>().HasData(
            //    new { Id = 1, Name = "Director Name" });

            //builder.Entity<Film>().HasData(
            //    new { Id = 1, Title = "Spiderman", DirectorId = 1, Description = "asadasdas", Released = 2011, Lenght = "1:40:00", ImageURL = "asdaxvcxv", VideoURL = "sdxcsd" },
            //    new { Id = 2, Title = "Batman", DirectorId = 1, Description = "asadasdas", Released = 2011, Lenght = "1:40:00", ImageURL = "asdaxvcxv", VideoURL = "sdxcsd" },
            //    new { Id = 3, Title = "The Hulk", DirectorId = 1, Description = "asadasdas", Released = 2011, Lenght = "1:40:00", ImageURL = "asdaxvcxv", VideoURL = "sdxcsd" });

            //builder.Entity<SimilarFilm>().HasData(
            //    new SimilarFilm { ParentFilmId = 1, SimilarFilmId = 2 },
            //    new SimilarFilm { ParentFilmId = 1, SimilarFilmId = 3 });

            //builder.Entity<Genre>().HasData(
            //    new { Id = 1, Name = "Action" },
            //    new { Id = 2, Name = "Sci-Fi" });

            //builder.Entity<FilmGenre>().HasData(
            //    new FilmGenre { FilmId = 1, GenreId = 1 },
            //    new FilmGenre { FilmId = 1, GenreId = 2 },
            //    new FilmGenre { FilmId = 2, GenreId = 1 },
            //    new FilmGenre { FilmId = 3, GenreId = 1 });
        }
    }
    

    
}
