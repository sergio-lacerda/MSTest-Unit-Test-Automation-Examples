using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketShare.Tests
{
    [TestClass()]
    public class CalculoUnitTests
    {
        private Calculo _calculo;

        [TestInitialize]
        public void Inicializar()
        {
            _calculo = new Calculo();
        }

        /*
            Testing for normal conditions. 

            + pVendas: Total sales of the company
            + pTotal: Total sales of all players together
            + esperado: expected value
        */
        [TestMethod()]
        [DataRow(2645369.95f, 15445878.25f, 17.13f)]
        [DataRow(3002847.01f, 17999174.87f, 16.68f)]
        public void recebeValores_DeveCalcularMarketShare(float pVendas, float pTotal, float esperado)
        {
            //Act - Executing the test
            float obtido = _calculo.calculaMarketShare(pVendas, pTotal);

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido, 2);
        }

        /*
            Testing for division by zero. In this case, an exception is expected. 

            + pVendas: Total sales of the company
            + pTotal: Total sales of all players together
            + esperado: expected value
        */
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException), "Divisão por zero!")]
        [DataRow(3002847.01f, 0.00f)]
        [DataRow(0.00f, 0.00f)]
        public void recebeValores_DeveGerarDivZeroException(float pVendas, float pTotal)
        {
            //Act - Executing the test
            float obtido = _calculo.calculaMarketShare(pVendas, pTotal);
        }

        /*
            Testing for incoherent parameters such as negative sales, or company sales
            higher than all players sales togheter, etc. In this case, an exception 
            is also expected. 

            + pVendas: Total sales of the company
            + pTotal: Total sales of all players together
            + esperado: expected value
        */
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Parâmetros inválidos!")]
        [DataRow(-12500.00f, 25000.12f)]
        [DataRow(12500.00f, -25000.12f)]
        [DataRow(-12500.00f, -25000.12f)]
        [DataRow(50000.00f, 25000.12f)]        
        public void recebeValores_DeveGerarArgumentException(float pVendas, float pTotal)
        {
            //Act - Executing the test
            float obtido = _calculo.calculaMarketShare(pVendas, pTotal);
        }
    }
}