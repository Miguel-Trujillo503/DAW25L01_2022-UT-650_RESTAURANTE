namespace L01_2022_UT_650.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int MotoristaId { get; set; }
        public int ClienteId { get; set; }
        public int PlatoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public Cliente? Cliente { get; set; }
        public Motorista? Motorista { get; set; }
        public Plato? Plato { get; set; }
    }
}
