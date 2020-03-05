
using Sindicato_v1.Hubs;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Sindicato_v1.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Notifications()
        {
            return View();
        }

        public JsonResult Get()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["StrConnection"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT [cedula],[nombre],[primer_Apellido], [segundo_Apellido] FROM [dbo].[Tbl_Persona] WHERE [Estado] = 2", connection))
                {
                    command.Notification = null;

                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    var listNoti = reader.Cast<IDataRecord>()
                            .Select(x => new
                            {
                                Cedula = (long)x["cedula"],
                                Nombre = (string)x["nombre"],
                                Apellido1 = (string)x["primer_Apellido"],
                                Apellido2 = (string)x["segundo_Apellido"]
                            }).ToList();

                    return Json(new { listNoti = listNoti }, JsonRequestBehavior.AllowGet);

                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            NotificationsHub.Show();
        }
    }
}