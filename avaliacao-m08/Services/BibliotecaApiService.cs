using System.Text.Json;

namespace avaliacao_m08.Services
{
    public class BibliotecaApiService
    {
        private readonly HttpClient httpClient = new();

        public async Task BuscarDetalhesApiAsync(string titulo)
        {
            try
            {
                string tituloFormatado = titulo.Replace(" ", "+");

                string url = $"https://openlibrary.org/search.json?title={tituloFormatado}";

                var resposta = await httpClient.GetStringAsync(url);

                using JsonDocument doc = JsonDocument.Parse(resposta);

                var docs = doc.RootElement.GetProperty("docs");

                if (docs.GetArrayLength() == 0)
                {
                    Console.WriteLine("Livro não encontrado.");
                    return;
                }

                var livro = docs[0];

                string tituloLivro = livro.GetProperty("title").GetString() ?? "";

                int ano = 0;

                if (livro.TryGetProperty("first_publish_year", out JsonElement anoElement))
                {
                    ano = anoElement.GetInt32();
                }

                string autor = "Não informado";

                if (livro.TryGetProperty("author_name", out JsonElement autores) && autores.GetArrayLength() > 0)
                {
                    autor = autores[0].GetString() ?? "";
                }

                Console.WriteLine($"\nTítulo: {tituloLivro}");
                Console.WriteLine($"Autor: {autor}");
                Console.WriteLine($"Ano: {ano}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro ao acessar API: {ex.Message}");
            }
        }
    }
}