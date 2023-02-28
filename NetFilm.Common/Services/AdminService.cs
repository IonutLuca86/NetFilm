


using System.Text;

namespace NetFilm.Common.Services
{
    public class AdminService : IAdminService
    {

        public readonly NetFilmHttpClient _http;
        public AdminService(NetFilmHttpClient client)
        {
            _http = client;
        }

        public async Task<List<TDto>> GetAsync<TDto>(string uri) where TDto : class
        {
            try
            {
                using HttpResponseMessage response = await _http.Client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var result = JsonSerializer.Deserialize<List<TDto>>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result ?? new List<TDto>();
            }
            catch (Exception ex) { throw; }

        }
        public async Task<TDto> SingleAsync<TDto>(string uri) where TDto : class
        {
            try
            {
                using HttpResponseMessage response = await _http.Client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var result = JsonSerializer.Deserialize<TDto>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result ?? default;
            }
            catch (Exception ex) { throw; }

        }
        public async Task CreateAsync<TDto>(string uri, TDto dto) where TDto : class
        {
            try {
                using StringContent jsonContent = new(JsonSerializer.Serialize(dto),Encoding.UTF8,"application/json");

                using HttpResponseMessage response = await _http.Client.PostAsync(uri, jsonContent); 

                response.EnsureSuccessStatusCode();

            }
            catch (Exception ex) { throw; }
        }
        public async Task EditAsync<TDto>(string uri, TDto dto) where TDto : class
        {
            try
            {
                using StringContent jsonContent = new(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

                using HttpResponseMessage response = await _http.Client.PutAsync(uri, jsonContent);

                response.EnsureSuccessStatusCode();

            }
            catch (Exception ex) { throw; }
        }
        public async Task DeleteAsync<TDto>(string uri) where TDto : class
        {
            try
            {
                using HttpResponseMessage response = await _http.Client.DeleteAsync(uri);

                response.EnsureSuccessStatusCode();

            }
            catch (Exception ex) { throw; }
        }
    }
}
