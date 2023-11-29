using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO.Controllers;
using TP_POO.Models;

namespace TP_POO.Views
{
    public class CategoriaView
    {
        private CategoriaController categoriaController;

        public CategoriaView(CategoriaController controller)
        {
            categoriaController = controller;
        }

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
                    ExecutarEscolha(op);
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
            } while (op != 5);
        }

        private void ExecutarEscolha(int escolha)
        {
            switch (escolha)
            {
                case 1:
                    Console.Clear();
                    AdicionarCategoria();
                    break;
                case 2:
                    Console.Clear();
                    VerCategorias();
                    break;
                case 3:
                    Console.Clear();
                    AtualizarCategoria();
                    break;
                case 4:
                    Console.Clear();
                    RemoverCategoria();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Voltando para o menu principal...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        private void AdicionarCategoria()
        {
            Console.WriteLine("Insira o nome da categoria: ");
            string nome = Console.ReadLine();

            Categoria novaCategoria = new Categoria(0, nome);
            categoriaController.AdicionarCategoria(novaCategoria);

            Console.WriteLine("Categoria adicionada com sucesso");
        }

        public void VerCategorias()
        {
            var categorias = categoriaController.ListarCategorias();

            Console.WriteLine("Lista de categorias:\n");

            foreach (var categoria in categorias)
            {
                Console.WriteLine($"ID: {categoria.IdCategoria}, Nome: {categoria.Nome}");
            }

            Console.WriteLine();
        }


        public void AtualizarCategoria()
        {
            Console.WriteLine("Insira o ID da categoria para atualizar: ");
            int id = int.Parse(Console.ReadLine());
            
            Categoria categoriaExistente = categoriaController.findCategoriaById(id);

            if (categoriaExistente != null)
            {
                Console.WriteLine("Insira o novo nome da categoria: ");
                string novoNome = Console.ReadLine();

                Categoria categoriaAtualizada = new Categoria(id, novoNome);
                categoriaController.AtualizarCategoria(categoriaAtualizada);

                Console.WriteLine("Categoria atualizada");
            }
            else
            {
                Console.WriteLine("Categoria não encontrada");
            }
        }

        private void RemoverCategoria()
        {
            Console.Write("Digite o ID da categoria que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Categoria categoriaExistente = categoriaController.findCategoriaById(id);

            if (categoriaExistente != null)
            {
                categoriaController.RemoverCategoria(id);
                Console.WriteLine("Categoria removida com sucesso");
            }
            else
            {
                Console.WriteLine("Categoria não encontrada.");
            }
        }
    }
}
