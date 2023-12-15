/*
 * @file CategoriaView.cs
 * @author Marcos Vasconcelos (a18568@alunos.ipca.pt)
 * @author Diogo Oliveira (a20468@alunos.ipca.pt)
 * @brief Classe CategoriaView para visualizar o menu que permite adicionar, listar, atualizar e remover categorias, ao utilizar o controller associado
 * @date dezembro 2023
 * 
 * @copyright Copyright (c) 2023
 * 
 */

using Controllers;
using Models;

namespace Views
{
    public class CategoriaView
    {
        #region Attributes

        private CategoriaController categoriaController;

        #endregion

        #region Methods

        #region Constructor

        /// <summary>
        /// Construtor da classe CategoriaView
        /// Inicializa uma nova instância de classe associando-a ao controller
        /// Carrega as categorias a partir do ficheiro binário
        /// </summary>
        /// <param name="controller"></param>
        public CategoriaView(CategoriaController controller)
        {
            categoriaController = controller;
            categoriaController.CarregarCategoriasBin("categorias.bin");
        }

        #endregion

        #region Menu Categoria

        /// <summary>
        /// Método para mostrar o menu de categorias
        /// </summary>
        public void MenuCategoria()
        {
            int op;
            do
            {
                Console.WriteLine("========== Categorias ==========");
                Console.WriteLine("1. Adicionar categoria");
                Console.WriteLine("2. Ver categorias");
                Console.WriteLine("3. Atualizar categoria");
                Console.WriteLine("4. Remover categoria");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out op))
                {
                    Opcao(op);
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
            } while (op != 5);
        }

        /// <summary>
        /// Método para lidar com a opção selecionada no menu de categorias
        /// </summary>
        /// <param name="op"></param>
        private void Opcao(int op)
        {
            switch (op)
            {
                case 1:
                    Console.Clear();
                    AdicionarCategoriaView();
                    categoriaController.GuardarCategoriasBin("categorias.bin");
                    categoriaController.GuardarCategoriasJSON("categorias.json");
                    break;
                case 2:
                    Console.Clear();
                    VerCategoriasView();
                    break;
                case 3:
                    Console.Clear();
                    AtualizarCategoriaView();
                    categoriaController.GuardarCategoriasBin("categorias.bin");
                    categoriaController.GuardarCategoriasJSON("categorias.json");
                    break;
                case 4:
                    Console.Clear();
                    RemoverCategoriaView();
                    categoriaController.GuardarCategoriasBin("categorias.bin");
                    categoriaController.GuardarCategoriasJSON("categorias.json");
                    break;
                case 5:
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        #endregion

        #region Other Methods

        /// <summary>
        /// Método para adicionar uma nova categoria
        /// </summary>
        private void AdicionarCategoriaView()
        {
            Console.WriteLine("Insira o ID da categoria: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Insira o nome da categoria: ");
                string nome = Console.ReadLine();

                Categoria novaCategoria = new Categoria(id, nome);

                if (categoriaController.AdicionarCategoriaController(novaCategoria))
                {
                    Console.WriteLine("Categoria adicionada com sucesso");
                }
                else
                {
                    Console.WriteLine("Categoria já existente ou ID duplicado");
                }
            }
            else
            {
                Console.WriteLine("ID inválido");
            }
        }

        /// <summary>
        /// Método para listar as categorias existentes
        /// </summary>
        private void VerCategoriasView()
        {
            List<Categoria> categorias = categoriaController.ListarCategoriasController();

            Console.WriteLine("Lista de categorias:\n");

            if (categorias.Count == 0)
            {
                Console.WriteLine("Não existe nenhuma categoria");
            }
            else
            {
                foreach (Categoria categoria in categorias)
                {
                    Console.WriteLine($"Categoria #{categoria.IdCategoria}\nNome: {categoria.Nome}\n");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Método para atualizar uma categoria
        /// </summary>
        private void AtualizarCategoriaView()
        {
            Console.WriteLine("Insira o ID da categoria para atualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Categoria categoriaExistente = categoriaController.EncontrarCategoriaPorId(id);

                if (categoriaExistente != null)
                {
                    Console.WriteLine("Insira o novo nome da categoria: ");
                    string novoNome = Console.ReadLine();

                    Categoria categoriaAtualizada = new Categoria(id, novoNome);

                    if (categoriaController.AtualizarCategoriaController(categoriaAtualizada))
                    {
                        Console.WriteLine("Categoria atualizada com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Categoria já existente");
                    }
                }
                else
                {
                    Console.WriteLine("Categoria não encontrada");
                }
            }
            else
            {
                Console.WriteLine("ID inválido");
            }
        }

        /// <summary>
        /// Método para remover uma categoria
        /// </summary>
        private void RemoverCategoriaView()
        {
            Console.Write("Insira o ID da categoria que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Categoria categoriaExistente = categoriaController.EncontrarCategoriaPorId(id);

            if (categoriaExistente != null)
            {
                categoriaController.RemoverCategoriaController(id);
                Console.WriteLine("Categoria removida com sucesso");
            }
            else
            {
                Console.WriteLine("Categoria não encontrada");
            }
        }

        #endregion

        #endregion
    }
}
