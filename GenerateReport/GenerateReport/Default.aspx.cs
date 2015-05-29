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
            Paragraph p = new Paragraph("Export Database data to PDF file");

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                PdfPTable pdfTab = new PdfPTable(146);
                pdfTab.HorizontalAlignment = 1;
                pdfTab.SpacingBefore = 20f;

                List<InspectionField> data = new List<InspectionField>();
                InspectionField data_1 = new InspectionField(1);
                data.Add(data_1);

                foreach (var item in data)
                {
                    pdfTab.AddCell(item.Device_ID.ToString());
                    //ADD Everthing else as well

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