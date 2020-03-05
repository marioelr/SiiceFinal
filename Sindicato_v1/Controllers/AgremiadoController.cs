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
    public class AgremiadoController : Controller
    {
        // GET: Agremiado
        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Agremiados(int? page, int cedula = 0)
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
                    var lista = new List<SelectAgremiadosViewModel>();

                    if (cedula != 0)
                    {
                        var agremiados = from a in db.Tbl_Agremiado
                                         join u in db.Tbl_Usuario on a.id_Usuario equals u.id_Usuario
                                         join p in db.Tbl_Persona on u.id_Persona equals p.id_Persona
                                         join pa in db.Tbl_Pais on p.nacionalidad equals pa.id_Pais
                                         join ec in db.Tbl_EstadoCivil on p.id_ECivil equals ec.id_ECivil
                                         join d in db.Tbl_Departamento on a.id_LugarTrabajo equals d.id_Departamento
                                         join c in db.Tbl_Compania on d.id_Compania equals c.id_Compania
                                         where p.estado == 1 && p.cedula.ToString().StartsWith(cedula.ToString())
                                         select new
                                         {
                                             p.cedula,
                                             p.nombre,
                                             p.primer_Apellido,
                                             p.segundo_Apellido,
                                             p.fecha_Nac,
                                             p.genero,
                                             ec.estado_Civil,
                                             p.direccion,
                                             a.puesto,
                                             a.grado_Academico,
                                             d.departamento,
                                             c.nom_Compania,
                                             d.ubicacion,
                                             a.colegio_Profesional,
                                             p.correo_Electronico,
                                             p.telefono
                                         };

                        foreach (var agremiado in agremiados.ToList())
                        {
                            var modelo = new SelectAgremiadosViewModel();

                            modelo.cedula = agremiado.cedula;
                            modelo.nombre = agremiado.nombre;
                            modelo.primer_Apellido = agremiado.primer_Apellido;
                            modelo.segundo_Apellido = agremiado.segundo_Apellido;
                            modelo.fecha_n = agremiado.fecha_Nac;
                            modelo.genero = agremiado.genero;
                            modelo.ecivil = agremiado.estado_Civil;
                            modelo.telefono = agremiado.telefono;
                            modelo.correo_Electronico = agremiado.correo_Electronico;
                            modelo.direccion = agremiado.direccion;
                            modelo.fecha_n = agremiado.fecha_Nac;
                            modelo.puesto = agremiado.puesto;
                            modelo.ubicacion = agremiado.ubicacion;
                            modelo.nom_comp = agremiado.nom_Compania;
                            modelo.col_pro = agremiado.colegio_Profesional;
                            modelo.g_acade = agremiado.grado_Academico;
                            modelo.departamento = agremiado.departamento;
                            lista.Add(modelo);
                        }
                    }
                    else
                    {
                        var agremiados = from a in db.Tbl_Agremiado
                                         join u in db.Tbl_Usuario on a.id_Usuario equals u.id_Usuario
                                         join p in db.Tbl_Persona on u.id_Persona equals p.id_Persona
                                         join pa in db.Tbl_Pais on p.nacionalidad equals pa.id_Pais
                                         join ec in db.Tbl_EstadoCivil on p.id_ECivil equals ec.id_ECivil
                                         join d in db.Tbl_Departamento on a.id_LugarTrabajo equals d.id_Departamento
                                         join c in db.Tbl_Compania on d.id_Compania equals c.id_Compania
                                         where p.estado == 1
                                         select new
                                         {
                                             p.cedula,
                                             p.nombre,
                                             p.primer_Apellido,
                                             p.segundo_Apellido,
                                             p.fecha_Nac,
                                             p.genero,
                                             ec.estado_Civil,
                                             p.direccion,
                                             a.puesto,
                                             a.grado_Academico,
                                             d.departamento,
                                             c.nom_Compania,
                                             d.ubicacion,
                                             a.colegio_Profesional,
                                             p.correo_Electronico,
                                             p.telefono
                                         };

                        foreach (var agremiado in agremiados.ToList())
                        {
                            var modelo = new SelectAgremiadosViewModel();

                            modelo.cedula = agremiado.cedula;
                            modelo.nombre = agremiado.nombre;
                            modelo.primer_Apellido = agremiado.primer_Apellido;
                            modelo.segundo_Apellido = agremiado.segundo_Apellido;
                            modelo.fecha_n = agremiado.fecha_Nac;
                            modelo.genero = agremiado.genero;
                            modelo.ecivil = agremiado.estado_Civil;
                            modelo.telefono = agremiado.telefono;
                            modelo.correo_Electronico = agremiado.correo_Electronico;
                            modelo.direccion = agremiado.direccion;
                            modelo.fecha_n = agremiado.fecha_Nac;
                            modelo.puesto = agremiado.puesto;
                            modelo.ubicacion = agremiado.ubicacion;
                            modelo.nom_comp = agremiado.nom_Compania;
                            modelo.col_pro = agremiado.colegio_Profesional;
                            modelo.g_acade = agremiado.grado_Academico;
                            modelo.departamento = agremiado.departamento;
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

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Editar_Agremiado(int? id)
        {

            AddAgremiadoViewModel model = new AddAgremiadoViewModel();

            using (SII_Entities db = new SII_Entities())
            {
                var agremiado = db.Tbl_Agremiado.Find(id);
                model.profesion = agremiado.profesion;
                model.puesto = agremiado.puesto;
                model.correo_Electronico = agremiado.Tbl_Usuario.Tbl_Persona.correo_Electronico;
                model.Telefono = agremiado.Tbl_Usuario.Tbl_Persona.telefono;
            }

            return View(model);
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpPost]
        public ActionResult Editar_Agremiado(AddAgremiadoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SII_Entities db = new SII_Entities())
                    {
                        var agremiado = db.Tbl_Agremiado.Find();
                        agremiado.profesion = model.profesion;
                        agremiado.Tbl_Usuario.Tbl_Persona.telefono = model.Telefono;
                        agremiado.puesto = model.puesto;
                        agremiado.Tbl_Usuario.Tbl_Persona.correo_Electronico = model.correo_Electronico;
                        db.Entry(agremiado).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        TempData["msg"] = "Modificado";
                        ViewBag.Msg = TempData["msg"];

                    }
                    return Redirect("/Agremiados/Agremiados");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}