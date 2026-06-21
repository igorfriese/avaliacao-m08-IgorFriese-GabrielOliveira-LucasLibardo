using avaliacao_m08.Exceptions;
using avaliacao_m08.Modelos;
using avaliacao_m08.Repositories;
using avaliacao_m08.Services;
using Newtonsoft.Json;

namespace avaliacao_m08
{
    class Program
    {
        static async Task Main(string[] args)
        {
            RepositorioLivro repositorio = new RepositorioLivro();
            BibliotecaApiService apiService = new BibliotecaApiService();
            string arquivo = "livros.json";

            repositorio.Adicionar(new Livro(1, "Dom Casmurro", "Machado de Assis", 1899));
            repositorio.Adicionar(new Livro(2, "O Hobbit", "Tolkien", 1937));
            repositorio.Adicionar(new Livro(3, "Harry Potter e a Pedra Filosofal", "J.K.Rowling", 1997));
            repositorio.Adicionar(new Livro(4, "Christine - O carro assassino", "Stephen King", 1983));
            repositorio.Adicionar(new Livro(5, "Duna", "Frank Herbert", 1965));

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

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        var lista = repositorio.ListarTodos();

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

                            var livro = repositorio.BuscarPorId(id);
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

                        var livrosAutor = repositorio.BuscarPorAutor(autor);

                        if (livrosAutor.Count == 0)
                        {
                            Console.WriteLine("Nenhum livro encontrado.");
                        }
                        else
                        {
                            foreach (var livro in livrosAutor)
                            {
                                Console.WriteLine(livro.Titulo);
                            }
                        }
                        break;

                    case 4:
                        Console.Write("Título: ");
                        string titulo = Console.ReadLine()!;

                        await apiService.BuscarDetalhesApiAsync(titulo);

                        break;

                    case 5:
                        await repositorio.ListarDisponiveisAsync();

                        break;

                    case 6:
                        string json = JsonConvert.SerializeObject(repositorio.ListarTodos(), Formatting.Indented);
                        File.WriteAllText(arquivo, json);

                        Console.WriteLine("Acervo salvo.");
                        break;

                    case 0:
                        Console.WriteLine("Saindo do Sistema.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}