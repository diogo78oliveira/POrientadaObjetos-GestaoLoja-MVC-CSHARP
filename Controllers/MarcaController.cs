/*
 * @file MarcaController.cs
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
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;
using System.Text.Json;

namespace Controllers
{
    [Serializable]
    public class MarcaController
    {
        #region Attributes

        private List<Marca> marcas = new List<Marca>();

        #endregion

        #region Methods

        /// <summary>
        /// Método para encontrar uma marca através do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Marca EncontraMarcaPorId(int id)
        {
            return marcas.Find(m => m.IdMarca == id);
        }

        /// <summary>
        /// Método para adicionar uma nova marca
        /// </summary>
        /// <param name="novaMarca"></param>
        /// <returns></returns>
        public bool AdicionarMarcaController(Marca novaMarca)
        {
            if (marcas.Any(m => m.IdMarca == novaMarca.IdMarca))
            {
                return false;
            }

            if (marcas.Any(m => m.Nome.Equals(novaMarca.Nome, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            marcas.Add(novaMarca);
            return true;
        }

        /// <summary>
        /// Método para listar as marcas existentes
        /// </summary>
        /// <returns></returns>
        public List<Marca> ListarMarcasController()
        {
            return marcas;
        }

        /// <summary>
        /// Método para atualizar uma marca
        /// </summary>
        /// <param name="marcaAtualizada"></param>
        /// <returns></returns>
        public bool AtualizarMarcaController(Marca marcaAtualizada)
        {
            Marca marcaExistente = EncontraMarcaPorId(marcaAtualizada.IdMarca);

            if (marcaExistente != null)
            {
                if (marcas.Any(m => m.IdMarca != marcaAtualizada.IdMarca && m.Nome.Equals(marcaAtualizada.Nome, StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }
                marcaExistente.Nome = marcaAtualizada.Nome;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Método para remover uma marca
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoverMarcaController(int id)
        {
            Marca marcaExistente = EncontraMarcaPorId(id);

            if (marcaExistente != null)
            {
                marcas.Remove(marcaExistente);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método para guardar as marcas num ficheiro binário
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool GuardarMarcasBin(string fileName)
        {
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, marcas);
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
        /// Método para carregar as marcas a partir de um ficheiro binário
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool CarregarMarcasBin(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    marcas = (List<Marca>)bin.Deserialize(stream);
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
        /// Método para guardar as marcas num ficheiro JSON
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool GuardarMarcasJSON(string fileName)
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
                    foreach (var marca in marcas)
                    {
                        string json = JsonSerializer.Serialize(marca, options);
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
