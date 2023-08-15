using ItemService.Dtos;

namespace ItemService.ItemServiceHttpClient
{
    public interface IItemServiceHttpClient
    {

        public void EnviaRestauranteParaItemService(RestauranteReadDto readDto);
    }
}
