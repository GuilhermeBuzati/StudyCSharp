using ItemService.Dtos;
using System.Text;
using System.Text.Json;

namespace ItemService.ItemServiceHttpClient
{
    public class ItemServiceHttpClient : IItemServiceHttpClient
    {
        private readonly HttpClient _client;

        public ItemServiceHttpClient(HttpClient client)
        {
            _client = client;
        }

        public void EnviaRestauranteParaItemService(RestauranteReadDto readDto)
        {
            var conteudoHttp =  new StringContent(
                JsonSerializer.Serialize(readDto),
                Encoding.UTF8,
                "application/json"
            );
        }
    }
}
