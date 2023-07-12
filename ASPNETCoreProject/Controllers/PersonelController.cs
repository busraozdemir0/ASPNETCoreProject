using ASPNETCoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}
