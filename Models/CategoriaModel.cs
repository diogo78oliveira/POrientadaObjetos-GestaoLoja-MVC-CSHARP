/*
 * @file CategoriaModel.cs
 * @author Marcos Vasconcelos (a18568@alunos.ipca.pt)
 * @author Diogo Oliveira (a20468@alunos.ipca.pt)
 * @brief
 * @date dezembro 2023
 * 
 * @copyright Copyright (c) 2023
 * 
 */

namespace Models
{
    [Serializable]
    public class Categoria
    {
        #region Attributes

        private int idCategoria;
        private string nome;

        #endregion

        #region Methods

        #region Constructor

        /// <summary>
        /// Construtor de uma Categoria ao receber parâmetros
        /// </summary>
        /// <param name="n"></param>
        public Categoria(int id, string n)
        {
            idCategoria = id;
            nome = n;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade para manipular o id da categoria
        /// </summary>
        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        /// <summary>
        /// Propriedade para manipular o nome da categoria
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
        ~Categoria()
        {
        }
        #endregion

        #endregion
    }
}
