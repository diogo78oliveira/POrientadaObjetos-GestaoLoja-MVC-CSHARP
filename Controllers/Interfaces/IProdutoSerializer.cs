/*
 * @file IProdutoSerializer.cs
 * @author Marcos Vasconcelos (a18568@alunos.ipca.pt)
 * @author Diogo Oliveira (a20468@alunos.ipca.pt)
 * @brief 
 * @date dezembro 2023
 * 
 * @copyright Copyright (c) 2023
 * 
 */

namespace Controllers.Interfaces
{
    public interface IProdutoSerializer
    {
        bool GuardarProdutosBin(string fileName);
        bool CarregarProdutosBin(string fileName);
        bool GuardarProdutosJSON(string fileName);
    }
}
