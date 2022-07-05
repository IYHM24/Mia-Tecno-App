using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mia_Tecno_Store_App.Models
{
    public class Forros
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_forro { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(255, ErrorMessage = "el {0} debe ser almenos {2} y maximo {1} caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "^Referencia es obligatorio")]
        [StringLength(255, ErrorMessage = "el {0} debe ser almenos {2} y maximo {1} caracteres")]
        public string referencia { get; set; }

        [Required(ErrorMessage = "Elige si es tipo Cerrado o abierto")]
        [StringLength(255, ErrorMessage = "el {0} debe ser almenos {2} y maximo {1} caracteres")]
        public string tipo { get; set; }

        [Required(ErrorMessage = "El color es obligatorio")]
        [StringLength(255, ErrorMessage = "el {0} debe ser almenos {2} y maximo {1} caracteres")]
        public string colores { get; set; }

        [Required(ErrorMessage = "la marca es obligatoria")]
        [StringLength(255, ErrorMessage = "el {0} debe ser almenos {2} y maximo {1} caracteres")]
        public string marca { get; set; }
        public string variante { get; set; }
        public string variante_2 { get; set; }

    }
}
