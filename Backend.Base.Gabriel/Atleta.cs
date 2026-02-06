using Backend.Infra.Base.Interfaces;

namespace Backend.Infra.Base.Gabriel
{
    public class Atleta : BaseNamed, IBaseNamed
    {
        public int Numero { get; set; }
        public string? Posicao { get; set; }
        public int QtdCartaoVermelho { get; set; }
        public int QtdCartaoAmarelo { get; set; }
    }
}