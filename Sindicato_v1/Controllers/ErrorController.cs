using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sindicato_v1.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult UnauthorizedOperation()
        {
            ViewData["View"] = AccesoController.view;
            return View();
        }

        public ActionResult InaccessiblePage()
        {
           ViewData["View"] = AccesoController.view;
           return View( );
        }

        public ActionResult UploadTooLarge()
        {
            ViewData["View"] = AccesoController.view;
            return View();
        }
    }
}