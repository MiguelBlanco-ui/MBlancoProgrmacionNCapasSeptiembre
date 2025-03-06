using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class Rol
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection connection = new SqlConnection(DL.Conexion.GetStringConnection()))
                {
                    SqlCommand cmd = new SqlCommand("RolGetAll", connection);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in dataTable.Rows)
                        {
                            ML.Rol rol = new ML.Rol();
                            rol.IdRol = Convert.ToInt32(row[0]);
                            rol.Nombre = row[1].ToString();
                            rol.FechaRegistro = row[2].ToString();
                            result.Objects.Add(rol);

                        }
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro información sobre Rol";

                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
                result.ErrorMessage = ex.Message;


            }
            return result;

        }

        public static ML.Result RolGetById(int IdRol)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conection = new SqlConnection(DL.Conexion.GetStringConnection()))
                {
                    SqlCommand cmd = new SqlCommand("RolGetById", conection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdRol", IdRol);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];
                        ML.Rol rol = new ML.Rol();
                        rol.IdRol = Convert.ToInt32(row[0]);
                        rol.Nombre = row[1].ToString();
                        rol.FechaRegistro = row[2].ToString();

                        result.Object = rol;

                        result.Correct = true;


                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro información";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }

        public static ML.Result RolAdd(ML.Rol rol)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conection = new SqlConnection(DL.Conexion.GetStringConnection()))
                {
                    SqlCommand cmd = new SqlCommand("RolAdd", conection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Nombre", rol.Nombre);
                    cmd.Parameters.AddWithValue("FechaRegistro", rol.FechaRegistro);

                    conection.Open();

                    int filasAfectada = cmd.ExecuteNonQuery();
                    if (filasAfectada > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }

        public static ML.Result RolUpdate(ML.Rol rol)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conection = new SqlConnection(DL.Conexion.GetStringConnection()))
                {
                    SqlCommand cmd = new SqlCommand("RolUpdate", conection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdRol", rol.IdRol);
                    cmd.Parameters.AddWithValue("Nombre", rol.Nombre);
                    cmd.Parameters.AddWithValue("FechaRegistro", rol.FechaRegistro);

                    conection.Open();

                    int filasAfectada = cmd.ExecuteNonQuery();
                    if (filasAfectada > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }

        public static ML.Result Delete(int IdRol)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conection = new SqlConnection(DL.Conexion.GetStringConnection()))
                {
                    SqlCommand cmd = new SqlCommand("RolDelete", conection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdRol", IdRol);
                    conection.Open();

                    int filasAfectada = cmd.ExecuteNonQuery();
                    if (filasAfectada > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }

        //EntityFramework Store Procedure
        public static ML.Result GetAllEFSP()
        {
            ML.Result result = new Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                var listaRol = context.RolGetAll().ToList();
                if (listaRol.Count > 0)
                {
                    result.Objects = new List<object>();

                    foreach (var rol in listaRol)
                    {
                        ML.Rol rol1 = new ML.Rol();
                        rol1.IdRol = rol.IdRol;
                        rol1.Nombre = rol.Nombre;
                        rol1.FechaRegistro = rol.FechaRegistro;

                        result.Objects.Add(rol1);
                    }

                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encotraron registros";
                }

                return result;
            }

        }

        public static ML.Result GetByIdEFSP(int IdRol) {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities()) { 

            var listaRol = context.RolGetById(IdRol).FirstOrDefault();
                if (listaRol != null)
                {
                    ML.Rol rol1 = new ML.Rol();

                    rol1.IdRol = listaRol.IdRol;
                    rol1.Nombre = listaRol.Nombre;
                    rol1.FechaRegistro = listaRol.FechaRegistro;

                    result.Object = rol1;
                    result.Correct = true;

                }
                else { 
                 result.Correct = false;
                    result.ErrorMessage = "No se encotraron registros";
                }
            }
                return result;
        }

        public static ML.Result AddEFSP(ML.Rol rol) {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities()) {

                var querryInsert = context.RolAdd(rol.Nombre,rol.FechaRegistro);
                if (querryInsert > 0) { 

                result.Correct=true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encotraron las registros";
                }
            }
            return result;
        }

        public static ML.Result UpdateEFSP(ML.Rol rol) {
            ML.Result result = new ML.Result();

            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities()) {

                var querryUpdate = context.RolUpdate(rol.IdRol, rol.Nombre, rol.FechaRegistro);
                if (querryUpdate > 0)
                {
                    result.Correct = true;
                }
                else { 
                result.Correct = false;
                    result.ErrorMessage = "No se encontraron registros";
                }
            }

                return result;
        }

        public static ML.Result DeleteEFSP(int IdRol) {
 
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities()) {
               
                var querryDelete = context.RolDelete(IdRol);
                if (querryDelete > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct= false;
                    result.ErrorMessage = "No se encontraron registros";
                }
            }
                return result;
        }


        //EntityFramework LINQ

        public static ML.Result GetAllEFLinq() {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities()) { 

                var querryRol = (from rolBD in context.Rols
                                  select rolBD).ToList();

                if (querryRol.Count > 0)
                { result.Objects = new List<object>();

                    foreach (var rol in querryRol) { 

                        ML.Rol rol1 = new ML.Rol();

                        rol1.IdRol = rol.IdRol;
                        rol1.Nombre = rol.Nombre;
                        rol1.FechaRegistro =rol.FechaRegistro.ToString("dd-MM-yyyy");


                     result.Objects.Add(rol1);
                    }

                    result.Correct = true;
                }
                else {
                    result.Correct = false;
                    result.ErrorMessage = "No se en conraron registros";
                }

            }
                return result;
        }

        public static ML.Result GetByIdEFLinq(int IdRol) {
            ML.Result result = new Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities()) {

                var querryRol = (from rolDB in context.Rols
                                 where rolDB.IdRol == IdRol
                                 select rolDB).FirstOrDefault();

                if (querryRol != null) {

                    ML.Rol rol1 = new ML.Rol();

                    rol1.IdRol = querryRol.IdRol;
                    rol1.Nombre = querryRol.Nombre;
                    rol1.FechaRegistro = querryRol.FechaRegistro.ToString("dd-MM-yyyy");


                    result.Object = rol1;
                    result.Correct = true;

                }
                else {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontraron registros";
                }



            }
        
                return result;     
        }

        public static ML.Result AddEFLinq(ML.Rol rol) {
            ML.Result result = new Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                DL_EF.Rol rol1 = new DL_EF.Rol();
                rol1.Nombre = rol.Nombre;
                rol1.FechaRegistro = DateTime.Now;

                context.Rols.Add(rol1); 
                int querryInsert= context.SaveChanges();
                if (querryInsert > 0)
                {
                    result.Correct= true;
                }
                else {
                    result.Correct= false;
                    result.ErrorMessage = "No se encotraron registros";
                }

            }

            return result;
        }

        public static ML.Result UpdateEFLinq(ML.Rol rol) {
           ML.Result result= new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                var querryRol = ( from rolDB in context.Rols
                                  where rolDB.IdRol==rol.IdRol
                                  select rolDB).FirstOrDefault();

                //querryRol.IdRol = rol.IdRol;
                querryRol.Nombre = rol.Nombre;
                querryRol.FechaRegistro= DateTime.Now;

                int querryInsert = context.SaveChanges();

                if (querryInsert > 0) { 
                     result.Correct = true;
                }
                else
                {
                     result.Correct = false;
                    result.ErrorMessage = "No se encontraron registros";
                }
            }


                return result;
        }

        public static ML.Result DeleteEFLinq(ML.Rol rol) {
            ML.Result result = new ML.Result();

            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                var querryRol = (from rolDB in context.Rols
                                 where rolDB.IdRol== rol.IdRol
                                 select rolDB).FirstOrDefault();
                if (querryRol != null) { 
                context.Rols.Remove(querryRol);
                }
                int querryInsert = context.SaveChanges();
                if (querryInsert > 0)
                {
                    result.Correct = true;
                }
                else { 
                    result.Correct = false;
                    result.ErrorMessage = "No se encontraron reagistros";
                }

            }
                return result; 
        }

    }
}
