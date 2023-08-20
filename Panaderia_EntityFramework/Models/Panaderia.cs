using System.ComponentModel.DataAnnotations;

namespace Panaderia_EntityFramework.Models
{
    public class Panaderia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Disponibilidad { get; set; }
        public string Ingredientes { get; set; }
        public string Alergenos { get; set; }
        public string Tamano { get; set; }
        public string ValorNutricional { get; set; }
        public string Imagen { get; set; }
        
    }
}
