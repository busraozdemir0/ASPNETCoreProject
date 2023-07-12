using ASPNETCoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASPNETCoreProject.Controllers
{
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
        [HttpGet]
        public IActionResult BirimGuncelle(int id)
        {
            var birimBul = context.Birims.Find(id);
            return View(birimBul);
        }
        [HttpPost]
        public IActionResult BirimGuncelle(Birim birim)
        {
            //var birim = context.Birims.Find(birim.BirimID);
            //birim.BirimAd = birim.BirimAd;
            //context.SaveChanges();

            context.Birims.Update(birim);
            context.SaveChanges();
            return RedirectToAction("Index", "Birim");
        }
        public IActionResult BirimDetay(int id)
        {
            var degerler = context.Personels.Where(x => x.BirimID == id).ToList();
            return View(degerler);
        }
    }
}
