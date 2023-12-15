/*
 * @file MarcaModel.cs
 * @author Marcos Vasconcelos (a18568@alunos.ipca.pt)
 * @author Diogo Oliveira (a20468@alunos.ipca.pt)
 * @brief Classe MarcaModel para representar uma marca com propriedades para o identificador e o nome
 * @date dezembro 2023
 * 
 * @copyright Copyright (c) 2023
 * 
 */

namespace Models
{
    [Serializable]
    public class Marca
    {
        #region Attributes

        private int idMarca;
        private string nome;

        #endregion

        #region Methods

        #region Constructor

        /// <summary>
        /// Construtor de uma Marca ao receber parâmetros
        /// </summary>
        /// <param name="n"></param>
        public Marca(int id, string n)
        {
            idMarca = id;
            nome = n;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade para manipular o id da marca
        /// </summary>
        public int IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }
        }

        /// <summary>
        /// Propriedade para manipular o nome da marca
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        #endregion

        #region Other Methods
        #endregion

        #region Destructor

        /// <summary>
        /// Destrutor por defeito
        /// </summary>
        ~Marca()
        {
        }
        #endregion

        #endregion
    }
}
