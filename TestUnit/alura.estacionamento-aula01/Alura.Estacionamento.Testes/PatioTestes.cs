using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes : IDisposable
    {

        private Veiculo veiculo;
        private Operador operador;
        private ITestOutputHelper saidaConsoleTeste;

        public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            saidaConsoleTeste = _saidaConsoleTeste;
            saidaConsoleTeste.WriteLine("Construtor Invocado"); 
            veiculo = new Veiculo();
            operador = new Operador();
            operador.Nome = "Guilherme";
        }



        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange

            var estacionamento = new Patio();

            estacionamento.OperadorPatio = operador;

            veiculo.Proprietario = "João";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Branco";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData ("João Silva", "ASD-1498", "preto", "Strada")]
        [InlineData("Joana Soares", "ESD-8752", "branco", "Gol")]
        [InlineData("Maria Branco", "CXZ-3654", "branco", "Jeep")]
        [InlineData("Antonio James", "QWE-5465", "vermelho", "Uno")]
        public void ValidaFaturamentoComVariosVeiculos(string propietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
            veiculo.Proprietario = propietario;
            veiculo.Cor = cor;
            veiculo.Placa = placa;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Joana Soares", "ESD-8752", "branco", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseIdTicket(string propietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
            veiculo.Proprietario = propietario;
            veiculo.Cor = cor;
            veiculo.Placa = placa;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Contains("Ticket Estacionamento", consultado.Ticket);

        }

        [Fact]
        public void AlterarDadosVeiculo()
        {            
            //Arrange
            var estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
            veiculo.Proprietario = "João";
            veiculo.Cor = "Branco";
            veiculo.Placa = "asd-9999";
            veiculo.Modelo = "Strada";
            estacionamento.RegistrarEntradaVeiculo(veiculo);


            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "João";
            veiculoAlterado.Cor = "Cinza";
            veiculoAlterado.Placa = "asd-9999";
            veiculo.Modelo = "Strada";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Asset
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose Invocado");
        }
    }
}
