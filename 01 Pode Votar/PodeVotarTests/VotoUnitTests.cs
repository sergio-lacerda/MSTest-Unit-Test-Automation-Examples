using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodeVotar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodeVotar.Tests
{
    /*
        This first example uses the simplest way to create the
        tests, not implementing parameters (single conditions tests).
        In this case, we are not testing yet for invalid age parameters.
    */
    [TestClass()]
    public class VotoUnitTests
    {
        //Age = 11 --> Expected: Cannot vote ("Não pode votar!")
        [TestMethod()]
        public void Idade11_NaoDevePoderVotar()
        {
            //Arrange - Preparing test conditions
            Voto voto = new Voto();
            int idade = 11;
            string esperado = "Não pode votar!";

            //Act - Executing the test
            string obtido = voto.podeVotar(idade);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido);
        }

        //Age = 15 --> Expected: Cannot vote ("Não pode votar!")
        [TestMethod()]
        public void Idade15_NaoDevePoderVotar()
        {
            //Arrange - Preparing test conditions
            Voto voto = new Voto();
            int idade = 15;
            string esperado = "Não pode votar!";

            //Act - Executing the test
            string obtido = voto.podeVotar(idade);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido);
        }

        //Age = 16 --> Expected: Optional ("Voto opcional!")
        [TestMethod()]
        public void Idade16_DeveSerOpcional()
        {
            //Arrange - Preparing test conditions
            Voto voto = new Voto();
            int idade = 16;
            string esperado = "Voto opcional!";

            //Act - Executing the test
            string obtido = voto.podeVotar(idade);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido);
        }

        //Age = 17 --> Expected: Optional ("Voto opcional!")
        [TestMethod()]
        public void Idade17_DeveSerOpcional()
        {
            //Arrange - Preparing test conditions
            Voto voto = new Voto();
            int idade = 17;
            string esperado = "Voto opcional!";

            //Act - Executing the test
            string obtido = voto.podeVotar(idade);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido);
        }

        //Age = 18 --> Expected: Can vote ("Pode votar!")
        [TestMethod()]
        public void Idade18_DevePoderVotar()
        {
            //Arrange - Preparing test conditions
            Voto voto = new Voto();
            int idade = 18;
            string esperado = "Pode votar!";

            //Act - Executing the test
            string obtido = voto.podeVotar(idade);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido);
        }

        //Age = 21 --> Expected: Can vote ("Pode votar!")
        [TestMethod()]
        public void Idade21_DevePoderVotar()
        {
            //Arrange - Preparing test conditions
            Voto voto = new Voto();
            int idade = 21;
            string esperado = "Pode votar!";

            //Act - Executing the test
            string obtido = voto.podeVotar(idade);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido);
        }

        //Age = 69 --> Expected: Can vote ("Pode votar!")
        [TestMethod()]
        public void Idade69_DevePoderVotar()
        {
            //Arrange - Preparing test conditions
            Voto voto = new Voto();
            int idade = 69;
            string esperado = "Pode votar!";

            //Act - Executing the test
            string obtido = voto.podeVotar(idade);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido);
        }

        //Age = 70 --> Expected: Optional ("Voto opcional!")
        [TestMethod()]
        public void Idade70_DeveSerOpcional()
        {
            //Arrange - Preparing test conditions
            Voto voto = new Voto();
            int idade = 70;
            string esperado = "Voto opcional!";

            //Act - Executing the test
            string obtido = voto.podeVotar(idade);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido);
        }

        //Age = 85 --> Expected: Optional ("Voto opcional!")
        [TestMethod()]
        public void Idade85_DeveSerOpcional()
        {
            //Arrange - Preparing test conditions
            Voto voto = new Voto();
            int idade = 85;
            string esperado = "Voto opcional!";

            //Act - Executing the test
            string obtido = voto.podeVotar(idade);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido);
        }

    }
}