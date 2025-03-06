using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    { 
        public static ML.Result GetAll(){ 
        ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities()) { 
                var listaPaises= context.PaisGetAll().ToList();
                if (listaPaises.Count > 0)
                {
                    result.Objects = new List<object>();

                    foreach (var pais in listaPaises)
                    {
                        ML.Pais pais1 = new ML.Pais();
                        pais1.IdPais = pais.IdPais;
                        pais1.Nombre = pais.Nombre;

                        result.Objects.Add(pais1);
                    }
                    result.Correct = true;

                }
                else { 
                    result.Correct = false;
                    result.ErrorMessage = "No se Encotraron registros";
                }

            }

                return result;       
        }
        
    }
}
