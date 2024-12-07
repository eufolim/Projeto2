using SQLitePCL;
using taxa.Infra;

namespace taxa.Services
{
    public class ServTaxa
    {
        public readonly DataContext _dataContext;

        public readonly ResidenciaHelper _ResidenciaHelper;

        public ServTaxa() 
        {
            _dataContext = GeradorDeServicos.CarregarContexto();
            _ResidenciaHelper = new ResidenciaHelper();
        }

        public void ValidarDadosTaxa(int residencia)
        {
            var Residencia = _ResidenciaHelper.RetornarResidencia(residencia);

            if (Residencia == null || !Residencia.Ativa)
            {
                throw new Exception("Residencia não está ativa");
            }
        }

        public void Inserir(Taxa Taxa)
        {
            //ValidarDadosTaxa(Taxa);

            _dataContext.Add(Taxa);

            _dataContext.SaveChanges();
        }

        public void Editar(Taxa Taxa)
        {
            //ValidarDadosTaxa(Taxa);

            _dataContext.SaveChanges();
        }
        public Taxa BuscarTaxa(int id)
        {
            var Taxa = _dataContext.Taxas.FirstOrDefault(x => x.Id == id);

            return Taxa;
        }

        public List<Taxa> BuscarTodos()
        {
            var listaTaxa = _dataContext.Taxas.ToList();

            return listaTaxa;
        }
    }
}