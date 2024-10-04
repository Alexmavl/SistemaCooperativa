using System.ComponentModel.DataAnnotations;

namespace SistemaCooperativa.Models
{
    public class CategoriaProducto
    {
        [Key]
        public int IdCategoriaProducto { get; set; }

        public string Descripcion { get; set; }
    }
}
