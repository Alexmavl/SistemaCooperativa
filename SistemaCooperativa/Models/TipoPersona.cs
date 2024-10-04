namespace SistemaCooperativa.Models
{
    public class TipoPersona
    {
        public int IdTipoPersona { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Persona> Personas { get; set; }
    }
}
