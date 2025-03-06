using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Configuration.Provider;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
// using System.Configuration; se agrega por conecctionString
namespace DL
{
    public class Conexion
    {
        public static string GetStringConnection()
        {
            //SqlCommand cmd = new SqlCommand("QueryUsuario", conection);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dataTable = new DataTable();s
            //adapter.Fill(dataTable);

            //< add name = "MBlancoProgramacionCapasSeptiembre" connectionString = "Data Source=.;Initial Catalog=MBlancoProgramacionCapasSeptiembre;
            //User ID=sa;Password=pass@word1;Encrypt=False;" providerName = "System.Data.SqlClient" />

            string conexion = ConfigurationManager.ConnectionStrings["MBlancoProgramacionCapasSeptiembre"].ConnectionString;
            return conexion;

        }

    }
}
