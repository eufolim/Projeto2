namespace residencias.Services
{
    public class Residencia 
    {
        public int Id { get; set; }
        public int Metragen { get; set; }
        public int Valor { get; set; }
        public int Numero { get; set; }
        public bool Ativa { get; set; }
        public int CodMorador { get; set; }
    }
}