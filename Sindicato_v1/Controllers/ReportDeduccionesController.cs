using Sindicato_v1.Models;
using Sindicato_v1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.Mvc;

namespace Sindicato_v1.Controllers
{
    public class ReportDeduccionesController : Controller
    {
        public void GetDeduccionesReport()
        {
            ReportParams<DeduccionesInfoEntity> obj_ReportParams = new ReportParams<DeduccionesInfoEntity>();
            obj_ReportParams.DataSource = GetAllDeducciones();
            obj_ReportParams.RptFileName = "DeduccionesReport.rpt";
            this.HttpContext.Session["ReportType"] = "DeduccionesInfoReport";
            this.HttpContext.Session["ReportParam"] = obj_ReportParams;
        }

        public List<DeduccionesInfoEntity> GetAllDeducciones()
        {
            string constr = ConfigurationManager.ConnectionStrings["StrConnection1"].ConnectionString;
            DataTable dt = new DataTable();
            string sql = "select d.id_Deduccion, p.cedula, d.fecha_Deduccion, d.monto from Tbl_Deduccion d, Tbl_Agremiado a, Tbl_Persona p, Tbl_Usuario u where a.id_Usuario = u.id_Usuario and u.id_Persona = p.id_Persona and d.id_Agremiado = a.id_Agremiado";
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adtp = new SqlDataAdapter(cmd);
            adtp.Fill(dt);
            var list = ConvertDataTableToList<DeduccionesInfoEntity>(dt);
            return list;
        }

        private static List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return obj;
        }
    }
}