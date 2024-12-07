using Microsoft.Extensions.Caching.Memory;
using static System.Net.WebRequestMethods;
using taxa.Infra;
using taxa.DTO;

namespace taxa.Services
{
    public class ResidenciaHelper
    {
        private const string _ResidenciaesController = "api/Residenciaes/";
        private IMemoryCache _memoryCache;

        public ResidenciaHelper()
        {
            _memoryCache = GeradorDeServicos.CarregarServicoDeCache();
        }

        public ResidenciaDTO RetornarResidencia(int codigoResidencia)
        {
            var httpClient = new HttpClient();

            var urlResidencia = BuscarUrlResidencia();

            var url = urlResidencia  + _ResidenciaesController + codigoResidencia;



            var resposta = httpClient.GetAsync(url).Result;

            if (!resposta.IsSuccessStatusCode)
            {
                throw new Exception("Residencia " + codigoResidencia+ " não encontrado.");
            }

            if (resposta.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return null;
            }

            var residencia = resposta.Content.ReadFromJsonAsync<ResidenciaDTO>().Result;

            InserirResidenciaNoCache(residencia);

            return residencia;
        }

        public void InserirResidenciaNoCache(ResidenciaDTO ResidenciaDto)
        {
            _memoryCache.Set("Residencia" +  ResidenciaDto.Id, ResidenciaDto, TimeSpan.FromHours(1));
        }

        public ResidenciaDTO RetornarResidenciaComCache(int codigoResidencia)
        {
            var Residencia = _memoryCache.Get<ResidenciaDTO>("Residencia" + codigoResidencia);

            if (Residencia != null)
            {
                return Residencia;
            }

            Residencia = RetornarResidencia(codigoResidencia);

            return Residencia;
        }

        public string BuscarUrlResidencia()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            string url = configuration["UrlResidencia"];

            return url;
        }
    }
}