/*
 * @file EncomendaModel.cs
 * @author Marcos Vasconcelos (a18568@alunos.ipca.pt)
 * @author Diogo Oliveira (a20468@alunos.ipca.pt)
 * @brief Classe EncomendaModel para representar uma encomenda com propriedades para o identificador, cliente e fornecedor, produtos e quantidades, data, valor total e total de encomendas
 * @date dezembro 2023
 * 
 * @copyright Copyright (c) 2023
 * 
 */

namespace Models
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

        /// <summary>
        /// Construtor de uma Encomenda ao receber parâmetros
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="col"></param>
        public Encomenda(Cliente cli, Colaborador col)
        {
            totalEncomendas++;
            idEncomenda = totalEncomendas;
            cliente = cli;
            colaborador = col;
            data = DateTime.Now;
            total = 0;
            GuardarTotalEncomendas();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade para manipular o id da encomenda
        /// </summary>
        public int IdEncomenda
        {
            get { return idEncomenda; }
        }

        /// <summary>
        /// Propriedade para manipular a data da encomenda
        /// </summary>
        public DateTime Data
        {
            get { return data; }
        }

        /// <summary>
        /// Propriedade para manipular a lista de produtos da encomenda
        /// </summary>
        public List<Produto> Produtos
        {
            get { return produtos; }
        }

        /// <summary>
        /// Propriedade para manipular as quantidades da encomenda
        /// </summary>
        public List<int> Quantidades
        {
            get { return quantidades; }
        }

        /// <summary>
        /// Propriedade para manipular o total de encomendas
        /// </summary>
        public int TotalEncomendas
        {
            get { return totalEncomendas; }
        }

        /// <summary>
        /// Propriedade para manipular o valor total da encomenda
        /// </summary>
        public double Total
        {
            get { return total; }
        }

        #endregion

        #region Other Methods

        /// <summary>
        /// Método para adicionar um produto e quantidade a uma encomenda
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método para guardar o total de encomendas num ficheiro de texto
        /// </summary>
        /// <returns></returns>
        private static bool GuardarTotalEncomendas()
        {
            File.WriteAllText("totalEncomendas.txt", totalEncomendas.ToString());
            return true;
        }

        /// <summary>
        /// Método para carregar o total de encomendas a partir de um ficheiro de texto
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Destrutor por defeito
        /// </summary>
        ~Encomenda()
        {
        }

        #endregion

        #endregion
    }
}
