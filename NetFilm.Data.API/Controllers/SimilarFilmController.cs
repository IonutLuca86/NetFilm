using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetFilm.Data.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimilarFilmController : ControllerBase
    {
        private readonly IDbService _db;
        public SimilarFilmController(IDbService db) => _db = db;
        // GET: api/<SimilarFilmController>
        [HttpGet]
        public async Task<IResult> GetSimilarFilms()
        {
            try
            {
                var films = await _db.ConnectionGetAsync<SimilarFilm, SimilarFilmDTO>();
                return Results.Ok(films);
            }
            catch (Exception ex) { return Results.NotFound("No items were found!" + ex); }

        }

        // GET api/<SimilarFilmController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<SimilarFilmController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] SimilarFilmDTO dto)
        {
            try
            {
                var similar = await _db.AddAsync<SimilarFilm, SimilarFilmDTO>(dto);
                var result = await _db.SaveChangesAsync();
                if (!result) return Results.BadRequest();
                return Results.Created($"api/{typeof(SimilarFilm).Name.ToLower()}s/{similar.SimilarFilmId}", similar);
            }
            catch { return Results.NotFound(); }
        }

        //// PUT api/<SimilarFilmController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SimilarFilmController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
