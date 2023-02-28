namespace NetFilm.Common.Services
{
    public interface IAdminService
    {
        Task CreateAsync<TDto>(string uri, TDto dto) where TDto : class;
        Task DeleteAsync<TDto>(string uri) where TDto : class;
        Task EditAsync<TDto>(string uri, TDto dto) where TDto : class;
        Task<List<TDto>> GetAsync<TDto>(string uri) where TDto : class;
        Task<TDto> SingleAsync<TDto>(string uri) where TDto : class;
    }
}