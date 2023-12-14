/*
 * @file ProdutoController.cs
 * @author Marcos Vasconcelos (a18568@alunos.ipca.pt)
 * @author Diogo Oliveira (a20468@alunos.ipca.pt)
 * @brief
 * @date dezembro 2023
 * 
 * @copyright Copyright (c) 2023
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Text.Json;

namespace Controllers
{
    [Serializable]
    public class ProdutoController
    {
        #region Attributes

        private List<Produto> produtos = new List<Produto>();

        #endregion

        #region Methods

        /// <summary>
        /// Método para encontrar um produto através do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Produto EncontraProdutoPorId(int id)
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
            Produto produtoExistente = EncontraProdutoPorId(produtoAtualizado.IdProduto);

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
            Produto produtoExistente = EncontraProdutoPorId(id);

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
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Método para guardar os produtos num ficheiro JSON
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool GuardarProdutosJSON(string fileName)
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions //Cria o objeto JsonSerializerOptions para configurar o processo de serealizaçao em json
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, //Permite uso de caracteres especiais
                    WriteIndented = true //Permite a formataçao com quebras de linha para ficar mais facilmente legivel
                };

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var produto in produtos)
                    {
                        string json = JsonSerializer.Serialize(produto, options);
                        writer.WriteLine(json);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return false;
            }
        }

        #endregion
    }
}