using Sindicato_v1.Models;
using Sindicato_v1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Sindicato_v1.Controllers
{

    public class SolicitudController : Controller
    {
        public void GetSolicitud()
        {
            ReportParams<SolicitudViewModel> obj_ReportParams = new ReportParams<SolicitudViewModel>();
            obj_ReportParams.DataSource = GetAllInfoSol();
            obj_ReportParams.RptFileName = "Solicitud.rpt";
            this.HttpContext.Session["ReportType"] = "SolicitudInfoReport";
            this.HttpContext.Session["ReportParam"] = obj_ReportParams;
        }

        public List<SolicitudViewModel> GetAllInfoSol()
        {
            string constr = ConfigurationManager.ConnectionStrings["StrConnection1"].ConnectionString;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            var sql = new System.Data.SqlClient.SqlCommand();
            sql.Connection = con;
            sql.CommandType = CommandType.Text;
            sql.CommandText = "select p.nombre, p.primer_Apellido, p.segundo_Apellido, p.telefono, p.correo_Electronico, p.cedula, p.genero, p.fecha_Nac, a.puesto, a.profesion, a.colegio_Profesional, a.grado_Academico, c.nom_Compania, d.departamento, d.ubicacion from Tbl_Persona p, Tbl_Agremiado a, Tbl_Compania c, Tbl_Departamento d, Tbl_EstadoCivil ec, Tbl_Usuario u where a.id_Usuario = u.id_Usuario AND u.id_Persona = p.id_Persona AND a.id_LugarTrabajo = d.id_Departamento AND d.id_Compania = c.id_Compania AND p.id_ECivil = ec.id_ECivil"; //AND p.id_Persona = @id";
            //sql.Parameters.AddWithValue("@id", Id_Persona);

            SqlDataAdapter adtp = new SqlDataAdapter(sql);
            adtp.Fill(dt);
            var list = ConvertDataTableToList<SolicitudViewModel>(dt);
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