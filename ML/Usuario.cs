using Microsoft.Win32;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    [DataContract]
    public class Usuario
    {
        //clase encapsulada
        [DataMember]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ]*$", ErrorMessage = "Solo se permiten letras.")]
        [DataMember]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido Paterno es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ]*$", ErrorMessage = "Solo se permiten letras.")]
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataMember]
        public string FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos.")]
        [DataMember]
        public string Celular { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [RegularExpression(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}", ErrorMessage = "Correo incorrecto")]
        [DataMember]
        public string Email { get; set; }
        [Compare("Email",
        ErrorMessage = "El correo y la verificación no son correctas")]
        [DataMember]
        public string ValidarEmail { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@@$!%*?&])[A-Za-z\\d@@$!%*?&]{8,}$", ErrorMessage = "Contraseña no valida")]
        [DataMember]
        public string Password { get; set; }
        [Compare("Password",
        ErrorMessage = "La clave y la verificación no son correctas")]
        [DataMember]
        public string ValidarPassword { get; set; }
        [DataMember]
        [RegularExpression(@"^(M|F)$", ErrorMessage = "El sexo debe ser M o F")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos.")] //ESte mesnaje también aparece En curp
        [DataMember]
        public string Telefono { get; set; }
        [RegularExpression(@"[A-Z]{4}[0-9]{6}[HM]{1}[A-Z]{2}[BCDFGHJKLMNPQRSTVWXYZ]{3}([A-Z]{2})?([0-9]{2})?", ErrorMessage = "CURP no valido")]
        [DataMember]
        public string CURP { get; set; }
        [Required(ErrorMessage = "El Rol es obligatorio.")]
        [DataMember]
        public ML.Rol Rol { get; set; }
        //Herencia por atributo 
        [DataMember]
        public byte[] Imagen { get; set; }
        [DataMember]
        public List<object> Usuarios { get; set; }
        public List<object> UsuariosCorrectos { get; set; }
        public List<object> UsuariosIncorrectos { get; set; }
        [DataMember]
        public ML.Direccion Direccion { get; set; }
        [DataMember]
        public string TipoArchivo { get; set; }
        [DataMember]
        public bool Estatus { get; set; }
        //Constructor 
    }
}
