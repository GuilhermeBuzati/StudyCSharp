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
