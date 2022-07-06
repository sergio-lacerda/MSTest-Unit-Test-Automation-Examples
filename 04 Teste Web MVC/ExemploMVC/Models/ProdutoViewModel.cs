using System.Collections.Generic;

namespace ExemploMVC.Models
{
    /*
     *  This class provides a simulation of product list
     */
    public class ProdutoViewModel
    {
        public IEnumerable<ProdutoEntity> listarProdutos()
        {
            List<ProdutoEntity> lista = new List<ProdutoEntity>();

            lista.Add(new ProdutoEntity { Id = 1, Nome = "Camisa Social Azul", Preco = 185.0f });
            lista.Add(new ProdutoEntity { Id = 2, Nome = "Sapato Preto", Preco = 250.0f });
            lista.Add(new ProdutoEntity { Id = 3, Nome = "Sapato Marrom", Preco = 250.0f });
            lista.Add(new ProdutoEntity { Id = 4, Nome = "Camisa Social Branca", Preco = 170.0f });
            lista.Add(new ProdutoEntity { Id = 5, Nome = "Gravata", Preco = 85.0f });

            return lista;
        }
    }
}
