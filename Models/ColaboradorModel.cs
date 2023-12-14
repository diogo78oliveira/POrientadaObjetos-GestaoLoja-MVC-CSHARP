/*
 * @file ColaboradorModel.cs
 * @author Marcos Vasconcelos (a18568@alunos.ipca.pt)
 * @author Diogo Oliveira (a20468@alunos.ipca.pt)
 * @brief
 * @date dezembro 2023
 * 
 * @copyright Copyright (c) 2023
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Colaborador : Utilizador
    {
        #region Attributes

        private int idColaborador;

        #endregion

        #region Constructor

        /// <summary>
        /// Construtor de um Cliente ao receber parâmetros
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="morada"></param>
        /// <param name="telemovel"></param>
        /// <param name="dataNascimento"></param>
        public Colaborador(int id, string nome, string morada, string telemovel, DateTime dataNascimento)
            : base(nome, morada, telemovel, dataNascimento)
        {
            idColaborador = id;
        }

        #endregion

        #region Methods

        #region Properties

        /// <summary>
        /// Propriedade para manipular o id do colaborador
        /// </summary>
        public int IdColaborador
        {
            get { return idColaborador; }
            set { idColaborador = value; }
        }

        #endregion

        #region Other Methods
        #endregion

        #region Destructor

        /// <summary>
        /// Destrutor por defeito
        /// </summary>
        ~Colaborador() { }
        #endregion

        #endregion
    }
}
