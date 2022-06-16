using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class ModelCliente
    {
        //public int idCliente { get; set; }
        [Required(ErrorMessage = "Se requiere el campo {0}")]
        [MaxLength(30, ErrorMessage = "{0} puede tener un máximo de 30 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Se requiere el campo {0}")]
        [MaxLength(30, ErrorMessage = "{0} puede tener un máximo de 30 caracteres")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "Se requiere el campo {0}")]
        [MaxLength(30, ErrorMessage = "{0} puede tener un máximo de 30 caracteres")]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "Se requiere el campo {0}")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; } = DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy"));
        [Required(ErrorMessage = "Se requiere el campo {0}")]
        public int Edad { get; set; }
    }
}
