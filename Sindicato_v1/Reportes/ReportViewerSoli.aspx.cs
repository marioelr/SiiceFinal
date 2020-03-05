using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

namespace Sindicato_v1.Reportes
{
    public partial class ReportViewerSoli : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadReportSoli();
        }

        public void LoadReportSoli()
        {
            var reportParam = (dynamic)HttpContext.Current.Session["ReportParam"];
            ReportDocument rd = new ReportDocument();
            string path = Server.MapPath("~") + "Reportes//Rpt//" + reportParam.RptFileName;
            var dataSource = reportParam.DataSource;
            rd.Load(path);
            rd.SetDataSource(dataSource);
            Solicitudes_Afiliacion.ReportSource = rd;
        }
    }
}