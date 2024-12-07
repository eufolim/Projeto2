using residencia.DTO;

namespace residencias.DTO
{
    public class ResidenciaView
    {
        public int Id { get; set; }
        public int Metragen { get; set; }
        public int Valor { get; set; }
        public int Numero { get; set; }
        public int CodMorador { get; set; }
        public bool Ativa { get; set; }
        public MoradorDTO Morador { get; set; }
    }
}