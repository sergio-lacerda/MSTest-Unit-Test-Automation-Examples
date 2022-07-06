using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExemploMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploMVC.Models.Tests
{
    //Class test for discount rules
    [TestClass()]
    public class DescontoUnitTests
    {
        private Desconto _desconto;

        [TestInitialize]
        public void Inicializar()
        {
            _desconto = new Desconto();
        }

        //************** Testing for normal conditions ***************

        /*
         *  Testing for order percentage discount:
         *      * valor: order total value
         *      * esperado: expected value
         */
        [TestMethod()]
        [DataRow(210.00f, 1.5f)]
        [DataRow(200.01f, 1.5f)]
        [DataRow(200.00f, 1.0f)]
        [DataRow(120.00f, 1.0f)]
        [DataRow(100.01f, 1.0f)]
        [DataRow(100.00f, 0.0f)]
        [DataRow(85.00f, 0.0f)]
        public void recebeValor_DeveCalcularPercentualDesconto(float valor, float esperado)
        {
            //Act - Executing the test
            float obtido = _desconto.percentualDesconto(valor);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido);
        }

        /*
         *  Testing for order discount value:
         *      * valor: order total value
         *      * esperado: expected value
         */
        [TestMethod()]
        [DataRow(210.00f, 3.15f)]
        [DataRow(200.01f, 3.00f)]
        [DataRow(200.00f, 2.00f)]
        [DataRow(120.00f, 1.20f)]
        [DataRow(100.01f, 1.00f)]
        [DataRow(100.00f, 0.00f)]
        [DataRow(85.00f,  0.00f)]
        public void recebeValor_DeveCalcularValorDesconto(float valor, float esperado)
        {
            //Act - Executing the test
            float obtido = _desconto.percentualDesconto(valor);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido, 2);
        }

        /*
         *  Testing for order net value:
         *      * valor: order total value
         *      * esperado: expected value
         */
        [TestMethod()]
        [DataRow(210.00f, 206.85f)]
        [DataRow(200.01f, 197.01f)]
        [DataRow(200.00f, 198.00f)]
        [DataRow(120.00f, 118.80f)]
        [DataRow(100.01f,  99.01f)]
        [DataRow(100.00f, 100.00f)]
        [DataRow(85.00f,   85.00f)]
        public void recebeValor_DeveCalcularValorFinal(float valor, float esperado)
        {
            //Act - Executing the test
            float obtido = _desconto.valorFinal(valor);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido, 2);
        }

        //************** Testing for incoherent values ***************

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Parâmetro inválido!")]        
        [DataRow(-200.01f)]        
        [DataRow(-120.00f)]        
        [DataRow(-85.00f)]
        public void recebeValor_DeveGerarExceptionParaPercentual(float valor)
        {
            //Act - Executing the test
            float obtido = _desconto.percentualDesconto(valor);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Parâmetro inválido!")]
        [DataRow(-200.01f)]
        [DataRow(-120.00f)]
        [DataRow(-85.00f)]
        public void recebeValor_DeveGerarExceptionParaValor(float valor)
        {
            //Act - Executing the test
            float obtido = _desconto.valorDesconto(valor);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Parâmetro inválido!")]
        [DataRow(-200.01f)]
        [DataRow(-120.00f)]
        [DataRow(-85.00f)]
        public void recebeValor_DeveGerarExceptionParaTotal(float valor)
        {
            //Act - Executing the test
            float obtido = _desconto.valorFinal(valor);
        }
    }
}