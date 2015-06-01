using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GenerateReport
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fileName = Guid.NewGuid() + ".pdf";
            string filePath = Path.Combine(Server.MapPath("~/PDFFiles"), fileName);

            Document doc = new Document(PageSize.A4, 2, 2, 2, 2);
            Paragraph p = new Paragraph("Data Sheet");

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                PdfPTable pdfTab = new PdfPTable(2);
                pdfTab.HorizontalAlignment = 1;
                pdfTab.SpacingBefore = 20f;

                Table data = new Table();


                foreach (var prop in data.GetType().GetProperties())
                {
                    PdfPCell[] cells = new PdfPCell[] {  
                                                        new PdfPCell(new Phrase(prop.Name)),
                                                        new PdfPCell(new Phrase(prop.GetValue(data,null).ToString()))
                                                      };


                    PdfPRow row = new PdfPRow(cells);
                    pdfTab.Rows.Add(row);
                }

                doc.Open();
                doc.Add(p);
                doc.Add(pdfTab);
                doc.Close();

                byte[] content = File.ReadAllBytes(filePath);
                HttpContext context = HttpContext.Current;

                context.Response.BinaryWrite(content);
                context.Response.ContentType = "application/pdf";
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                context.Response.End();


            }

            catch
            {
                throw;

            }

            finally
            {
                doc.Close();
            }
        }

      
    }
}