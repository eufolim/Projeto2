namespace taxa.DTO
{
    public class MoradorDTO
    {
        public int Id { get; set; }
        required public string Nome { get; set; }
        required public string CPF { get; set; }
        public int Divida { get; set; }
    }
}