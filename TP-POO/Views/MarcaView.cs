using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO.Controllers;
using TP_POO.Models;

namespace TP_POO.Views
{
    public class MarcaView
    {
        #region Attributes

        private MarcaController marcaController;

        #endregion

        #region Methods

        #region Constructor

        public MarcaView(MarcaController controller)
        {
            marcaController = controller;
            marcaController.CarregaMarcasBin("marcas.bin");
        }

        #endregion

        #region Menu Marca
        public void MenuMarca()
        {
            int op;
            do
            {
                Console.WriteLine("========== Marcas ==========");
                Console.WriteLine("1. Adicionar marca");
                Console.WriteLine("2. Ver marcas");
                Console.WriteLine("3. Atualizar marca");
                Console.WriteLine("4. Remover marca");
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

        private void Opcao(int op)
        {
            switch (op)
            {
                case 1:
                    Console.Clear();
                    AdicionarMarcaView();
                    marcaController.SalvaMarcasBin("marcas.bin");
                    break;
                case 2:
                    Console.Clear();
                    VerMarcasView();
                    break;
                case 3:
                    Console.Clear();
                    AtualizarMarcaView();
                    marcaController.SalvaMarcasBin("marcas.bin");
                    break;
                case 4:
                    Console.Clear();
                    RemoverMarcaView();
                    marcaController.SalvaMarcasBin("marcas.bin");
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
        /// Método para adicionar uma nova marca
        /// </summary>
        private void AdicionarMarcaView()
        {
            Console.WriteLine("Insira o ID da marca: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Insira o nome da marca: ");
                string nome = Console.ReadLine();

                Marca novaMarca = new Marca(id, nome);

                if (marcaController.AdicionarMarcaController(novaMarca))
                {
                    Console.WriteLine("Marca adicionada com sucesso");
                }
                else
                {
                    Console.WriteLine("Marca já existente ou ID duplicado");
                }
            }
            else
            {
                Console.WriteLine("ID inválido");
            }
        }

        /// <summary>
        /// Método para listar as marcas existentes
        /// </summary>
        private void VerMarcasView()
        {
            List<Marca> marcas = marcaController.ListarMarcasController();

            Console.WriteLine("Lista de marcas:\n");

            if (marcas.Count == 0)
            {
                Console.WriteLine("Não existe nenhuma marca");
            }
            else
            {
                foreach (Marca marca in marcas)
                {
                    Console.WriteLine($"Marca #{marca.IdMarca}\nNome: {marca.Nome}\n");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Método para atualizar uma marca
        /// </summary>
        private void AtualizarMarcaView()
        {
            Console.WriteLine("Insira o ID da marca para atualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Marca marcaExistente = marcaController.findMarcaById(id);

                if (marcaExistente != null)
                {
                    Console.WriteLine("Insira o novo nome da marca: ");
                    string novoNome = Console.ReadLine();

                    Marca marcaAtualizada = new Marca(id, novoNome);

                    if (marcaController.AtualizarMarcaController(marcaAtualizada))
                    {
                        Console.WriteLine("Marca atualizada com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Marca já existente");
                    }
                }
                else
                {
                    Console.WriteLine("Marca não encontrada");
                }
            }
            else
            {
                Console.WriteLine("ID inválido");
            }
        }

        /// <summary>
        /// Método para remover uma marca
        /// </summary>
        private void RemoverMarcaView()
        {
            Console.Write("Insira o ID da marca que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Marca marcaExistente = marcaController.findMarcaById(id);

            if (marcaExistente != null)
            {
                marcaController.RemoverMarcaController(id);
                Console.WriteLine("Marca removida com sucesso");
            }
            else
            {
                Console.WriteLine("Marca não encontrada.");
            }
        }

        #endregion

        #endregion
    }
}