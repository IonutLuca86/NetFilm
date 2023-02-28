using NetFilm.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilm.Common.Services
{
    public class ClientService : IClientService
    {
        public NetFilmHttpClient _http { get; }

        public ClientService(NetFilmHttpClient httpClient)
        {
            _http = httpClient;
        }

        public async Task<List<TDto>> GetAsync<TDto>(string uri) where TDto : class
        {
            try
            {
                using HttpResponseMessage response = await _http.Client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var result = JsonSerializer.Deserialize<List<TDto>>(await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result ?? new List<TDto>();
            }
            catch (Exception ex) { throw; }
        }
        public async Task<TDto> SingleAsync<TDto>(string uri, int id) where TDto : class
        {
            try
            {

                using HttpResponseMessage response = await _http.Client.GetAsync($"{uri}/{id}");
                response.EnsureSuccessStatusCode();
                var result = JsonSerializer.Deserialize<TDto>(await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result ?? default;
            }
            catch (Exception ex) { throw; }
        }

    }
}
