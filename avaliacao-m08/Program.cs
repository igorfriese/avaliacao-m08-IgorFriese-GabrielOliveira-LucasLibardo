using avaliacao_m08.Exceptions;
using avaliacao_m08.Modelos;
using avaliacao_m08.Repositories;
using avaliacao_m08.Services;
using System;

namespace avaliacao_m08
    {
        class Program
        {
            static void Main(string[] args)
            {


                RepositorioLivro repo = new RepositorioLivro();
                BibliotecaApiService api = new BibliotecaApiService();

                repo.Adicionar(new Livro(1, "Dom Casmurro", "Machado de Assis", 1899));
                repo.Adicionar(new Livro(2, "O Hobbit", "Tolkien", 1937));
                repo.Adicionar(new Livro(3, "Harry Poter e a Pedra Filosofal", "J.K.Rowling", 1997));
                repo.Adicionar(new Livro(4, "Christine - O carro assassino", "Stephen King", 1983));
                repo.Adicionar(new Livro(5, "Duna", "Frank Herbert", 1965));

                int opcao = -1;

                while (opcao != 0)
                {
                    Console.WriteLine("\n=== BIBLIOTECA ===");
                    Console.WriteLine("1 - Listar livros");
                    Console.WriteLine("2 - Buscar por ID");
                    Console.WriteLine("3 - Buscar por Autor");
                    Console.WriteLine("4 - Buscar na API");
                    Console.WriteLine("5 - Listar disponíveis");
                    Console.WriteLine("6 - Salvar arquivo");
                    Console.WriteLine("0 - Sair");

                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            var lista = repo.ListarTodos();
                            foreach (var l in lista)
                            {
                                Console.WriteLine(l.Titulo);
                            }
                            break;

                        case 2:
                            try
                            {
                                Console.Write("ID: ");
                                int id = int.Parse(Console.ReadLine()!);
                                var livro = repo.BuscarPorId(id);
                                Console.WriteLine($"{livro.Titulo} - {livro.Autor}");
                            }
                            catch (LivroNaoEncontradoException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case 3:
                            Console.Write("Autor: ");
                            string autor = Console.ReadLine()!;
                            var livrosAutor =
                                repo.BuscarPorAutor(autor);
                            foreach (var livro in livrosAutor)
                            {
                                Console.WriteLine(
                                    $"{livro.Titulo}");
                            }
                            break;
                        /*

                                            case 4:

                                            case 5:

                                                await repo.ListarDisponiveisAsync();

                                                break;

                                            case 6:
                        */

                        case 0:
                            Console.WriteLine("Saindo do Sistema.");
                            break;

                    }
                }



            }
        }
    }


}
