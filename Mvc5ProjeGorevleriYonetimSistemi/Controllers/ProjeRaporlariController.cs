﻿using Mvc5ProjeGorevleriYonetimSistemi.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5ProjeGorevleriYonetimSistemi.Controllers
{
    public class ProjeRaporlariController : Controller
    {
        private ProjeTakipDBContext db = new ProjeTakipDBContext();
        public ActionResult TamamalanmisOncelikGruplari()
        {
            return View();
        }
        public ActionResult VisualizeSTamamlanmisDurumGruplari()
        {
            return Json(OncelikGrupTİpi(), JsonRequestBehavior.AllowGet);
        }
        public List<ClassOncelikDurumAnaliz> OncelikGrupTİpi()
        {
            ;
            List<ClassOncelikDurumAnaliz> snf = new List<ClassOncelikDurumAnaliz>();
            using (var c = new ProjeTakipDBContext())

                snf = c.personelProjeleris.Where(x => x.TamamlanmaDurumu == true).GroupBy(p => p.OncelikDurumu).Select(x => new ClassOncelikDurumAnaliz
                {

                    onceliktipi = x.Key,
                    oncelikadeti = x.Count(),
                }).ToList();

            return snf;
        }




        public ActionResult TamamalanmamisOncelikGruplari()
        {
            return View();
        }
        public ActionResult VisualizeTamamlanmayanDurumruplari()
        {
            return Json(OncelikTamamlanmisGrupTİpi(), JsonRequestBehavior.AllowGet);
        }
        public List<ClassOncelikDurumAnaliz> OncelikTamamlanmisGrupTİpi()
        {
            ;
            List<ClassOncelikDurumAnaliz> snf = new List<ClassOncelikDurumAnaliz>();
            using (var c = new ProjeTakipDBContext())

                snf = c.personelProjeleris.Where(x => x.TamamlanmaDurumu == false).GroupBy(p => p.OncelikDurumu).Select(x => new ClassOncelikDurumAnaliz
                {

                    onceliktipi = x.Key,
                    oncelikadeti = x.Count(),
                }).ToList();

            return snf;
        }


        public ActionResult GenelProjeRaporlari()
        {
            return View();
        }


        public ActionResult CanliDestek()
        {
            var destek = db.personelBilgileris.Where(x => x.Departman == "Yönetim");
            return View(destek.ToList());
        }

    }
}