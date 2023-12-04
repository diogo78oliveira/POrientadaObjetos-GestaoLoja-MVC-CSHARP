using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TP_POO.Models
{
    [Serializable]
    public class Encomenda
    {
        #region Attributes

        private static int totalEncomendas = 1;
        private int idEncomenda;
        public Cliente cliente;
        public Colaborador colaborador;
        private List<Produto> produtos = new List<Produto>();
        private List<int> quantidades = new List<int>();
        private DateTime data;

        #endregion

        #region Methods

        #region Constructor

        public Encomenda(Cliente cli, Colaborador col)
        {
            cliente = cli;
            colaborador = col;
            idEncomenda = totalEncomendas++;
            data = DateTime.Now;
        }

        #endregion

        #region Properties

        public int IdEncomenda
        {
            get { return idEncomenda; }
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

        #endregion

        #region Other Methods

        public bool AdicionarProdutoQuantidade(Produto produto, int quantidade)
        {
            if (quantidade > 0 && quantidade <= produto.Stock)
            {
                produtos.Add(produto);
                quantidades.Add(quantidade);
                produto.Stock -= quantidade;
                return true;
            }
            else
            {
                return false;
            }
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
