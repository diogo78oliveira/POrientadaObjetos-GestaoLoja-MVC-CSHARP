/*
 * <date>2023</date>
 * <author>Marcos Vasconcelos</author>
 * <email>a18568@alunos.ipca.pt</email>
 * <author>Diogo Oliveira</author>
 * <email>a20468@alunos.ipca.pt</email>
 * <desc>Main/Program</desc>
 */

using System;
using E_Commerce;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TP_POO.Controllers;
using TP_POO.Views;

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

            if(int.TryParse(Console.ReadLine(), out op))
            {
                switch(op)
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
                        //produtoView.MenuCliente();
                        break;
                    case 5:
                        Console.Clear();
                        //colaboradorView.MenuColaborador();
                        break;
                    case 6:
                        Console.Clear();
                        //encomendaView.MenuEncomenda();
                        break;
                    case 0:
                        Console.WriteLine("A sair...");
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