using Mvc5ProjeGorevleriYonetimSistemi.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5ProjeGorevleriYonetimSistemi.Controllers
{
    public class GenelBakisController : Controller
    {
        private ProjeTakipDBContext db = new ProjeTakipDBContext();

        // GET: GenelBakis
        public ActionResult Index()
        {

            int projesayisi = db.personelProjeleris.Count();
            ViewBag.Projesayisi = projesayisi;



            int tamamlanmisproje = db.personelProjeleris.Where(p => p.TamamlanmaDurumu == true).Count();
            ViewBag.TamamlanmisProje = tamamlanmisproje;


            var yuksekoncelikliprojeler = db.personelProjeleris.Where(p => p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.YuksekOncelikli = yuksekoncelikliprojeler;


            var dusukoncelikliprojeler = db.personelProjeleris.Where(p => p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.DusukOncelikli = dusukoncelikliprojeler;


            var ortaoncelikliprojeler = db.personelProjeleris.Where(p => p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.OrtaOncelikli = ortaoncelikliprojeler;



            var basariliveyuksek = db.personelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu=="Yüksek Öncelikli").Count();

            ViewBag.YuksekVeBasarili = basariliveyuksek;

            var basariliveorta = db.personelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Orta Öncelikli").Count();

            ViewBag.OrtaVeBasarili = basariliveorta;

            var basarilivedusuk = db.personelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Düşük Öncelikli").Count();

            ViewBag.DusukVeBasarili = basarilivedusuk;


            int tamamlanmamisproje = db.personelProjeleris.Where(p => p.TamamlanmaDurumu == true).Count();
            ViewBag.TamamlanmamisProje = tamamlanmamisproje;


            var personelProjeListesi = db.personelProjeleris.ToList();
            var personelTamamlanmisProjeSayisi = new Dictionary<int, int>();
            foreach (var personel in db.personelBilgileris.ToList())
            {
                int tamamlanmisProjeSayisi = 0;
                foreach (var proje in personel.PersonelProjeleris)
                {

                    if (proje.TamamlanmaDurumu==true)
                    {

                        tamamlanmisProjeSayisi++;

                    }

                    personelTamamlanmisProjeSayisi[personel.PersonelBilgileriId] = tamamlanmisProjeSayisi;

                }
                var siraliPersoneListesi = personelTamamlanmisProjeSayisi.OrderByDescending(x => x.Value);
                var encoktamamlananpersonelId = siraliPersoneListesi.First().Key;
                var encokTamamlananPersonel = db.personelBilgileris.FirstOrDefault(p => p.PersonelBilgileriId == encoktamamlananpersonelId);
                ViewBag.EnCokTamamlayanPersonelBilgisi = encokTamamlananPersonel.AdSoyad;


                int enCokProjeTamamlayanPersonelSayisi = personelTamamlanmisProjeSayisi[encoktamamlananpersonelId];
                ViewBag.EnCokProjeTamamlayanPersonelinProjeSayisi = enCokProjeTamamlayanPersonelSayisi;


                return View();
               


            }
















            return View();
        }

        public ActionResult Genelİstatistik()

        {
            var personeller = db.personelBilgileris.ToList();
            var personelProjeleri = db.personelProjeleris.ToList();
            var tamamlananProjeSayisi = new Dictionary<int, int>();
            var tamamlanmayanProjeSayisi = new Dictionary<int, int>();
            var toplamProjeSayisi = new Dictionary<int, int>();
            foreach (var personel in personeller)
            {
                int tamamlananProje = 0;
                int tamamlanmayanProje = 0;
                int toplamProje = 0;
                foreach (var proje in personelProjeleri)
                {
                    if (proje.PersonelBilgileris.Contains(personel))
                    {

                        toplamProje++;
                        if (proje.TamamlanmaDurumu)
                        {
                            tamamlananProje++;
                        }
                        else
                        {
                            tamamlanmayanProje++;
                        }
                    }
                }
                tamamlananProjeSayisi[personel.PersonelBilgileriId] = tamamlananProje;
                tamamlanmayanProjeSayisi[personel.PersonelBilgileriId] = tamamlanmayanProje;
                toplamProjeSayisi[personel.PersonelBilgileriId] = toplamProje;


            }

            ViewBag.TamamlananProjeSayisi = tamamlananProjeSayisi;
            ViewBag.TamamlanmayanProjeSayisi = tamamlanmayanProjeSayisi;
            ViewBag.ToplamProjeSayisi = toplamProjeSayisi;



            int projeSayisi = db.personelProjeleris.Count();
            ViewBag.ProjeSayisi = projeSayisi;



            int personelSayisi = db.personelBilgileris.Count();
            ViewBag.PersonelSayisi = personelSayisi;


            int tamamlanmisProje = db.personelProjeleris.Where(p => p.TamamlanmaDurumu == true).Count();
            ViewBag.TamamlanmisProje = tamamlanmisProje;

            int tamamlanmamisProje = db.personelProjeleris.Where(p => p.TamamlanmaDurumu == false).Count();
            ViewBag.TamamlanmamisProje = tamamlanmamisProje;



            var basarisizveyuksek = db.personelProjeleris.Where(p => p.TamamlanmaDurumu == false && p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.YuksekVeBasarisiz = basarisizveyuksek;

            var basarisizveorta = db.personelProjeleris.Where(p => p.TamamlanmaDurumu == false && p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.OrtaVeBasarisiz = basarisizveorta;


            return View(personeller);

        }

        



    }
}