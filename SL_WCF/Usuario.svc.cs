using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Usuario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Usuario.svc o Usuario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Usuario : IUsuario
    {
        public ML.Result UsuarioAdd(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.AddEFLinq(usuario);
            return result;
        }
        public ML.Result UsuarioDelete(int IdUsuario) {
            ML.Result result = BL.Usuario.DeleteEFLinq(IdUsuario);
            return result;
        }

        public ML.Result UsuarioUpdate(ML.Usuario usuario) { 
        ML.Result result = BL.Usuario.UpdateEFLinq(usuario);
            return result;
        }

        public ML.Result UsuarioGetAll(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.GetAllEFSP(usuario);
            return result;
        }
        public ML.Result UsuarioGetById(int IdUsuario)
        {
            ML.Result result = BL.Usuario.GetByIdEFLinq(IdUsuario);
            return result;
        }

    }
}
