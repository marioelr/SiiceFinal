using Sindicato_v1.Filters;
using Sindicato_v1.Models;
using Sindicato_v1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sindicato_v1.Controllers
{
    public class EditaPerfilController : Controller
    {
        [AuthorizeUser(permiso: 4, tusu: 3)]
        public ActionResult Editar_Perfil()
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            EditPerfilViewModels model = new EditPerfilViewModels();

            using (SII_Entities db = new SII_Entities())
            {
                var id_Persona = (from u in db.Tbl_Usuario
                                  join p in db.Tbl_Persona
                                  on u.id_Persona equals p.id_Persona
                                  join a in db.Tbl_Agremiado on u.id_Usuario equals a.id_Usuario
                                  where a.id_Agremiado == AccesoController.id_Ag
                                  select p.id_Persona).First();

                var persona = db.Tbl_Persona.Find(id_Persona);
                model.nombre = persona.nombre;
                model.p_apellido = persona.primer_Apellido;
                model.s_apellido = persona.segundo_Apellido;
                model.telefono = persona.telefono;
                model.correo_Electronico = persona.correo_Electronico;
                model.direccion = persona.direccion;
                model.id = persona.id_Persona;
            }

            return View(model);
        }

        [AuthorizeUser(permiso: 4, tusu: 3)]
        [HttpPost]
        public ActionResult Editar_Perfil(EditPerfilViewModels model)
        {
            try
            {
                ViewData["Nombre"] = AccesoController.nombre;
                ViewData["Apellido"] = AccesoController.apellido;

                if (ModelState.IsValid)
                {
                    using (SII_Entities db = new SII_Entities())
                    {
                        var agremiado = db.Tbl_Persona.Find(model.id);
                        agremiado.nombre = model.nombre;
                        agremiado.primer_Apellido = model.p_apellido;
                        agremiado.segundo_Apellido = model.s_apellido;
                        agremiado.telefono = model.telefono;
                        agremiado.correo_Electronico = model.correo_Electronico;
                        agremiado.direccion = model.direccion;
                        db.Entry(agremiado).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        TempData["msg"] = "Modificado";
                        ViewBag.Msg = TempData["msg"];

                        AccesoController.nombre = model.nombre;
                        AccesoController.apellido = model.p_apellido;
                    }
                    return Redirect("/Usuario/Usuarios");
                }
                return View(model);
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }
    }
}