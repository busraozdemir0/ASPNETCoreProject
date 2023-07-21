using ASPNETCoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Linq;

namespace ASPNETCoreProject.ViewComponents.Default
{
    public class BirimList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var birims = c.Birims.ToList();
            return View(birims);
        }
    }
}
