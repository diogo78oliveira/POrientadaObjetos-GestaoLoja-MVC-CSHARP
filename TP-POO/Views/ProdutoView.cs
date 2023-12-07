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
            produtoController.CarregarProdutosBin("produtos.bin");
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
                    produtoController.GuardarProdutosBin("produtos.bin");
                    produtoController.GuardaProdutosJSON("produtos.json");
                    break;
                case 2:
                    Console.Clear();
                    VerProdutosView();
                    break;
                case 3:
                    Console.Clear();
                    AtualizarProdutoView();
                    produtoController.GuardarProdutosBin("produtos.bin");
                    produtoController.GuardaProdutosJSON("produtos.json");
                    break;
                case 4:
                    Console.Clear();
                    RemoverProdutoView();
                    produtoController.GuardarProdutosBin("produtos.bin");
                    produtoController.GuardaProdutosJSON("produtos.json");
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
        /// Método para adicionar um novo produto
        /// </summary>
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

        /// <summary>
        /// Método para listar os produtos existentes
        /// </summary>
        private void VerProdutosView()
        {
            List<Produto> produtos = produtoController.ListarProdutosController();

            Console.WriteLine("Lista de produtos:\n");

            if (produtos.Count == 0)
            {
                Console.WriteLine("Não existe nenhum produto");
            }
            else
            {
                foreach (Produto produto in produtos)
                {
                    Console.WriteLine($"Produto #{produto.IdProduto}\nNome: {produto.Nome}\nDescrição: {produto.Descricao}\nPreço: {produto.Preco}\nStock: {produto.Stock}\nMarca: {produto.marca.Nome}\nCategoria: {produto.categoria.nome}\n");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Método para atualizar um produto
        /// </summary>
        private void AtualizarProdutoView()
        {
            Console.WriteLine("Insira o ID do produto para atualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Produto produtoExistente = produtoController.findProdutoById(id);

                if (produtoExistente != null)
                {
                    Console.WriteLine("Escolha o que deseja atualizar:");
                    Console.WriteLine("1. Nome do produto");
                    Console.WriteLine("2. Descrição do produto");
                    Console.WriteLine("3. Preço do produto");
                    Console.WriteLine("4. Stock do produto");
                    Console.WriteLine("5. Marca do produto");
                    Console.WriteLine("6. Categoria do produto");
                    Console.WriteLine("7. Voltar");
                    Console.Write("Escolha uma opção: ");

                    if (int.TryParse(Console.ReadLine(), out int opAtualizarProduto))
                    {
                        AtualizarCamposProduto(id, opAtualizarProduto);
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida");
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

        /// <summary>
        /// Método atualizar uma determinada informação de um produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="opAtualizarProduto"></param>
        private void AtualizarCamposProduto(int id, int opAtualizarProduto)
        {
            Produto produtoExistente = produtoController.findProdutoById(id);

            switch (opAtualizarProduto)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Insira o novo nome do produto: ");
                    string novoNome = Console.ReadLine();
                    produtoExistente.Nome = novoNome;
                    Console.WriteLine("Nome do produto atualizado com sucesso");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Insira a nova descrição do produto: ");
                    string novaDescricao = Console.ReadLine();
                    produtoExistente.Descricao = novaDescricao;
                    Console.WriteLine("Descrição do produto atualizada com sucesso");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Insira o novo preço do produto: ");
                    if (double.TryParse(Console.ReadLine(), out double novoPreco))
                    {
                        produtoExistente.Preco = novoPreco;
                        Console.WriteLine("Preço do produto atualizado com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Novo preço inválido");
                    }
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Insira a quantidade que deseja adicionar ao stock do produto: ");

                    if (int.TryParse(Console.ReadLine(), out int novoStock))
                    {
                        if (novoStock > 0)
                        {
                            produtoExistente.Stock += novoStock;
                            Console.WriteLine("Stock do produto atualizado com sucesso");
                        }
                        else
                        {
                            Console.WriteLine("Insira um número positivo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Stock inválido.");
                    }
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Insira o ID da nova marca do produto: ");
                    if(int.TryParse(Console.ReadLine(), out int novoIdMarca))
                    {
                        Marca novaMarca = marcaController.findMarcaById(novoIdMarca);
                        if (novaMarca != null)
                        {
                            produtoExistente.marca = novaMarca;
                            Console.WriteLine("Marca do produto atualizada com sucesso");
                        }
                        else
                        {
                            Console.WriteLine("Nova marca não existe");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID da nova marca inválido");
                    }
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Insira o ID da nova categoria do produto: ");
                    if(int.TryParse(Console.ReadLine(), out int novoIdCategoria))
                    {
                        Categoria novaCategoria = categoriaController.findCategoriaById(novoIdCategoria);
                        if(novaCategoria != null)
                        {
                            produtoExistente.categoria = novaCategoria;
                            Console.WriteLine("Categoria do produto atualizada com sucesso");
                        }
                        else
                        {
                            Console.WriteLine("Nova categoria não existe");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID da nova categoria inválido");
                    }
                    break;
                case 7:
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        /// <summary>
        /// Método para remover um produto
        /// </summary>
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