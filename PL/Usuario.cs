using ML;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Usuario
    {
        public static void AddSP() {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese Nombre: ");
            usuario.Nombre =  Console.ReadLine();
            Console.WriteLine("Apellido Materno: ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Apellido Paterno: ");
            usuario.ApellidoMaterno  = Console.ReadLine();
            //Console.WriteLine("Fecha de Nacimiento;");
            //usuario.FechaNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Numero Telefonico: ");
            usuario.Telefono = Console.ReadLine(); 
            BL.Usuario.AddSP(usuario);
        }
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido Materno: ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Apellido Paterno: ");
            usuario.ApellidoMaterno = Console.ReadLine();
            //Console.WriteLine("Fecha de Nacimiento;");
            //usuario.FechaNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Numero Telefonico: ");
            usuario.Telefono = Console.ReadLine();
            BL.Usuario.Add(usuario);
        }
        public static void UpdateSP() {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese el Id del usuario que desea actualizar :");
            usuario.IdUsuario = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Ingrese los nuevos datos ");
            Console.WriteLine("Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido Materno: ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Apellido Paterno: ");
            usuario.ApellidoMaterno = Console.ReadLine();
            //Console.WriteLine("Fecha de Nacimiento;");
            //usuario.FechaNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Numero Telefonico: ");
            usuario.Telefono = Console.ReadLine();
            BL.Usuario.UpdateSP(usuario);

        }
        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese el Id del usuario que desea actualizar :");
            usuario.IdUsuario = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Ingrese los nuevos datos ");
            Console.WriteLine("Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido Materno: ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Apellido Paterno: ");
            usuario.ApellidoMaterno = Console.ReadLine();
            //Console.WriteLine("Fecha de Nacimiento;");
            //usuario.FechaNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Numero Telefonico: ");
            usuario.Telefono = Console.ReadLine();
            BL.Usuario.Update(usuario);

        }
        public static void DeleteSP() {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese el Id del Usuario que desea eliminar :");
            usuario.IdUsuario = Convert.ToInt16(Console.ReadLine());
            BL.Usuario.DeleteSP(usuario);
        }
        public static void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese el Id del Usuario que desea eliminar :");
            usuario.IdUsuario = Convert.ToInt16(Console.ReadLine());
            BL.Usuario.Delete(usuario);
        }
        public static void ShowData() { 
            ML.Result result = new ML.Result();
            result = BL.Usuario.SowData();

            if (result.Correct) {
                foreach (ML.Usuario usuario in result.Objects) 
                {
                    //Console.WriteLine(usuario.IdUsuario);
                    //Console.WriteLine(usuario.Nombre);
                    //Console.WriteLine(usuario.ApPaterno);
                    //Console.WriteLine(usuario.ApMaterno);
                    //Console.WriteLine(usuario.Tel+"\n");
                    Console.WriteLine($"ID: {usuario.IdUsuario} Nombre: {usuario.Nombre} Apellido Paterno: {usuario.ApellidoPaterno} " +
                        $"Apellido Materno: {usuario.ApellidoMaterno} Tel: {usuario.Telefono} \n");
                }
                }
                else {
                    Console.WriteLine("Error"+result.ErrorMessage);
                }

            }
        public static void GetUserId()
        {
            Console.WriteLine("Ingrese el Id  :");
            int IdUsuario = Convert.ToInt32(Console.ReadLine());

            ML.Result result = new ML.Result();
            result = BL.Usuario.GetUserId(IdUsuario);

            if (result.Correct)
            {
                //Imprime el registro
                ML.Usuario usuario = new ML.Usuario();
                usuario = (ML.Usuario)result.Object; //unboxing
                Console.WriteLine($"\nID: {usuario.IdUsuario} Nombre: {usuario.Nombre} Apellido Paterno: {usuario.ApellidoPaterno} " +
                        $"Apellido Materno: {usuario.ApellidoMaterno} Tel: {usuario.Telefono} \n");
            }
            else
            {
                Console.WriteLine("Error" + result.ErrorMessage);
            }

        }
        public static void UsuarioGetAll()
        {
            ML.Result result = new ML.Result();
            result = BL.Usuario.UsuarioGetAll();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine(usuario.IdUsuario);
                    Console.WriteLine(usuario.Nombre);
                    Console.WriteLine(usuario.ApellidoPaterno);
                    Console.WriteLine(usuario.ApellidoMaterno);
                    Console.WriteLine(usuario.FechaNacimiento);
                    Console.WriteLine(usuario.Celular);
                    Console.WriteLine(usuario.UserName);
                    Console.WriteLine(usuario.Email);
                    Console.WriteLine(usuario.Password);
                    Console.WriteLine(usuario.Sexo);
                    Console.WriteLine(usuario.Telefono);
                    Console.WriteLine(usuario.CURP);
                    Console.WriteLine(usuario.Rol.IdRol);
                    Console.WriteLine('\n');


                    //Console.WriteLine($"ID: {usuario.IdUsuario} Nombre: {usuario.Nombre} Apellido Paterno: {usuario.ApPaterno} " +
                    //   $"Apellido Materno: {usuario.ApMaterno} Tel: {usuario.Tel} \n");
                }
            }
            else
            {
                Console.WriteLine("Error" + result.ErrorMessage);
            }

        }
        public static void UsuarioAdd()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese Nombre : ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido Materno : ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Apellido Paterno : ");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Fecha de Nacimiento :");
            usuario.FechaNacimiento = Console.ReadLine();
            Console.WriteLine(" Celular :");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("UserName :");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Email :");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Password :");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Sexo :");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Telefono :");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Curp :");
            usuario.CURP = Console.ReadLine();
            Console.WriteLine("IdRol :");
            usuario.Rol.IdRol = Convert.ToInt32(Console.ReadLine());


            BL.Usuario.UsuarioAdd(usuario);
        }



        public static void RolGetAll()
        {
            ML.Result result = new ML.Result();
            result = BL.Rol.GetAllEFLinq();

            if (result.Correct)
            {
                foreach (ML.Rol rol in result.Objects)
                {
                    Console.WriteLine(rol.IdRol);
                    Console.WriteLine(rol.Nombre);
                    Console.WriteLine(rol.FechaRegistro);

                }
            }
            else
            {
                Console.WriteLine("Error" + result.ErrorMessage);
            }

        }

        public static void RolGetById()
        {
            Console.WriteLine("Ingrese el Id  :");
            int IdRol = Convert.ToInt32(Console.ReadLine());

            ML.Result result = new ML.Result();
            result = BL.Rol.RolGetById(IdRol);

            if (result.Correct)
            {
                //Imprime el registro
                ML.Rol rol = new ML.Rol();
                rol = (ML.Rol)result.Object; //unboxing
                Console.WriteLine($"\nID: {rol.IdRol} Nombre: {rol.Nombre} Fecha de Registro: {rol.FechaRegistro} " );
            }
            else
            {
                Console.WriteLine("Error" + result.ErrorMessage);
            }

        }

        public static void RolAdd()
        {
            ML.Rol rol = new ML.Rol();
         
            Console.WriteLine("Nombre : ");
            rol.Nombre = Console.ReadLine();
            Console.WriteLine("Fecha : ");
            rol.FechaRegistro = Console.ReadLine();

            BL.Rol.RolAdd(rol);
        }

        public static void RolUpdate()
        {
            ML.Rol rol = new ML.Rol();
            Console.WriteLine("Ingrese el Id del Rol que desea actualizar :");
            rol.IdRol = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Ingrese los nuevos datos ");
            Console.WriteLine("Nombre: ");
            rol.Nombre = Console.ReadLine();
            Console.WriteLine("Fecha: ");
            rol.FechaRegistro = Console.ReadLine();
            BL.Rol.RolUpdate(rol);

        }

        public static void RolDelete()
        {
            ML.Rol rol = new ML.Rol();
            Console.WriteLine("Ingrese el Id del Usuario que desea eliminar :");
            int IdRol = Convert.ToInt16(Console.ReadLine());
            BL.Rol.DeleteEFLinq(rol);
        }



    }
}

