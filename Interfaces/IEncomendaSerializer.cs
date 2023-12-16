/*
 * @file IEncomendaSerializer.cs
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
    public interface IEncomendaSerializer
    {
        bool GuardarEncomendasBin(string fileName);
        bool CarregarEncomendasBin(string fileName);
    }
}
