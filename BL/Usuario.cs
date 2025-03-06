using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;


namespace BL
{
    public class Usuario
    {
        //metodo
        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetStringConnection()))
                {
                    SqlCommand cmd = new SqlCommand("AddUsuario", context);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Tel", usuario.Telefono);

                    context.Open();

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
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
        public static void Add(ML.Usuario usuario)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection("Data Source=.;Initial Catalog=MBlancoProgramacionCapasSeptiembre;User ID=sa;Password=pass@word1;Encrypt=False;"))
                {
                    SqlCommand cmd = new SqlCommand("insert into Usuario(Nombre,ApPaterno ,ApMaterno,Tel) values (@Nombre,@ApPaterno,@ApMaterno, @Tel)", conection);
                    //cmd.CommandType = CommandType.Text; El sqlcommand es de tipo text ya cambia cunado es procedure
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Tel", usuario.Telefono);

                    conection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

        }
        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (SqlConnection conection = new SqlConnection(DL.Conexion.GetStringConnection()))
                {
                    SqlCommand cmd = new SqlCommand("UpdateUsuario", conection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Tel", usuario.Telefono);

                    conection.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
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
        public static void Update(ML.Usuario usuario)
        {
            try
            {

                using (SqlConnection conection = new SqlConnection("Data Source=.;Initial Catalog=MBlancoProgramacionCapasSeptiembre;User " +
                    "ID=sa;Password=pass@word1;Encrypt=False;"))
                {
                    SqlCommand cmd = new SqlCommand("update Usuario set Nombre = @Nombre, ApPaterno = @ApPaterno, ApMaterno=@ApMaterno, Tel = @Tel " +
                        "where IdUsuario = @IdUsuario", conection);
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Tel", usuario.Telefono);

                    conection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

        }
        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conection = new SqlConnection(DL.Conexion.GetStringConnection()))
                {
                    SqlCommand cmd = new SqlCommand("DeleteUsuario", conection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    conection.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
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
        public static void Delete(ML.Usuario usuario)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection("Data Source=.;Initial Catalog=MBlancoProgramacionCapasSeptiembre;User" +
                    " ID=sa;Password=pass@word1;Encrypt=False;"))
                {
                    SqlCommand cmd = new SqlCommand("delete from Usuario where IdUsuario = @IdUsuario", conection);
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);

                    conection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

            }
        }
        public static ML.Result SowData()
        {
            {
                ML.Result result = new ML.Result();
                try
                {
                    using (SqlConnection conection = new SqlConnection(DL.Conexion.GetStringConnection()))
                    {
                        SqlCommand cmd = new SqlCommand("QueryUsuarios", conection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0) //Trajo infrormacion
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = Convert.ToInt32(row[0]);
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.Telefono = row[4].ToString();

                                result.Objects.Add(usuario);
                            }
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
        }
        public static ML.Result GetUserId(int IdUsuario)
        {
            {
                ML.Result result = new ML.Result();
                try
                {
                    using (SqlConnection conection = new SqlConnection(DL.Conexion.GetStringConnection()))
                    {
                        SqlCommand cmd = new SqlCommand("QueryUsuario", conection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0) //Trajo informacion
                        {
                            DataRow row = dataTable.Rows[0];
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = Convert.ToInt32(row[0]);
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.Telefono = row[4].ToString();

                            result.Object = usuario;//boxing
                                                    //Guarda el registro en object

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
        }
        //
        public static ML.Result UsuarioGetAll()
        {
            {
                ML.Result result = new ML.Result();
                try
                {
                    using (SqlConnection conection = new SqlConnection(DL.Conexion.GetStringConnection()))
                    {
                        SqlCommand cmd = new SqlCommand("UsuarioGetAll", conection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0) //Trajo infrormación
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = Convert.ToInt32(row[0]);
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                //usuario.FechaNacimiento = row[4].ToString();
                                usuario.FechaNacimiento = row[4].ToString() != " " ? row[4].ToString() : null; //Operador ternario valida si un campo esta vacio 
                                usuario.Celular = row[5].ToString();
                                usuario.UserName = row[6].ToString();
                                usuario.Email = row[7].ToString();
                                //usuario.Password = row[8].ToString();
                                usuario.Password = row[8].ToString() != " " ? row[8].ToString() : null;
                                usuario.Sexo = row[9].ToString();
                                usuario.Telefono = row[10].ToString();
                                usuario.CURP = row[11].ToString();
                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = Convert.ToInt32(row[12]);  //Herencia por atributo
                                usuario.Rol.Nombre = row[13].ToString();
                                usuario.Imagen = row[14].ToString() != "" ? (byte[])row[14] : null;
                                result.Objects.Add(usuario);
                            }
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
        }
        public static ML.Result UsuarioAdd(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetStringConnection()))
                {
                    SqlCommand cmd = new SqlCommand("UsuarioAdd", context);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("CURP", usuario.CURP);
                    // se tiene que inicializar la Herencia por atributos 
                    cmd.Parameters.AddWithValue("IdRol", usuario.Rol.IdRol);  //Herencia por atributo
                    cmd.Parameters.AddWithValue("Imagen", usuario.Imagen);


                    context.Open();

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
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
        public static ML.Result UsuarioUpdate(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (SqlConnection conection = new SqlConnection(DL.Conexion.GetStringConnection()))
                {
                    SqlCommand cmd = new SqlCommand("UsuarioUpdate", conection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("CURP", usuario.CURP);
                    // se tiene que inicializar la Herencia por atributos 
                    cmd.Parameters.AddWithValue("IdRol", usuario.Rol.IdRol);
                    cmd.Parameters.AddWithValue("Imagen", usuario.Imagen);


                    conection.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
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
        public static ML.Result GetById(int IdUsuario)
        {
            {
                ML.Result result = new ML.Result();
                try
                {
                    using (SqlConnection conection = new SqlConnection(DL.Conexion.GetStringConnection()))
                    {
                        SqlCommand cmd = new SqlCommand("GetById", conection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0) //Trajo informacion
                        {
                            DataRow row = dataTable.Rows[0];
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = Convert.ToInt32(row[0]);
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            //usuario.FechaNacimiento = row[4].ToString();
                            usuario.FechaNacimiento = row[4].ToString() != " " ? row[4].ToString() : null; //Operador ternario valida si un campo esta vacio 
                            usuario.Celular = row[5].ToString();
                            usuario.UserName = row[6].ToString();
                            usuario.Email = row[7].ToString();
                            //usuario.Password = row[8].ToString();
                            usuario.Password = row[8].ToString() != " " ? row[8].ToString() : null;
                            usuario.Sexo = row[9].ToString();
                            usuario.Telefono = row[10].ToString();
                            usuario.CURP = row[11].ToString();
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = Convert.ToInt32(row[12]);  //Herencia por atributo
                            usuario.Imagen = row[13].ToString() != "" ? (byte[])row[13] : null;
                            result.Object = usuario;//boxing
                                                    //Guarda el registro en object

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
        }
        public static ML.Result UsuarioDelete(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conection = new SqlConnection(DL.Conexion.GetStringConnection()))
                {
                    SqlCommand cmd = new SqlCommand("DeleteUsuario", conection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    conection.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
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

        //Entity Framework Store porcedure 

        public static ML.Result GetAllEFSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                var listaUsuario = context.UsuarioGetAll(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno).ToList();
                if (listaUsuario.Count > 0)
                {
                    result.Objects = new List<object>();

                    foreach (var usuarioBD in listaUsuario)
                    {

                        ML.Usuario usuario1 = new ML.Usuario();

                        usuario1.IdUsuario = usuarioBD.IdUsuario;
                        usuario1.Nombre = usuarioBD.NombreUsuario;
                        usuario1.ApellidoPaterno = usuarioBD.ApellidoPaterno;
                        usuario1.ApellidoMaterno = usuarioBD.ApellidoMaterno;
                        usuario1.FechaNacimiento = usuarioBD.FechaNacimiento;
                        usuario1.Celular = usuarioBD.Celular;
                        usuario1.UserName = usuarioBD.UserName;
                        usuario1.Email = usuarioBD.Email;
                        usuario1.Password = usuarioBD.Password;
                        usuario1.Sexo = usuarioBD.Sexo;
                        usuario1.Telefono = usuarioBD.Telefono;
                        usuario1.CURP = usuarioBD.CURP;
                        usuario1.Estatus = (bool)usuarioBD.Estatus;
                        usuario1.Rol = new ML.Rol();
                        usuario1.Rol.IdRol = usuarioBD.IdRol.Value;
                        usuario1.Rol.Nombre = usuarioBD.NombreRol;
                        usuario1.Imagen = usuarioBD.Imagen;
                        usuario1.Direccion = new ML.Direccion();
                        usuario1.Direccion.IdDireccion = usuarioBD.IdDireccion ?? 0;
                        usuario1.Direccion.Calle = usuarioBD.Calle;
                        usuario1.Direccion.NumeroExterior = usuarioBD.NumeroExterior;
                        usuario1.Direccion.NumeroInterior = usuarioBD.NumeroInterior;
                        usuario1.Direccion.Colonia = new ML.Colonia();
                        usuario1.Direccion.Colonia.IdColonia = usuarioBD.IdColonia ?? 0;
                        usuario1.Direccion.Colonia.Nombre = usuarioBD.ColoniaNombre;
                        usuario1.Direccion.Colonia.CodigoPostal = usuarioBD.CodigoPostal;
                        usuario1.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario1.Direccion.Colonia.Municipio.IdMunicipio = usuarioBD.IdMunicipio ?? 0;
                        usuario1.Direccion.Colonia.Municipio.Nombre = usuarioBD.NombreMunicipio;
                        usuario1.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario1.Direccion.Colonia.Municipio.Estado.IdEstado = usuarioBD.IdEstado ?? 0;
                        usuario1.Direccion.Colonia.Municipio.Estado.Nombre = usuarioBD.NombreEstado;
                        usuario1.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario1.Direccion.Colonia.Municipio.Estado.Pais.IdPais = usuarioBD.IdPais ?? 0;
                        usuario1.Direccion.Colonia.Municipio.Estado.Pais.Nombre = usuarioBD.NombrePais;
                        result.Objects.Add(usuario1);

                    }
                    result.Correct = true;
                }
                else
                {

                    result.Correct = false;
                    result.ErrorMessage = "No se encontraron los registros";
                }
            }
            return result;

        }
        public static ML.Result GetByIdEFSP(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                var listaUsuario = context.GetById(IdUsuario).FirstOrDefault();
                if (listaUsuario != null)
                {
                    ML.Usuario usuario1 = new ML.Usuario();


                    usuario1.IdUsuario = listaUsuario.IdUsuario;
                    usuario1.Nombre = listaUsuario.Nombre;
                    usuario1.ApellidoPaterno = listaUsuario.ApellidoPaterno;
                    usuario1.ApellidoMaterno = listaUsuario.ApellidoMaterno;
                    usuario1.FechaNacimiento = listaUsuario.FechaNacimiento;
                    usuario1.Celular = listaUsuario.Celular;
                    usuario1.UserName = listaUsuario.UserName;
                    usuario1.Email = listaUsuario.Email;
                    usuario1.Password = listaUsuario.Password;
                    usuario1.Sexo = listaUsuario.Sexo;
                    usuario1.Telefono = listaUsuario.Telefono;
                    usuario1.CURP = listaUsuario.CURP;
                    usuario1.Rol = new ML.Rol();
                    usuario1.Rol.IdRol = listaUsuario.IdRol.Value;
                    usuario1.Imagen = listaUsuario.Imagen;

                    result.Object = usuario1;
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontraron los registros";
                }
            }
            return result;
        }
        public static ML.Result AddEFSP(ML.Usuario usuario)
        {
            ML.Result result = new Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                var querryInsert = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Celular,
                usuario.UserName, usuario.Email, usuario.Password, usuario.Sexo, usuario.Telefono, usuario.CURP, usuario.Rol.IdRol, usuario.Imagen);
                if (querryInsert > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontrarion registros";
                }
            }

            return result;
        }
        public static ML.Result UpdateEFSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                var querryUpdate = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Celular,
                        usuario.UserName, usuario.Email, usuario.Password, usuario.Sexo, usuario.Telefono, usuario.CURP, usuario.Rol.IdRol, usuario.Imagen);
                if (querryUpdate > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No Se encontraron registros";
                }

            }

            return result;
        }
        public static ML.Result DeleteEFSP(int IdUsuario)
        {
            Result result = new ML.Result();

            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {

                var querryDelete = context.UsuarioDelete(IdUsuario);
                if (querryDelete > 0)
                {

                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encotraron registros";


                }
            }

            return result;
        }

        public static ML.Result UpdateEstatus(int IdUsuario)
        {
            Result result = new Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                var querryUpdateEstatus = context.UsuarioUpdateEstatus(IdUsuario);
                if (querryUpdateEstatus > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se actualizó el estatus del usuario";
                }
            }
            return result;
        }





        // EntityFramework LINQ

        public static ML.Result GetAllEFLinq()
        {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                var querryUsuario = (from usuarioBD in context.Usuarios // se hacer un join en Linq
                                     join rolBD in context.Rols
                                     on usuarioBD.IdRol equals rolBD.IdRol

                                     select usuarioBD).ToList();

                if (querryUsuario.Count > 0)
                {
                    result.Objects = new List<object>();
                    foreach (var usuario in querryUsuario)
                    {
                        ML.Usuario usuario1 = new ML.Usuario();
                        usuario1.IdUsuario = usuario.IdUsuario;
                        usuario1.Nombre = usuario.Nombre;
                        usuario1.ApellidoPaterno = usuario.ApellidoPaterno;
                        usuario1.ApellidoMaterno = usuario.ApellidoMaterno;
                        usuario1.FechaNacimiento = usuario.FechaNacimiento != null ? usuario.FechaNacimiento.Value.ToString("dd-MM-yyyy") : null; //operador ternario
                        usuario1.Celular = usuario.Celular;
                        usuario1.UserName = usuario.UserName;
                        usuario1.Email = usuario.Email;
                        usuario1.Password = usuario.Password;
                        usuario1.Sexo = usuario.Sexo;
                        usuario1.Telefono = usuario.Telefono;
                        usuario1.CURP = usuario.CURP;
                        usuario1.Rol = new ML.Rol();
                        usuario1.Rol.IdRol = usuario.IdRol.Value;
                        usuario1.Rol.Nombre = usuario.Rol.Nombre;
                        usuario1.Imagen = usuario.Imagen;


                        result.Objects.Add(usuario1);

                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontro registros";
                }
                return result;
            }

        }

        public static ML.Result GetByIdEFLinq(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                var querryUsuario = (from usuarioBD in context.Usuarios
                                     where usuarioBD.IdUsuario == IdUsuario
                                     select usuarioBD).FirstOrDefault();

                if (querryUsuario != null)
                {
                    ML.Usuario usuario1 = new ML.Usuario();
                    usuario1.IdUsuario = querryUsuario.IdUsuario;
                    usuario1.Nombre = querryUsuario.Nombre;
                    usuario1.ApellidoPaterno = querryUsuario.ApellidoPaterno;
                    usuario1.ApellidoMaterno = querryUsuario.ApellidoMaterno;
                    usuario1.FechaNacimiento = querryUsuario.FechaNacimiento != null ? querryUsuario.FechaNacimiento.Value.ToString("dd-MM-yyyy") : null; //operador ternario
                    usuario1.Celular = querryUsuario.Celular;
                    usuario1.UserName = querryUsuario.UserName;
                    usuario1.Email = querryUsuario.Email;
                    usuario1.Password = querryUsuario.Password;
                    usuario1.Sexo = querryUsuario.Sexo;
                    usuario1.Telefono = querryUsuario.Telefono;
                    usuario1.CURP = querryUsuario.CURP;
                    usuario1.Rol = new ML.Rol();
                    usuario1.Rol.IdRol = querryUsuario.IdRol.Value;
                    usuario1.Rol.Nombre = querryUsuario.Rol.Nombre;
                    usuario1.Imagen = querryUsuario.Imagen;


                    result.Object = usuario1;
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

        public static ML.Result AddEFLinq(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            //usuario.Rol = new ML.Rol();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {

                DL_EF.Usuario usuario1 = new DL_EF.Usuario();
                //usuario1.IdUsuario = usuario.IdUsuario;
                usuario1.Nombre = usuario.Nombre;
                usuario1.ApellidoPaterno = usuario.ApellidoPaterno;
                usuario1.ApellidoMaterno = usuario.ApellidoMaterno;
                usuario1.FechaNacimiento = DateTime.Now;
                usuario1.Celular = usuario.Celular;
                usuario1.UserName = usuario.UserName;
                usuario1.Email = usuario.Email;
                usuario1.Password = usuario.Password;
                usuario1.Sexo = usuario.Sexo;
                usuario1.Telefono = usuario.Telefono;
                usuario1.CURP = usuario.CURP;
                usuario1.IdRol = usuario.Rol.IdRol != 0 ? usuario.Rol.IdRol : 2;
                //usuario1.Rol.Nombre = usuario.Rol.Nombre;
                usuario1.Imagen = usuario.Imagen != null ? usuario.Imagen : null; // verificar +++
                usuario1.Estatus = true;

                context.Usuarios.Add(usuario1);

                int querryAdd = context.SaveChanges();
                if (querryAdd > 0)
                {
                    result.Correct = true;
                    result.Object = usuario1.IdUsuario;
                    //envia correo al agregar usuario
                    bool confirmacionCorreo = BL.Correo.ConfirmacionCorreo(usuario);
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontraron los registros";

                }

            }

            return result;
        }

        public static ML.Result UpdateEFLinq(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {

                var querryUsuario = (from usuarioBD in context.Usuarios
                                     where usuarioBD.IdUsuario == usuario.IdUsuario
                                     select usuarioBD).FirstOrDefault();

                querryUsuario.IdUsuario = usuario.IdUsuario;
                querryUsuario.Nombre = usuario.Nombre;
                querryUsuario.ApellidoPaterno = usuario.ApellidoPaterno;
                querryUsuario.ApellidoMaterno = usuario.ApellidoMaterno;
                querryUsuario.FechaNacimiento = DateTime.Now;
                querryUsuario.Celular = usuario.Celular;
                querryUsuario.UserName = usuario.UserName;
                querryUsuario.Email = usuario.Email;
                querryUsuario.Password = usuario.Password;
                querryUsuario.Sexo = usuario.Sexo;
                querryUsuario.Telefono = usuario.Telefono;
                querryUsuario.CURP = usuario.CURP;
                querryUsuario.IdRol = usuario.Rol.IdRol;
                querryUsuario.Imagen = usuario.Imagen;

                int querryInsert = context.SaveChanges();
                if (querryInsert > 0)
                {
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

        public static ML.Result DeleteEFLinq(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {

                var querryUsuario = (from usuarioBD in context.Usuarios
                                     where usuarioBD.IdUsuario == IdUsuario
                                     select usuarioBD).FirstOrDefault();
                if (querryUsuario != null)
                {
                    context.Usuarios.Remove(querryUsuario);
                }
                int querryInsert = context.SaveChanges();
                if (querryInsert > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Nose encotraron registros";
                }

            }
            return result;
        }

        public static ML.Result GetAllLinq()
        {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                var querryUsuario = (from usuarioBD in context.Usuarios // se hacer un join en Linq
                                     join rolBD in context.Rols
                                     on usuarioBD.IdRol equals rolBD.IdRol
                                     join direccionBD in context.Direccions on usuarioBD.IdUsuario equals direccionBD.IdUsuario
                                     into direccionTable
                                     from direccionBD in direccionTable.DefaultIfEmpty()

                                     join coloniaBD in context.Colonias on direccionBD.IdColonia equals coloniaBD.IdColonia
                                     into coloniaTable
                                     from coloniaBD in coloniaTable.DefaultIfEmpty()

                                     join municipioBD in context.Municipios on coloniaBD.IdMunicipio equals municipioBD.IdMunicipio
                                     into municipioTable
                                     from municipioBD in municipioTable.DefaultIfEmpty()

                                     join estadoBD in context.Estadoes on municipioBD.IdEstado equals estadoBD.IdEstado
                                     into estadoTable
                                     from estadoBD in estadoTable.DefaultIfEmpty()

                                     join paisBD in context.Pais on estadoBD.IdPais equals paisBD.IdPais
                                     into paisTable
                                     from paisBD in paisTable.DefaultIfEmpty()
                                     select new
                                     {
                                         usuarioBD.IdUsuario,
                                         usuarioBD.Nombre,
                                         usuarioBD.ApellidoPaterno,
                                         usuarioBD.ApellidoMaterno,
                                         usuarioBD.FechaNacimiento,
                                         usuarioBD.Celular,
                                         usuarioBD.UserName,
                                         usuarioBD.Email,
                                         usuarioBD.Password,
                                         usuarioBD.Sexo,
                                         usuarioBD.Telefono,
                                         usuarioBD.CURP,
                                         rolBD.IdRol,
                                         nombreRol = rolBD.Nombre,
                                         usuarioBD.Imagen,
                                         idDireccion = direccionBD != null ? direccionBD.IdDireccion : (int?)null,
                                         direccionCalle = direccionBD.Calle,
                                         numeroExterior = direccionBD.NumeroExterior,
                                         numeroInterior = direccionBD.NumeroInterior,
                                         idColonia = coloniaBD != null ? direccionBD.IdColonia : (int?)null,
                                         nombreColonia = coloniaBD.Nombre,
                                         coloniaBD.CodigoPostal,
                                         idMunicipio = municipioBD != null ? municipioBD.IdMunicipio : (int?)null,
                                         nombreMunicipio = municipioBD.Nombre,
                                         idEstado = estadoBD != null ? estadoBD.IdEstado : (int?)null,
                                         nombreEstado = estadoBD.Nombre,
                                         idPais = paisBD != null ? paisBD.IdPais : (int?)null,
                                         nombrePais = paisBD.Nombre

                                     }

                                     ).ToList();

                if (querryUsuario.Count > 0)
                {
                    result.Objects = new List<object>();
                    foreach (var usuario in querryUsuario)
                    {
                        ML.Usuario usuario1 = new ML.Usuario();
                        usuario1.IdUsuario = usuario.IdUsuario;
                        usuario1.Nombre = usuario.Nombre;
                        usuario1.ApellidoPaterno = usuario.ApellidoPaterno;
                        usuario1.ApellidoMaterno = usuario.ApellidoMaterno;
                        usuario1.FechaNacimiento = usuario.FechaNacimiento != null ? usuario.FechaNacimiento.Value.ToString("dd-MM-yyyy") : null; //operador ternario
                        usuario1.Celular = usuario.Celular;
                        usuario1.UserName = usuario.UserName;
                        usuario1.Email = usuario.Email;
                        usuario1.Password = usuario.Password;
                        usuario1.Sexo = usuario.Sexo;
                        usuario1.Telefono = usuario.Telefono;
                        usuario1.CURP = usuario.CURP;
                        usuario1.Rol = new ML.Rol();
                        usuario1.Rol.IdRol = usuario.IdRol;
                        usuario1.Rol.Nombre = usuario.nombreRol;
                        usuario1.Imagen = usuario.Imagen;
                        usuario1.Direccion = new ML.Direccion();
                        usuario1.Direccion.IdDireccion = usuario.idDireccion ?? 0;
                        usuario1.Direccion.Calle = usuario.direccionCalle;
                        usuario1.Direccion.NumeroExterior = usuario.numeroExterior;
                        usuario1.Direccion.NumeroInterior = usuario.numeroInterior;
                        usuario1.Direccion.Colonia = new ML.Colonia();
                        usuario1.Direccion.Colonia.IdColonia = usuario.idColonia ?? 0;
                        usuario1.Direccion.Colonia.Nombre = usuario.nombreColonia;
                        usuario1.Direccion.Colonia.CodigoPostal = usuario.CodigoPostal;
                        usuario1.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario1.Direccion.Colonia.Municipio.IdMunicipio = usuario.idMunicipio ?? 0;
                        usuario1.Direccion.Colonia.Municipio.Nombre = usuario.nombreMunicipio;
                        usuario1.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario1.Direccion.Colonia.Municipio.Estado.IdEstado = usuario.idEstado ?? 0;
                        usuario1.Direccion.Colonia.Municipio.Estado.Nombre = usuario.nombreEstado;
                        usuario1.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario1.Direccion.Colonia.Municipio.Estado.Pais.IdPais = usuario.idPais ?? 0;
                        usuario1.Direccion.Colonia.Municipio.Estado.Pais.Nombre = usuario.nombrePais;

                        result.Objects.Add(usuario1);

                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontro registros";
                }
                return result;


            }
        }

        public static ML.Result LeerExcel(string connectionString)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (OleDbConnection context = new OleDbConnection(connectionString))
                {
                    string querry = "Select * from [Usuario$]";
                    using (OleDbCommand command = new OleDbCommand())
                    {

                        command.CommandText = querry;
                        command.Connection = context;

                        OleDbDataAdapter adapter = new OleDbDataAdapter();
                        adapter.SelectCommand = command;

                        DataTable tableUsuario = new DataTable();

                        adapter.Fill(tableUsuario);
                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableUsuario.Rows)
                            {

                                ML.Usuario usuario = new ML.Usuario();

                                usuario.Nombre = row[0].ToString();
                                usuario.ApellidoPaterno = row[1].ToString();
                                usuario.ApellidoMaterno = row[2].ToString();
                                usuario.FechaNacimiento = Convert.ToDateTime(row[3]).ToString("dd/MM/yyyy");
                                usuario.Celular = row[4].ToString();
                                usuario.UserName = row[5].ToString();
                                usuario.Email = row[6].ToString();
                                usuario.Password = row[7].ToString();
                                usuario.Sexo = row[8].ToString();
                                usuario.Telefono = row[9].ToString();
                                usuario.CURP = row[10].ToString();
                                result.Objects.Add(usuario);

                            }
                            result.Correct = true;
                        }
                        result.Object = tableUsuario;


                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Correct = true; /*redundancia*/
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        // prueba 

        public static ML.Result AddUsuario(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
                {

                    var queryGetAll = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Celular,
                usuario.UserName, usuario.Email, usuario.Password, usuario.Sexo, usuario.Telefono, usuario.CURP, usuario.Rol.IdRol, usuario.Imagen);

                    if (queryGetAll > 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;

            }
            return result;
        }

        public static ML.Result GetByIdUsuario(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                var queryGetById = (from usuarioBD in context.Usuarios
                                    where usuarioBD.IdUsuario == IdUsuario
                                    select usuarioBD).FirstOrDefault();
                if (queryGetById != null)
                {
                    ML.Usuario usuario = new ML.Usuario();
                    usuario.IdUsuario = queryGetById.IdUsuario;
                    usuario.Nombre = queryGetById.Nombre;
                    result.Object = usuario;
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

        public static ML.Result UpdateUser(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
                {
                    var queryUpdate = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Celular,
                        usuario.UserName, usuario.Email, usuario.Password, usuario.Sexo, usuario.Telefono, usuario.CURP, usuario.Rol.IdRol, usuario.Imagen);
                    if (queryUpdate>0)
                    {
                        result.Correct = true;
                    }
                    else { 
                    result.Correct = false;
                        result.ErrorMessage = "";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;

            }
            return result;
        }

        public static ML.Result Updateusaurio(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                var queryUpdate = (from usuarioBD in context.Usuarios
                                   where usuarioBD.IdUsuario == usuario.IdUsuario
                                   select usuarioBD).FirstOrDefault();
                queryUpdate.Nombre = usuario.Nombre;
                int querySave = context.SaveChanges();

                if (querySave > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se actualizo el registro.";
                }
            }

            return result;
        }

        public static ML.Result DeleteUsuario(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
                {
                    var queryDelete = context.UsuarioDelete(IdUsuario);

                    if (queryDelete > 0)
                    {
                        result.Correct = true;
                    }
                    else { 
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino el registro.";
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

    }

}



