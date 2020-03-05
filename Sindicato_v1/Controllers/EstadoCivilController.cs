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
    public class EstadoCivilController : Controller
    {
        // GET: EstadoCivil
        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Mant_ECivil(int? page)
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

                List<SelectECivilViewModel> lst;
                using (SII_Entities db = new SII_Entities())
                {
                    lst = (from d in db.Tbl_EstadoCivil
                           where d.estado == 1 || d.estado == 3
                           select new SelectECivilViewModel
                           {
                               id_ECiv = d.id_ECivil,
                               est_Civil = d.estado_Civil,
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
        public ActionResult Nuevo_ECivil()
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            return View();
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Inha_ECiv(int? page)
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
                List<SelectECivilViewModel> lst;
                using (SII_Entities db = new SII_Entities())
                {
                    lst = (from d in db.Tbl_EstadoCivil
                           where d.estado == 0
                           select new SelectECivilViewModel
                           {
                               id_ECiv = d.id_ECivil,
                               est_Civil = d.estado_Civil,
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
        public ActionResult Activar_ECiv(int? id)
        {
            try
            {
                using (SII_Entities db = new SII_Entities())
                {
                    var obj_ECiv = db.Tbl_EstadoCivil.Find(id);

                    if (obj_ECiv.estado == 0)
                    {
                        obj_ECiv.estado = 1;
                        db.Entry(obj_ECiv).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        TempData["msg"] = "Agregado";
                        ViewBag.Msg = TempData["msg"];

                    }
                }
                return Redirect("/EstadoCivil/Inha_ECiv");
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpPost]
        public ActionResult Nuevo_ECivil(AddECivilViewModel model)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            try
            {
                if (ModelState.IsValid)
                {
                    using (SII_Entities db = new SII_Entities())
                    {
                        var obj_Est = new Tbl_EstadoCivil();
                        obj_Est.estado_Civil = model.est_Civil;
                        obj_Est.estado = 1;
                        db.Tbl_EstadoCivil.Add(obj_Est);
                        db.SaveChanges();

                        TempData["msg"] = "Agregado";
                        ViewBag.Msg = TempData["msg"];
                    }
                    return Redirect("/EstadoCivil/Mant_ECivil");
                }
                return View(model);
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]

        public ActionResult Editar_ECivil(int? ID)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            try
            {
                AddECivilViewModel model = new AddECivilViewModel();
                using (SII_Entities db = new SII_Entities())
                {
                    var obj_Est = db.Tbl_EstadoCivil.Find(ID);
                    model.est_Civil = obj_Est.estado_Civil;
                    model.id_ECiv = obj_Est.id_ECivil;
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
        public ActionResult Editar_ECivil(AddECivilViewModel model)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            try
            {
                if (ModelState.IsValid)
                {
                    using (SII_Entities db = new SII_Entities())
                    {
                        var obj_Est = db.Tbl_EstadoCivil.Find(model.id_ECiv);

                        obj_Est.estado_Civil = model.est_Civil;
                        db.Entry(obj_Est).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        TempData["msg"] = "Modificado";
                        ViewBag.Msg = TempData["msg"];
                    }
                    return Redirect("/EstadoCivil/Mant_ECivil");
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
        public ActionResult Eliminar_E_Civil(int? id)
        {
            try
            {
                using (SII_Entities db = new SII_Entities())
                {
                    var obj_EC = db.Tbl_EstadoCivil.Find(id);

                    if (obj_EC.estado == 3)
                    {
                        obj_EC.estado = 0;
                        db.Entry(obj_EC).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        TempData["msg"] = "Eliminado";
                        ViewBag.Msg = TempData["msg"];
                    }

                    if (obj_EC.estado == 1)
                    {
                        try
                        {
                            obj_EC.estado = 0;
                            db.Entry(obj_EC).State = System.Data.Entity.EntityState.Modified;
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
                return Redirect("/EstadoCivil/Mant_ECivil");
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }
    }
}