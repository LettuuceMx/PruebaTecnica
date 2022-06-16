namespace PruebaTecnica.Models
{
    public class ModeloMultiple
    {
        public ModelCliente modelCliente { get; set; }
        public ModelDireccion modelDireccion { get; set; }
        public IEnumerable<ModelClienteDireccion> modelClienteDireccions { get; set; }
    }
}
