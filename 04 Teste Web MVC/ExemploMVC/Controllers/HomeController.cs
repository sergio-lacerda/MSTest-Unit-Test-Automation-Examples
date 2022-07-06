using ExemploMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action for main page
        public IActionResult Index()
        {
            return View("Index");
        }

        // Action for product list 
        public IActionResult Produtos()
        {
            ProdutoViewModel produtos = new ProdutoViewModel();            
            return View("Produtos", produtos.listarProdutos());            
        }

        // Action for "about" view
        public IActionResult Sobre()
        {
            return View("Sobre");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
