namespace SistemaCooperativa.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int IdCategoriaProducto { get; set; }
        public CategoriaProducto CategoriaProducto { get; set; }
    }
}
