namespace SistemaCooperativa.Models
{
    public class Saldo
    {
        public int IdSaldo { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public int? IdCuenta { get; set; }
        public Cuenta Cuenta { get; set; }
    }
}
