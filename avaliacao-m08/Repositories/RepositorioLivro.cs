using avaliacao_m08.Exceptions;
using avaliacao_m08.Interfaces;
using avaliacao_m08.Modelos;

namespace avaliacao_m08.Repositories
{
    public class RepositorioLivro : IRepositorioLivro
    {
        private List<Livro> livros = new List<Livro>();

        public void Adicionar(Livro livro)
        {
            livros.Add(livro);
        }
        public Livro BuscarPorId(int id)
        {
            var livro = livros
                .FirstOrDefault(l => l.Id == id);

            if (livro == null)
            {
                throw new LivroNaoEncontradoException("Livro não encontrado");
            }

            return livro;
        }
        public List<Livro> ListarTodos()
        {
            return livros
                .OrderBy(l => l.Titulo)
                .ToList();
        }
        public List<Livro> BuscarPorAutor(string autor)
        {
            return livros
                .Where(l => l.Autor.ToLower()
                .Contains(autor.ToLower()))
                .ToList();
        }

        public async Task ListarDisponiveisAsync()
        {
            await Task.Delay(500);

            var disponiveis = livros.Where(l => l.Disponivel);

            foreach (var livro in disponiveis)
            {
                Console.WriteLine($"{livro.Id} - {livro.Titulo}");
            }
        }
    }
}
