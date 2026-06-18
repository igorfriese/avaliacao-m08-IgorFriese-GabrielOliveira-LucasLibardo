using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avaliacao_m08.Modelos
{
    public class Livro
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public int Ano { get; private set; }
        public bool Disponivel { get; private set; }

        public Livro(int id, string titulo, string autor, int ano)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Disponivel = true;
        }
    }
}
