using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TP_POO.Models;

namespace TP_POO.Controllers
{
    [Serializable]
    public class ProdutoController
    {
        #region Attributes

        private List<Produto> produtos = new List<Produto>();

        #endregion

        #region Methods

        /// <summary>
        /// Método para encontrar um produto através do seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Produto findProdutoById(int id)
        {
            return produtos.Find(p => p.IdProduto == id);
        }

        /// <summary>
        /// Método para adicionar um novo produto
        /// </summary>
        /// <param name="novoProduto"></param>
        /// <returns></returns>
        public bool AdicionarProdutoController(Produto novoProduto)
        {
            if (produtos.Any(p => p.IdProduto == novoProduto.IdProduto))
            {
                return false;
            }

            if (produtos.Any(p => p.Nome.Equals(novoProduto.Nome, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            produtos.Add(novoProduto);
            return true;
        }

        /// <summary>
        /// Método para listar os produtos existentes
        /// </summary>
        /// <returns></returns>
        public List<Produto> ListarProdutosController()
        {
            return produtos;
        }

        /// <summary>
        /// Método para atualizar um produto
        /// </summary>
        /// <param name="produtoAtualizado"></param>
        /// <returns></returns>
        public bool AtualizarProdutoController(Produto produtoAtualizado)
        {
            Produto produtoExistente = findProdutoById(produtoAtualizado.IdProduto);

            if (produtoExistente != null)
            {
                if (produtos.Any(p => p.IdProduto != produtoAtualizado.IdProduto && p.Nome.Equals(produtoAtualizado.Nome, StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }

                produtoExistente.Nome = produtoAtualizado.Nome;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método para remover um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoverProdutoController(int id)
        {
            Produto produtoExistente = findProdutoById(id);

            if (produtoExistente != null)
            {
                produtos.Remove(produtoExistente);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método para guardar os produtos num ficheiro binário
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool GuardarProdutosBin(string fileName)
        {
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, produtos);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Método para carregar os produtos a partir de um ficheiro binário
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool CarregarProdutosBin(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    produtos = (List<Produto>)bin.Deserialize(stream);
                    stream.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        #endregion
    }
}