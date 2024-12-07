using moradores.Infra;

namespace moradores.Services
{
    public class ServMorador
    {
        private readonly DataContext _dataContext;

        public ServMorador() 
        {
            _dataContext = GeradorDeServicos.CarregarContexto();
        }

        public void ValidarDadosMorador(Morador morador)
        {
            if(morador.CPF.Length < 11)
            {
                throw new Exception("CPF invalido.");
            }
            if(morador.Nome.Length < 2)
            {
                throw new Exception("Nome invalido.");
            }
        }

        public void Inserir(Morador Morador)
        {
            ValidarDadosMorador(Morador);

            _dataContext.Add(Morador);

            _dataContext.SaveChanges();
        }

        public void Editar(Morador Morador)
        {
            ValidarDadosMorador(Morador);

            _dataContext.SaveChanges();
        }
        public Morador BuscarMorador(int id)
        {
            var Morador = _dataContext.Moradores.FirstOrDefault(x => x.Id == id);

            return Morador;
        }

        public List<Morador> BuscarTodos()
        {
            var listaMorador = _dataContext.Moradores.ToList();

            return listaMorador;
        }
    }
}
