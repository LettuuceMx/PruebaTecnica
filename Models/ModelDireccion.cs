using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class ModelDireccion
    {
        public int idCliente { get; set; }

        [Required(ErrorMessage = "Se requiere el campo {0}")]
        [MaxLength(50, ErrorMessage = "{0} puede tener un máximo de 50 caracteres")]
        public string Calle { get; set; }
        [Required(ErrorMessage = "Se requiere el campo {0}")]
        [MaxLength(5, ErrorMessage = "{0} puede tener un máximo de 5 caracteres")]
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        [Required(ErrorMessage = "Se requiere el campo {0}")]
        [MaxLength(30, ErrorMessage = "{0} puede tener un máximo de 30 caracteres")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Se requiere el campo {0}")]
        [MaxLength(50, ErrorMessage = "{0} puede tener un máximo de 50 caracteres")]
        public string Municipio { get; set; }
        [Required(ErrorMessage = "Se requiere el campo {0}")]
        public string Colonia { get; set; }
        [Required(ErrorMessage = "Se requiere el campo {0}")]
        [MaxLength(5, ErrorMessage = "{0} puede tener un máximo de 5 caracteres")]
        public string CodigoPostal { get; set; }
    }
}
