/*
 * @file ClienteController.cs
 * @author Marcos Vasconcelos (a18568@alunos.ipca.pt)
 * @author Diogo Oliveira (a20468@alunos.ipca.pt)
 * @brief Classe ClienteController para gerir clientes com métodos para adicionar, listar, atualizar e remover, para além de serialização em binário e JSON
 * @date dezembro 2023
 * 
 * @copyright Copyright (c) 2023
 * 
 */

using Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Controllers
{
    [Serializable]
    public class ClienteController
    {
        #region Attributes

        private List<Cliente> clientes = new List<Cliente>();

        #endregion

        #region Methods

        /// <summary>
        /// Método para encontrar um cliente através do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cliente EncontrarClientePorId(int id)
        {
            return clientes.Find(c => c.IdCliente == id);
        }

        /// <summary>
        /// Método para adicionar um novo cliente
        /// </summary>
        /// <param name="novoCliente"></param>
        /// <returns></returns>
        public bool AdicionarClienteController(Cliente novoCliente)
        {
            if (clientes.Any(c => c.IdCliente == novoCliente.IdCliente))
            {
                return false;
            }

            if (clientes.Any(c => c.Nome.Equals(novoCliente.Nome, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            clientes.Add(novoCliente);
            return true;
        }

        /// <summary>
        /// Método para listar os clientes existentes
        /// </summary>
        /// <returns></returns>
        public List<Cliente> ListarClientesController()
        {
            return clientes;
        }

        /// <summary>
        /// Método para atualizar um cliente
        /// </summary>
        /// <param name="clienteAtualizado"></param>
        /// <returns></returns>
        public bool AtualizarClienteController(Cliente clienteAtualizado)
        {
            Cliente clienteExistente = EncontrarClientePorId(clienteAtualizado.IdCliente);

            if (clienteExistente != null)
            {
                if (clientes.Any(c => c.IdCliente != clienteAtualizado.IdCliente && c.Nome.Equals(clienteAtualizado.Nome, StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }
                clienteExistente.Nome = clienteAtualizado.Nome;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método para remover um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoverClienteController(int id)
        {
            Cliente clienteExistente = EncontrarClientePorId(id);

            if (clienteExistente != null)
            {
                clientes.Remove(clienteExistente);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método para guardar os clientes num ficheiro binário
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool GuardarClientesBin(string fileName)
        {
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, clientes);
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
        /// Método para carregar os clientes a partir de um ficheiro binário
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool CarregarClientesBin(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    clientes = (List<Cliente>)bin.Deserialize(stream);
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
        /// Método para guardar os clientes num ficheiro JSON
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool GuardarClientesJSON(string fileName)
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var cliente in clientes)
                    {
                        string json = JsonSerializer.Serialize(cliente, options);
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
