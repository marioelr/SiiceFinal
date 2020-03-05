using Sindicato_v1.Controllers;
using Sindicato_v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sindicato_v1.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        private Tbl_Usuario  usuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
            
                usuario = (Tbl_Usuario)HttpContext.Current.Session[AccesoController.sess_name];
                if (usuario == null)
                {
                    if (filterContext.Controller is AccesoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Acceso/Login");
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }
        }
    }
}