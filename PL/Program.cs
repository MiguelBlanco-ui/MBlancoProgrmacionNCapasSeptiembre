using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CargaMasivaUsuario.ReadTXT();

            Console.ReadKey();
            //Usuario.Add();
            //Usuario.Update();
            //Usuario.Delete();

            //bool continuar = true;

            //while (continuar) {
            //Console.WriteLine("\n" + "Opciones :");
            //Console.WriteLine("1. Añadir Usuario ");
            //Console.WriteLine("2. Actualizar Usuario");
            //Console.WriteLine("3. Eliminar un Usuario");
            //Console.WriteLine("4. Mostrar datos ");
            //Console.WriteLine("5. Ingresar un Id para mostrar su datos");
            //Console.WriteLine("6. Salir ");

            //    string opcion = Console.ReadLine();
            //   Console.WriteLine("\n");
            //switch(opcion){
            //    case "1":
            //        Usuario.RolAdd();
            //        break;
            //    case "2":
            //        Usuario.RolUpdate();
            //        break;
            //     case"3":
            //        Usuario.RolDelete();
            //        break;
            //     case "4":
            //        Usuario.RolGetAll();
            //        break;
            //    case "5":
            //        Usuario.RolGetById();
            //        break;
            //    case "6":
            //        continuar=false;
            //        break;
            //    default:
            //        Console.WriteLine("Opción no valida");
            //        Console.ReadKey();

            //        break;

            //} 
            //}
        }
    }
}
