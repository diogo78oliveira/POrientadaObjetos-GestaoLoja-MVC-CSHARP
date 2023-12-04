/*
 * <date>2023</date>
 * <author>Marcos Vasconcelos</author>
 * <email>a18568@alunos.ipca.pt</email>
 * <author>Diogo Oliveira</author>
 * <email>a20468@alunos.ipca.pt</email>
 * <desc>Classe Produto</desc>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO.Models;

namespace TP_POO.Models
{
    [Serializable]
    public class Produto
    {
        #region Attributes

        private int idProduto;
        public Marca marca;
        public Categoria categoria;
        private string nome;
        private string descricao;
        private double preco;
        private int stock;

        #endregion

        #region Methods

        #region Constructor

        /// <summary>
        /// Construtor de um Produto ao receber parâmetros
        /// </summary>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <param name="p"></param>
        /// <param name="s"></param>
        public Produto(int id, string n, string d, double p, int s, Marca m, Categoria c)
        {
            idProduto = id;
            nome = n;
            descricao = d;
            preco = p;
            stock = s;
            marca = m;
            categoria = c;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade para manipular o id do produto
        /// </summary>
        public int IdProduto
        {
            get { return idProduto; }
        }

        /// <summary>
        /// Propriedade para manipular o nome do produto
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Propriedade para manipular a descrição do produto
        /// </summary>
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        /// <summary>
        /// Propriedade para manipular o preço do produto
        /// </summary>
        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        /// <summary>
        /// Propriedade para manipular o stock do produto
        /// </summary>
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        #endregion

        #region Other Methods
        #endregion

        #region Destructor

        /// <summary>
        /// Destrutor por defeito
        /// </summary>
        ~Produto()
        {
        }
        #endregion

        #endregion
    }
}