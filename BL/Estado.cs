using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetById(int IdPais) {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities()) { 
            var listEstado = context.GetEstadoByIdPais(IdPais).ToList();
                if (listEstado.Count > 0)
                {
                    result.Objects = new List<object>();
                    foreach (var estado in listEstado)
                    {
                        ML.Estado estado1 = new ML.Estado();
                        estado1.IdEstado = estado.IdEstado;
                        estado1.Nombre = estado.Nombre;
                        result.Objects.Add(estado1);
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontraron Estados";
                }
                }
                return result;
       
            }
        
    }
}
