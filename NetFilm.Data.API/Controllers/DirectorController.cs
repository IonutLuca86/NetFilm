


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetFilm.Data.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDbService _db;
        public DirectorController(IDbService db) => _db = db;

        // GET: api/<DirectorController>
        [HttpGet]
        public async Task<IResult> GetDirectors()
        {
            try
            {                
                var directors = await _db.GetAsync<Director, DirectorDTO>();
                return Results.Ok(directors);
            }
            catch { return Results.NotFound("No items were found!"); }

        }

        // GET api/<DirectorController>/5
        [HttpGet("{id}")]
        public async Task<IResult> GetDirectorAsync(int id)
        {
            try
            {
                var director = await _db.SingleAsync<Director, DirectorDTO>(e => e.Id.Equals(id));
                return Results.Ok(director);
            }
            catch { return Results.NotFound(); }
        }


        // POST api/<DirectorController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] DirectorDTO dto)
        {
            try
            {
                var director = await _db.AddAsync<Director, DirectorDTO>(dto);
                var result = await _db.SaveChangesAsync();
                if (!result) return Results.BadRequest();
                return Results.Created($"api/{typeof(Director).Name.ToLower()}s/{director.Id}", director);
            }
            catch { return Results.NotFound(); }
        }


        // PUT api/<DirectorController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody]  DirectorDTO dto)
        {
            try
            {
                if (!await _db.AnyAsync<Director>(e => e.Id.Equals(id))) return Results.NotFound();

                _db.Update<Director, DirectorDTO>(id, dto);
                if (await _db.SaveChangesAsync()) return Results.NoContent();

            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Couldn't update the {typeof(Director).Name} entity.\n{ex}.");
            }
            return Results.BadRequest($"Couldn't update the {typeof(Director).Name} entity.\n.");
        }

        // DELETE api/<DirectorController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                if (!await _db.DeleteAsync<Director>(id)) return Results.NotFound();

                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Couldn't delete the {typeof(Director).Name} entity.\n{ex}.");
            }

            return Results.BadRequest($"Couldn't delete the {typeof(Director).Name} entity.");
        }
    }
}
