using Sindicato_v1.Filters;
using Sindicato_v1.Models;
using Sindicato_v1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Sindicato_v1.Controllers
{
    public class GestionesController : Controller
    {
        public List<GestionesViewModel> lst;
        // GET: Vacaciones
        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Gestiones()
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

            using (SII_Entities db = new SII_Entities())
            {
                lst = (from e in db.Tbl_Empleado
                       join u in db.Tbl_Usuario on e.id_Usuario equals u.id_Usuario
                       join p in db.Tbl_Persona on u.id_Persona equals p.id_Persona
                       join d in db.Tbl_Departamento on e.id_LugarTrabajo equals d.id_Departamento
                       select new GestionesViewModel
                       {
                           id_Emp = e.id_Empleado,
                           nombre_emp = p.nombre,
                           apellido1 = p.primer_Apellido,
                           apellido2 = p.segundo_Apellido,
                           departamento = d.departamento
                       }).ToList();
            }
            return View(lst);
        }

        public List<EditGestionesViewModel> lst_gest;

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Editar_Gestiones()
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

            using (SII_Entities db = new SII_Entities())
            {
                lst_gest = (from g in db.Tbl_Gestion
                            join e in db.Tbl_Empleado on g.id_Empleado equals e.id_Empleado
                            join u in db.Tbl_Usuario on e.id_Usuario equals u.id_Usuario
                            join p in db.Tbl_Persona on u.id_Persona equals p.id_Persona
                            join tg in db.Tbl_TipoGestion on g.id_TipoGestion equals tg.id_TipoGestion
                            where g.estado == 1
                            select new EditGestionesViewModel
                            {
                                Id_Ges = g.id_Gestion,
                                Motivo = g.motivo,
                                F_Inicio = g.fecha_Inicio.ToString(),
                                F_Fin = g.fecha_Fin.ToString(),
                                Nombre = p.nombre,
                                Ap_Paterno = p.primer_Apellido,
                                T_Gestion = tg.tipo_Gestion,
                                F_Ausencia = g.fecha_Ausencia.ToString()
                            }).ToList();
            }
            return View(lst_gest);
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Nueva_Gestion(int ID)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            FillDropDownList();

            GestionesViewModel model = new GestionesViewModel();

            using (SII_Entities db = new SII_Entities())
            {
                var obj_Emp = db.Tbl_Empleado.Find(ID);
                model.cant_au_jus = Convert.ToInt32(obj_Emp.cant_AusenciasJustificadas);
                model.cant_au_injus = Convert.ToInt32(obj_Emp.cant_AusenciasInjustificadas);
                model.vac_uti = Convert.ToInt32(obj_Emp.vac_Utilizadas);
                model.vac_rest = Convert.ToInt32(obj_Emp.vac_Restantes);
                model.tot_vac = Convert.ToInt32(obj_Emp.total_Vacaciones);
                model.id_Emp = Convert.ToInt32(obj_Emp.id_Empleado);
            }
            return View(model);
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpPost]
        public ActionResult Nueva_Gestion(GestionesViewModel model)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            FillDropDownList();

            try
            {
                if (ModelState.IsValid)
                {
                    using (SII_Entities db = new SII_Entities())
                    {
                        var obj_Emp = db.Tbl_Empleado.Find(model.id_Emp);
                        obj_Emp.cant_AusenciasJustificadas = model.cant_au_jus + model.cant_aus;
                        obj_Emp.cant_AusenciasInjustificadas = model.cant_au_injus;
                        obj_Emp.total_Vacaciones = model.tot_vac;
                        obj_Emp.vac_Utilizadas = model.vac_uti + model.vac_solic;
                        obj_Emp.vac_Restantes = model.tot_vac - obj_Emp.vac_Utilizadas;
                        obj_Emp.id_Empleado = model.id_Emp;

                        db.Entry(obj_Emp).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    using (SII_Entities db = new SII_Entities())
                    {

                        var obj_Gest = new Tbl_Gestion();
                        obj_Gest.motivo = model.motivo;
                        obj_Gest.id_TipoGestion = model.id_TipoGes;
                        if (obj_Gest.id_TipoGestion == 1)
                        {
                            obj_Gest.fecha_Inicio = model.f_inicio;
                            obj_Gest.fecha_Fin = model.f_fin;
                            obj_Gest.fecha_Ausencia = null;
                        }
                        else
                        {
                            obj_Gest.fecha_Inicio = null;
                            obj_Gest.fecha_Fin = null;
                            obj_Gest.fecha_Ausencia = model.f_aus;
                        }
                        obj_Gest.id_Empleado = model.id_Emp;
                        obj_Gest.estado = 1;
                        db.Tbl_Gestion.Add(obj_Gest);
                        db.SaveChanges();

                        TempData["msg"] = "Agregado";
                        ViewBag.Msg = TempData["msg"];
                    }
                    return Redirect("/Gestiones/Gestiones");
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
        public ActionResult Eliminar_Gestion(int id)
        {
            using (SII_Entities db = new SII_Entities())
            {
                try
                {
                    var obj_Ges = db.Tbl_Gestion.Find(id);

                    if (obj_Ges.estado == 1)
                    {
                        obj_Ges.estado = 0;
                    }
                    db.Entry(obj_Ges).State = System.Data.Entity.EntityState.Modified;
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
            return Redirect("/Gestiones/Editar_Gestiones");
        }

        public void FillDropDownList()
        {
            SII_Entities dba = new SII_Entities();
            List<Tbl_TipoGestion> list = dba.Tbl_TipoGestion.ToList();
            ViewBag.GestionList = new SelectList(list, "id_TipoGestion", "tipo_Gestion");
        }
    }
}