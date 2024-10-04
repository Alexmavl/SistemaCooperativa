namespace SistemaCooperativa.Models
{
    public class DetallePrestamo
    {
        public int IdDetallePrestamo { get; set; }
        public decimal Monto { get; set; }

        public int IdPrestamo { get; set; }
        public Prestamo Prestamo { get; set; }
    }

}
