using System.ComponentModel.DataAnnotations;

namespace Mia_Tecno_Store_App.Models
{
    public class Archivo
    {
        [Key]
        public int id_archivo { get; set; }
        public string nombre { get; set; }
        public string extension { get; set; }
        public double tamanio { get; set; }
        public string ubicacion { get; set; }
    }
}
