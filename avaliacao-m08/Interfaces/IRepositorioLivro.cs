using avaliacao_m08.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avaliacao_m08.Interfaces
{
    public interface IRepositorioLivro
    {
        public void Adicionar(Livro livro);
        public Livro BuscarPorId(int id);
        public List<Livro> ListarTodos();
        public List<Livro> BuscarPorAutor(string autor);
    }
}
