using Mvc5ProjeGorevleriYonetimSistemi.Models.DataContext;
using Mvc5ProjeGorevleriYonetimSistemi.Models.ProjeTakip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5ProjeGorevleriYonetimSistemi.Controllers
{
    public class PersonelProjeController : Controller
    {


        private ProjeTakipDBContext db = new ProjeTakipDBContext();
 
        //Get
        public ActionResult Index()
        {

            var projelistele = db.personelProjeleris.ToList();

            return View(projelistele);
        }

        public ActionResult Create()
        {


            ViewBag.PersonelBilgileriId = new SelectList(db.personelBilgileris, "PersonelBilgileriId", "AdSoyad");

            return View();


        }

        [HttpPost]
        public ActionResult Create(PersonelProjeleri projeobj, int[] PersonelBilgileriId)
        {


            foreach (var x in PersonelBilgileriId)
            {


                projeobj.PersonelBilgileris.Add(db.personelBilgileris.Find(x));


            }

            projeobj.OlusturmaTarihi = DateTime.Now;
            db.personelProjeleris.Add(projeobj);
            db.SaveChanges();


            return RedirectToAction("Index");

        }


        public ActionResult Edit(int? id)
        {

            var projeObj = db.personelProjeleris.Find(id);

            return View(projeObj);




        }


        [HttpPost]
        public ActionResult Edit(PersonelProjeleri projeObj)
        {

            var projeDbObj = db.personelProjeleris.Find(projeObj.PersonelProjeId);
            projeDbObj.ProjeAciklama = projeObj.ProjeAciklama;
            projeDbObj.ProjeBaslik = projeObj.ProjeBaslik;
            projeDbObj.TamamlanmaOrani = projeObj.TamamlanmaOrani;
            projeDbObj.OncelikDurumu = projeObj.OncelikDurumu;
            db.SaveChanges();
            return RedirectToAction("Index");


            

        }

        public ActionResult Tamamla(int id)
        {


            var projeObj = db.personelProjeleris.Find(id);
            projeObj.TamamlanmaDurumu = true;
            projeObj.TamamlanmaOrani = 100;
            db.SaveChanges();
            return RedirectToAction("Index");   
            
        }



    }
}