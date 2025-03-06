using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //proporciona metodos  para lectura y escritura

namespace PL
{
    public class CargaMasivaUsuario
    {
        public static void ReadTXT()
        {
            Console.WriteLine("Ingrese la ruta del archivo.txt ;");
            var archivo = Console.ReadLine();

            using (StreamReader file = new StreamReader(archivo))// El @ se utiliza para indicar que la cadena que sigue debe ser tratada como una ruta de archivo literal,
                                                                  // sin interpretación adicional por el compilador.
            {
                file.ReadLine();
                string line;
 
                while (( line = file.ReadLine()) !=null)
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
                            CURP = values[10],

                        };
                        ML.Result result = BL.Usuario.AddEFLinq(usuario);
                        if (result.Correct)
                        {
                            Console.WriteLine("Insertado Correctamente " + values[0]);
                        }
                        else
                        {
                            Console.WriteLine(result.ErrorMessage);

                        }
                    }
                    else {
                        Console.WriteLine("Se esperaban 11 campos");
                    }
                }

            }
        }

        public static void ReadExel()
        {
            Console.WriteLine("Ingrese la ruta del archivo.csv ;");
            var archivo = Console.ReadLine();

            using (StreamReader file = new StreamReader(archivo))// El @ se utiliza para indicar que la cadena que sigue debe ser tratada como una ruta de archivo literal,
                                                                 // sin interpretación adicional por el compilador.
            {
                file.ReadLine();
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    var values = line.Split(',');
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
                            CURP = values[10],

                        };
                        ML.Result result = BL.Usuario.AddEFLinq(usuario);
                        if (result.Correct)
                        {
                            Console.WriteLine("Insertado Correctamente " + values[0]);
                        }
                        else
                        {
                            Console.WriteLine(result.ErrorMessage);

                        }
                    }
                    else
                    {
                        Console.WriteLine("Se esperaban 11 campos");
                    }
                }

            }
        }


    }
}
