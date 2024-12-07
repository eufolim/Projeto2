using Microsoft.Extensions.Caching.Memory;
using static System.Net.WebRequestMethods;
using taxa.Infra;
using taxa.DTO;

namespace taxa.Services
{
    public interface IMoradorHelper
    {
        void InformarDividaNaMorador(int codigoMorador, MoradorDTO InformarDividaDto);
    }

    public class MoradorHelper : IMoradorHelper
    {
        public void InformarDividaNaMorador(int codigoMorador, MoradorDTO InformarDividaDto)
        {
            var httpClient = new HttpClient();

            var url = "http://localhost:5189/api/Morador/InformarDividaMorador/" + codigoMorador;

            var result = httpClient.PostAsJsonAsync(url, InformarDividaDto).Result;

            if (!result.IsSuccessStatusCode)
            {
                var content = result.Content.ReadAsStringAsync().Result;

                throw new Exception("Erro ao inserir movimento financeiro: " + content);
            }
        }

        public void InformarDividaMorador(int codigoMorador, MoradorDTO InformarDividaDto)
        {
            throw new NotImplementedException();
        }
    }
}
