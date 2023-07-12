using ASPNETCoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETCoreProject.Controllers
{
    public class PersonelController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var personelList = context.Personels.Include(x=>x.Birim).ToList();
            return View(personelList);
        }
        [HttpGet]
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> birimler = (from x in context.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text=x.BirimAd,
                                                 Value=x.BirimID.ToString()
                                             }).ToList();
            ViewBag.birims = birimler;
            return View();
        }
        [HttpPost]
        public IActionResult YeniPersonel(Personel personel)
        {
            // dropdownlistten seçilen değerin ID'sini alma
            var per=context.Birims.Where(x=>x.BirimID==personel.Birim.BirimID).FirstOrDefault();
            personel.Birim = per;

            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index","Personel");
        }
        public IActionResult PersonelSil(int id)
        {
            var personelBul = context.Personels.Find(id);
            context.Personels.Remove(personelBul);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Personel");
        }
        [HttpGet]
        public IActionResult PersonelGuncelle(int id)
        {
            List<SelectListItem> birimler = (from x in context.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAd,
                                                 Value = x.BirimID.ToString()
                                             }).ToList();
            ViewBag.birims = birimler;

            var personelID=context.Personels.Find(id);
            return View(personelID);
        }
        [HttpPost]
        public IActionResult PersonelGuncelle(Personel personel)
        {
            // dropdownlistten seçilen değerin ID'sini alma (hatalı!)
            var per = context.Birims.Where(x => x.BirimID == personel.Birim.BirimID).FirstOrDefault();
            personel.Birim = per;

            context.Personels.Update(personel);
            context.SaveChanges();
            return RedirectToAction("Index", "Personel");
        }
    }
}
