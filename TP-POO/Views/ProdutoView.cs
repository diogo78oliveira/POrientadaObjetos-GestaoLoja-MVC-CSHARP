using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO.Controllers;
using TP_POO.Models;

namespace TP_POO.Views
{
    public class ProdutoView
    {
        #region Attributes

        private ProdutoController produtoController;
        private MarcaController marcaController;
        private CategoriaController categoriaController;

        #endregion

        #region Methods

        #region Constructor

        public ProdutoView(ProdutoController produtoController, MarcaController marcaController, CategoriaController categoriaController)
        {
            this.produtoController = produtoController;
            this.marcaController = marcaController;
            this.categoriaController = categoriaController;
            produtoController.CarregaProdutosBin("produtos.bin");
        }

        #endregion

        #region Menu Produto

        public void MenuProduto()
        {
            int op;
            do
            {
                Console.WriteLine("========== Produtos ==========");
                Console.WriteLine("1. Adicionar produto");
                Console.WriteLine("2. Ver produtos");
                Console.WriteLine("3. Atualizar produto");
                Console.WriteLine("4. Remover produto");
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
                    AdicionarProdutoView();
                    produtoController.SalvaProdutosBin("produtos.bin");
                    break;
                case 2:
                    Console.Clear();
                    VerProdutosView();
                    break;
                case 3:
                    Console.Clear();
                    AtualizarProdutoView();
                    produtoController.SalvaProdutosBin("produtos.bin");
                    break;
                case 4:
                    Console.Clear();
                    RemoverProdutoView();
                    produtoController.SalvaProdutosBin("produtos.bin");
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

        private void AdicionarProdutoView()
        {
            Console.WriteLine("Insira o ID do produto: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Insira o nome do produto: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Insira a descrição do produto: ");
                string descricao = Console.ReadLine();

                Console.WriteLine("Insira o preço do produto: ");
                if (double.TryParse(Console.ReadLine(), out double preco))
                {
                    Console.WriteLine("Insira o stock do produto: ");
                    if (int.TryParse(Console.ReadLine(), out int stock))
                    {
                        Console.WriteLine("Insira o ID da marca do produto: ");
                        if (int.TryParse(Console.ReadLine(), out int idMarca))
                        {
                            Console.WriteLine("Insira o ID da categoria do produto: ");
                            if (int.TryParse(Console.ReadLine(), out int idCategoria))
                            {
                                Marca marca = marcaController.findMarcaById(idMarca);
                                Categoria categoria = categoriaController.findCategoriaById(idCategoria);

                                if (marca != null && categoria != null)
                                {
                                    Produto novoProduto = new Produto(id, nome, descricao, preco, stock, marca, categoria);

                                    if (produtoController.AdicionarProdutoController(novoProduto))
                                    {
                                        Console.WriteLine("Produto adicionado com sucesso");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Erro ao adicionar produto");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Marca ou categoria não encontradas");
                                }
                            }
                            else
                            {
                                Console.WriteLine("ID da categoria inválido");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID da marca inválido");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Stock inválido");
                    }
                }
                else
                {
                    Console.WriteLine("Preço inválido");
                }
            }
            else
            {
                Console.WriteLine("ID inválido");
            }
        }

        private void VerProdutosView()
        {
            var produtos = produtoController.ListarProdutosController();

            Console.WriteLine("Lista de produtos:\n");

            if (produtos.Count == 0)
            {
                Console.WriteLine("Não existe nenhum produto");
            }
            else
            {
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"ID: {produto.IdProduto}, Nome: {produto.Nome}, Descrição: {produto.Descricao}, Preço: {produto.Preco}, Stock: {produto.Stock}, Marca: {produto.marca.Nome}, Categoria: {produto.categoria.nome};");
                }
            }
            Console.WriteLine();
        }

        private void AtualizarProdutoView()
        {
            Console.WriteLine("Insira o ID do produto para atualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Produto produtoExistente = produtoController.findProdutoById(id);

                if (produtoExistente != null)
                {
                    Console.WriteLine("Insira o novo nome do produto: ");
                    string novoNome = Console.ReadLine();

                    Console.WriteLine("Insira a nova descrição do produto: ");
                    string novaDescricao = Console.ReadLine();

                    Console.WriteLine("Insira o novo preço do produto: ");
                    if (double.TryParse(Console.ReadLine(), out double novoPreco))
                    {
                        Console.WriteLine("Insira o novo stock do produto: ");
                        if (int.TryParse(Console.ReadLine(), out int novoStock))
                        {
                            Console.WriteLine("Insira o ID da nova marca associada ao produto: ");
                            if (int.TryParse(Console.ReadLine(), out int novoIdMarca))
                            {
                                Console.WriteLine("Insira o ID da nova categoria associada ao produto: ");
                                if (int.TryParse(Console.ReadLine(), out int novoIdCategoria))
                                {
                                    Marca novaMarca = marcaController.findMarcaById(novoIdMarca);
                                    Categoria novaCategoria = categoriaController.findCategoriaById(novoIdCategoria);

                                    if (novaMarca != null && novaCategoria != null)
                                    {
                                        Produto produtoAtualizado = new Produto(id, novoNome, novaDescricao, novoPreco, novoStock, novaMarca, novaCategoria);

                                        if (produtoController.AtualizarProdutoController(produtoAtualizado))
                                        {
                                            Console.WriteLine("Produto atualizado com sucesso");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Erro ao atualizar o produto.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nova marca ou categoria associada não existe.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ID da nova categoria inválido.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("ID da nova marca inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Novo stock inválido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Novo preço inválido.");
                    }
                }
                else
                {
                    Console.WriteLine("Produto não encontrado");
                }
            }
            else
            {
                Console.WriteLine("ID inválido");
            }
        }

        private void RemoverProdutoView()
        {
            Console.Write("Insira o ID do produto que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Produto produtoExistente = produtoController.findProdutoById(id);

            if(produtoExistente != null)
            {
                produtoController.RemoverProdutoController(id);
                Console.WriteLine("Produto removido com sucesso");
            }
            else
            {
                Console.WriteLine("Produto não encontrado");
            }
        }

        #endregion

        #endregion
    }
}