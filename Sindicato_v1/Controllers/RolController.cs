using Sindicato_v1.Filters;
using Sindicato_v1.Models;
using Sindicato_v1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Sindicato_v1.Controllers
{
    public class RolController : Controller
    {
        // GET: EstadoCivil
        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Mant_Rol(int? page)
        {
            try
            {
                ViewBag.Msg = TempData["msg"].ToString();
            }
            catch (Exception)
            {

            }
            try
            {
                ViewData["Nombre"] = AccesoController.nombre;
                ViewData["Apellido"] = AccesoController.apellido;


                List<SelectRolesViewModel> lst;

                using (SII_Entities db = new SII_Entities())
                {
                    lst = (from d in db.Tbl_Rol
                           where d.estado == 1 || d.estado == 3 || d.estado == 0
                           select new SelectRolesViewModel
                           {
                               id_R = d.id_Rol,
                               rol = d.tipo_Rol,
                               estado = d.estado
                           }).ToList();
                }

                return View(lst.ToPagedList(page ?? 1, 8));
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        public ActionResult Inha_Rol(int? page)
        {
            try
            {
                ViewBag.Msg = TempData["msg"].ToString();
            }
            catch (Exception)
            {

            }
            try
            {
                List<SelectRolesViewModel> lst;

                using (SII_Entities db = new SII_Entities())
                {
                    lst = (from d in db.Tbl_Rol
                           where d.estado == 0
                           select new SelectRolesViewModel
                           {
                               id_R = d.id_Rol,
                               rol = d.tipo_Rol,
                               estado = d.estado
                           }).ToList();
                }

                return View(lst.ToPagedList(page ?? 1, 8));
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Nuevo_Rol()
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            return View();
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpPost]
        public ActionResult Nuevo_Rol(AddRolesViewModel model)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            try
            {
                if (ModelState.IsValid)
                {
                    using (SII_Entities db = new SII_Entities())
                    {
                        var obj_Rol = new Tbl_Rol();
                        obj_Rol.tipo_Rol = model.rol;
                        obj_Rol.estado = 1;
                        db.Tbl_Rol.Add(obj_Rol);
                        db.SaveChanges();

                        TempData["msg"] = "Agregado";
                        ViewBag.Msg = TempData["msg"];
                    }
                    return Redirect("/Rol/Mant_Rol");

                }
                return View(model);
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Editar_Rol(int? ID)
        {
            try
            {
                ViewData["Nombre"] = AccesoController.nombre;
                ViewData["Apellido"] = AccesoController.apellido;

                AddRolesViewModel model = new AddRolesViewModel();
                using (SII_Entities db = new SII_Entities())
                {
                    var obj_Rol = db.Tbl_Rol.Find(ID);
                    model.rol = obj_Rol.tipo_Rol;
                    model.id_R = obj_Rol.id_Rol;
                }
                return View(model);
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }

        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpPost]
        public ActionResult Editar_Rol(AddRolesViewModel model)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            try
            {
                if (ModelState.IsValid)
                {
                    using (SII_Entities db = new SII_Entities())
                    {
                        var obj_Rol = db.Tbl_Rol.Find(model.id_R);
                        obj_Rol.tipo_Rol = model.rol;
                        db.Entry(obj_Rol).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        TempData["msg"] = "Modificado";
                        ViewBag.Msg = TempData["msg"];
                    }
                    return Redirect("/Rol/Mant_Rol");
                }
                return View(model);
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpGet]
        public ActionResult Eliminar_Rol(int? id)
        {
            try
            {
                using (SII_Entities db = new SII_Entities())
                {
                    var obj_Rol = db.Tbl_Rol.Find(id);

                    if (obj_Rol.estado == 3)
                    {
                        obj_Rol.estado = 0;
                        db.Entry(obj_Rol).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        TempData["msg"] = "Eliminado";
                        ViewBag.Msg = TempData["msg"];
                    }

                    if (obj_Rol.estado == 1)
                    {
                        try
                        {
                            obj_Rol.estado = 0;
                            db.Entry(obj_Rol).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();

                            TempData["msg"] = "Eliminado";
                            ViewBag.Msg = TempData["msg"];
                        }
                        catch (Exception)
                        {
                            TempData["msg"] = "Error";
                            ViewBag.Msg = TempData["msg"];
                        }
                    }
                }
                return Redirect("/Rol/Mant_Rol");
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpGet]
        public ActionResult Activar_Rol(int? id)
        {
            try
            {
                using (SII_Entities db = new SII_Entities())
                {
                    var obj_Rol = db.Tbl_Rol.Find(id);

                    if (obj_Rol.estado == 0)
                    {
                        obj_Rol.estado = 1;
                        db.Entry(obj_Rol).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        TempData["msg"] = "Agregado";
                        ViewBag.Msg = TempData["msg"];

                    }
                }
                return Redirect("/Rol/Inha_Rol");
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }
    }
}