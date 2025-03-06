using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Direccion
    {
        public static ML.Result Add(ML.Usuario usuario){

            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities()) {
                var querryInsert = context.DireccionAdd(usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior,
                                                        usuario.Direccion.Colonia.IdColonia, usuario.IdUsuario);
                if (querryInsert > 0) {
                    result.Correct = true;

                }
                else {  
                    result.Correct = false;
                    result.ErrorMessage = "No se insertaron datos";
                }
            }
            
                return result;
        }


        // get by Id

        public static ML.Result GetById(int IdUsuario) {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities()) {
                var querryGetById = context.DireccionGetById(IdUsuario).FirstOrDefault();
                if (querryGetById != null) {
                    ML.Direccion direccion = new ML.Direccion();
                    
                    direccion.Calle = querryGetById.Calle;
                    direccion.Colonia = new ML.Colonia();
                    direccion.Colonia.IdColonia = querryGetById.IdColonia;
                    direccion.Colonia.Nombre = querryGetById.ColoniaNombre;
                    direccion.Colonia.Municipio = new ML.Municipio();
                    direccion.Colonia.Municipio.IdMunicipio = querryGetById.IdMunicipio;
                    direccion.Colonia.Municipio.Nombre = querryGetById.MunicipioNombre;
                    direccion.Colonia.Municipio.Estado = new ML.Estado();
                    direccion.Colonia.Municipio.Estado.IdEstado = querryGetById.IdEstado;
                    direccion.Colonia.Municipio.Estado.Nombre = querryGetById.EstadoNombre;
                    direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                    direccion.Colonia.Municipio.Estado.Pais.IdPais = querryGetById.IdPais;
                    direccion.Colonia.Municipio.Estado.Pais.Nombre = querryGetById.PaisNombre;
                    direccion.NumeroExterior = querryGetById.NumeroExterior;
                    direccion.NumeroInterior = querryGetById.NumeroInterior;
                    direccion.IdDireccion = querryGetById.IdDireccion;
                    
                    result.Object = direccion;
                    result.Correct = true;
                } else {
                result.Correct = false;
                    result.ErrorMessage = "No se encontraron registros";
                }
            }

                return result;
        }


        public static ML.Result Update(ML.Usuario usuario) {
            ML.Result result = new ML.Result();
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities()) {
                var querryUdate = context.DireccionUpdate(usuario.IdUsuario, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                if (querryUdate > 0)
                {
                    result.Correct = true;
                }
                else {
                    result.Correct = false;
                    result.ErrorMessage = "No se actualizaron resultados";
                }
            }

                return result;
        }

        public static ML.Result Delete(int IdUsuario) {
            ML.Result result = new ML.Result(); 
            using (DL_EF.MBlancoProgramacionCapasSeptiembreEntities context = new DL_EF.MBlancoProgramacionCapasSeptiembreEntities()) {
                var querryDelete = context.DireccionDelete(IdUsuario);
                if (querryDelete > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No Se pudo elimnar el registro";

                }
             }
            return result;
        }
        
    }
}
