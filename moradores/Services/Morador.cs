namespace moradores.Services
{
    public class Morador
    {
        public int Id { get; set; }
        required public string Nome { get; set; }
        required public string CPF { get; set; }
        public int Residencia { get; set; }
        public int Divida { get; set; }
    }
}