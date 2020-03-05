using Sindicato_v1.Models;
using Sindicato_v1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Siice_WebSite.Controllers
{
    public class PasswordRecoveryController : Controller
    {
        #region Recuperar contraseña

        string urlDomain = "https://localhost:44356/";

        [HttpGet]
        public ActionResult StarRecovery(string token)
        {
            RecoveryViewModel model = new RecoveryViewModel();
            return View();
        }

        [HttpPost]
        public ActionResult StarRecovery(RecoveryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string token = GetSha256(Guid.NewGuid().ToString());

            using (SII_Entities db = new SII_Entities())
            {
                var oUser = db.Tbl_Usuario.Where(d => d.Tbl_Persona.correo_Electronico == model.Email).FirstOrDefault();
                if (oUser != null)
                {
                    oUser.token_recovery = token;
                    token = oUser.token_recovery;
                    db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    TempData["msg"] = "Recuperado";
                    ViewBag.Msg = TempData["msg"];

                    //enviar email
                    SendEmail(oUser.Tbl_Persona.correo_Electronico, token);
                }
            }
            return Redirect("http://localhost:51219/Acceso/Login");
        }

        [HttpGet]
        public ActionResult Recovery(string token)
        {
            RecoveryPasswordViewModel model = new RecoveryPasswordViewModel();
            model.token = token;

            using (SII_Entities db = new SII_Entities())
            {

                if (model.token == null || model.token.Trim().Equals(""))
                {
                    return Redirect("http://localhost:51219/Acceso/Login");
                }
                var oUser = db.Tbl_Usuario.Where(d => d.token_recovery == model.token).FirstOrDefault();
                if (oUser == null)
                {
                    ViewBag.Error = "Session expirada";
                    return Redirect("http://localhost:51219/Acceso/Login");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Recovery(RecoveryPasswordViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                using (SII_Entities db = new SII_Entities())
                {
                    var oUser = db.Tbl_Usuario.Where(d => d.token_recovery == model.token).FirstOrDefault();

                    if (oUser != null)
                    {
                        string encrypted_Pass = Encrypt.GetSHA256(model.Contraseña);
                        oUser.contrasenia = encrypted_Pass;
                        oUser.token_recovery = null;
                        db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            ViewBag.Message = "Contraseña modificada con exito";
            return Redirect("http://localhost:51219/Acceso/Login");
        }

        #region Helpers

        private string GetSha256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        private void SendEmail(string EmailDestino, string token)
        {
            string EmailOrigen = "sindicatocr.siice@gmail.com";
            string Contraseña = "Siice.2019";
            string url = urlDomain + "/Usuario/Recovery/?token=" + token;

            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Recuperacion de contraseña",
                "<p>Correo para recuperacion de contraseña</p><br/>" +
                "<a href='" + url + "'>Click para recuperar<a/>");

            oMailMessage.IsBodyHtml = true;
            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");

            oSmtpClient.UseDefaultCredentials = false;
            //oSmtpClient.Host = "smtp.gmail.com";
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);
            oSmtpClient.EnableSsl = true;
            oSmtpClient.Send(oMailMessage);
            oSmtpClient.Dispose();
        }

        #endregion
    }
    #endregion
}