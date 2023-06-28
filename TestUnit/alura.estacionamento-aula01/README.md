<h1 align="center" id="installEntityFramework"> CAT83 - Processamento </h1>

<h2 id="files" align="center"> <i> Sumário </i></h2>

<ol>
<li><a href="#testUnit"> Test Unit </a></li>
<li><a href="#patternAAA"> Pattern AAA </a></li>
<li><a href="#annotations"> Annotations xUnit </a></li>
<li><a href="#testCommandLine"> Test with command line </a></li>
<li><a href="#attributesAnnotarions"> Attributes from Annotations xUnit </a></li>
<li><a href="#theoryClassDats"> Theory with ClassData </a></li>
<li><a href="#exception"> Test with Exception </a></li>
</ol>

</br>
<h2 id="testUnit"> Test Unit </h2>
<hr>

- <p> In project, add a new project as xUnit Test Project </p>
	
    ![Alt text](readme_images/image-1.png)

    ![Alt text](readme_images/image-2.png)

    ![Alt text](readme_images/image-3.png)


- <p> Project test added </p>

    ![Alt text](readme_images/image-4.png)


- <p> Now, you must add a reference in xUnit Test Project </p>

    ![Alt text](readme_images/image-5.png)

    ![Alt text](readme_images/image-6.png)


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

    ![Alt text](readme_images/image-7.png)

    ![Alt text](readme_images/image-8.png)


- <p> Results </p>

    ![Alt text](readme_images/image-9.png)

    ![Alt text](readme_images/image-10.png)


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

    
    ![Alt text](readme_images/image-11.png)


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


- <p> Method Contains, verify if param is in variable </p>

        [Fact]
        public void DadosVeiculo()
        {

            //Arrange
            var veiculo = new Veiculo();
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


</br>
<h2 id="patternAAA"> Pattern AAA </h2>
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


</br>
<h2 id="annotations"> Annotations xUnix </h2>
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


</br>
<h2 id="testCommandLine"> Test with command line </h2>
<hr>

- <p> In "Package Manager Console", type:

        dotnet test

- <p> Return </p>

    ![Alt text](readme_images/image-12.png)


</br>
<h2 id="attributesAnnotarions"> Attributes from Annotations xUnit </h2>
<hr>

- <p> <b> Attribute "Skip" </b>: The test will be skipped </p>

        [Fact(Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomePropietario()
        { }

- <p> <b> Attribute "DisplayName" </b>: The test will be renamed </p>


        [Fact(DisplayName = "Teste de frear")]
        public void TestaVeiculoFrear()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        
        
    ![Alt text](readme_images/image-13.png)
    
- <p> <b> Attribute "Trait" </b>: To organize the tests </p>

        [Fact]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            var veiculo = new Veiculo();
            veiculo.Acelerar(10);
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste de frear")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

    ![Alt text](readme_images/image-14.png)


</br>
<h2 id="theoryClassDats"> Theory with ClassData </h2>
<hr>

- <p> 1º </p>
  
        public class Veiculo:IEnumerable<object[]>

- <p> 2º </p>

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Veiculo
                {
                    Proprietario = "André Silva",
                    Placa = "ASD-9999",
                    Cor="Verde",
                    Modelo="Fusca"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

- <p> 3º </p>

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }


</br>
<h2 id="exception"> Test with Exception </h2>
<hr>

- <p> Testing exception from class "Veiculo" </p>

    //Class "VeiculoTeste"

        [Fact]
        public void TesteNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            string nomeProprietario = "Ab";

            Assert.Throws<System.FormatException>(
                () => new Veiculo(nomeProprietario));
        }


    //Class "Proprietario"

        public string Proprietario
        {
            get
            {
                return _proprietario;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new System.FormatException(" Nome de proprietário deve ter no mínimo 3 caracteres.");
                }
                _proprietario = value;
            }

        }
    
- <p> Will return FormatException, as defined in the class </p>

    ![Alt text](readme_images/image-15.png)