using residencias.DTO;
using residencias.Infra;
using residencias;

namespace residencias.Services
{
    public class ServResidencia
    {
        public readonly DataContext _dataContext;
        public readonly MoradorHelper _moradorHelper;

        public ServResidencia() 
        {
            _dataContext = GeradorDeServicos.CarregarContexto();
            _moradorHelper = new MoradorHelper();
        }

        public void ValidarDadosResidencia(Residencia residencia)
        {

        }

        public void Inserir(Residencia Residencia)
        {
            ValidarDadosResidencia(Residencia);

            _dataContext.Add(Residencia);

            _dataContext.SaveChanges();
        }

        public void Editar(Residencia Residencia)
        {
            ValidarDadosResidencia(Residencia);

            _dataContext.SaveChanges();
        }
        public ResidenciaView BuscarResidencia(int id)
        {
            var residencia = _dataContext.Residencias.FirstOrDefault(p => p.Id == id) ?? throw new Exception("residencia não encontrada");
            var morador = _moradorHelper.RetornarMoradorComCache(residencia.CodMorador);

            var view = new ResidenciaView()
            {
                Id = residencia.Id,
                CodMorador = residencia.CodMorador,
                Valor = residencia.Valor,
                Metragen = residencia.Metragen,
                Morador = morador
            };
            return view;
        }

        public List<Residencia> BuscarTodos()
        {
            var listaResidencia = _dataContext.Residencias.ToList();

            return listaResidencia;
        }

        internal void Inserir(ResidenciaDTO cadastraResidenciaDto)
        {
            throw new NotImplementedException();
        }
    }
}
