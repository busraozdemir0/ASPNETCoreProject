using ASPNETCoreProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASPNETCoreProject.Controllers
{
    [Authorize]
    public class BirimController : Controller
    {
        Context context = new Context();
        
        public IActionResult Index()
        {
            var birimList = context.Birims.ToList();
            return View(birimList);
        }
        [HttpGet]
        public IActionResult YeniBirim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim birim)
        {
            context.Birims.Add(birim);
            context.SaveChanges();
            return RedirectToAction("Index", "Birim");
        }
        public IActionResult BirimSil(int id)
        {
            var birimSil = context.Birims.Find(id);
            context.Birims.Remove(birimSil);
            context.SaveChanges();
            return RedirectToAction("Index", "Birim");
        }
        public IActionResult BirimGetir(int id)
        {
            var birimBul = context.Birims.Find(id);
            return View("BirimGetir",birimBul);
        }
        public IActionResult BirimGuncelle(Birim birim)
        {
            var brm = context.Birims.Find(birim.BirimID);
            brm.BirimAd = birim.BirimAd;
            context.SaveChanges();
            return RedirectToAction("Index", "Birim");

            //context.Birims.Update(birim);
            //context.SaveChanges();
            //return RedirectToAction("Index", "Birim");
        }
        public IActionResult BirimDetay(int id)
        {
            var degerler = context.Personels.Where(x => x.BirimID == id).ToList();
            var birimAd = context.Birims.Where(x => x.BirimID == id).Select(y => y.BirimAd).FirstOrDefault();
            ViewBag.birimAdi = birimAd;
            return View(degerler);
        }
    }
}
