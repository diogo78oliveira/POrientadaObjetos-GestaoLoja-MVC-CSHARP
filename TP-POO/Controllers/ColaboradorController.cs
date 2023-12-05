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
    public class ColaboradorController
    {
        #region Attributes

        private List<Colaborador> colaboradores = new List<Colaborador>();

        #endregion

        #region Methods

        /// <summary>
        /// Método para encontrar um colaborador através do seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Colaborador findColaboradorById(int id)
        {
            return colaboradores.Find(c => c.IdColaborador == id);
        }

        /// <summary>
        /// Método para adicionar um novo colaborador
        /// </summary>
        /// <param name="novoColaborador"></param>
        /// <returns></returns>
        public bool AdicionarColaboradorController(Colaborador novoColaborador)
        {
            if(colaboradores.Any(c => c.IdColaborador == novoColaborador.IdColaborador))
            {
                return false;
            }

            if(colaboradores.Any(c => c.Nome.Equals(novoColaborador.Nome, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            colaboradores.Add(novoColaborador);
            return true;
        }

        /// <summary>
        /// Método para atualizar um colaborador
        /// </summary>
        /// <param name="colaboradorAtualizado"></param>
        /// <returns></returns>
        public bool AtualizarColaboradorController(Colaborador colaboradorAtualizado)
        {
            Colaborador colaboradorExistente = findColaboradorById(colaboradorAtualizado.IdColaborador);

            if(colaboradorExistente != null)
            {
                if(colaboradores.Any(c => c.IdColaborador != colaboradorAtualizado.IdColaborador && c.Nome.Equals(colaboradorAtualizado.Nome, StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }
                colaboradorExistente.Nome = colaboradorAtualizado.Nome;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método para listar os colaboradores existentes
        /// </summary>
        /// <returns></returns>
        public List<Colaborador> ListarColaboradoresController()
        {
            return colaboradores;
        }

        /// <summary>
        /// Método para remover um colaborador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoverColaboradorController(int id)
        {
            Colaborador colaboradorExistente = findColaboradorById(id);

            if( colaboradorExistente != null )
            {
                colaboradores.Remove(colaboradorExistente);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método para guardar os colaboradores num ficheiro binário
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool GuardarColaboradoresBin(string fileName)
        {
            try
            {
                using(Stream stream = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, colaboradores);
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
        /// Método para carregar os colaboradores a partir de um ficheiro binário
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool CarregarColaboradoresBin(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    colaboradores = (List<Colaborador>)bin.Deserialize(stream);
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
        public bool GuardarColaboradoresJSON(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var colaborador in colaboradores)
                    {
                        string json = JsonSerializer.Serialize(colaborador);
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
