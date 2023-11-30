using E_Commerce;
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
    public class MarcaController
    {
    #region Attributes

    private List<Marca> marcas = new List<Marca>();

    #endregion

    #region Methods

    /// <summary>
    /// Método para encontrar uma categoria através do seu ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Marca findMarcaById(int id)
    {
        return marcas.Find(m => m.IdMarca == id);
    }

    /// <summary>
    /// Método para adicionar uma nova categoria
    /// </summary>
    /// <param name="novaMarca"></param>
    /// <returns></returns>
    public bool AdicionarMarcaController(Marca novaMarca)
    {
        if (marcas.Any(m => m.IdMarca == novaMarca.IdMarca))
        {
            return false;
        }

        if (marcas.Any(m => m.Nome.Equals(novaMarca.Nome, StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }

        marcas.Add(novaMarca);
        return true;
    }

    /// <summary>
    /// Método para listar as categorias existentes
    /// </summary>
    /// <returns></returns>
    public List<Marca> ListarMarcasController()
    {
        return marcas;
    }

    /// <summary>
    /// Método para atualizar uma categoria
    /// </summary>
    /// <param name="marcaAtualizada"></param>
    /// <returns></returns>
    public bool AtualizarMarcaController(Marca marcaAtualizada)
    {
        Marca marcaExistente = findMarcaById(marcaAtualizada.IdMarca);

        if (marcaExistente != null)
        {
            if (marcas.Any(m => m.IdMarca != marcaAtualizada.IdMarca && m.Nome.Equals(marcaAtualizada.Nome, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }
            marcaExistente.Nome = marcaAtualizada.Nome;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Método para remover uma categoria
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool RemoverMarcaController(int id)
    {
        Marca marcaExistente = findMarcaById(id);

        if (marcaExistente != null)
        {
            marcas.Remove(marcaExistente);
            return true;
        }
        return false;
    }

    #endregion
}
}
