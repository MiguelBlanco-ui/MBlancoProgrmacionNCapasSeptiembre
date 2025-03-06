using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetById(int IdMunicipio) { 
        ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities()) {
                var listColonias = context.GetColoniaByIdMunicipio(IdMunicipio).ToList();
                if (listColonias.Count > 0)
                {
                    result.Objects = new List<Object>();
                    foreach (var colonia in listColonias)
                    {
                        ML.Colonia colonia1 = new ML.Colonia(); 
                        colonia1.IdColonia = colonia.IdColonia;
                        colonia1.Nombre = colonia.Nombre;
                        result.Objects.Add(colonia1);

                    }
                    result.Correct = true;

                }
                else { 
                    result.Correct= false;
                    result.ErrorMessage = "No se encotraron Colonias";
                } 
            }

                return result;
        }
    }
}
