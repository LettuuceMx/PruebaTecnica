using Dapper;
using Microsoft.Data.SqlClient;
using PruebaTecnica.Conexion;
using PruebaTecnica.Models;

namespace PruebaTecnica.Repositorio
{
    public interface IFarmacia
    {
        public Task<int> InsertarDatosCliente(ModelCliente cliente);
        public Task<int> InsertarDatosDireccionCliente(ModelDireccion direccion);
        Task<IEnumerable<ModelClienteDireccion>> ObtenerClientes();
    }

    public class TFarmacia : IFarmacia
    {
        private readonly string _cadenaConexion;
        public TFarmacia(IConfiguration configuration)
        {
            _cadenaConexion = configuration.GetConnectionString(CadenaConexion.nombreConexion);
        }

        public async Task<int> InsertarDatosCliente(ModelCliente cliente)
        {
            using var conexion = new SqlConnection(_cadenaConexion);

            var idCliente = await conexion.QueryFirstOrDefaultAsync<int>("INSERT INTO Cliente VALUES (@Nombre,@ApellidoPaterno,@ApellidoMaterno,@FechaNacimiento,@Edad);" +
                "SELECT SCOPE_IDENTITY();", cliente);

            return idCliente;
        }

        public async Task<int> InsertarDatosDireccionCliente(ModelDireccion direccion)
        {
            using var conexion = new SqlConnection(_cadenaConexion);

            var idDireccion = await conexion.QueryFirstOrDefaultAsync<int>("INSERT INTO Direccion VALUES (@idCliente, @Calle,@NumeroExterior,@NumeroInterior,@Estado,@Municipio,@Colonia,@CodigoPostal);" +
                "SELECT SCOPE_IDENTITY();", direccion);

            return idDireccion;
        }

        public async Task<IEnumerable<ModelClienteDireccion>> ObtenerClientes()
        {
            using var conexion = new SqlConnection(_cadenaConexion);

            return await conexion.QueryAsync<ModelClienteDireccion>("select * from Cliente inner join Direccion on Cliente.idCliente = Direccion.idCliente");
        }
    }
}
