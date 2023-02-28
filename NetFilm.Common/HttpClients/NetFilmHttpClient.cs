using System.Net.Http;

namespace NetFilm.Common.HttpClients
{
    public class NetFilmHttpClient
    {
        public HttpClient Client { get; }

        public NetFilmHttpClient(HttpClient client)
        {
            Client = client;

        }
    }
}
