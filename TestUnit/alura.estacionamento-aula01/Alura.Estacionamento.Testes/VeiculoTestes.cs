using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable
    {

        private Veiculo veiculo;
        private ITestOutputHelper saidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            saidaConsoleTeste = _saidaConsoleTeste;
            saidaConsoleTeste.WriteLine("Construtor Invocado");
            veiculo = new Veiculo();
        }

        [Fact]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Pattern AAA
            //Arrange

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);

        }

        [Fact(DisplayName = "Teste de frear")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {

            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);

        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomePropietario()
        {


        }

        [Fact]
        public void DadosVeiculo()
        {

            //Arrange
            veiculo.Proprietario = "João";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Branco";
            veiculo.Placa = "asd-9999";
            veiculo.Modelo = "Strada";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo:", dados);
        }

        [Fact]
        public void TesteNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            string nomeProprietario = "Ab";

            Assert.Throws<System.FormatException>(
                () => new Veiculo(nomeProprietario));
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            string placa = "ACX35DAX";

            var mensagem = Assert.Throws<System.FormatException> (
                    () =>  new Veiculo().Placa = placa
                );


            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose Invocado");
        }
    }
}
