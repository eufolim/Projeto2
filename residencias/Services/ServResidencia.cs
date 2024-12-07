using residencias.Infra;

namespace residencias.Services
{
    public class ServResidencia
    {
        private readonly DataContext _dataContext;

        public ServResidencia() 
        {
            _dataContext = GeradorDeServicos.CarregarContexto();
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
        public Residencia BuscarResidencia(int id)
        {
            var Residencia = _dataContext.Residencias.FirstOrDefault(x => x.Id == id);

            return Residencia;
        }

        public List<Residencia> BuscarTodos()
        {
            var listaResidencia = _dataContext.Residencias.ToList();

            return listaResidencia;
        }
    }
}
