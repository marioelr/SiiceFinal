using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Web;

namespace Sindicato_v1.Reportes
{
    public partial class ReportViewerAgr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadReportAg();
        }
        public void LoadReportAg()
        {
            var reportParam = (dynamic)HttpContext.Current.Session["ReportParam"];
            ReportDocument rd = new ReportDocument();
            string path = Server.MapPath("~") + "Reportes//Rpt//" + reportParam.RptFileName;
            var dataSource = reportParam.DataSource;
            rd.Load(path);
            rd.SetDataSource(dataSource);
            Reporte_Agremiados.ReportSource = rd;
        }
    }
}