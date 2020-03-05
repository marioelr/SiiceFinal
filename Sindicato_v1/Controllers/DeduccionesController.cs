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
    public class DeduccionesController : Controller
    {
        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult BusquedaDeduccion(int? page, int cedula = 0)
        {
            try
            {
                ViewBag.Msg = TempData["msg"].ToString();
            }
            catch (Exception)
            {

            }

            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            try
            {
                using (SII_Entities db = new SII_Entities())
                {
                    var lista = new List<SelectDeduccionesViewModel>();

                    if (cedula != 0)
                    {
                        var deducciones = from d in db.Tbl_Deduccion
                                          join a in db.Tbl_Agremiado on d.id_Agremiado equals a.id_Agremiado
                                          join u in db.Tbl_Usuario on a.id_Usuario equals u.id_Usuario
                                          join p in db.Tbl_Persona on u.id_Persona equals p.id_Persona
                                          where p.estado == 1 && p.cedula.ToString().StartsWith(cedula.ToString()) && d.estado == 1
                                          select new { p.cedula, p.nombre, p.primer_Apellido, p.segundo_Apellido, d.fecha_Deduccion, d.monto, d.id_Deduccion };

                        foreach (var deduccion in deducciones.ToList())
                        {
                            var modelo = new SelectDeduccionesViewModel();

                            modelo.cedula = deduccion.cedula;
                            modelo.nombre = deduccion.nombre;
                            modelo.primer_apellido = deduccion.primer_Apellido;
                            modelo.segundo_apellido = deduccion.segundo_Apellido;
                            modelo.fecha_deduccion = deduccion.fecha_Deduccion;
                            modelo.monto = deduccion.monto;
                            modelo.id = deduccion.id_Deduccion;
                            lista.Add(modelo);
                        }
                    }
                    else
                    {
                        var deducciones = from d in db.Tbl_Deduccion
                                          join a in db.Tbl_Agremiado on d.id_Agremiado equals a.id_Agremiado
                                          join u in db.Tbl_Usuario on a.id_Usuario equals u.id_Usuario
                                          join p in db.Tbl_Persona on u.id_Persona equals p.id_Persona
                                          where d.estado == 1
                                          select new { p.cedula, p.nombre, p.primer_Apellido, p.segundo_Apellido, d.fecha_Deduccion, d.monto, d.id_Deduccion };

                        foreach (var deduccion in deducciones.ToList())
                        {
                            var modelo = new SelectDeduccionesViewModel();

                            modelo.cedula = deduccion.cedula;
                            modelo.nombre = deduccion.nombre;
                            modelo.primer_apellido = deduccion.primer_Apellido;
                            modelo.segundo_apellido = deduccion.segundo_Apellido;
                            modelo.fecha_deduccion = deduccion.fecha_Deduccion;
                            modelo.monto = deduccion.monto;
                            modelo.id = deduccion.id_Deduccion;
                            lista.Add(modelo);
                        }
                    }
                    return View(lista.ToPagedList(page ?? 1, 8));

                }
            }
            catch (Exception)
            {

                return Redirect("/Error/InaccessiblePage");
            }

        }

        [HttpGet]
        public ActionResult Eliminar_Ded(int? id)
        {
            try
            {
                using (SII_Entities db = new SII_Entities())
                {
                    var obj_Ded = db.Tbl_Deduccion.Find(id);

                    if (obj_Ded.estado == 1)
                    {
                        obj_Ded.estado = 0;
                        db.Entry(obj_Ded).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        TempData["msg"] = "Eliminado";
                        ViewBag.Msg = TempData["msg"];
                    }
                }
                return Redirect("/Deducciones/BusquedaDeduccion");
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }
    }
}