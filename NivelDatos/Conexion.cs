using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NivelDatos
{
    public class Conexion
    {
        public SqlCommand comando;
        protected SqlConnection coneccion;
        public SqlDataAdapter dataadapter;
        public DataTable datatable;

        public Conexion()
        {
            string nombre_server = ConfigurationManager.AppSettings.Get("SERVIDOR");//SERVIDOR Var creada en webconfig
            coneccion = new SqlConnection(@"Database=Ciclismo2009;Server=" + nombre_server + ";Integrated Security=False;" +
                "User ID=UsuarioCiclismo; Password=usuario; Asynchronous Processing=true; MultipleActiveResultSets = true");
            datatable = new DataTable();            
        }
    }
}
