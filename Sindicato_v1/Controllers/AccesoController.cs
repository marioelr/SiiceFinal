using Sindicato_v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sindicato_v1.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            try
            {
                ViewBag.Msg = TempData["msg"].ToString();
            }
            catch (Exception)
            {

            }

            return View();
        }

        public static int pendientes;
        public static int id_Ag;
        public static int id_Per;
        public static int agre;
        public static string sess_name;
        public static string nombre;
        public static string apellido;
        public static string view;

        [HttpPost]
        public ActionResult Login(long user, string contrasenia)
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
                using (SII_Entities db = new SII_Entities())
                {
                    string encryptedPass = Encrypt.GetSHA256(contrasenia);

                    var usuario = (from u in db.Tbl_Usuario
                                   join p in db.Tbl_Persona on u.id_Persona equals p.id_Persona
                                   join tr in db.Tbl_Rol on u.id_Rol equals tr.id_Rol
                                   join tu in db.Tbl_TipoUsuario on u.id_TipoUsu equals tu.id_TipoUsu
                                   where u.contrasenia == encryptedPass && p.cedula == user && p.estado == 1
                                   select u).FirstOrDefault();

                    var lista_pend = from p in db.Tbl_Persona
                                     where p.estado == 2
                                     select new { p.id_Persona };

                    #region NombreUsuario, Pendientes

                    pendientes = lista_pend.Count();

                    nombre = (from p in db.Tbl_Persona
                              where p.id_Persona == usuario.id_Persona
                              select p.nombre).First();

                    apellido = (from p in db.Tbl_Persona
                                where p.id_Persona == usuario.id_Persona
                                select p.primer_Apellido).First();

                    #endregion

                    if (usuario == null)
                    {
                        TempData["msg"] = "Error_Log";
                        ViewBag.Msg = TempData["msg"];

                        return Login();
                    }

                    if (usuario.id_Rol == 1 || usuario.id_Rol == 2)
                    {
                        sess_name = "User";

                        Session[sess_name] = usuario;
                    }
                    else if (usuario.id_Rol == 4)
                    {
                        sess_name = "Agremiado";

                        id_Ag = (from a in db.Tbl_Agremiado
                                 where usuario.id_Usuario == a.id_Usuario
                                 select a.id_Agremiado).First();

                        Session[sess_name] = usuario;
                    }
                }

                view = null;

                if (Session[sess_name] == Session["User"])
                {
                    view = "Administrador";
                }
                else if (Session[sess_name] == Session["Agremiado"])
                {
                    view = "Perfil";
                }
                return RedirectToAction(view, "Usuario");

            }
            catch (Exception ex)
            {
                ex.Message.ToString();

                TempData["msg"] = "Error_Log";
                ViewBag.Msg = TempData["msg"];

                return RedirectToAction("Login", "Acceso");
            }
        }

        //public void insert_Bitacora(int usuario, int rol)
        //{
        //    try
        //    {
        //        using (SII_Entities db = new SII_Entities())
        //        {
        //            var bitacora = new Tbl_Bit_Ingreso();
        //            bitacora.usuario = usuario;
        //            bitacora.rol = rol;
        //            bitacora.hora = DateTime.Now;
        //            db.Tbl_Bit_Ingreso.Add(bitacora);
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }



}