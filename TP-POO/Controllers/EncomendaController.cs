using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TP_POO.Models;

namespace TP_POO.Controllers
{
    public class EncomendaController
    {
        #region Attributes

        private List<Encomenda> encomendas = new List<Encomenda>();

        #endregion

        #region Methods

        public Encomenda FindEncomendaById(int id)
        {
            return encomendas.Find(e => e.IdEncomenda == id);
        }

        public bool AdicionarEncomendaController(Encomenda novaEncomenda)
        {
            if (encomendas.Any(e => e.IdEncomenda == novaEncomenda.IdEncomenda))
            {
                return false;
            }
            encomendas.Add(novaEncomenda);
            return true;
        }

        public List<Encomenda> ListarEncomendasController()
        {
            return encomendas;
        }

        public bool RemoverEncomendaController(int id)
        {
            Encomenda encomendaExistente = FindEncomendaById(id);

            if(encomendaExistente != null)
            {
                encomendas.Remove(encomendaExistente);
                return true;
            }
            return false;
        }

        public bool SalvaEncomendasBin(string fileName)
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

        public bool CarregaEncomendasBin(string fileName)
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
