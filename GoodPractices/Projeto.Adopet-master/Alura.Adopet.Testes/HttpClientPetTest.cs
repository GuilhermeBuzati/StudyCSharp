using Alura.Adopet.Console;

namespace Alura.Adopet.Testes
{
    public class HttpClientPetTest
    {
        [Fact]
        public async Task ListaPetsDeveRetornarNaoVazio()
        {
            //Arrange
            var clientePet = new HttpClientPet();

            //Act
            var lista = await clientePet.ListPetsAsync();

            //Assert
            Assert.NotNull(lista);
            Assert.NotEmpty(lista);

        }

        [Fact]
        public async Task QuandoAPIForaDeveRetornarUmaExcecao()
        {
            var clientePet = new HttpClientPet("http://localhost:1111");

            await Assert.ThrowsAnyAsync<Exception>(() => clientePet.ListPetsAsync());
        }
    }
}