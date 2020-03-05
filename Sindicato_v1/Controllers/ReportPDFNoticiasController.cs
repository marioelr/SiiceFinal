using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sindicato_v1.Models;
using Sindicato_v1.Models.ViewModels;
using Sindicato_v1.Filters;

namespace Sindicato_v1.Controllers
{
    public class ReportPDFNoticiasController : Controller
    {
        SII_Entities db = new SII_Entities();
        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult ShowNoticias()
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
            try
            {
                List<NoticasInfoEntity> lst;
                using (SII_Entities db = new SII_Entities())
                {
                    lst = (from n in db.Tbl_NoticiasPDF
                           where n.estado == 1
                           select new NoticasInfoEntity
                           {
                               id_Noticias = n.id_Noticia,
                               titulo = n.titulo_Noticia,
                               fecha_Creacion = n.fecha_Creacion_N,
                               subtitulo = n.subtitulo_Noticia,
                               texto = n.contenido_Noticia
                           }).ToList();
                }
                return View(lst);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult PDFNoticias()
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            return View();
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpPost]
        public ActionResult PDFNoticias(AddNoticiasViewModel model)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            try
            {
                if (ModelState.IsValid)
                {
                    using (SII_Entities db = new SII_Entities())
                    {
                        var obj_Noticia = new Tbl_NoticiasPDF();
                        obj_Noticia.titulo_Noticia = model.titulo;
                        obj_Noticia.fecha_Creacion_N = DateTime.Now;
                        obj_Noticia.subtitulo_Noticia = model.subtitulo;
                        obj_Noticia.contenido_Noticia = model.texto;
                        obj_Noticia.estado = 1;
                        db.Tbl_NoticiasPDF.Add(obj_Noticia);
                        db.SaveChanges();

                        TempData["msg"] = "Agregado";
                        ViewBag.Msg = TempData["msg"];
                    }
                    return Redirect("/ReportPDFNoticias/ShowNoticias");
                }
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpGet]
        public ActionResult PDF(int IdNoticia)
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

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Editar_Noticia(int? IdNoticia)
        {
            try
            {
                ViewData["Nombre"] = AccesoController.nombre;
                ViewData["Apellido"] = AccesoController.apellido;

                AddNoticiasViewModel model = new AddNoticiasViewModel();
                using (SII_Entities db = new SII_Entities())
                {
                    var obj_Noticias = db.Tbl_NoticiasPDF.Find(IdNoticia);
                    model.id_Noticias = obj_Noticias.id_Noticia;
                    model.fecha_Creacion = obj_Noticias.fecha_Creacion_N;
                    model.titulo = obj_Noticias.titulo_Noticia;
                    model.subtitulo = obj_Noticias.subtitulo_Noticia;
                    model.texto = obj_Noticias.contenido_Noticia;
                }
                return View(model);
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpPost]
        public ActionResult Editar_Noticia(AddNoticiasViewModel model)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            try
            {
                if (ModelState.IsValid)
                {
                    using (SII_Entities db = new SII_Entities())
                    {
                        var obj_Noticias = db.Tbl_NoticiasPDF.Find(model.id_Noticias);
                        obj_Noticias.id_Noticia = model.id_Noticias;
                        obj_Noticias.titulo_Noticia = model.titulo;
                        obj_Noticias.subtitulo_Noticia = model.subtitulo;
                        obj_Noticias.contenido_Noticia = model.texto;
                        db.Entry(obj_Noticias).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        TempData["msg"] = "Modificado";
                        ViewBag.Msg = TempData["msg"];
                    }
                    return Redirect("/ReportPDFNoticias/ShowNoticias");
                }
                return View(model);
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpGet]
        public ActionResult Eliminar_Noticia(int? IdNoticias)
        {
            try
            {
                using (SII_Entities db = new SII_Entities())
                {
                    try
                    {
                        var obj_Noticias = db.Tbl_NoticiasPDF.Find(IdNoticias);

                        if (obj_Noticias.estado == 1)
                        {
                            obj_Noticias.estado = 0;
                            db.Entry(obj_Noticias).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();

                            TempData["msg"] = "Eliminado";
                            ViewBag.Msg = TempData["msg"];
                        }
                    }
                    catch (Exception)
                    {
                        TempData["msg"] = "Error";
                        ViewBag.Msg = TempData["msg"];
                    }
                }
                return Redirect("/ReportPDFNoticias/ShowNoticias");
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }
    }
}
