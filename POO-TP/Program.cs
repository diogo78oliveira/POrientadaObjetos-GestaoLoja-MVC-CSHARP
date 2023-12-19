/*
 * @file Program.cs
 * @author Marcos Vasconcelos (a18568@alunos.ipca.pt)
 * @author Diogo Oliveira (a20468@alunos.ipca.pt)
 * @brief Classe Program (Main) para gerir o sistema com categorias, marcas, produtos, clientes, colaboradores e encomendas.
 * @date dezembro 2023
 * 
 * @copyright Copyright (c) 2023
 * 
 */

using Controllers;
using Views;

class Program
{
    static void Main(string[] args)
    {
        #region Attributes

        CategoriaController categoriaController = new CategoriaController();
        CategoriaView categoriaView = new CategoriaView(categoriaController);

        MarcaController marcaController = new MarcaController();
        MarcaView marcaView = new MarcaView(marcaController);

        ProdutoController produtoController = new ProdutoController();
        ProdutoView produtoView = new ProdutoView(produtoController, marcaController, categoriaController);

        ClienteController clienteController = new ClienteController();
        ClienteView clienteView = new ClienteView(clienteController);

        ColaboradorController colaboradorController = new ColaboradorController();
        ColaboradorView colaboradorView = new ColaboradorView(colaboradorController);

        EncomendaController encomendaController = new EncomendaController();
        EncomendaView encomendaView = new EncomendaView(encomendaController, produtoController, clienteController, colaboradorController);

        #endregion

        #region Menu

        int op;

        do
        {
            Console.WriteLine("========== MENU ==========");
            Console.WriteLine("1. Gerir produtos");
            Console.WriteLine("2. Gerir categorias");
            Console.WriteLine("3. Gerir marcas");
            Console.WriteLine("4. Gerir clientes");
            Console.WriteLine("5. Gerir colaboradores");
            Console.WriteLine("6. Gerir encomendas");
            Console.WriteLine("0. Sair");
            Console.WriteLine("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out op))
            {
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        produtoView.MenuProduto();
                        break;
                    case 2:
                        Console.Clear();
                        categoriaView.MenuCategoria();
                        break;
                    case 3:
                        Console.Clear();
                        marcaView.MenuMarca();
                        break;
                    case 4:
                        Console.Clear();
                        clienteView.MenuCliente();
                        break;
                    case 5:
                        Console.Clear();
                        colaboradorView.MenuColaborador();
                        break;
                    case 6:
                        Console.Clear();
                        encomendaView.MenuEncomenda();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida");
            }
        } while (op != 0);

        #endregion
    }
}