namespace NetFilm.Common.Services
{
    public interface IClientService
    {
        NetFilmHttpClient _http { get; }

        Task<List<TDto>> GetAsync<TDto>(string uri) where TDto : class;
        Task<TDto> SingleAsync<TDto>(string uri, int id) where TDto : class;
    }
}