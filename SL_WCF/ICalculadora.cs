using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ICalculadora" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICalculadora
    {
        [OperationContract]
        int Suma(int A, int B); // frima de metodo

        [OperationContract]
        int Resta(int A, int B); // frima de metodo
    }
}
