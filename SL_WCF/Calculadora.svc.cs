using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Calculadora" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Calculadora.svc o Calculadora.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Calculadora : ICalculadora
    {
        public int Suma(int A, int B)
        {
            int ResultadoS = A + B;
            return ResultadoS;
        }
        public int Resta(int A, int B)
        {
            int ResultadoR = A - B;
            return ResultadoR;
        }
    }
}
