using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Mvc5ProjeGorevleriYonetimSistemi.Models.ProjeTakip;

namespace Mvc5ProjeGorevleriYonetimSistemi.Models
{
    public class PersonelBilgileri
    {
        public PersonelBilgileri()
        {

            this.PersonelProjeleris = new HashSet<PersonelProjeleri>(); //burada bunu yapmamızın nedeni PersonelBilgieri örneği oluşuturulduğunda kurucu metot personelprojeleris adında koleksiyon oluşturacaktır null dönmemesi için yoksa hata alırız.


        }


        [Key]
        public int PersonelBilgileriId { get; set; }

        [DisplayName("E-POSTA")]
        public string Eposta { get; set; }
        [DisplayName("ŞİFRE")] //İSİMNLENDİRMELER
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string Sifre { get; set; }
        [DisplayName("YETKİ")]
        [StringLength(15, ErrorMessage = "Maximum uzunluk 15 karakterden fazla olamaz")]
        public string Yetki { get; set; }
        [DisplayName("AD SOYAD")]
        [StringLength(50, ErrorMessage = "Maximum uzunluk 50 karakterden fazla olamaz")]
        public string AdSoyad { get; set; }

        [DisplayName("PERSONEL GÖRSELİ")]
        public string PersonelGörseli { get; set; }

        [DisplayName("TC KİMLİK NO")]
        [StringLength(15, ErrorMessage = "Maximum uzunluk 15 karakterden fazla olamaz")]
        public string TCNO { get; set; }
        [DisplayName("DEPARTMANI")]
        public string Departman { get; set; }
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        [DisplayName("GÖREVİ")]

        public string Gorev { get; set; }
        [DisplayName("AÇIKLAMA")]
        public string PozisyonAciklama { get; set; }
        [DisplayName("TELEFON NUMARASI")]
        [StringLength(15, ErrorMessage = "Maximum uzunluk 15 karakterden fazla olamaz")]
        public string TelNo { get; set; }
        [DisplayName("ADRES BİLGİLERİ")]
        public string Adres { get; set; }
        [DisplayName("MEDENİ HAL")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string MedeniHal { get; set; }
        [DisplayName("YAKINLIK BİLGİSİ")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string YakinBilgisi { get; set; }
        [DisplayName("YAKIN TC NO")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string YakinTC { get; set; }
        [DisplayName("YAKIN AD SOYAD")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string YakinAdSoyad { get; set; }
        [DisplayName("YAKIN TELEFONU")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string YakinTel { get; set; }
        [DisplayName("DOĞUM TARİHİ")]
        public DateTime? DogumTarihi { get; set; }
        [DisplayName("İŞE GİRİŞ TARİHİ")]
        public DateTime? IseGirisTarihi { get; set; }


        virtual public ICollection<PersonelProjeleri> PersonelProjeleris { get; set; }





    }
}