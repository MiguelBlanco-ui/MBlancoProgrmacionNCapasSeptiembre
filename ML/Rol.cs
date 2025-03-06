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
    public class Rol
    {
        [DataMember]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "El Nombre del rol es un campo obligatorio.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ]*$", ErrorMessage = "Solo se permiten letras.")]
        [DataMember]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha no válido.")]
        [DataMember]
        public string FechaRegistro  { get; set; }
        [DataMember]
        public List<object> Roles { get; set; }
    }
}
