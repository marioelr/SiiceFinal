using Sindicato_v1.Models;
using Sindicato_v1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sindicato_v1.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Registro()
        {
            loadDropDownListEstado();
            loadDropDownListRol();
            loadDropDownListUsuario();
            loadDropDownListDep();
            loadCountryDropDownList();
            return View();
        }

        [HttpPost]
        public ActionResult Registro(AddAgremiadoViewModel model)
        {
            loadDropDownListEstado();
            loadDropDownListRol();
            loadDropDownListUsuario();
            loadDropDownListDep();
            loadCountryDropDownList();

            try
            {
                if (ModelState.IsValid)
                {
                    using (SII_Entities db = new SII_Entities())
                    {
                        //****************************************************Persona*******************************************************
                        var obj_Persona = new Tbl_Persona();

                        var comp_ced = (from c in db.Tbl_Persona
                                        where c.cedula == model.cedula
                                        select c.cedula);

                        if (comp_ced.Count() != 0)
                        {
                            Response.Write("<script>alert('¡El numero de cédula ya se encuentra registrado en el sistema! por favor, revíselo e intente de nuevo.');</script>");
                            return View(model);
                        }
                        else
                        {
                            obj_Persona.cedula = model.cedula;
                            obj_Persona.nombre = model.nombre;
                            obj_Persona.primer_Apellido = model.primer_apellido;
                            obj_Persona.segundo_Apellido = model.segundo_apellido;
                            obj_Persona.genero = model.Genero;
                            obj_Persona.nacionalidad = model.nacionalidad;
                            obj_Persona.id_ECivil = model.id_ECivil;
                            obj_Persona.fecha_Nac = model.fecha_Nac;
                            obj_Persona.fecha_Reg = DateTime.Today;
                            obj_Persona.telefono = model.Telefono;
                            obj_Persona.direccion = model.Direccion;
                            obj_Persona.correo_Electronico = model.correo_Electronico;
                            obj_Persona.estado = 2;

                            int IDPer = obj_Persona.id_Persona;

                            ////**************************************************Usuario*************************************************
                            var obj_Usuario = new Tbl_Usuario();

                            string encrypted_Pass0 = Encrypt.GetSHA256(model.contrasenia);
                            obj_Usuario.contrasenia = encrypted_Pass0;

                            string encrypted_Pass1 = Encrypt.GetSHA256(model.conf_contrasenia);

                            if (obj_Usuario.contrasenia != encrypted_Pass1)
                            {
                                TempData["msg"] = "Pass";
                                ViewBag.Msg = TempData["msg"];
                                return View(model);
                            }

                            obj_Usuario.id_Persona = IDPer;
                            obj_Usuario.id_Rol = 4;
                            obj_Usuario.id_TipoUsu = 3;
                            obj_Usuario.estado = 1;

                            int IDUsu = obj_Usuario.id_Usuario;

                            //***************************************************Empleado************************************************
                            var obj_Agremiado = new Tbl_Agremiado();
                            obj_Agremiado.profesion = model.profesion;
                            obj_Agremiado.colegio_Profesional = model.colegio_Pro;
                            obj_Agremiado.id_LugarTrabajo = model.id_Departamento;
                            obj_Agremiado.id_Usuario = IDUsu;
                            obj_Agremiado.grado_Academico = model.g_Academico;
                            obj_Agremiado.puesto = model.puesto;
                            obj_Agremiado.estado = 1;

                            db.Tbl_Persona.Add(obj_Persona);
                            db.Tbl_Usuario.Add(obj_Usuario);
                            db.Tbl_Agremiado.Add(obj_Agremiado);
                            db.SaveChanges();

                            TempData["msg"] = "Agregado";
                            ViewBag.Msg = TempData["msg"];
                        }
                    }
                    return Redirect("~/Acceso/Login");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void loadDropDownListRol()
        {
            SII_Entities dba = new SII_Entities();
            List<Tbl_Rol> list = dba.Tbl_Rol.ToList();
            ViewBag.RolList = new SelectList(list, "id_Rol", "tipo_Rol");
        }
        public void loadDropDownListUsuario()
        {
            SII_Entities dba = new SII_Entities();
            List<Tbl_TipoUsuario> list = dba.Tbl_TipoUsuario.ToList();
            ViewBag.UsuarioList = new SelectList(list, "id_TipoUsu", "tipo_Usuario");
        }

        public void loadDropDownListEstado()
        {
            SII_Entities dba = new SII_Entities();
            List<Tbl_EstadoCivil> list = dba.Tbl_EstadoCivil.ToList();
            ViewBag.EstadoCivilList = new SelectList(list, "id_ECivil", "estado_Civil");
        }

        public void loadDropDownListDep()
        {
            SII_Entities dba = new SII_Entities();
            List<Tbl_Departamento> list = dba.Tbl_Departamento.ToList();
            ViewBag.DepList = new SelectList(list, "id_Departamento", "departamento");
        }

        public void loadCountryDropDownList()
        {
            SII_Entities dba = new SII_Entities();
            List<Tbl_Pais> list = dba.Tbl_Pais.ToList();
            ViewBag.Country = new SelectList(list, "id_Pais", "country_name");
        }
    }
}