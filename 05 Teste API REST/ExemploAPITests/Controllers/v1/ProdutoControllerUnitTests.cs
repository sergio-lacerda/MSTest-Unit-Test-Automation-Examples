using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExemploAPI.Controllers.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using ExemploAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExemploAPI.Controllers.v1.Tests
{
    [TestClass()]
    public class ProdutoControllerUnitTests
    {
        // Initializing an instance of ProdutoController
        private ProdutoController _controller;
        private ProdutoViewModel _produtos;

        [TestInitialize]
        public void Inicializar()
        {
            _controller = new ProdutoController(new NullLogger<ProdutoController>());
            _produtos = new ProdutoViewModel();
        }

        // Testing the endpoint for quantity of result items (products)
        [TestMethod()]
        public async Task reqGet_DeveRetornarQuantidadeProdutos()
        {
            //Arrange - Preparing test conditions
            int esperado = _produtos.listarProdutos().Count();

            //Act - Executing the test
            var resultado = await _controller.listarProdutos();
            var objectResult = resultado.Result as OkObjectResult;
            var obtido = objectResult?.Value as List<ProdutoEntity>;

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido?.Count);
        }

        // Testing the endpoint for result data type
        [TestMethod()]
        public async Task reqGet_DeveRetornarTipoDados()
        {
            //Arrange - Preparing test conditions
            var esperado = typeof(List<ProdutoEntity>);

            //Act - Executing the test
            var resultado = await _controller.listarProdutos();
            var objectResult = resultado.Result as OkObjectResult;
            var obtido = objectResult?.Value;

            //Assert - Comparing expected and obtained values
            Assert.AreEqual(esperado, obtido?.GetType());
        }

        // Testing the endpoint for the content (product list) - Testing the Ids only
        [TestMethod()]
        public async Task reqGet_DeveRetornarListaDeProdutos()
        {
            //Arrange - Preparing test conditions
            var esperado = _produtos.listarProdutos().ToList();            

            //Act - Executing the test
            var resultado = await _controller.listarProdutos();
            var objectResult = resultado.Result as OkObjectResult;
            var obtido = objectResult?.Value as List<ProdutoEntity>;

            //Assert - Comparing expected and obtained values
            var idsEsperados = (from e in esperado select e.Id).ToList(); //expected Ids
            var idsObtidos = (from o in obtido select o.Id).ToList();     //obtained Ids

            //checking differences between expected and obtained Ids
            var diferencaEspObt = idsEsperados.Except(idsObtidos).ToList();
            var diferencaObtEsp = idsObtidos.Except(idsEsperados).ToList();

            //If expected == obtained, there are no differences and both lists above are empty
            bool iguais = (diferencaEspObt.Count() == 0) && (diferencaObtEsp.Count() == 0);

            //Expected and Obtained are equal
            Assert.IsTrue(iguais);
        }
    }
}