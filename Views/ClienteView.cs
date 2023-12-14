using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Views
{
    public class ClienteView
    {
        #region Attributes

        private ClienteController clienteController;

        #endregion

        #region Methods

        #region Constructor

        /// <summary>
        /// Construtor da classe ClienteView
        /// Inicializa uma nova instância de classe associando-a ao controller
        /// Carrega os clientes a partir do ficheiro binário
        /// </summary>
        /// <param name="controller"></param>
        public ClienteView(ClienteController controller)
        {
            clienteController = controller;
            clienteController.CarregarClientesBin("clientes.bin");
        }

        #endregion

        #region Menu Cliente

        /// <summary>
        /// Método para mostrar o menu de clientes
        /// </summary>
        public void MenuCliente()
        {
            int op;
            do
            {
                Console.WriteLine("========== Clientes ==========");
                Console.WriteLine("1. Adicionar cliente");
                Console.WriteLine("2. Ver clientes");
                Console.WriteLine("3. Atualizar cliente");
                Console.WriteLine("4. Remover cliente");
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
        /// Método para lidar com a opção selecionada no menu de clientes
        /// </summary>
        /// <param name="op"></param>
        private void Opcao(int op)
        {
            switch (op)
            {
                case 1:
                    Console.Clear();
                    AdicionarClienteView();
                    clienteController.GuardarClientesBin("clientes.bin");
                    clienteController.GuardarClientesJSON("clientes.json");
                    break;
                case 2:
                    Console.Clear();
                    VerClientesView();
                    break;
                case 3:
                    Console.Clear();
                    AtualizarClienteView();
                    clienteController.GuardarClientesBin("clientes.bin");
                    clienteController.GuardarClientesJSON("clientes.json");
                    break;
                case 4:
                    Console.Clear();
                    RemoverClienteView();
                    clienteController.GuardarClientesBin("clientes.bin");
                    clienteController.GuardarClientesJSON("clientes.json");
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
        /// Método para adicionar um novo cliente
        /// </summary>
        private void AdicionarClienteView()
        {
            Console.WriteLine("Insira o ID do cliente: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Insira o nome do cliente: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Insira a morada do cliente: ");
                string morada = Console.ReadLine();

                Console.WriteLine("Insira o número de telemóvel do cliente: ");
                string telemovel = Console.ReadLine();

                Console.WriteLine("Insira a data de nascimento do cliente (dd/mm/yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento))
                {
                    Cliente novoCliente = new Cliente(id, nome, morada, telemovel, dataNascimento);

                    if (clienteController.AdicionarClienteController(novoCliente))
                    {
                        Console.WriteLine("Cliente adicionado com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Cliente já existente ou ID duplicado");
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
        /// Método para listar os clientes existentes
        /// </summary>
        private void VerClientesView()
        {
            List<Cliente> clientes = clienteController.ListarClientesController();

            Console.WriteLine("Lista de clientes:\n");

            if (clientes.Count == 0)
            {
                Console.WriteLine("Não existe nenhum cliente");
            }
            else
            {
                foreach (Cliente cliente in clientes)
                {
                    Console.WriteLine($"Cliente #{cliente.IdCliente}\nNome: {cliente.Nome}\nMorada: {cliente.Morada}\nTelemóvel: {cliente.Telemovel}\nData Nascimento: {cliente.DataNascimento.ToString("dd/MM/yyyy")}\n");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Método para atualizar um cliente
        /// </summary>
        private void AtualizarClienteView()
        {
            Console.WriteLine("Insira o ID do cliente para atualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Cliente clienteExistente = clienteController.EncontrarClientePorId(id);

                if (clienteExistente != null)
                {
                    Console.WriteLine("Escolha o que deseja atualizar:");
                    Console.WriteLine("1. Nome do cliente");
                    Console.WriteLine("2. Morada do cliente");
                    Console.WriteLine("3. Telemóvel do cliente");
                    Console.WriteLine("4. Voltar");
                    Console.Write("Escolha uma opção: ");

                    if (int.TryParse(Console.ReadLine(), out int opAtualizarCliente))
                    {
                        AtualizarCamposCliente(id, opAtualizarCliente);
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida");
                    }
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado");
                }
            }
            else
            {
                Console.WriteLine("ID inválido");
            }
        }

        /// <summary>
        /// Método atualizar uma determinada informação de um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="opAtualizarCliente"></param>
        private void AtualizarCamposCliente(int id, int opAtualizarCliente)
        {
            Cliente clienteExistente = clienteController.EncontrarClientePorId(id);

            switch (opAtualizarCliente)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Insira o novo nome do cliente: ");
                    string novoNome = Console.ReadLine();
                    clienteExistente.Nome = novoNome;
                    Console.WriteLine("Nome do cliente atualizado com sucesso");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Insira a nova morada do cliente: ");
                    string novaMorada = Console.ReadLine();
                    clienteExistente.Morada = novaMorada;
                    Console.WriteLine("Morada do cliente atualizada com sucesso");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Insira o novo número de telemóvel do cliente: ");
                    string novoTelemovel = Console.ReadLine();
                    clienteExistente.Telemovel = novoTelemovel;
                    Console.WriteLine("Número de telemóvel do cliente atualizado com sucesso");
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
        /// Método para remover um cliente
        /// </summary>
        private void RemoverClienteView()
        {
            Console.WriteLine("Insira o ID do cliente que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Cliente clienteExistente = clienteController.EncontrarClientePorId(id);

            if (clienteExistente != null)
            {
                clienteController.RemoverClienteController(id);
                Console.WriteLine("Cliente removido com sucesso");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado");
            }
        }

        #endregion

        #endregion
    }
}
