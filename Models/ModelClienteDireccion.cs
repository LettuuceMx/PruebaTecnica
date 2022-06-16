namespace PruebaTecnica.Models
{
    public class ModelClienteDireccion
    {
        public int idCliente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; } = DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy"));
        public int Edad { get; set; }

        public int idDireccion { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
    }
}
