using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TP_POO.Models;
using System.Text.Json;

namespace TP_POO.Controllers
{
    [Serializable]
    public class ClienteController
    {
        #region Attributes

        private List<Cliente> clientes = new List<Cliente>();

        #endregion

        #region Methods

        /// <summary>
        /// Método para encontrar um cliente através do seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cliente findClienteById(int id)
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
            if(clientes.Any(c => c.IdCliente == novoCliente.IdCliente))
            {
                return false;
            }
            
            if(clientes.Any(c => c.Nome.Equals(novoCliente.Nome, StringComparison.OrdinalIgnoreCase)))
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
            Cliente clienteExistente = findClienteById(clienteAtualizado.IdCliente);

            if(clienteExistente != null)
            {
                if(clientes.Any(c => c.IdCliente != clienteAtualizado.IdCliente && c.Nome.Equals(clienteAtualizado.Nome, StringComparison.OrdinalIgnoreCase)))
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
            Cliente clienteExistente = findClienteById(id);

            if(clienteExistente != null)
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
                using(Stream stream = File.Open(fileName, FileMode.Create))
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
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public bool GuardarClientesJSON(string fileName)
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
