using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Cliente : Utilizador
    {
        #region Attributes

        private int idCliente;

        #endregion

        #region Constructor

        /// <summary>
        /// Construtor de um Cliente ao receber parâmetros
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="morada"></param>
        /// <param name="telemovel"></param>
        /// <param name="dataNascimento"></param>
        public Cliente(int id, string nome, string morada, string telemovel, DateTime dataNascimento)
            : base(nome, morada, telemovel, dataNascimento)
        {
            idCliente = id;
        }

        #endregion

        #region Methods

        #region Properties

        /// <summary>
        /// Propriedade para manipular o id do cliente
        /// </summary>
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        #endregion

        #region Other Methods
        #endregion

        #region Destructor

        /// <summary>
        /// Destrutor por defeito
        /// </summary>
        ~Cliente() { }
        #endregion

        #endregion

    }
}
