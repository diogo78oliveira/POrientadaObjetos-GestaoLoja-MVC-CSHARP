using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO.Controllers;
using TP_POO.Models;

namespace TP_POO.Views
{
    public class ColaboradorView
    {
        #region Attributes

        private ColaboradorController colaboradorController;

        #endregion

        #region Methods

        #region Constructor

        public ColaboradorView(ColaboradorController controller)
        {
            colaboradorController = controller;
            colaboradorController.CarregaColaboradoresBin("colaboradores.bin");
        }

        #endregion

        #region Menu Colaborador

        public void MenuColaborador()
        {
            int op;
            do
            {
                Console.WriteLine("========== Colaboradores ==========");
                Console.WriteLine("1. Adicionar colaborador");
                Console.WriteLine("2. Ver colaboradores");
                Console.WriteLine("3. Atualizar colaborador");
                Console.WriteLine("4. Remover colaborador");
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
                    AdicionarColaboradorView();
                    colaboradorController.SalvaColaboradoresBin("colaboradores.bin");
                    break;
                case 2:
                    Console.Clear();
                    VerColaboradoresView();
                    break;
                case 3:
                    Console.Clear();
                    AtualizarColaboradorView();
                    colaboradorController.SalvaColaboradoresBin("colaboradores.bin");
                    break;
                case 4:
                    Console.Clear();
                    RemoverColaboradorView();
                    colaboradorController.SalvaColaboradoresBin("colaboradores.bin");
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
        /// Método para adicionar um novo colaborador
        /// </summary>
        private void AdicionarColaboradorView()
        {
            Console.WriteLine("Insira o ID do colaborador: ");
            if(int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Insira o nome do colaborador: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Insira a morada do colaborador: ");
                string morada = Console.ReadLine();

                Console.WriteLine("Insira o número de telemóvel do colaborador: ");
                string telemovel = Console.ReadLine();

                Console.WriteLine("Insira a data de nascimento do colaborador (dd/mm/yyy): ");
                if(DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento))
                {
                    Colaborador novoColaborador = new Colaborador(id, nome, morada, telemovel, dataNascimento);

                    if(colaboradorController.AdicionarColaboradorController(novoColaborador))
                    {
                        Console.WriteLine("Colaborador adicionado com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Colaborador já existente ou ID duplicado");
                    }
                }
                else
                {
                    Console.WriteLine("Data de nascimento inválida");
                }
            }
            else
            {
                Console.WriteLine("ID inválido");
            }
        }

        /// <summary>
        /// Método para listar os colaboradores existentes
        /// </summary>
        public void VerColaboradoresView()
        {
            List<Colaborador> colaboradores = colaboradorController.ListarColaboradoresController();

            Console.WriteLine("Lista de colaboradores:\n");

            if(colaboradores.Count == 0)
            {
                Console.WriteLine("Não existe nenhum colaborador");
            }
            else
            {
                foreach(Colaborador colaborador in colaboradores)
                {
                    Console.WriteLine($"Colaborador #{colaborador.IdColaborador}\nNome: {colaborador.Nome}\nMorada: {colaborador.Morada}\nTelemóvel: {colaborador.Telemovel}\nData Nascimento: {colaborador.DataNascimento}\n");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Método para atualizar um colaborador
        /// </summary>
        public void AtualizarColaboradorView()
        {
            Console.WriteLine("Insira o ID do colaborador para atualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Colaborador colaboradorExistente = colaboradorController.findColaboradorById(id);

                if( colaboradorExistente != null)
                {
                    Console.WriteLine("Escolha o que deseja atualizar:");
                    Console.WriteLine("1. Nome do colaborador");
                    Console.WriteLine("2. Morada do colaborador");
                    Console.WriteLine("3. Telemóvel do colaborador");
                    Console.WriteLine("4. Voltar");
                    Console.Write("Escolha uma opção: ");

                    if(int.TryParse(Console.ReadLine(), out int opAtualizarColaborador))
                    {
                        AtualizarCamposColaborador(id, opAtualizarColaborador);
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida");
                    }
                }
                else
                {
                    Console.WriteLine("Colaborador não encontrado");
                }
            }
            else
            {
                Console.WriteLine("ID inválido");
            }
        }

        /// <summary>
        /// Método atualizar uma determinada informação de um colaborador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="opAtualizarColaborador"></param>
        private void AtualizarCamposColaborador(int id, int opAtualizarColaborador)
        {
            Colaborador colaboradorExistente = colaboradorController.findColaboradorById(id);

            switch(opAtualizarColaborador)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Insira o novo nome do colaborador: ");
                    string novoNome = Console.ReadLine();
                    colaboradorExistente.Nome = novoNome;
                    Console.WriteLine("Nome do colaborador atualizado com sucesso");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Insira a nova morada do colaborador: ");
                    string novaMorada = Console.ReadLine();
                    colaboradorExistente.Morada = novaMorada;
                    Console.WriteLine("Morada do colaborador atualizada com sucesso");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Insira o novo número de telemóvel do colaborador: ");
                    string novoTelemovel = Console.ReadLine();
                    colaboradorExistente.Telemovel = novoTelemovel;
                    Console.WriteLine("Número de telemóvel do colaborador atualizado com sucesso");
                    break;
                case 4:
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        /// <summary>
        /// Método para remover um colaborador
        /// </summary>
        private void RemoverColaboradorView()
        {
            Console.WriteLine("Insira o ID do colaborador que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Colaborador colaboradorExistente = colaboradorController.findColaboradorById(id);

            if (colaboradorExistente != null)
            {
                colaboradorController.RemoverColaboradorController(id);
                Console.WriteLine("Colaborador removido com sucesso");
            }
            else
            {
                Console.WriteLine("Colaborador não encontrado");
            }
        }

        #endregion

        #endregion
    }
}
