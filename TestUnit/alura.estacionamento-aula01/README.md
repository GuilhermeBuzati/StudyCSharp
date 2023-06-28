<h2> Test Unit </h2>
<hr>

- <p> In project, add a new project as xUnit Test Project </p>
	
    ![Alt text](image-1.png)

    ![Alt text](image-2.png)

    ![Alt text](image-3.png)


- <p> Project test added </p>

    ![Alt text](image-4.png)


- <p> Now, you must add a reference in xUnit Test Project </p>

    ![Alt text](image-5.png)

    ![Alt text](image-6.png)


- <p> Testing method "Acelerar" from class "Veiculo" </p>

    Class "Veiculo" in Project
    
        public void Acelerar(int tempoSeg)
        {
            this.VelocidadeAtual += (tempoSeg * 10);
        }

    Class "VeiculoTestes" in xUnit Test

        public class VeiculoTestes
        {
            [Fact]
            public void TestaVeiculoAcelerar()
            {

                var veiculo = new Veiculo();
                veiculo.Acelerar(10);

                //Expected value 100 for the method and variable
                Assert.Equal(100, veiculo.VelocidadeAtual);
            }
        }


- <p> To test the function </p>

    ![Alt text](image-7.png)

    ![Alt text](image-8.png)


- <p> Results </p>

    ![Alt text](image-9.png)

    ![Alt text](image-10.png)


- <p> Repeting test for method "Frear </p>

    Class "Veiculo"
        
        public void Frear(int tempoSeg)
        {
            this.VelocidadeAtual -= (tempoSeg * 15);
        }
        
    Class "VeiculoTestar" in xUnit Test Project

        [Fact]
        public void TestaVeiculoFrear()
        {

            var veiculo = new Veiculo();
            veiculo.Frear(10);

            //Expected value -150
            Assert.Equal(-150, veiculo.VelocidadeAtual);

        }

    
    ![Alt text](image-11.png)


- <p> Now, testing the method "TotalFaturado", class "Patio".

        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
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


<h2> Pattern AAA </h2>
<hr>

- <p> <b>Arrange</b>: Preparing environment </p>

- <p> <b>Act</b>: What will be tested </p>

- <p> <b>Assert</b>: Results from the tests </p>


        [Fact]
        public void TestaVeiculoAcelerar()
        {
            //Pattern AAA
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);

        }


<h2> Annotations xUnix </h2>
<hr>

- <p> Annotation [Fact], test simple </p>
  
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            //Pattern AAA
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);

        }


- <p> Annotation [Theory], you may test with any values </p>

        [Theory]
        [InlineData ("João Silva", "ASD-1498", "preto", "Strada")]
        [InlineData("Joana Soares", "ESD-8752", "branco", "Gol")]
        [InlineData("Maria Branco", "CXZ-3654", "branco", "Jeep")]
        [InlineData("Antonio James", "QWE-5465", "vermelho", "Uno")]
        public void ValidaFaturamentoComVariosVeiculos(string propietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
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