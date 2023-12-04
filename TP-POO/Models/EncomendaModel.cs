using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TP_POO.Models
{
    [Serializable]
    public class Encomenda
    {
        #region Attributes

        private static int totalEncomendas = 0;
        private int idEncomenda;
        public Cliente cliente;
        public Colaborador colaborador;
        private List<Produto> produtos = new List<Produto>();
        private List<int> quantidades = new List<int>();
        private DateTime data;
        private double total;

        #endregion

        #region Methods

        #region Constructor

        static Encomenda()
        {
            CarregarTotalEncomendas();
        }

        public Encomenda(Cliente cli, Colaborador col)
        {
            totalEncomendas++;
            idEncomenda = totalEncomendas;
            cliente = cli;
            colaborador = col;
            data = DateTime.Now;
            total = 0;
            SalvarTotalEncomendas();
        }

        #endregion

        #region Properties

        public int IdEncomenda
        {
            get { return idEncomenda; }
            set { idEncomenda = value; }
        }

        public DateTime Data
        {
            get { return data;}
        }
        public List<Produto> Produtos
        {
            get { return produtos; }
        }

        public List<int> Quantidades
        {
            get { return quantidades; }
        }

        public int TotalEncomendas
        {
            get { return totalEncomendas; }
        }

        public double Total
        {
            get { return total; }
        }

        #endregion

        #region Other Methods

        public bool AdicionarProdutoQuantidade(Produto produto, int quantidade)
        {
            if (quantidade > 0 && quantidade <= produto.Stock)
            {
                produtos.Add(produto);
                quantidades.Add(quantidade);
                produto.Stock -= quantidade;
                total += produto.Preco * quantidade;
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool SalvarTotalEncomendas()
        {
            File.WriteAllText("totalEncomendas.txt", totalEncomendas.ToString());
            return true;
        }

        private static bool CarregarTotalEncomendas()
        {
            if (File.Exists("totalEncomendas.txt"))
            {
                if (int.TryParse(File.ReadAllText("totalEncomendas.txt"), out int enc))
                {
                    totalEncomendas = enc;
                    return true;
                }
                return false;
            }
            return false;
        }

        #endregion

        #region Destructor

        ~Encomenda()
        {
        }

        #endregion

        #endregion
    }
}
