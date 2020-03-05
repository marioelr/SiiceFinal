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
    public class ReportAgremiadoController : Controller
    {
        public void GetAgremiadosReport()
        {
            ReportParams<AgremiadosInfoEntity> obj_ReportParams = new ReportParams<AgremiadosInfoEntity>();
            obj_ReportParams.DataSource = GetAllAgremiados();
            obj_ReportParams.RptFileName = "AgremiadosReport.rpt";
            this.HttpContext.Session["ReportType"] = "AgremiadosInfoReport";
            this.HttpContext.Session["ReportParam"] = obj_ReportParams;
        }

        public List<AgremiadosInfoEntity> GetAllAgremiados()
        {
            string constr = ConfigurationManager.ConnectionStrings["StrConnection1"].ConnectionString;
            DataTable dt = new DataTable();
            string sql = "select p.cedula, p.nombre, p.primer_Apellido, p.segundo_Apellido, p.genero, a.colegio_Profesional, a.puesto, a.profesion from Tbl_Agremiado a, Tbl_Persona p, Tbl_Usuario u where u.id_Persona = p.id_Persona and a.id_Usuario = u.id_Usuario";
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adtp = new SqlDataAdapter(cmd);
            adtp.Fill(dt);
            var list = ConvertDataTableToList<AgremiadosInfoEntity>(dt);
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
