namespace SistemaCooperativa.Models
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public int IdTipoPersona { get; set; }
        public TipoPersona TipoPersona { get; set; }

        public int IdEstatus { get; set; }
        public Estatus Estatus { get; set; }
    }
}
