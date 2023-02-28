

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetFilm.Data.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IDbService _db;
        public FilmController(IDbService db) => _db = db;
        // GET: api/<FilmController>
        [HttpGet]
        public async Task<IResult> GetFilms()
        {
            try
            {
                _db.Include<Director>();
                //_db.Include<SimilarFilm>();
                _db.Include<FilmGenre>();
                //_db.Include<Genre>();
                var films = await _db.GetAsync<Film, FilmDTO>();
                return Results.Ok(films);
            }
            catch (Exception ex) { return Results.NotFound("No items were found!" +ex); }

        }
        // GET api/<FilmController>/5
        [HttpGet("{id}")]
        public async Task<IResult> GetFilmAsync(int id)
        {
            try
            {
                _db.Include<Director>();
                _db.Include<SimilarFilm>();
                _db.Include<FilmGenre>();
                var film = await _db.SingleAsync<Film, FilmDTO>(e => e.Id.Equals(id));
                return Results.Ok(film);
            }
            catch { return Results.NotFound(); }
        }

        // POST api/<FilmController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] FilmCreateDTO dto)
        {
            try
            {
                
                var film = await _db.AddAsync<Film, FilmCreateDTO>(dto);
                               
                var result = await _db.SaveChangesAsync();
                if (!result) return Results.BadRequest();
                //foreach (var genre in film.FilmGenres)
                //{
                //    FilmGenreDTO newGenre = new FilmGenreDTO { FilmId = film.Id, GenreId = genre.Id };
                //    try
                //    {
                //        var filmgenre = await _db.AddAsync<FilmGenre, FilmGenreDTO>(newGenre);
                //        var result2 = await _db.SaveChangesAsync();
                //        if (!result2) return Results.BadRequest();
                //        return Results.Created($"api/{typeof(FilmGenre).Name.ToLower()}s/{filmgenre.FilmId}", filmgenre);
                //    }
                //    catch { return Results.NotFound(); }
                //}
                return Results.Created($"api/{typeof(Film).Name.ToLower()}s/{film.Id}", film);
            }
            catch (Exception ex){ return Results.NotFound(ex); }
        }

        // PUT api/<FilmController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] FilmUpdateDTO dto)
        {
            try
            {
                if (!await _db.AnyAsync<Film>(e => e.Id.Equals(id))) return Results.NotFound();

                _db.Update<Film, FilmUpdateDTO>(id, dto);
                if (await _db.SaveChangesAsync()) return Results.NoContent();

            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Couldn't update the {typeof(Film).Name} entity.\n{ex}.");
            }
            return Results.BadRequest($"Couldn't update the {typeof(Film).Name} entity.\n.");
        }

        // DELETE api/<FilmController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                if (!await _db.DeleteAsync<Film>(id)) return Results.NotFound();

                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Couldn't delete the {typeof(Film).Name} entity.\n{ex}.");
            }

            return Results.BadRequest($"Couldn't delete the {typeof(Film).Name} entity.");
        }
    }
}
