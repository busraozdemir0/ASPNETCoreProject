using ASPNETCoreProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreProject.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> YeniPersonel(Personel personel)
        {
            // dropdownlistten seçilen değerin ID'sini alma
            var per=context.Birims.Where(x=>x.BirimID==personel.Birim.BirimID).FirstOrDefault();
            personel.Birim = per;

            if(ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(personel.Gorsel.FileName);
                string extension = Path.GetExtension(personel.Gorsel.FileName);
                personel.GorselYol = fileName = fileName + extension;
                string path = Path.Combine("wwwroot/images/", fileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await personel.Gorsel.CopyToAsync(filestream);
                }
                context.Personels.Add(personel);
                context.SaveChanges();
                return RedirectToAction("Index", "Personel");
            }
            else
            {
                return View();
            }
            
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
        public async Task<IActionResult> PersonelGuncelle(Personel personel)
        {
            // dropdownlistten seçilen değerin ID'sini alma
            var per = context.Birims.Where(x => x.BirimID == personel.Birim.BirimID).FirstOrDefault();
            personel.Birim = per;
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(personel.Gorsel.FileName);
                string extension = Path.GetExtension(personel.Gorsel.FileName);
                personel.GorselYol = fileName = fileName + extension;
                string path = Path.Combine("wwwroot/images/", fileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await personel.Gorsel.CopyToAsync(filestream);
                }
                context.Personels.Update(personel);
                context.SaveChanges();
                return RedirectToAction("Index", "Personel");
            }
            else
            {
                return View();
            }
            

        }
    }
}
