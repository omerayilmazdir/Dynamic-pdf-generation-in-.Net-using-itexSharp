using iTextSharp.text;
using iTextSharp.text.pdf;
using PDF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PDF.EmployeePdf
{
    public class EmployeeReport
    {


       
        int toplamSutun = 2;
        // eklediğimiz itextsharp kütüphanesinden document kullanıyoruz
        Document document;
        Font fontStyle;
        // Pdf kütüphanesinden bir nesne türetiyoruz
        PdfPTable pdfTable = new PdfPTable(2);
        PdfPCell pdfPCell;
        MemoryStream memoryStream = new MemoryStream();

        // Employee modelini ekliyoruz
        List<Employee> employees = new List<Employee>();

        // byte şeklinde olan bir fonksiyon oluşturuyoruz
        // içerisine pdf in özelliklerini yazıyoruz
        public byte[] ReportPdf(List<Employee> employee)
        {
            

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance("C:/Users/omera/source/repos/PDF/PDF/Img/kocaeli-universitesi-logo.png");

            //Resize image depend upon your need

            jpg.ScaleToFit(45f, 45f);
            

            //Give space before image

            //jpg.SpacingBefore = 300f;

            //Give some space after the image

            //jpg.SpacingAfter = 500f;

            jpg.Alignment = Element.TITLE;
            
            

            // yukarıda türetilen sınıfı report pdf içerisindeki listeye atıyoruz
            employees = employee;

            // document nesnesini oluşturduk a4 boyutunda
            // sağ sol üst alt kısmından herhangi bir boşluk bırakmadık
            document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(25f, 25f, 10f, 10f);
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            fontStyle = FontFactory.GetFont("Times New Roman", 11f,1);
            PdfWriter.GetInstance(document, memoryStream);
            document.Open();
            pdfTable.SetWidths(new float[] { 40f, 120f });

            document.Add(jpg);
            this.ReportPdfHeader();
            this.ReportPdfBody();
            
            pdfTable.HeaderRows = 1;
            document.Add(pdfTable);
            document.Close();
            return memoryStream.ToArray();
        }

        // sütun başlıkları için method
        public void ReportPdfHeader()
        {

            fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
            pdfPCell = new PdfPCell(new Phrase(" T.C.\nKOCAELI UNIVERSITESI\nTEKNOLOJI FAKULTESI\n(Staj Basvuru ve Kabul Formu)\n\n\n\nILGILI MAKAMA", fontStyle));
            pdfPCell.Colspan = 2;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.ExtraParagraphSpace = 5;
            pdfTable.AddCell(pdfPCell);
            pdfTable.CompleteRow();
            
            fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
            pdfPCell = new PdfPCell(new Phrase("Tarih:..../..../20..", fontStyle));
            pdfPCell.Colspan = 2;
            pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.ExtraParagraphSpace = 5;
            pdfTable.AddCell(pdfPCell);
            pdfTable.CompleteRow();

            fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
            pdfPCell = new PdfPCell(new Phrase(" Teknoloji Fakültesi _ _ _ _ _ _ _ _ _ _ _ Mühendisliği Bölümü _ _ _ _ _ _ _ _ _ numaralı öğrencisiyim. Kurumunuzda staj yapmamın uygun görülmesi halinde bu formun alttaki kısmını doldurularak fakültemiz ilgili bölüm başkanlığına gönderilmesini saygılarımla arz ederim. İşyeri uygulaması süresi içerisinde alınan rapor, istirahat vb.belgelerin aslını alınan gün içerisinde bölüm başkanlığına bildireceğimi beyan ve taahhüt ederim.", fontStyle));
            pdfPCell.Colspan = 2;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.ExtraParagraphSpace = 5;
            pdfTable.AddCell(pdfPCell);
            pdfTable.CompleteRow();

            fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
            pdfPCell = new PdfPCell(new Phrase(" İşyeri uygulaması süresi içerisinde alınan rapor, istirahat vb.belgelerin aslını alınan gün içerisinde bölüm başkanlığına bildireceğimi beyan ve taahhüt ederim.", fontStyle));
            pdfPCell.Colspan = 2;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.ExtraParagraphSpace = 5;
            pdfTable.AddCell(pdfPCell);
            pdfTable.CompleteRow();
            

        }

        // işçilerin tutulacağı method
        public void ReportPdfBody()
        {
           

            fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);

            foreach (Employee employee in employees)
            {
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("Ad", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.Name, fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("Soyad", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.Surname, fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("TC Kimlik No", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.TcNo, fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("Telefon Numarasi", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.TelNo, fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("Adres", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.Adres, fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 10f, 1);
                pdfPCell = new PdfPCell(new Phrase("", fontStyle));
                pdfPCell.Rowspan = 1;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase("Staj Bilgileri", fontStyle));
                pdfPCell.Rowspan = 1;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("Yapılacak Staj/IME", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.durum,fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("Baslama Tarihi", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.BaslamaT.ToShortDateString(), fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("Bitis Tarihi", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.BitisT.ToShortDateString(), fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("Is Gunu", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.IsGunu.ToString(), fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("Genel Saglik Sigortasi", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.durum2, fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("25 yasini doldurdum", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.durum3, fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 10f, 1);
                pdfPCell = new PdfPCell(new Phrase("", fontStyle));
                pdfPCell.Rowspan = 1;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase("Firma Bilgileri",fontStyle));
                pdfPCell.Rowspan = 1;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();

                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("Firma Adi", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.FirmaAdi, fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("Faaliyet Alani", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.Faaliyet, fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("Firma Adresi", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.AdresFirma, fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 1);
                pdfPCell = new PdfPCell(new Phrase("Telefon", fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                fontStyle = FontFactory.GetFont("Times New Roman", 9f, 0);
                pdfPCell = new PdfPCell(new Phrase(employee.TelFirma, fontStyle));
                pdfPCell.Rowspan = toplamSutun;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCell);
                pdfTable.CompleteRow();

            }


        }
    }
}