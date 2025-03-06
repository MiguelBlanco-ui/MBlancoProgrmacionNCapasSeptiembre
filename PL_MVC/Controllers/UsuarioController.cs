using BL;
using Microsoft.Owin.Security.Provider;
using ML;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Razor.Parser.SyntaxTree;
using System.Data.OleDb;
using System.Data;
using OfficeOpenXml;
using Microsoft.Ajax.Utilities;
using System.IO.Ports;
using System.Runtime.Remoting.Contexts;
using System.Configuration;
using System.Collections;



namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private bool ValidarUsuario(string[] datos) {

            if (!Regex.IsMatch(datos[0], @"^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$")) {
                return false;
            }

            if (!Regex.IsMatch(datos[1], @"^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$")) {
                return false;
            }
            if (!Regex.IsMatch(datos[2], @"^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$"))
            {
                return false;
            }
            if (!Regex.IsMatch(datos[3], @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$"))
            {
                return false;
            }
            if (!Regex.IsMatch(datos[4], @"^\+?[1-9][0-9]{7,14}$"))
            {
                return false;
            }
            if (!Regex.IsMatch(datos[5], @"^[a-zA-Z]+$"))
            {
                return false;
            }
            if (!Regex.IsMatch(datos[6], @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false;
            }

            if (!Regex.IsMatch(datos[7], @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
            {
                return false;
            }

            if (!Regex.IsMatch(datos[8], @"^[a-zA-Z]+$"))
            {
                return false;
            }
            if (!Regex.IsMatch(datos[9], @"^\+?[1-9][0-9]{7,14}$"))
            {
                return false;
            }
            if (!Regex.IsMatch(datos[10], @"[A-Z]{4}[0-9]{6}[HM]{1}[A-Z]{2}[BCDFGHJKLMNPQRSTVWXYZ]{3}([A-Z]{2})?([0-9]{2})?"))
            {
                return false;
            }
            //nombre @"^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$"
            //numero telefonico @"^\+?[1-9][0-9]{7,14}$"
            //curp  @"[A-Z]{4}[0-9]{6}[HM]{1}[A-Z]{2}[BCDFGHJKLMNPQRSTVWXYZ]{3}([A-Z]{2})?([0-9]{2})?"
            //Fecha de nacimiento @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$"
            //email @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
            //password @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"
            return true;
        }

        private bool ValidarExel(ML.Usuario usuario) {
            if (!Regex.IsMatch(usuario.Nombre, @"^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$"))
            {
                return false;
            }

            if (!Regex.IsMatch(usuario.ApellidoPaterno, @"^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$"))
            {
                return false;
            }
            if (!Regex.IsMatch(usuario.ApellidoMaterno, @"^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$"))
            {
                return false;
            }
            if (!Regex.IsMatch(usuario.FechaNacimiento, @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$"))
            {
                return false;
            }
            if (!Regex.IsMatch(usuario.Celular, @"^\+?[1-9][0-9]{7,14}$"))
            {
                return false;
            }
            if (!Regex.IsMatch(usuario.UserName, @"^[a-zA-Z]+$"))
            {
                return false;
            }
            if (!Regex.IsMatch(usuario.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false;
            }

            if (!Regex.IsMatch(usuario.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
            {
                return false;
            }

            if (!Regex.IsMatch(usuario.Sexo, @"^[a-zA-Z]+$"))
            {
                return false;
            }
            if (!Regex.IsMatch(usuario.Telefono, @"^\+?[1-9][0-9]{7,14}$"))
            {
                return false;
            }
            if (!Regex.IsMatch(usuario.CURP, @"[A-Z]{4}[0-9]{6}[HM]{1}[A-Z]{2}[BCDFGHJKLMNPQRSTVWXYZ]{3}([A-Z]{2})?([0-9]{2})?"))
            {
                return false;
            }
            
            return true;

        }

       private ML.Result ProcesarExelOleBD(HttpPostedFileBase archivo) {

            ML.Result result = new Result();
            ML.Usuario usuario = new ML.Usuario();
            result.Objects = new List<object>();
            usuario.UsuariosCorrectos = new List<object>();
            usuario.UsuariosIncorrectos = new List<object>();

            if (archivo != null) { 
            string Extension = Path.GetExtension(archivo.FileName).ToLower(); //ToLower convierte en minusculas
                if (Extension == ".xlsx")
                {

                    //Guardar el archivo en el proyecto con fecha,hora, min y seg para evitar redundancia
                    string filePath = Server.MapPath("~/Excel/") + Path.GetFileNameWithoutExtension(archivo.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

                    if (!System.IO.File.Exists(filePath))// no existe el archivo 
                    {
                        archivo.SaveAs(filePath);
                        // Leer el archivo
                        string cadenaConexion = ConfigurationManager.AppSettings["ConexionExcel"].ToString() + filePath;
                        //cadenaConexion = cadenaConexion+filePath;

                        // todos los usuarios del excel
                         result = BL.Usuario.LeerExcel(cadenaConexion);

                        if (result.Correct)
                        {
                            foreach (ML.Usuario usuarios in result.Objects)
                            {
                                bool validacion = ValidarExel(usuarios);

                                if (validacion)
                                {
                                    usuario.UsuariosCorrectos.Add(
                                        new ML.Usuario
                                        {
                                            Nombre = usuarios.Nombre,
                                            ApellidoPaterno = usuarios.ApellidoPaterno,
                                            ApellidoMaterno = usuarios.ApellidoMaterno,
                                            FechaNacimiento = usuarios.FechaNacimiento,
                                            Celular = usuarios.Celular,
                                            UserName = usuarios.UserName,
                                            Email = usuarios.Email,
                                            Password = usuarios.Password,
                                            Sexo = usuarios.Sexo,
                                            Telefono = usuarios.Telefono,
                                            CURP = usuarios.CURP
                                        }

                                    );
                                }
                                else
                                {
                                    usuario.UsuariosIncorrectos.Add(
                                        new ML.Usuario
                                        {
                                            Nombre = usuarios.Nombre,
                                            ApellidoPaterno = usuarios.ApellidoPaterno,
                                            ApellidoMaterno = usuarios.ApellidoMaterno,
                                            FechaNacimiento = usuarios.FechaNacimiento,
                                            Celular = usuarios.Celular,
                                            UserName = usuarios.UserName,
                                            Email = usuarios.Email,
                                            Password = usuarios.Password,
                                            Sexo = usuarios.Sexo,
                                            Telefono = usuarios.Telefono,
                                            CURP = usuarios.CURP
                                        }

                                    );
                                }
                            }

                            if (usuario.UsuariosIncorrectos.Count == 0)
                            {
                                Session["RutaExcel"] = cadenaConexion;
                            }
                        }

                    }

                }
            }
            return result;
        }
       
        // GET: Usuario
        public ActionResult GetAll()
        { 
            ML.Usuario usuario = new ML.Usuario();
            

            usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
            usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;
            usuario.ApellidoMaterno = (usuario.ApellidoMaterno == null) ? "" : usuario.ApellidoMaterno;

           
            usuario.Rol = new ML.Rol();
        
            //ML.Result result = BL.Usuario.GetAllEFSP(usuario);
            ServicioUsuario.UsuarioClient servicioUsuario = new ServicioUsuario.UsuarioClient();

            ML.Result result = servicioUsuario.UsuarioGetAll(usuario);
            
            usuario.UsuariosCorrectos = new List<object>();
            usuario.UsuariosIncorrectos = new List<object>();

            if (result.Correct == true)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Error = result.ErrorMessage;
            }

            if (Session["RutaTXT"] != null)
            {
                Session.Remove("RutaTXT");
            }
            if (Session["RutaExcel"] != null)
            {
                Session.Remove("RutaExcel");
            }

            return View(usuario);//ML.Materia
        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario, HttpPostedFileBase archivo) {

            usuario.UsuariosCorrectos = new List<object>();
            usuario.UsuariosIncorrectos = new List<object>();

            if (usuario.TipoArchivo == null)
            {
                usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
                usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;
                usuario.ApellidoMaterno = (usuario.ApellidoMaterno == null) ? "" : usuario.ApellidoMaterno;

                //ML.Result result = BL.Usuario.GetAllEFSP(usuario);
                ServicioUsuario.UsuarioClient servicioUsuario = new ServicioUsuario.UsuarioClient();

                ML.Result result = servicioUsuario.UsuarioGetAll(usuario);


                usuario.UsuariosCorrectos = new List<object>();
                usuario.UsuariosIncorrectos = new List<object>();
                if (result.Correct == true)
                {
                    usuario.Usuarios = result.Objects;
                }
                else
                {
                    ViewBag.Error = result.ErrorMessage;
                }
            }
            else {
                string extension = Path.GetExtension(archivo.FileName).ToLower(); // todas la estenciones de los archivos se pasa a minusculas

                if (usuario.TipoArchivo == "txt")
                {
                    if (archivo != null)
                    {
                        if (extension == ".txt")
                        {
                            using (StreamReader file = new StreamReader(archivo.InputStream))
                            {

                                file.ReadLine();

                                //int couter = 0;
                                string line;

                                while ((line = file.ReadLine()) != null)
                                {
                                    var values = line.Split('|');


                                    if (values.Length == 11)
                                    {
                                        bool respuesta = ValidarUsuario(values);
                                        ML.Usuario usuarioTxt = new ML.Usuario

                                        {
                                            Nombre = values[0],
                                            ApellidoPaterno = values[1],
                                            ApellidoMaterno = values[2],
                                            FechaNacimiento = Convert.ToDateTime(values[3]).ToString("dd/MM/yyyy"),
                                            Celular = values[4],
                                            UserName = values[5],
                                            Email = values[6],
                                            Password = values[7],
                                            Sexo = values[8],
                                            Telefono = values[9],
                                            CURP = values[10]
                                        };
                                        if (respuesta)
                                        {
                                            usuario.UsuariosCorrectos.Add(usuarioTxt);
                                        }
                                        else
                                        {
                                            usuario.UsuariosIncorrectos.Add(usuarioTxt);
                                        }

                                    }
                                    else
                                    {
                                        // usuarios con datos incompletos

                                    }

                                }
                            }

                        }
                        else
                        {
                            ViewBag.ErrorTipoArchivo = "Ingresó un archivo incorrecto";
                            return View(usuario);
                        }
                    }
                    else
                    {
                        ViewBag.ErrorTipoArchivo = "No se ingreso archivo";
                        return View(usuario);
                    }


                }
                else
                {
                    if (usuario.TipoArchivo == "Excel" && extension == ".xlsx")
                    {

                        ML.Result resultUsuarios = ProcesarExelOleBD(archivo);

                        if (resultUsuarios.Correct)
                        {
                            foreach (ML.Usuario usuarios in resultUsuarios.Objects)
                            {
                                bool validacion = ValidarExel(usuarios);

                                if (validacion)
                                {
                                    usuario.UsuariosCorrectos.Add(
                                        new ML.Usuario
                                        {
                                            Nombre = usuarios.Nombre,
                                            ApellidoPaterno = usuarios.ApellidoPaterno,
                                            ApellidoMaterno = usuarios.ApellidoMaterno,
                                            FechaNacimiento = usuarios.FechaNacimiento,
                                            Celular = usuarios.Celular,
                                            UserName = usuarios.UserName,
                                            Email = usuarios.Email,
                                            Password = usuarios.Password,
                                            Sexo = usuarios.Sexo,
                                            Telefono = usuarios.Telefono,
                                            CURP = usuarios.CURP
                                        }

                                    );
                                }
                                else
                                {
                                    usuario.UsuariosIncorrectos.Add(
                                        new ML.Usuario
                                        {
                                            Nombre = usuarios.Nombre,
                                            ApellidoPaterno = usuarios.ApellidoPaterno,
                                            ApellidoMaterno = usuarios.ApellidoMaterno,
                                            FechaNacimiento = usuarios.FechaNacimiento,
                                            Celular = usuarios.Celular,
                                            UserName = usuarios.UserName,
                                            Email = usuarios.Email,
                                            Password = usuarios.Password,
                                            Sexo = usuarios.Sexo,
                                            Telefono = usuarios.Telefono,
                                            CURP = usuarios.CURP
                                        }

                                    );
                                }
                            }
                        }
                        //using (var stream = new MemoryStream()) {

                        //    ExcelPackage.LicenseContext =OfficeOpenXml.LicenseContext.NonCommercial;
                        //    archivo.InputStream.CopyTo(stream);

                        //    var package = new ExcelPackage(stream);

                        //    var worksheet = package.Workbook.Worksheets[0];
                        //    var rowCount = worksheet.Dimension.Rows; //RowCount y colCount no son valores numéricos para eso se utliza Dimension
                        //    var colCount = worksheet.Dimension.Columns;

                        //    for (int row = 2; row <= rowCount; row++) {

                        //        var rowData = new List<string>();

                        //        for (int col = 1; col <= colCount; col++) {

                        //            if (col == 4)
                        //            {
                        //                var cellValue = worksheet.Cells[row, col].Value;

                        //                if (cellValue is DateTime FechaNacimento)
                        //                {
                        //                    rowData.Add(FechaNacimento.ToString("dd-MM-yyyy"));
                        //                }
                        //                else if (double.TryParse(cellValue.ToString(), out double serialDate))
                        //                {

                        //                    DateTime Fecha = DateTime.FromOADate(serialDate);

                        //                    rowData.Add(Fecha.ToString("dd-MM-yyyy"));

                        //                }

                        //            }
                        //            else { 

                        //            rowData.Add(worksheet.Cells[row, col].Text);
                        //            }
                        //        }

                        //        bool validacion = ValidarUsuario(rowData.ToArray());

                        //        if (validacion)
                        //        {
                        //            usuario.UsuariosCorrectos.Add(
                        //                 new ML.Usuario
                        //                {
                        //                    Nombre = rowData[0],
                        //                    ApellidoPaterno = rowData[1],
                        //                    ApellidoMaterno = rowData[2],
                        //                    FechaNacimiento = rowData[3],
                        //                    Celular = rowData[4],
                        //                    UserName = rowData[5],
                        //                    Email = rowData[6],
                        //                    Password = rowData[7],
                        //                    Sexo = rowData[8],
                        //                    Telefono = rowData[9],
                        //                    CURP = rowData[10]
                        //                }
                        //            );

                        //        }
                        //        else {
                        //            usuario.UsuariosIncorrectos.Add(
                        //                new ML.Usuario
                        //                {
                        //                    Nombre = rowData[0],
                        //                    ApellidoPaterno = rowData[1],
                        //                    ApellidoMaterno = rowData[2],
                        //                    FechaNacimiento = rowData[3],
                        //                    Celular = rowData[4],
                        //                    UserName = rowData[5],
                        //                    Email = rowData[6],
                        //                    Password = rowData[7],
                        //                    Sexo = rowData[8],
                        //                    Telefono = rowData[9],
                        //                    CURP = rowData[10]
                        //                }

                        //             );
                        //        }
                        //    }
                        //}

                    }
                }
                //Meter la ruta del txt en una session

                if (usuario.UsuariosIncorrectos.Count == 0)
                {



                    if (usuario.TipoArchivo == "txt")
                    {
                        var fileName = Path.GetFileName(archivo.FileName);
                        var path = Path.Combine(Server.MapPath("~/Src/"), fileName);
                        Session["RutaTXT"] = path;

                        //filePath para obtener la ruta del archivo TXT
                    }
                    // OpenXml se guardar la direccion del archivo del anterior metodo Excel
                    //else
                    //{   
                    //    var fileName = Path.GetFileName(archivo.FileName);
                    //    var path = Path.Combine(Server.MapPath("~/Src/"), fileName);
                    //    Session["RutaExcel"] = path;
                    //}
                }
            }


         

            return View(usuario);
        }
        public ActionResult CargaUsuario() {

            if (Session["RutaTXT"] != null)
            {
                string archivo = (string)Session["RutaTXT"];

                using (StreamReader file = new StreamReader(archivo))
                {
                    file.ReadLine();
                    string line;

                    while ((line = file.ReadLine()) != null)
                    {
                        var values = line.Split('|');
                        if (values.Length == 11)
                        {
                            var usuario = new ML.Usuario
                            {
                                Nombre = values[0],
                                ApellidoPaterno = values[1],
                                ApellidoMaterno = values[2],
                                FechaNacimiento = values[3],
                                Celular = values[4],
                                UserName = values[5],
                                Email = values[6],
                                Password = values[7],
                                Sexo = values[8],
                                Telefono = values[9],
                                CURP = values[10]

                            };
                            ML.Result result = BL.Usuario.AddEFLinq(usuario);

                        }
                    }
                }
            }
            else {
                if (Session["RutaExcel"] != null)
                {  //connectionString obtiene la direccion del cadenaDeConexion+archivo 
                    string connectionString = (string)Session["RutaExcel"];

                    ML.Result resultUsuarios = BL.Usuario.LeerExcel(connectionString);

                    if (resultUsuarios.Correct) {
                        foreach (ML.Usuario usuario in resultUsuarios.Objects) {
                            var  usuarioExcel=new ML.Usuario
                            {
                                Nombre = usuario.Nombre,
                                ApellidoPaterno = usuario.ApellidoPaterno,
                                ApellidoMaterno = usuario.ApellidoMaterno,
                                FechaNacimiento = usuario.FechaNacimiento,
                                Celular = usuario.Celular,
                                UserName = usuario.UserName,
                                Email = usuario.Email,
                                Password = usuario.Password,
                                Sexo = usuario.Sexo,
                                Telefono = usuario.Telefono,
                                CURP = usuario.CURP
                            };
                            ML.Result result = BL.Usuario.AddEFLinq(usuario);

                        }
                    }
                    
                }
            }
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult Delete(int IdUsuario ) {  //int IdUsuario
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;
            ML.Result resultDelete = BL.Direccion.Delete(IdUsuario);
            if (resultDelete.Correct) {
                //ML.Result result = BL.Usuario.DeleteEFLinq(IdUsuario);
                ServicioUsuario.UsuarioClient servicioUsuario = new ServicioUsuario.UsuarioClient();

                ML.Result result = servicioUsuario.UsuarioDelete(IdUsuario); 
              
            }
           
           

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public JsonResult UpdateEstatus(int IdUsuario) {
            ML.Result resultUpdateEstatus = BL.Usuario.UpdateEstatus(IdUsuario);
            return Json(resultUpdateEstatus, JsonRequestBehavior.AllowGet);
        }

        [HttpGet] // Muestra una vista
        public ActionResult Formulario(int ? IdUsuario) {
            ML.Result resultPais = BL.Pais.GetAll();

            ML.Usuario usuario = new ML.Usuario();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            ML.Result resultRol = BL.Rol.GetAllEFLinq();
            usuario.Rol = new ML.Rol();
            usuario.Rol.Roles = resultRol.Objects;


            if (IdUsuario > 0)  //Update si no es null
            {
                //ML.Result result = BL.Usuario.GetByIdEFLinq(IdUsuario.Value); Recuerda UNBOXING

                ServicioUsuario.UsuarioClient servicioUsuario = new ServicioUsuario.UsuarioClient();

                ML.Result result = servicioUsuario.UsuarioGetById(IdUsuario.Value); //Recuerda UNBOXING
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                }
                usuario.Rol.Roles = resultRol.Objects;

                ML.Result resultDireccion = BL.Direccion.GetById(IdUsuario.Value);

                if (resultDireccion.Correct) { 
                usuario.Direccion =(ML.Direccion)resultDireccion.Object;

                    if (resultPais.Correct)
                    {
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                        ML.Result resultEstados = BL.Estado.GetById(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                        usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;

                        ML.Result resultMunicipios = BL.Municipio.GetById(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                        usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;

                        ML.Result resultColonias = BL.Colonia.GetById(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                        usuario.Direccion.Colonia.Colonias = resultColonias.Objects;

                    }

                }

                else
                {
                    usuario.Direccion = new ML.Direccion();
                    usuario.Direccion.Colonia = new ML.Colonia();
                    usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                    usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                    usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                }




            }
            else //ADD
            { 
                //la vista va sin informacion
                usuario.Rol = new ML.Rol();
                usuario.Rol.Roles = resultRol.Objects;

                if (resultPais.Correct) { 
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                }
            }
            
            return View(usuario);
        }
        
        [HttpPost] //guarda datos
        public ActionResult Formulario(ML.Usuario usuario, HttpPostedFileBase inputUsuario)
        {
            if (inputUsuario != null)
            {
            MemoryStream target = new MemoryStream();
            inputUsuario.InputStream.CopyTo(target);
            byte[] data = target.ToArray();
            usuario.Imagen = data;
            }
            

            if (usuario.IdUsuario == 0 ) {
              
                if (!ModelState.IsValid)

                {
                    ML.Result resultPais = BL.Pais.GetAll();
                    ML.Result resultRol = BL.Rol.GetAllEFLinq();
                    usuario.Rol = new ML.Rol();
                    usuario.Rol.Roles = resultRol.Objects;
                   
                    if (resultPais.Correct)
                    {
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                    }

                    return View(usuario);
                }

                //ML.Result result = BL.Usuario.AddEFLinq(usuario);

                ServicioUsuario.UsuarioClient servicioUsuario = new ServicioUsuario.UsuarioClient();

                ML.Result result = servicioUsuario.UsuarioAdd(usuario); 

                int IdUsuario = (int)result.Object;
                //recuperar el Id
                usuario.IdUsuario = IdUsuario;
                ML.Result resultDireccion = BL.Direccion.Add(usuario);
            }
            else
            {
                //ML.Result result = BL.Usuario.UpdateEFLinq(usuario);

                ServicioUsuario.UsuarioClient servicioUsuario = new ServicioUsuario.UsuarioClient();

                ML.Result result = servicioUsuario.UsuarioUpdate(usuario); //Recuerda UNBOXING

                if (usuario.Direccion.IdDireccion > 0)
                {

                    ML.Result resultDireccion = BL.Direccion.Update(usuario);
                }
                else {

                    ML.Result resultDireccion = BL.Direccion.Add(usuario);

                }
                

               //validar con IdDireccion
              
            }
            
            return RedirectToAction("GetAll");
        }

        public ActionResult GetEstadoByIdPais(int IdPais)
        {
            ML.Result resultEstados = BL.Estado.GetById(IdPais);
            return Json(resultEstados, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetMunicipioByIdestado(int IdEstado)
        {
            ML.Result resultMunicipios = BL.Municipio.GetById(IdEstado);
            return Json(resultMunicipios, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetColoniaByIdMunicipio(int IdMunicipio) { 
        ML.Result resultColonias = BL.Colonia.GetById(IdMunicipio);
            return Json(resultColonias, JsonRequestBehavior.AllowGet);

        }
    }
}