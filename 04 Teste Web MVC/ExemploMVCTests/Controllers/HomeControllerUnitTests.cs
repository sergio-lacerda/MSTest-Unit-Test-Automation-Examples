using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExemploMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ExemploMVC.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerUnitTests
    {
        // Initializing an instance of HomeController
        private HomeController? _controller;

        [TestInitialize]
        public void Inicializar()
        {
            _controller = new HomeController(new NullLogger<HomeController>());
        }

        //************** Testing if actions are returning any view ***************

        [TestMethod()]
        public void actionIndex_DeveRetornarUmaView()
        {
            //Act - Executing the test
            var resultado = _controller?.Index() as ViewResult;

            //Assert - Comparing expected and obtained values
            Assert.IsNotNull(resultado);
        }

        [TestMethod()]
        public void actionSobre_DeveRetornarUmaView()
        {
            //Act - Executing the test
            var resultado = _controller?.Sobre() as ViewResult;

            //Assert - Comparing expected and obtained values
            Assert.IsNotNull(resultado);
        }

        [TestMethod()]
        public void actionProdutos_DeveRetornarUmaView()
        {
            //Act - Executing the test
            var resultado = _controller?.Produtos() as ViewResult;

            //Assert - Comparing expected and obtained values
            Assert.IsNotNull(resultado);
        }

        //********** Testing if actions are returning the correct view ***********

        [TestMethod()]
        public void actionIndex_DeveRetornarViewIndex()
        {
            //Arrange - Preparing test conditions
            string esperado = "Index";

            //Act - Executing the test
            var resultado = _controller?.Index() as ViewResult;

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, resultado?.ViewName);
        }

        [TestMethod()]
        public void actionSobre_DeveRetornarUmaViewSobre()
        {
            //Arrange - Preparing test conditions
            string esperado = "Sobre";

            //Act - Executing the test
            var resultado = _controller?.Sobre() as ViewResult;

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, resultado?.ViewName);
        }

        [TestMethod()]
        public void actionProdutos_DeveRetornarUmaViewProdutos()
        {
            //Arrange - Preparing test conditions
            string esperado = "Produtos";

            //Act - Executing the test
            var resultado = _controller?.Produtos() as ViewResult;

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, resultado?.ViewName);
        }

    }
}