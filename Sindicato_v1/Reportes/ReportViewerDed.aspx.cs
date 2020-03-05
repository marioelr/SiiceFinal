using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Web;

namespace Sindicato_v1
{
    public partial class ReportViewer1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadReportDed();
        }
        public void LoadReportDed()
        {
            var reportParam = (dynamic)HttpContext.Current.Session["ReportParam"];
            ReportDocument rd = new ReportDocument();
            string path = Server.MapPath("~") + "Reportes//Rpt//" + reportParam.RptFileName;
            var dataSource = reportParam.DataSource;
            rd.Load(path);
            rd.SetDataSource(dataSource);
            Reporte_Deducciones.ReportSource = rd;
        }
    }
}