

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetFilm.Data.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmGenreController : ControllerBase
    {
        private readonly IDbService _db;
        public FilmGenreController(IDbService db) => _db = db;
        // GET: api/<FilmGenreController>
        [HttpGet]
        public async Task<IResult> GetFilmGenres()
        {
            try
            {
                var filmgenres = await _db.ConnectionGetAsync<FilmGenre, FilmGenreDTO>();
                return Results.Ok(filmgenres);
            }
            catch (Exception ex) { return Results.NotFound("No items were found!" + ex); }

        }

        // GET api/<FilmGenreController>/5
        //[HttpGet("{id}")]
        

        // POST api/<FilmGenreController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] FilmGenreDTO dto)
        {
            try
            {
                var filmgenre = await _db.AddAsync<FilmGenre, FilmGenreDTO>(dto);
                var result = await _db.SaveChangesAsync();
                if (!result) return Results.BadRequest();
                return Results.Created($"api/{typeof(FilmGenre).Name.ToLower()}s/{filmgenre.FilmId}", filmgenre);
            }
            catch { return Results.NotFound(); }
        }

        // PUT api/<FilmGenreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FilmGenreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
