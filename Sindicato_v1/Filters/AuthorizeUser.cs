using Sindicato_v1.Controllers;
using Sindicato_v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sindicato_v1.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private Tbl_Usuario usuario;
        private SII_Entities db = new SII_Entities();
        private int permiso;
        private int tusu;

        public AuthorizeUser(int permiso, int tusu)
        {
            this.permiso = permiso;
            this.tusu = tusu;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                usuario = (Tbl_Usuario)HttpContext.Current.Session[AccesoController.sess_name];

                var list_Permisos = from tu in db.Tbl_TipoUsuario
                                    join r in db.Tbl_Rol
                                    on
                                    usuario.id_Rol equals r.id_Rol
                                    where tu.id_TipoUsu == usuario.id_TipoUsu
                                        && r.id_Rol == permiso && tu.id_TipoUsu == tusu
                                    select r;

                if (list_Permisos.ToList().Count() == 0)
                {
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation");
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation");
            }
        }
    }
}