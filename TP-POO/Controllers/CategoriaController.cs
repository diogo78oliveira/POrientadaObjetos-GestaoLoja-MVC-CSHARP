using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
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

        public bool AdicionarCategoriaController(Categoria novaCategoria)
        {
            try
            {
                if (categorias.Any(c => c.IdCategoria == novaCategoria.IdCategoria))
                {
                    return false;
                }

                if (categorias.Any(c => c.Nome.Equals(novaCategoria.Nome, StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }

                categorias.Add(novaCategoria);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Categoria> ListarCategoriasController()
        {
            return categorias;
        }

        public bool AtualizarCategoriaController(Categoria categoriaAtualizada)
        {
            try
            {
                Categoria categoriaExistente = findCategoriaById(categoriaAtualizada.IdCategoria);

                if (categoriaExistente != null)
                {
                    if (categorias.Any(c => c.IdCategoria != categoriaAtualizada.IdCategoria &&
                                             c.Nome.Equals(categoriaAtualizada.Nome, StringComparison.OrdinalIgnoreCase)))
                    {
                        return false;
                    }

                    categoriaExistente.Nome = categoriaAtualizada.Nome;
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public bool RemoverCategoriaController(int id)
        {
            try
            {
                Categoria categoriaExistente = findCategoriaById(id);

                if (categoriaExistente != null)
                {
                    categorias.Remove(categoriaExistente);
                    return true;
                }

                return false; 
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #endregion
    }
}
