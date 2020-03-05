using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using Sindicato_v1.Filters;
using Sindicato_v1.Models;
using Sindicato_v1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace Sindicato_v1.Controllers
{
    public class UsuarioController : Controller
    {
        public static string nom_Per;
        public static string apellido_Per;
        public static string t_Usuario;
        public static string t_Rol;
        public static int pendientes;

        SII_Entities db = new SII_Entities();

        [AuthorizeUser(permiso: 4, tusu: 3)]
        public ActionResult Usuarios()
        {
            try
            {
                ViewBag.Msg = TempData["msg"].ToString();
            }
            catch (Exception)
            {

            }

            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            return View();
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Documentos()
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            return View();
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Administrador()
        {
            try
            {
                ViewBag.Msg = TempData["msg"].ToString();
            }
            catch (Exception)
            {

            }

            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            ViewData["Conteo"] = AccesoController.pendientes;

            try
            {
                using (SII_Entities db = new SII_Entities())
                {
                    var lista = new List<SelectAgremiadosViewModel>();

                    var agremiados = from a in db.Tbl_Agremiado
                                     join u in db.Tbl_Usuario on a.id_Usuario equals u.id_Usuario
                                     join p in db.Tbl_Persona on u.id_Persona equals p.id_Persona
                                     join pa in db.Tbl_Pais on p.nacionalidad equals pa.id_Pais
                                     where p.estado == 2
                                     select new
                                     {
                                         p.cedula,
                                         p.nombre,
                                         p.primer_Apellido,
                                         p.segundo_Apellido,
                                         p.telefono,
                                         p.correo_Electronico,
                                         p.fecha_Reg,
                                         p.id_Persona
                                     };

                    foreach (var agremiado in agremiados.ToList())
                    {
                        var modelo = new SelectAgremiadosViewModel();
                        modelo.id_Persona = agremiado.id_Persona;
                        modelo.cedula = agremiado.cedula;
                        modelo.nombre = agremiado.nombre;
                        modelo.primer_Apellido = agremiado.primer_Apellido;
                        modelo.segundo_Apellido = agremiado.segundo_Apellido;
                        modelo.telefono = agremiado.telefono;
                        modelo.correo_Electronico = agremiado.correo_Electronico;
                        modelo.fecha_reg = agremiado.fecha_Reg;
                        lista.Add(modelo);

                    }
                    return View(lista);
                }
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpGet]
        public ActionResult aceptar_Soli(int? id)
        {
            try
            {
                using (SII_Entities db = new SII_Entities())
                {
                    var obj_Ag = db.Tbl_Persona.Find(id);

                    if (obj_Ag.estado == 2)
                    {
                        obj_Ag.estado = 1;
                        db.Entry(obj_Ag).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        TempData["msg"] = "Aprobado";
                        ViewBag.Msg = TempData["msg"];
                    }
                }
                return Redirect("/Usuario/Administrador");
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpGet]
        public ActionResult rechazar_Soli(int? id)
        {
            try
            {
                using (SII_Entities db = new SII_Entities())
                {
                    var obj_Ag = db.Tbl_Persona.Find(id);

                    if (obj_Ag.estado == 2)
                    {
                        obj_Ag.estado = 0;
                        db.Entry(obj_Ag).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        TempData["msg"] = "Eliminado";
                        ViewBag.Msg = TempData["msg"];
                    }
                }
                return Redirect("/Usuario/Administrador");
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        public ActionResult Noticias()
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            List<AddNoticiasViewModel> lst;
            using (SII_Entities db = new SII_Entities())
            {
                lst = (from d in db.Tbl_NoticiasPDF
                       where d.estado == 1
                       select new AddNoticiasViewModel
                       {
                           id_Noticias = d.id_Noticia,
                           titulo = d.titulo_Noticia,
                           subtitulo = d.subtitulo_Noticia,
                           fecha_Creacion = d.fecha_Creacion_N
                       }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult PDF_Noticias(int IdNoticia)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            MemoryStream ms = new MemoryStream();
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 30f, 20f, 50f, 40f);
            PdfWriter pw = PdfWriter.GetInstance(document, ms);
            pw.PageEvent = new HeaderFooterN();
            document.Open();

            //iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("/Content/Resources/Images/LogoSIICE.png");
            //document.Add(PNG);

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            Font fontText = new Font(bf, 12, 0, BaseColor.BLACK);
            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100f;
            using (SII_Entities db = new SII_Entities())
            {
                var noticia = (from n in db.Tbl_NoticiasPDF
                               where n.id_Noticia == IdNoticia
                               select n).FirstOrDefault();
                PdfPCell _cell = new PdfPCell();
                _cell = new PdfPCell(new Paragraph(noticia.id_Noticia.ToString(), fontText));
                _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(_cell);
                _cell = new PdfPCell(new Paragraph(noticia.fecha_Creacion_N.ToString(), fontText));
                _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(_cell);
                table.AddCell(new Paragraph(noticia.titulo_Noticia, fontText));
                table.AddCell(new Paragraph(noticia.subtitulo_Noticia, fontText));
                table.AddCell(new Paragraph(noticia.contenido_Noticia, fontText));
            }
            document.Add(table);
            document.Close();

            byte[] bytesStream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(bytesStream, 0, bytesStream.Length);
            ms.Position = 0;

            return new FileStreamResult(ms, "application/pdf");
        }

        class HeaderFooterN : PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                //base.OnEndPage(writer, document);
                PdfPTable tbHeader = new PdfPTable(3);
                tbHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tbHeader.DefaultCell.Border = 0;
                //iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("LogoSIICE.png");
                document.Add(new Paragraph());
                tbHeader.AddCell(new Paragraph());
                PdfPCell _cell = new PdfPCell(new Paragraph("Prueba de PDF"));
                _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                _cell.Border = 0;
                tbHeader.AddCell(_cell);
                tbHeader.AddCell(new Paragraph());
                tbHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin) + 40, writer.DirectContent);

                PdfPTable tbFooter = new PdfPTable(3);
                tbFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tbFooter.DefaultCell.Border = 0;
                tbFooter.AddCell(new Paragraph());
                _cell = new PdfPCell(new Paragraph("Acta"));
                _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                _cell.Border = 0;
                tbFooter.AddCell(_cell);
                _cell = new PdfPCell(new Paragraph("Pagina " + writer.PageNumber));
                _cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _cell.Border = 0;
                tbFooter.AddCell(_cell);
                tbFooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin) - 5, writer.DirectContent);
            }
        }

        public ActionResult Actas()
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            List<AddActasViewModel> lst;
            using (SII_Entities db = new SII_Entities())
            {
                lst = (from d in db.Tbl_ActasPDF
                       where d.estado == 1
                       select new AddActasViewModel
                       {
                           id_Actas = d.id_Acta,
                           titulo = d.titulo_Acta,
                           subtitulo = d.subtitulo_Acta,
                           fecha_Creacion = d.fecha_Creacion_A
                       }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult PDF_Actas(int IdActas)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            string pdfpath = Server.MapPath("PDF");
            string imagepath = Server.MapPath("LogoSIICE");
            MemoryStream ms = new MemoryStream();
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 30f, 20f, 50f, 40f);
            PdfWriter pw = PdfWriter.GetInstance(document, ms);

            pw.PageEvent = new HeaderFooter();
            document.Open();

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            Font fontText = new Font(bf, 12, 0, BaseColor.BLACK);
            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 100f;
            using (SII_Entities db = new SII_Entities())
            {
                var acta = (from a in db.Tbl_ActasPDF
                            where a.id_Acta == IdActas
                            select a).FirstOrDefault();

                PdfPCell _cell = new PdfPCell();
                _cell = new PdfPCell(new Paragraph(acta.id_Acta.ToString(), fontText));
                _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(_cell);
                _cell = new PdfPCell(new Paragraph(acta.fecha_Creacion_A.ToString(), fontText));
                _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(_cell);
                table.AddCell(new Paragraph(acta.titulo_Acta, fontText));
                table.AddCell(new Paragraph(acta.subtitulo_Acta, fontText));
                table.AddCell(new Paragraph(acta.contenido_Acta, fontText));
            }
            document.Add(table);
            document.Close();

            byte[] bytesStream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(bytesStream, 0, bytesStream.Length);
            ms.Position = 0;

            return new FileStreamResult(ms, "application/pdf");
        }

        class HeaderFooter : PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                //base.OnEndPage(writer, document);
                PdfPTable tbHeader = new PdfPTable(3);
                tbHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tbHeader.DefaultCell.Border = 0;
                //iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("LogoSIICE.png");
                document.Add(new Paragraph());
                tbHeader.AddCell(new Paragraph());
                PdfPCell _cell = new PdfPCell(new Paragraph("Prueba de PDF"));
                _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                _cell.Border = 0;
                tbHeader.AddCell(_cell);
                tbHeader.AddCell(new Paragraph());
                tbHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin) + 40, writer.DirectContent);

                PdfPTable tbFooter = new PdfPTable(3);
                tbFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tbFooter.DefaultCell.Border = 0;
                tbFooter.AddCell(new Paragraph());
                _cell = new PdfPCell(new Paragraph("Acta"));
                _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                _cell.Border = 0;
                tbFooter.AddCell(_cell);
                _cell = new PdfPCell(new Paragraph("Pagina " + writer.PageNumber));
                _cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _cell.Border = 0;
                tbFooter.AddCell(_cell);
                tbFooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin) - 5, writer.DirectContent);
            }
        }

        public ActionResult close_session()
        {
            Session[AccesoController.sess_name] = null;
            return RedirectToAction("Login", "Acceso");
        }

        public ActionResult Perfil()
        {
            try
            {
                ViewBag.Msg = TempData["msg"].ToString();
            }
            catch (Exception)
            {

            }

            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            return View();
        } 

    }
}