using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result GetById(int IdEstado)
        {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities())
            {
                var listMunicipios = context.GetMunicipioByIdEstado(IdEstado).ToList();
                if (listMunicipios.Count > 0)
                {
                    result.Objects = new List<object>();
                    foreach (var municipio in listMunicipios)
                    {
                        ML.Municipio municipio1 = new ML.Municipio();

                        municipio1.IdMunicipio = municipio.IdMunicipio;
                        municipio1.Nombre = municipio.Nombre;
                        result.Objects.Add(municipio1);
                    }
                    result.Correct = true;

                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Error al encontrar los Municipios";
                }
                return result;
            }
        }
    }
}
