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
    public class ReportPDFActasController : Controller
    {
        SII_Entities db = new SII_Entities();
        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult ShowActas()
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
                List<ActasInfoEntity> lst;
                using (SII_Entities db = new SII_Entities())
                {
                    lst = (from a in db.Tbl_ActasPDF
                           where a.estado == 1
                           select new ActasInfoEntity
                           {
                               id_Actas = a.id_Acta,
                               titulo = a.titulo_Acta,
                               fecha_Creacion = a.fecha_Creacion_A,
                               subtitulo = a.subtitulo_Acta,
                               texto = a.contenido_Acta
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
        public ActionResult PDFActas()
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            return View();
        }

        [AuthorizeUser(permiso: 1, tusu: 3)]
        [HttpPost]
        public ActionResult PDFActas(AddActasViewModel model)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            try
            {
                if (ModelState.IsValid)
                {
                    using (SII_Entities db = new SII_Entities())
                    {
                        var obj_Acta = new Tbl_ActasPDF();
                        obj_Acta.titulo_Acta = model.titulo;
                        obj_Acta.fecha_Creacion_A = DateTime.Now;
                        obj_Acta.subtitulo_Acta = model.subtitulo;
                        obj_Acta.contenido_Acta = model.texto;
                        obj_Acta.estado = 1;
                        db.Tbl_ActasPDF.Add(obj_Acta);
                        db.SaveChanges();

                        TempData["msg"] = "Agregado";
                        ViewBag.Msg = TempData["msg"];

                    }
                    return Redirect("/ReportPDFActas/ShowActas");
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
        public ActionResult PDF(int IdActas)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            string pdfpath = Server.MapPath("PDF");
            string imagepath = Server.MapPath("LogoSIICE");
            MemoryStream ms = new MemoryStream();
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 30f, 20f, 50f, 40f);
            PdfWriter pw = PdfWriter.GetInstance(document, ms);
            //PdfWriter.GetInstance(document, new FileStream("LogoSIICE.png", FileMode.Create));
            pw.PageEvent = new HeaderFooter();
            document.Open();

            //iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(System.Drawing.Imaging.ImageFormat.Png);

            //document.Add(new Paragraph("PNG Scaled to 300dpi"));
            //Image png = Image.GetInstance(imagepath + "~/Content/Resources/Images/LogoSIICE.png");
            //png.ScalePercent(24f);
            //document.Add(png);

            //iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("/Content/Resources/Images/logoSIICE.png");
            //document.Add(PNG);

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

        [AuthorizeUser(permiso: 1, tusu: 3)]
        public ActionResult Editar_Actas(int? IdActas)
        {
            try
            {
                ViewData["Nombre"] = AccesoController.nombre;
                ViewData["Apellido"] = AccesoController.apellido;

                AddActasViewModel model = new AddActasViewModel();

                using (SII_Entities db = new SII_Entities())
                {
                    var obj_Actas = db.Tbl_ActasPDF.Find(IdActas);
                    model.id_Actas = obj_Actas.id_Acta;
                    model.fecha_Creacion = obj_Actas.fecha_Creacion_A;
                    model.titulo = obj_Actas.titulo_Acta;
                    model.subtitulo = obj_Actas.subtitulo_Acta;
                    model.texto = obj_Actas.contenido_Acta;
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
        public ActionResult Editar_Actas(AddActasViewModel model)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;

            try
            {
                if (ModelState.IsValid)
                {
                    using (SII_Entities db = new SII_Entities())
                    {
                        var obj_Actas = db.Tbl_ActasPDF.Find(model.id_Actas);
                        obj_Actas.id_Acta = model.id_Actas;
                        obj_Actas.titulo_Acta = model.titulo;
                        obj_Actas.subtitulo_Acta = model.subtitulo;
                        obj_Actas.contenido_Acta = model.texto;
                        obj_Actas.estado = 1;
                        db.Entry(obj_Actas).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        TempData["msg"] = "Modificado";
                        ViewBag.Msg = TempData["msg"];

                    }
                    return Redirect("/ReportPDFActas/ShowActas");
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
        public ActionResult Eliminar_Acta(int? IdActas)
        {
            ViewData["Nombre"] = AccesoController.nombre;
            ViewData["Apellido"] = AccesoController.apellido;
            try
            {
                using (SII_Entities db = new SII_Entities())
                {

                    try
                    {
                        var obj_Actas = db.Tbl_ActasPDF.Find(IdActas);

                        if (obj_Actas.estado == 1)
                        {
                            obj_Actas.estado = 0;
                            db.Entry(obj_Actas).State = System.Data.Entity.EntityState.Modified;
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
                return Redirect("/ReportPDFActas/ShowActas");
            }
            catch (Exception)
            {
                return Redirect("/Error/InaccessiblePage");
            }
        }
    }
}
