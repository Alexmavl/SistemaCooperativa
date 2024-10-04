namespace SistemaCooperativa.Models
{
    public class Prestamo
    {
        public int IdPrestamo { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        public int IdPersona { get; set; }
        public Persona Persona { get; set; }
        public ICollection<DetallePrestamo> DetallePrestamos { get; set; }
    }
}
