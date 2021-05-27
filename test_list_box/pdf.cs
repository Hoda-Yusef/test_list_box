using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text;
using iTextSharp;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;

namespace test_list_box
{
    public class pdf
    {
        DBSQL mySQL;

        Document myDocument = new Document();
       




        //public static void Main(string[] args)
        //{
        //    int[,] numbers = new int[10, 10];
        //    for (int i = 0; i < 10; i++)
        //    {
        //        for (int j = 0; j < 10; j++)
        //        {
        //            numbers[i, j] = i;
        //        }
        //    }

        //    pdf pr = new pdf();
        //    pr.SetImage("apple.png");
        //    pr.CloseReport();



        //}

        public pdf()//בנאי
        {
            DBSQL.DaseDataBaseName = "students";
            DBSQL.UserName = "root";
            DBSQL.Password = string.Empty;
            mySQL = DBSQL.Instance;
            iTextSharp.text.pdf.PdfWriter.GetInstance(myDocument, new FileStream("myDocument.pdf", FileMode.Create));
            myDocument.Open();
        }

        public pdf(string file_name)//בנאי מקבל שם של מסמך
        {
            DBSQL.DaseDataBaseName = "students";
            DBSQL.UserName = "root";
            DBSQL.Password = string.Empty;
            mySQL = DBSQL.Instance;
            iTextSharp.text.pdf.PdfWriter.GetInstance(myDocument, new FileStream(file_name + ".pdf", FileMode.Create));
            myDocument.Open();
        }

        public void SetTitle(string title)//פונקצייה מוסיפה כותרת במסמך
        {
            Font myFont = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, Font.ITALIC);
            myDocument.Add(new Paragraph(title, myFont));
        }

        public void SetImage(string imagePath)//פונקצייה מוסיפה תמונה במסמך
        {

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagePath);
            img.ScalePercent(50f);
            myDocument.Add(img);

        }

        public void SetIntTable(int[,] table)//פונקצייה מוסיפה טבלה עם ערכים מספרים שלימים במסמך
        {
            iTextSharp.text.pdf.PdfPTable myTable = new iTextSharp.text.pdf.PdfPTable(10);
            myTable.HorizontalAlignment = Element.ALIGN_CENTER;

            //set coloumn width in percent
            float[] widthCell = new float[10];
            for (int i = 0; i < 10; i++)
                widthCell[i] = 10;
            myTable.SetTotalWidth(widthCell);

            iTextSharp.text.pdf.PdfPCell myCell = new iTextSharp.text.pdf.PdfPCell();
            myCell.GrayFill = 0.5F;
            myCell.FixedHeight = 20;

            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    myCell.Phrase = new Phrase(table[i, j].ToString());
                    myTable.AddCell(myCell);
                }

            }

            myDocument.Add(myTable);
        }

        public void CloseReport()//פונקצייה סוגרת את המסמך
        {
            myDocument.Close();
        }

        public void students_array(person[] Person)//פונקצייה מוסיפה שמות של תלמידים
        {
            for(int i=0;i<Person.Length;i++)
            {
                myDocument.Add(new Paragraph(Person[i].FirstName));
            }
            
        }

        public void students_grades(person[] Person,grades[] Grades)//פונקצייה מוסיפה תלמידים עם ציונים במסמך
        {
            for(int i=0;i<Person.Length;i++)
            {
                myDocument.Add(new Paragraph(Person[i].FirstName+" : "+ Grades[i].Math + " " + Grades[i].English + " " + Grades[i].Comp));
            }

            
        }
    }
}
