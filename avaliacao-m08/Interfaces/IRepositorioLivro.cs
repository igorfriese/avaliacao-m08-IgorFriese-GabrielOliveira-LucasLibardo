using avaliacao_m08.Modelos;

namespace avaliacao_m08.Interfaces
{
    public interface IRepositorioLivro
    {
        public void Adicionar(Livro livro);
        public Livro BuscarPorId(int id);
        public List<Livro> ListarTodos();
        public List<Livro> BuscarPorAutor(string autor);
        public Task ListarDisponiveisAsync();
    }
}
