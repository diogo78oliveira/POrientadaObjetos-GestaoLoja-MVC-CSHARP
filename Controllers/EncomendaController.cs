using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class EncomendaController
    {
        #region Attributes

        private List<Encomenda> encomendas = new List<Encomenda>();

        #endregion

        #region Methods

        /// <summary>
        /// Método para encontrar uma encomenda através do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Encomenda EncontraEncomendaPorId(int id)
        {
            return encomendas.Find(e => e.IdEncomenda == id);
        }

        /// <summary>
        /// Método para adicionar uma nova encomenda
        /// </summary>
        /// <param name="novaEncomenda"></param>
        /// <returns></returns>
        public bool AdicionarEncomendaController(Encomenda novaEncomenda)
        {
            if (encomendas.Any(e => e.IdEncomenda == novaEncomenda.IdEncomenda))
            {
                return false;
            }

            if (novaEncomenda.Produtos.Count <= 0)
            {
                return false;
            }
            encomendas.Add(novaEncomenda);
            return true;
        }

        /// <summary>
        /// Método para listar as encomendas existentes
        /// </summary>
        /// <returns></returns>
        public List<Encomenda> ListarEncomendasController()
        {
            return encomendas;
        }

        /// <summary>
        /// Método para remover uma encomenda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoverEncomendaController(int id)
        {
            Encomenda encomendaExistente = EncontraEncomendaPorId(id);

            if (encomendaExistente != null)
            {
                encomendas.Remove(encomendaExistente);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método para guardar as encomendas num ficheiro binário
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool GuardarEncomendasBin(string fileName)
        {
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, encomendas);
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
        /// Método para carregar as encomendas a partir de um ficheiro binário
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool CarregarEncomendasBin(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    encomendas = (List<Encomenda>)bin.Deserialize(stream);
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
        #endregion
    }
}
