using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuario" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    [ServiceKnownType(typeof(ML.Usuario))] //Declaras que ML.Usuario es un tipo conocido  asegura que WCF pueda serializar y deserializar instancias
    public interface IUsuario
    {
        [OperationContract]
        ML.Result UsuarioAdd(ML.Usuario usuario);
      
        [OperationContract]
        ML.Result UsuarioDelete(int IdUsuario);
        
        [OperationContract]
        ML.Result UsuarioUpdate(ML.Usuario usuario);

        [OperationContract]
        ML.Result UsuarioGetAll(ML.Usuario usuario);

        [OperationContract]
        ML.Result UsuarioGetById(int IdUsuario);
    }
}
