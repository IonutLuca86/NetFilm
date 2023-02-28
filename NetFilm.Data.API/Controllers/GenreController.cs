using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetFilm.Data.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IDbService _db;
        public GenreController(IDbService db) => _db = db;
        // GET: api/<GenresController>
        [HttpGet]
        public async Task<IResult> GetGenres()
        {
            try
            {
                var genres = await _db.GetAsync<Genre, GenreDTO>();
                return Results.Ok(genres);
            }
            catch (Exception ex) { return Results.NotFound("No items were found!"+ex); }

        }

        // GET api/<GenresController>/5
        [HttpGet("{id}")]
        public async Task<IResult> GetGenreAsync(int id)
        {
            try
            {
                var genre = await _db.SingleAsync<Genre, GenreDTO>(e => e.Id.Equals(id));
                return Results.Ok(genre);
            }
            catch { return Results.NotFound(); }
        }

        // POST api/<GenresController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] GenreBaseDTO dto)
        {
            try
            {
                var genre = await _db.AddAsync<Genre, GenreBaseDTO>(dto);
                var result = await _db.SaveChangesAsync();
                if (!result) return Results.BadRequest();
                return Results.Created($"api/{typeof(Genre).Name.ToLower()}s/{genre.Id}", genre);
            }
            catch { return Results.NotFound(); }
        }

        // PUT api/<GenresController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] GenreDTO dto)
        {
            try
            {
                if (!await _db.AnyAsync<Genre>(e => e.Id.Equals(id))) return Results.NotFound();

                _db.Update<Genre, GenreDTO>(id, dto);
                if (await _db.SaveChangesAsync()) return Results.NoContent();

            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Couldn't update the {typeof(Genre).Name} entity.\n{ex}.");
            }
            return Results.BadRequest($"Couldn't update the {typeof(Genre).Name} entity.\n.");
        }

        // DELETE api/<GenresController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                if (!await _db.DeleteAsync<Genre>(id)) return Results.NotFound();

                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Couldn't delete the {typeof(Genre).Name} entity.\n{ex}.");
            }

            return Results.BadRequest($"Couldn't delete the {typeof(Genre).Name} entity.");
        }
    }
}
