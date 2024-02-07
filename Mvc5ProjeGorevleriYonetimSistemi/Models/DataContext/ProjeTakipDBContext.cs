using Mvc5ProjeGorevleriYonetimSistemi.Models.ProjeTakip;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc5ProjeGorevleriYonetimSistemi.Models.DataContext
{
    public class ProjeTakipDBContext : DbContext
    {
        public ProjeTakipDBContext(): base("ProjeTakipDB") //burada parametreli kurucu metot kullanmamızın sebebi DbContext tablolarımız oluşturulurken hangi veritabanını kullanacağını belirtiyoruz.
        {



        }

        public DbSet<PersonelBilgileri> personelBilgileris { get; set; } //Bu kısımlar veritabanında bu isimde tablolar oluşturacaktır.

        public DbSet<PersonelProjeleri> personelProjeleris { get; set; }    





    }
}