/*
 * @file ICategoriaSerializer.cs
 * @author Marcos Vasconcelos (a18568@alunos.ipca.pt)
 * @author Diogo Oliveira (a20468@alunos.ipca.pt)
 * @brief 
 * @date dezembro 2023
 * 
 * @copyright Copyright (c) 2023
 * 
 */

namespace Interfaces
{
    public interface ICategoriaSerializer
    {
        bool GuardarCategoriasBin(string fileName);
        bool CarregarCategoriasBin(string fileName);
        bool GuardarCategoriasJSON(string fileName);
    }
}
