# E-Commerce (Gestão de uma loja online em C#)

Este projeto é um sistema de gestão que permite a administração de produtos, categorias, marcas, clientes, colaboradores e encomendas. O código é implementado utilizando a arquitetura MVC (Model-View-Controller) e está estruturado em classes separadas para cada entidade (Categoria, Marca, Produto, Cliente, Colaborador, Encomenda), juntamente com os respetivos controladores e visualizações.

## Autores

- Marcos Vasconcelos (a18568@alunos.ipca.pt)
- Diogo Oliveira (a20468@alunos.ipca.pt)

Este projeto foi realizado no âmbito da Unidade Curricular de Programação Orientada a Objetos do curso de Licenciatura de Engenharia de Sistemas Informáticos no ano letivo 2023/2024, sob a orientação do docente Luis Ferreira.

## Funcionalidades

O sistema oferece as seguintes funcionalidades para cada entidade:

1. **Produtos:**
   - Adicionar, listar, atualizar e remover produtos.
   - Associar produtos a categorias e marcas.

2. **Categorias:**
   - Adicionar, listar, atualizar e remover categorias.

3. **Marcas:**
   - Adicionar, listar, atualizar e remover marcas.

4. **Clientes:**
   - Adicionar, listar, atualizar e remover clientes.

5. **Colaboradores:**
   - Adicionar, listar, atualizar e remover colaboradores.

6. **Encomendas:**
   - Gerir o processo de encomendas, associando produtos, clientes e colaboradores.

## Estrutura do Projeto

O projeto está organizado em várias classes e seguindo a estrutura MVC:

- **Controllers:**
  - Cada entidade tem um controlador correspondente (CategoriaController, MarcaController, ProdutoController, ClienteController, ColaboradorController, EncomendaController).
  - Os controladores contêm métodos para gerir as operações relacionadas com as respetivas entidades.

- **Models:**
  - Cada entidade tem um modelo correspondente (Categoria, Marca, Produto, Cliente, Colaborador, Encomenda).
  - Os modelos representam a estrutura de dados das entidades.

- **Views:**
  - Cada entidade tem uma vista correspondente (CategoriaView, MarcaView, ProdutoView, ClienteView, ColaboradorView, EncomendaView).
  - As vistas são responsáveis pela interação com o utilizador e apresentação de menus.

- **Program.cs:**
  - O arquivo `Program.cs` contém o ponto de entrada principal (`Main`) que cria instâncias dos controladores e vistas e inicia o menu principal.


