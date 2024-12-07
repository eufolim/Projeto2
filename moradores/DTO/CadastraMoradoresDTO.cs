namespace moradores.DTO
{
    public class CadastraMoradoresDTO
    {
        public int Id { get; set; }
        required public string Nome { get; set; }
        required public string CPF { get; set; }
        public int Residencia { get; set; }
    }
}