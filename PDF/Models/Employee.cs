using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PDF.Models
{
    public class Employee
    {
        // primary key ve otomatik artan özelliğini veriyoruz
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DisplayName("Ad")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyad")]
        public string Surname { get; set; }

        [Required]
        [DisplayName("TC Kimlik Numarası")]
        public string TcNo { get; set; }

        [Required]
        [DisplayName("Telefon Numarası")]
        public string TelNo { get; set; }

        [Required]
        [DisplayName("Adres")]
        public string Adres { get; set; }

        [Required]
        [DisplayName("Staj 1")]
        public bool Staj1 { get; set; }

        [Required]
        [DisplayName("Staj 2")]
        public bool Staj2 { get; set; }

        [Required]
        [DisplayName("Başlama Tarihi")]
        public DateTime BaslamaT { get; set; }

        [Required]
        [DisplayName("Bitiş Tarihi")]
        public DateTime BitisT { get; set; }

        [Required]
        [DisplayName("İş Günü")]
        public int IsGunu { get; set; }

        [Required]
        [DisplayName("Genel Sağlık Sigortası Alıyorum?")]
        public bool Gss { get; set; }

        [Required]
        [DisplayName("25 yaşını doldurdum")]
        public bool Yas { get; set; }

        [Required]
        [DisplayName("Firma Adı")]
        public string FirmaAdi { get; set; }

        [Required]
        [DisplayName("Faaliyet Alanı")]
        public string Faaliyet { get; set; }

        [Required]
        [DisplayName("Firma Adresi")]
        public string AdresFirma { get; set; }

        [Required]
        [DisplayName("Firma Telefon")]
        public string TelFirma { get; set; }


        public string durum { get; set; }
        public string durum2 { get; set; }
        public string durum3 { get; set; }

    }
}