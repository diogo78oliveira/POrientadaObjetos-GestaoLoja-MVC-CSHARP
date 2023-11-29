using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO.Models;

namespace TP_POO.Controllers
{
    public class CategoriaController
    {
        #region Attributes

        private List<Categoria> categorias = new List<Categoria>();

        #endregion

        #region Methods
        public Categoria findCategoriaById(int id)
        {
            return categorias.Find(c => c.IdCategoria == id);
        }

        public void AdicionarCategoria(Categoria categoria)
        {
            categoria.IdCategoria = categorias.Count + 1;
            categorias.Add(categoria);
        }

        public List<Categoria> ListarCategorias()
        {
            return categorias;
        }

        public void AtualizarCategoria(Categoria categoriaAtualizada)
        {
            Categoria categoriaExistente = findCategoriaById(categoriaAtualizada.IdCategoria);
            if(categoriaExistente != null)
            {
                categoriaExistente.Nome = categoriaAtualizada.Nome;
            }
        }

        public void RemoverCategoria(int id)
        {
            Categoria categoriaExistente = findCategoriaById(id);

            if( categoriaExistente != null )
            {
                categorias.Remove(categoriaExistente);
            }
        }

        #endregion
    }
}
