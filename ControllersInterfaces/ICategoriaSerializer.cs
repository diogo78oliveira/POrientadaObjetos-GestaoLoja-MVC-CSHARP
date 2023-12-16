using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllersInterfaces
{
    public interface ICategoriaSerializer
    {
        bool GuardarCategoriasBin(string fileName);
        bool CarregarCategoriasBin(string fileName);
        bool GuardarCategoriasJSON(string fileName);
    }
}
