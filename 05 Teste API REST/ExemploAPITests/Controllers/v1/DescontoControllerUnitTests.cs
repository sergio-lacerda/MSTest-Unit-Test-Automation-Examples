using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExemploAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ExemploAPI.Controllers.Tests
{
    [TestClass()]
    public class DescontoControllerUnitTests
    {
        // Initializing an instance of HomeController
        private DescontoController _controller;

        [TestInitialize]
        public void Inicializar()
        {
            _controller = new DescontoController(new NullLogger<DescontoController>());
        }

        /*
         *  Testing for API status information. If everything is Ok, it´s expected
         *  to receive a "Running and available" message.
         */
        [TestMethod()]
        public async Task status_DeveRetornarStatusAPI()
        {
            //Arrange - Preparing test conditions
            var esperado = "API em execução e disponível!";  //Running and available

            //Act - Executing the test
            var resultado = await _controller.statusApi();
            var objectResult = resultado.Result as OkObjectResult;
            var obtido = objectResult?.Value;

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido);
        }

        /*
         *  Testing for order percentage discount. 
         *      + Parameter: valor (order total value)
         *      + Parameter: esperado (expected value)
         */ 
        [TestMethod()]
        [DataRow( 150.00f, 0.00f)]
        [DataRow( 500.00f, 0.00f)]
        [DataRow( 550.01f, 0.01f)]
        [DataRow( 550.00f, 0.01f)]
        [DataRow(1000.00f, 0.01f)]
        [DataRow(1000.01f, 0.03f)]
        [DataRow(1500.00f, 0.03f)]
        public async Task valor_DeveRetornarPercentualDesconto(float valor, float esperado)
        {            
            //Act - Executing the test
            var resultado = await _controller.percentualDesconto(valor);
            var objectResult = resultado.Result as OkObjectResult;
            var obtido = objectResult?.Value;

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido);
        }

        /*
         *  Testing for discount value. 
         *      + Parameter: valor (order total value)
         *      + Parameter: esperado (expected value)
         */
        [TestMethod()]
        [DataRow( 150.00f,  0.00f)]
        [DataRow( 500.00f,  0.00f)]
        [DataRow( 550.01f,  5.50f)]
        [DataRow( 550.00f,  5.50f)]
        [DataRow(1000.00f, 10.00f)]
        [DataRow(1000.01f, 30.00f)]
        [DataRow(1500.00f, 45.00f)]
        [DataRow(1731.73f, 51.95f)]
        public async Task valor_DeveRetornarValorDesconto(float valor, float esperado)
        {
            //Act - Executing the test
            var resultado = await _controller.valorDesconto(valor);
            var objectResult = resultado.Result as OkObjectResult;
            var obtido = (float)objectResult?.Value;

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido, 2);
        }

        /*
         *  Testing for order net value. 
         *      + Parameter: valor (order total value)
         *      + Parameter: esperado (expected value)
         */
        [TestMethod()]
        [DataRow(150.00f,   150.00f)]
        [DataRow(500.00f,   500.00f)]
        [DataRow(550.01f,   544.51f)]
        [DataRow(550.00f,   544.50f)]
        [DataRow(1000.00f,  990.00f)]
        [DataRow(1000.01f,  970.01f)]
        [DataRow(1500.00f, 1455.00f)]
        [DataRow(1731.73f, 1679.78f)]
        public async Task valor_DeveRetornarValorFinal(float valor, float esperado)
        {
            //Act - Executing the test
            var resultado = await _controller.totalComDesconto(valor);
            var objectResult = resultado.Result as OkObjectResult;
            var obtido = objectResult?.Value;

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, (float)obtido, 2);
        }
    }
}