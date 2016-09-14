using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

using iTextSharp.text.pdf.fonts;
using System.IO;




namespace GUI.Forms.Fichas
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }

        private void Print_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 15, 15);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Teste de PDF.pdf", FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(5);

            table.TotalWidth = 100;
            table.PaddingTop = 0;

            PdfPCell cell = new PdfPCell(new Phrase("Nome da ficha técnica - 20.00.0000"));
            
            cell.Colspan = 5;
            cell.FixedHeight = 40f;
            cell.HorizontalAlignment = 1; //0=esquerda, 1 = centro, 2=direita
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cell);
            
            table.AddCell("Coluna 1, linha 1");
            table.AddCell("Coluna 2, linha 1");
            table.AddCell("Coluna 3, linha 1");
            table.AddCell("Coluna 4, linha 1");
            table.AddCell("Coluna 5, linha 1");
            table.AddCell("Coluna 1, linha 2");
            table.AddCell("Coluna 2, linha 2");
            table.AddCell("Coluna 3, linha 2");
            table.AddCell("Coluna 4, linha 2");
            table.AddCell("Coluna 5, linha 2");
            table.AddCell("Coluna 1, linha 3");
            table.AddCell("Coluna 2, linha 3");
            table.AddCell("Coluna 3, linha 3");
            table.AddCell("Coluna 4, linha 3");
            table.AddCell("Coluna 5, linha 3");

            doc.Add(table);


            doc.Close();
        }
    }
}
