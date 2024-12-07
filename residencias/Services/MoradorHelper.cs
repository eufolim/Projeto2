using Microsoft.Extensions.Caching.Memory;
using static System.Net.WebRequestMethods;
using residencias.Infra;
using residencia.DTO;

namespace residencias.Services
{
    public class MoradorHelper
    {
        private const string _moradoresController = "api/moradores/";
        private IMemoryCache _memoryCache;

        public MoradorHelper()
        {
            _memoryCache = GeradorDeServicos.CarregarServicoDeCache();
        }

        public MoradorDTO RetornarMorador(int codigoMorador)
        {
            var httpClient = new HttpClient();

            var urlMorador = BuscarUrlMorador();

            var url = urlMorador  + _moradoresController + codigoMorador;



            var resposta = httpClient.GetAsync(url).Result;

            if (!resposta.IsSuccessStatusCode)
            {
                throw new Exception("Morador " + codigoMorador+ " não encontrado.");
            }

            if (resposta.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return null;
            }

            var morador = resposta.Content.ReadFromJsonAsync<MoradorDTO>().Result;

            InserirMoradorNoCache(morador);

            return morador;
        }

        public void InserirMoradorNoCache(MoradorDTO moradorDto)
        {
            _memoryCache.Set("Morador" +  moradorDto.Id, moradorDto, TimeSpan.FromHours(1));
        }

        public MoradorDTO RetornarMoradorComCache(int codigoMorador)
        {
            var morador = _memoryCache.Get<MoradorDTO>("Morador" + codigoMorador);

            if (morador != null)
            {
                return morador;
            }

            morador = RetornarMorador(codigoMorador);

            return morador;
        }

        public string BuscarUrlMorador()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            string url = configuration["UrlMorador"];

            return url;
        }
    }
}
