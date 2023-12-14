using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    [Serializable]
    public class CategoriaController
    {
        #region Attributes

        private List<Categoria> categorias = new List<Categoria>();

        #endregion

        #region Methods

        /// <summary>
        /// Método para encontrar uma categoria através do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Categoria EncontrarCategoriaPorId(int id)
        {
            return categorias.Find(c => c.IdCategoria == id);
        }

        /// <summary>
        /// Método para adicionar uma nova categoria
        /// </summary>
        /// <param name="novaCategoria"></param>
        /// <returns></returns>
        public bool AdicionarCategoriaController(Categoria novaCategoria)
        {
            if (categorias.Any(c => c.IdCategoria == novaCategoria.IdCategoria))
            {
                return false;
            }

            if (categorias.Any(c => c.Nome.Equals(novaCategoria.Nome, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            categorias.Add(novaCategoria);
            return true;
        }

        /// <summary>
        /// Método para listar as categorias existentes
        /// </summary>
        /// <returns></returns>
        public List<Categoria> ListarCategoriasController()
        {
            return categorias;
        }

        /// <summary>
        /// Método para atualizar uma categoria
        /// </summary>
        /// <param name="categoriaAtualizada"></param>
        /// <returns></returns>
        public bool AtualizarCategoriaController(Categoria categoriaAtualizada)
        {
            Categoria categoriaExistente = EncontrarCategoriaPorId(categoriaAtualizada.IdCategoria);

            if (categoriaExistente != null)
            {
                if (categorias.Any(c => c.IdCategoria != categoriaAtualizada.IdCategoria && c.Nome.Equals(categoriaAtualizada.Nome, StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }
                categoriaExistente.Nome = categoriaAtualizada.Nome;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Método para remover uma categoria
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoverCategoriaController(int id)
        {
            Categoria categoriaExistente = EncontrarCategoriaPorId(id);

            if (categoriaExistente != null)
            {
                categorias.Remove(categoriaExistente);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método para guardar as categorias num ficheiro binário
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool GuardarCategoriasBin(string fileName)
        {
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, categorias);
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
        /// Método para carregar as categorias a partir de um ficheiro binário
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool CarregarCategoriasBin(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    categorias = (List<Categoria>)bin.Deserialize(stream);
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
        /// Método para guardar as categorias num ficheiro JSON
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool GuardarCategoriasJSON(string fileName)
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
                    foreach (var categoria in categorias)
                    {
                        string json = JsonSerializer.Serialize(categoria, options);
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
