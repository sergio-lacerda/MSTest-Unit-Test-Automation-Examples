using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExemploAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAPI.Util.Tests
{
    [TestClass()]
    public class DescontoUnitTests
    {
        private Desconto _desconto;

        [TestInitialize]
        public void Inicializar()
        {
            _desconto = new Desconto();
        }

        //************** Testing for normal conditions **************

        // Testing for order percentage discount
        [TestMethod()]
        [DataRow( 321.32f, 0.00f)]        
        [DataRow( 500.00f, 0.00f)]
        [DataRow( 500.01f, 0.01f)]
        [DataRow(1000.00f, 0.01f)]
        [DataRow(1000.01f, 0.03f)]
        [DataRow(2305.42f, 0.03f)]
        public void recebeValor_DeveCalcularPercentualDesconto(float valor, float esperado)
        {
            //Act - Executing the test
            float obtido = _desconto.percentualDesconto(valor);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido);
        }

        // Testing for order discount value
        [TestMethod()]
        [DataRow( 321.32f,  0.00f)]
        [DataRow( 500.00f,  0.00f)]
        [DataRow( 500.01f,  5.00f)]
        [DataRow(1000.00f, 10.00f)]
        [DataRow(1000.01f, 30.00f)]
        [DataRow(2305.42f, 69.16f)]
        public void recebeValor_DeveCalcularValorDesconto(float valor, float esperado)
        {
            //Act - Executing the test
            float obtido = _desconto.valorDesconto(valor);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido, 2);
        }

        // Testing for order net value
        [TestMethod()]
        [DataRow(321.32f,   321.32f)]
        [DataRow(500.00f,   500.00f)]
        [DataRow(500.01f,   495.01f)]
        [DataRow(1000.00f,  990.00f)]
        [DataRow(1000.01f,  970.01f)]
        [DataRow(2305.42f, 2236.26f)]
        public void recebeValor_DeveCalcularValorFinal(float valor, float esperado)
        {
            //Act - Executing the test
            float obtido = _desconto.valorFinalComDesconto(valor);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido, 2);
        }

        //***************** Testing for Exceptions ******************
                
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Parâmetro inválido!")]
        [DataRow(-321.32f)]
        [DataRow(-500.00f)]
        public void recebeValor_DeveRetornarExceptionPercentual(float valor)
        {
            //Act - Executing the test
            float obtido = _desconto.percentualDesconto(valor);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Parâmetro inválido!")]
        [DataRow(-321.32f)]
        [DataRow(-500.00f)]
        public void recebeValor_DeveRetornarExceptionValor(float valor)
        {
            //Act - Executing the test
            float obtido = _desconto.valorDesconto(valor);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Parâmetro inválido!")]
        [DataRow(-321.32f)]
        [DataRow(-500.00f)]
        public void recebeValor_DeveRetornarExceptionValorFinal(float valor)
        {
            //Act - Executing the test
            float obtido = _desconto.valorFinalComDesconto(valor);
        }

    }
}