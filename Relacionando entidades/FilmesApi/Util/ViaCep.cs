using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Util
{
    public class ViaCep
    {

        static HttpClient client = new HttpClient();
        public async Task<ReadEnderecoCepDTO> BuscarEnderecoPeloCep(string cep)
        {
            ReadEnderecoCepDTO endereco = null;
            HttpResponseMessage resposta = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            if (resposta.IsSuccessStatusCode)
            {
                endereco = await resposta.Content.ReadAsAsync<ReadEnderecoCepDTO>();
            }

            return endereco;
        }
    }
}
