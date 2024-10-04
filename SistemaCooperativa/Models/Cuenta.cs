namespace SistemaCooperativa.Models
{
    public class Cuenta
    {
        public int IdCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }

        public int IdPersona { get; set; }
        public Persona Persona { get; set; }
    }
}
