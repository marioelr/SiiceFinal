using Sindicato_v1.Filters;
using Sindicato_v1.Models;
using Sindicato_v1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Sindicato_v1.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Mant_Empleado(int? page)
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

            List<SelectEmpleadoViewModel> lst;

            using (SII_Entities db = new SII_Entities())
            {
                lst = (//Tabal persona y usuario
                       from p in db.Tbl_Persona
                       join u in db.Tbl_Usuario
                       on p.id_Persona equals u.id_Persona

                       //Tabla empleado y usuario
                       join em in db.Tbl_Empleado
                       on u.id_Usuario equals em.id_Usuario

                       //Tabla tipo de usuario y usuario
                       join t in db.Tbl_TipoUsuario
                       on u.id_TipoUsu equals t.id_TipoUsu

                       //Tabla rol y usuario
                       join r in db.Tbl_Rol
                       on u.id_Rol equals r.id_Rol

                       //Tabla estado civil y empleado
                       join e in db.Tbl_EstadoCivil
                       on p.id_ECivil equals e.id_ECivil

                       join pa in db.Tbl_Pais on p.nacionalidad equals
                       pa.id_Pais

                       where em.estado == 1 || em.estado == 3

                       // Llamar variables 
                       select new SelectEmpleadoViewModel


                       // persona usuario tipousuario estadocivil rol empleado 
                       {
                           //Persona
                           id_Persona = p.id_Persona,
                           cedula = p.cedula,
                           nombre = p.nombre,
                           primer_apellido = p.primer_Apellido,
                           segundo_apellido = p.segundo_Apellido,
                           Genero = p.genero,
                           nacionalidad = pa.country_name,
                           Telefono = p.telefono,
                           Direccion = p.direccion,
                           correo_Electronico = p.correo_Electronico,


                           //Usuario
                           id_Usuario = u.id_Usuario,
                           contrasenia = u.contrasenia,

                           //Estado civil
                           id_ECivil = e.id_ECivil,
                           estado_Civil = e.estado_Civil,

                           //Tipo usuario
                           id_TipoUsu = t.id_TipoUsu,
                           tipo_Usuario = t.tipo_Usuario,

                           //Rol
                           id_Rol = r.id_Rol,
                           tipo_Rol = r.tipo_Rol,

                           //Empleado
                           id_Empleado = em.id_Empleado,
                           cargo = em.cargo,
                           superior_Inmediato = em.superior_Inmediato


                       }).ToList();
            }
            return View(lst.ToPagedList(page ?? 1, 8));
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Inha_Emp(int? page)
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
                List<SelectEmpleadoViewModel> lst;

                using (SII_Entities db = new SII_Entities())
                {
                    lst = (//Tabal persona y usuario
                           from p in db.Tbl_Persona
                           join u in db.Tbl_Usuario
                           on p.id_Persona equals u.id_Persona

                           //Tabla empleado y usuario
                           join em in db.Tbl_Empleado
                               on u.id_Usuario equals em.id_Usuario

                           //Tabla tipo de usuario y usuario
                           join t in db.Tbl_TipoUsuario
                               on u.id_TipoUsu equals t.id_TipoUsu

                           //Tabla rol y usuario
                           join r in db.Tbl_Rol
                               on u.id_Rol equals r.id_Rol

                           //Tabla estado civil y empleado
                           join e in db.Tbl_EstadoCivil
                               on p.id_ECivil equals e.id_ECivil

                           join pa in db.Tbl_Pais on p.nacionalidad equals
                           pa.id_Pais

                           where em.estado == 0

                           // Llamar variables 
                           select new SelectEmpleadoViewModel


                           // persona usuario tipousuario estadocivil rol empleado 
                           {
                               //Persona
                               id_Persona = p.id_Persona,
                               cedula = p.cedula,
                               nombre = p.nombre,
                               primer_apellido = p.primer_Apellido,
                               segundo_apellido = p.segundo_Apellido,
                               Genero = p.genero,
                               nacionalidad = pa.country_name,
                               Telefono = p.telefono,
                               Direccion = p.direccion,
                               correo_Electronico = p.correo_Electronico,


                               //Usuario
                               id_Usuario = u.id_Usuario,
                               contrasenia = u.contrasenia,

                               //Estado civil
                               id_ECivil = e.id_ECivil,
                               estado_Civil = e.estado_Civil,

                               //Tipo usuario
                               id_TipoUsu = t.id_TipoUsu,
                               tipo_Usuario = t.tipo_Usuario,

                               //Rol
                               id_Rol = r.id_Rol,
                               tipo_Rol = r.tipo_Rol,

                               //Empleado
                               id_Empleado = em.id_Empleado,
                               cargo = em.cargo,
                               superior_Inmediato = em.superior_Inmediato


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
        public ActionResult Activar_Emp(int? id)
        {
            try
            {
                using (SII_Entities db = new SII_Entities())
                {
                    var obj_Emp = db.Tbl_Empleado.Find(id);

                    if (obj_Emp.estado == 0)
                    {
                        obj_Emp.estado = 1;
                        db.Entry(obj_Emp).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        TempData["msg"] = "Agregado";
                        ViewBag.Msg = TempData["msg"];

                    }
                }
                return Redirect("/Empleado/Inha_Emp");
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Nuevo_Empleado()
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            loadDropDownListEstado();
            loadDropDownListRol();
            loadDropDownListUsuario();
            loadDropDownListDep();
            loadCountryDropDownList();
            return View();
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpPost]
        public ActionResult Nuevo_Empleado(AddEmpleadosViewModel model)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

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
                        //Persona
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
                            obj_Persona.estado = 1;
                            db.Tbl_Persona.Add(obj_Persona);
                            db.SaveChanges();

                            int IDPer = obj_Persona.id_Persona;

                            ////Usuario
                            var obj_Usuario = new Tbl_Usuario();
                            string encrypted_Pass = Encrypt.GetSHA256(model.contrasenia);
                            obj_Usuario.contrasenia = encrypted_Pass;
                            obj_Usuario.id_Persona = IDPer;
                            obj_Usuario.id_Rol = model.id_Rol;
                            obj_Usuario.id_TipoUsu = model.id_TipoUsu;
                            obj_Usuario.estado = 1;
                            db.Tbl_Usuario.Add(obj_Usuario);
                            db.SaveChanges();

                            int IDUsu = obj_Usuario.id_Usuario;

                            //Empleado
                            var obj_Empleado = new Tbl_Empleado();
                            obj_Empleado.cargo = model.cargo;
                            obj_Empleado.superior_Inmediato = model.superior_Inmediato;
                            obj_Empleado.id_LugarTrabajo = model.id_Departamento;
                            obj_Empleado.id_Usuario = IDUsu;
                            obj_Empleado.estado = 1;
                            db.Tbl_Empleado.Add(obj_Empleado);

                            db.SaveChanges();

                            TempData["msg"] = "Agregado";
                            ViewBag.Msg = TempData["msg"];
                        }
                    }
                    return Redirect("/Empleado/Mant_Empleado");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int id_usu;
        public static int id_emp;

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Editar_Empleado(int ID)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            loadDropDownListEstado();
            loadDropDownListRol();
            loadDropDownListUsuario();
            loadDropDownListDep();
            loadCountryDropDownList();

            AddEmpleadosViewModel model = new AddEmpleadosViewModel();

            try
            {
                using (SII_Entities db = new SII_Entities())
                {

                    //Usuario
                    id_usu = (from u in db.Tbl_Usuario
                              join p in db.Tbl_Persona on
                              u.id_Persona equals p.id_Persona
                              where u.id_Persona == ID
                              select u.id_Usuario).First();
                    //Empleado
                    id_emp = (from e in db.Tbl_Empleado
                              join u in db.Tbl_Usuario on
                              e.id_Usuario equals u.id_Usuario
                              where e.id_Usuario == id_usu
                              select e.id_Empleado).First();

                    //Modelo persona 
                    var obj_Per = db.Tbl_Persona.Find(ID);
                    model.cedula = obj_Per.cedula;
                    model.nombre = obj_Per.nombre;
                    model.primer_apellido = obj_Per.primer_Apellido;
                    model.segundo_apellido = obj_Per.segundo_Apellido;
                    model.Genero = obj_Per.genero;
                    model.nacionalidad = obj_Per.nacionalidad;
                    model.fecha_Nac = obj_Per.fecha_Nac;
                    model.Direccion = obj_Per.direccion;
                    model.correo_Electronico = obj_Per.correo_Electronico;
                    model.Telefono = obj_Per.telefono;
                    model.id_ECivil = obj_Per.id_ECivil;
                    model.id_Persona = obj_Per.id_Persona;

                    ////Modelo usuario 
                    var obj_Usu = db.Tbl_Usuario.Find(id_usu);
                    model.id_Rol = obj_Usu.id_Rol;
                    model.id_TipoUsu = obj_Usu.id_TipoUsu;

                    ////Modelo empleado 
                    var obj_Emp = db.Tbl_Empleado.Find(id_emp);
                    model.cargo = obj_Emp.cargo;
                    model.superior_Inmediato = obj_Emp.superior_Inmediato;
                    model.id_Departamento = obj_Emp.id_LugarTrabajo;
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
        public ActionResult Editar_Empleado(AddEmpleadosViewModel model)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            loadDropDownListEstado();
            loadDropDownListRol();
            loadDropDownListUsuario();
            loadDropDownListDep();
            loadCountryDropDownList();

            try
            {
                //if (ModelState.IsValid)
                //{
                using (SII_Entities db = new SII_Entities())
                {
                    var obj_Persona = db.Tbl_Persona.Find(model.id_Persona);
                    obj_Persona.cedula = model.cedula;
                    obj_Persona.nombre = model.nombre;
                    obj_Persona.primer_Apellido = model.primer_apellido;
                    obj_Persona.segundo_Apellido = model.segundo_apellido;
                    obj_Persona.genero = model.Genero;
                    obj_Persona.nacionalidad = model.nacionalidad;
                    obj_Persona.id_ECivil = model.id_ECivil;
                    obj_Persona.fecha_Nac = model.fecha_Nac;
                    obj_Persona.fecha_Reg = DateTime.Now;
                    obj_Persona.telefono = model.Telefono;
                    obj_Persona.direccion = model.Direccion;
                    obj_Persona.correo_Electronico = model.correo_Electronico;
                    db.Entry(obj_Persona).State = System.Data.Entity.EntityState.Modified;

                    int IDPer = obj_Persona.id_Persona;

                    int b_usuario = (from u in db.Tbl_Usuario
                                     where u.id_Persona == IDPer
                                     select u.id_Usuario).First();


                    ////Usuario
                    var obj_Usuario = db.Tbl_Usuario.Find(b_usuario);
                    obj_Usuario.id_Persona = IDPer;
                    obj_Usuario.id_Rol = model.id_Rol;
                    obj_Usuario.id_TipoUsu = model.id_TipoUsu;
                    db.Entry(obj_Usuario).State = System.Data.Entity.EntityState.Modified;


                    int IDUsu = obj_Usuario.id_Usuario;

                    int b_empleado = (from e in db.Tbl_Empleado
                                      where e.id_Usuario == IDUsu
                                      select e.id_Empleado).First();

                    //Empleado
                    var obj_Empleado = db.Tbl_Empleado.Find(b_empleado);
                    obj_Empleado.cargo = model.cargo;
                    obj_Empleado.superior_Inmediato = model.superior_Inmediato;
                    obj_Empleado.id_LugarTrabajo = model.id_Departamento;
                    obj_Empleado.id_Usuario = IDUsu;
                    db.Entry(obj_Empleado).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();

                    TempData["msg"] = "Modificado";
                    ViewBag.Msg = TempData["msg"];
                }
                return Redirect("/Empleado/Mant_Empleado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpGet]
        public ActionResult Eliminar_Empleado(int id)
        {
            using (SII_Entities db = new SII_Entities())
            {
                var obj_Emp = db.Tbl_Empleado.Find(id);

                if (obj_Emp.estado == 1)
                {
                    obj_Emp.estado = 0;
                }
                db.Entry(obj_Emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                TempData["msg"] = "Eliminado";
                ViewBag.Msg = TempData["msg"];
            }
            return Redirect("/Empleado/Mant_Empleado");
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
