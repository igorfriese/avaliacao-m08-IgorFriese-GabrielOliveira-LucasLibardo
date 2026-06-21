using avaliacao_m08.Exceptions;
using avaliacao_m08.Modelos;
using avaliacao_m08.Repositories;
using avaliacao_m08.Services;
using System;
using System.Xml;

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

                        var livrosAutor = repo.BuscarPorAutor(autor);

                        foreach (var livro in livrosAutor)
                        {
                            Console.WriteLine(
                                $"{livro.Titulo}");
                        }
                        break;

                    case 4:
                        await repositorio.ListarDisponiveisAsync();
                        break;

                    case 5:
                        Console.Write("Título: ");
                        string titulo = Console.ReadLine()!;

                        await apiService.BuscarDetalhesApiAsync(titulo);

                        break;

                    case 6:
                        var novoLivro = new Livro();
                        Console.Write("Id: ");
                        novoLivro.Id = int.Parse(Console.ReadLine()!);

                        Console.Write("Título: ");
                        novoLivro.Titulo = Console.ReadLine()!;

                        Console.Write("Autor: ");
                        novoLivro.Autor = Console.ReadLine()!;

                        Console.Write("Ano: ");
                        novoLivro.Ano = int.Parse(Console.ReadLine()!);

                        Console.Write("Disponível (true/false): ");
                        novoLivro.Disponivel = bool.Parse(Console.ReadLine()!);

                        repositorio.Adicionar(novoLivro);

                        break;

                    case 7:
                        string json = JsonConvert.SerializeObject(repositorio.ObterLivros(), Formatting.Indented);
                        File.WriteAllText(arquivo, json);

                        Console.WriteLine("Acervo salvo.");
                        break;

                    case 0:
                        Console.WriteLine("Saindo do Sistema.");
                        break;

                }
            }
        }
    }
}