using CRUDvideojuegos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace CRUDvideojuegos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           // List<Genero> lst = null;
           //using (Models.VideojuegosContext db=new Models.VideojuegosContext())
           //{
           //     lst=
           //         (from d in db.Generos
           //          select new Genero
           //          {
           //             IdGenero=d.IdGenero,
           //             NombreGenero=d.NombreGenero

           //         }).ToList();


           //}

           // List<SelectListItem> items = lst.ConvertAll(d =>
           // {
           //     return new SelectListItem()
           //     {
           //         Text = d.NombreGenero.ToString(),
           //         Value = d.IdGenero.ToString(),
           //         Selected = false

           //     };

           // });
           // ViewBag.items= items;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}