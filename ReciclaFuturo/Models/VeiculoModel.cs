namespace ReciclaFuturo.Models
{
    public class VeiculoModel
    {
        public int VeiculoId { get; set; }
        public string PlacaVeiculo { get; set; }
        public float CapacidadeVeiculo { get; set; }
        public string NomeMotorista { get; set; }

        public List<RotaModel> Rotas { get; set; } = new List<RotaModel>();
    }
}
