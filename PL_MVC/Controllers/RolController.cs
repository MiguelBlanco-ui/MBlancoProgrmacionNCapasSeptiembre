using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult GetAll()
        {
            ML.Result result = BL.Rol.GetAllEFLinq();
            ML.Rol rol = new ML.Rol();

            if (result.Correct == true)
            {
                rol.Roles = result.Objects;

            }
            else {
                ViewBag.Error = result.ErrorMessage;
            }
            return View(rol);
        }

        [HttpGet]
        public ActionResult Formulario(int? IdRol) {
            ML.Rol rol = new ML.Rol();

            if (IdRol != null)
            {
                ML.Result result = BL.Rol.GetByIdEFLinq(IdRol.Value); //IdRol.Value
                if (result.Correct == true) {
                    rol = (ML.Rol)result.Object;
                }
            }

            return View(rol);
        }

        [HttpPost]
        public ActionResult Formulario(ML.Rol rol) {
            if (rol.IdRol == 0)
            {
                if (!ModelState.IsValid)
                {
                    
                    return View(rol);
                }

                ML.Result result =  BL.Rol.AddEFLinq(rol);

            }
            else { 
            
                ML.Result result = BL.Rol.UpdateEFLinq(rol);
            }

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult Delete(int IdRol) {
            ML.Rol rol = new ML.Rol();
            rol.IdRol = IdRol;
            ML.Result result = BL.Rol.DeleteEFLinq(rol);

            return RedirectToAction("GetAll");
        }


    }
}
