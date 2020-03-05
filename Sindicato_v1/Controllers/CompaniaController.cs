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
    public class CompaniaController : Controller
    {

        // GET: Compania
        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Mant_Compania(int? page)
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

                List<SelectCompaniaViewModel> lst;
                using (SII_Entities db = new SII_Entities())
                {
                    lst = (from d in db.Tbl_Compania
                           where d.estado == 1 || d.estado == 3
                           select new SelectCompaniaViewModel
                           {
                               id_Comp = d.id_Compania,
                               razon_Soc = d.razon_Social,
                               cedula_Jud = d.cedula_Juridica,
                               nombre_Comp = d.nom_Compania,
                               direc = d.direccion,
                               tel = d.telefono,
                               correo = d.correo_Electronico,
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
        public ActionResult Inha_Comp(int? page)
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
                List<SelectCompaniaViewModel> lst;
                using (SII_Entities db = new SII_Entities())
                {
                    lst = (from d in db.Tbl_Compania
                           where d.estado == 0
                           select new SelectCompaniaViewModel
                           {
                               id_Comp = d.id_Compania,
                               razon_Soc = d.razon_Social,
                               cedula_Jud = d.cedula_Juridica,
                               nombre_Comp = d.nom_Compania,
                               direc = d.direccion,
                               tel = d.telefono,
                               correo = d.correo_Electronico,
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
        public ActionResult Activar_Comp(int? id)
        {
            try
            {
                using (SII_Entities db = new SII_Entities())
                {
                    var obj_Comp = db.Tbl_Compania.Find(id);

                    if (obj_Comp.estado == 0)
                    {
                        obj_Comp.estado = 1;
                        db.Entry(obj_Comp).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        TempData["msg"] = "Agregado";
                        ViewBag.Msg = TempData["msg"];

                    }
                }
                return Redirect("/Compania/Inha_Comp");
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Nueva_Compania()
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            return View();
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpPost]
        public ActionResult Nueva_Compania(AddCompaniaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SII_Entities db = new SII_Entities())
                    {

                        var comp_ced = (from c in db.Tbl_Compania
                                        where c.cedula_Juridica == model.cedula_Jud
                                        select c.cedula_Juridica);


                        if (comp_ced.Count() != 0)
                        {
                            Response.Write("<script>alert('¡El numero de cédula ya se encuentra registrado en el sistema! por favor, revíselo e intente de nuevo.');</script>");
                            return View(model);
                        }
                        else
                        {
                            var obj_Comp = new Tbl_Compania();
                            obj_Comp.razon_Social = model.razon_Soc;
                            obj_Comp.cedula_Juridica = model.cedula_Jud;
                            obj_Comp.nom_Compania = model.nombre_Comp;
                            obj_Comp.direccion = model.direc;
                            obj_Comp.telefono = model.tel;
                            obj_Comp.correo_Electronico = model.correo_Electronico;
                            obj_Comp.estado = 1;
                            db.Tbl_Compania.Add(obj_Comp);
                            db.SaveChanges();
                            TempData["msg"] = "Agregado";
                            ViewBag.Msg = TempData["msg"];
                        }
                    }
                    return Redirect("/Compania/Mant_Compania");
                }
                return View(model);
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Editar_Compania(int? ID)
        {
            try
            {
                ViewData["Nombre"] = AccesoController.nombre;
                ViewData["Apellido"] = AccesoController.apellido;

                AddCompaniaViewModel model = new AddCompaniaViewModel();

                using (SII_Entities db = new SII_Entities())
                {
                    var obj_Comp = db.Tbl_Compania.Find(ID);

                    model.razon_Soc = obj_Comp.razon_Social;
                    model.cedula_Jud = obj_Comp.cedula_Juridica;
                    model.nombre_Comp = obj_Comp.nom_Compania;
                    model.direc = obj_Comp.direccion;
                    model.tel = obj_Comp.telefono;
                    model.correo_Electronico = obj_Comp.correo_Electronico;
                    model.id_Comp = obj_Comp.id_Compania;
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
        public ActionResult Editar_Compania(AddCompaniaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SII_Entities db = new SII_Entities())
                    {

                        var comp_ced = (from c in db.Tbl_Compania
                                        where c.cedula_Juridica == model.cedula_Jud
                                        select c.cedula_Juridica);


                        if (comp_ced.Count() > 1)
                        {
                            Response.Write("<script>alert('¡El numero de cédula ya se encuentra registrado en el sistema! por favor, revíselo e intente de nuevo.');</script>");
                            return View(model);
                        }

                        var obj_Comp = db.Tbl_Compania.Find(model.id_Comp);
                        obj_Comp.razon_Social = model.razon_Soc;
                        obj_Comp.cedula_Juridica = model.cedula_Jud;
                        obj_Comp.nom_Compania = model.nombre_Comp;
                        obj_Comp.direccion = model.direc;
                        obj_Comp.telefono = model.tel;
                        obj_Comp.correo_Electronico = model.correo_Electronico;
                        db.Entry(obj_Comp).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        TempData["msg"] = "Modificado";
                        ViewBag.Msg = TempData["msg"];
                    }
                    return Redirect("/Compania/Mant_Compania");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpGet]
        public ActionResult Eliminar_Compania(int? id)
        {
            try
            {
                using (SII_Entities db = new SII_Entities())
                {
                    var obj_Comp = db.Tbl_Compania.Find(id);

                    if (obj_Comp.estado == 3)
                    {
                        obj_Comp.estado = 0;
                        db.Entry(obj_Comp).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        TempData["msg"] = "Eliminado";
                        ViewBag.Msg = TempData["msg"];
                    }

                    if (obj_Comp.estado == 1)
                    {
                        try
                        {
                            obj_Comp.estado = 0;
                            db.Entry(obj_Comp).State = System.Data.Entity.EntityState.Modified;
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
                return Redirect("/Compania/Mant_Compania");
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }
    }
}