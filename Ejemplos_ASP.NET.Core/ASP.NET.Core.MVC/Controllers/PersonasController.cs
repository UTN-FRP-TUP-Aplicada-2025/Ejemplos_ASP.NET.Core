using ASP.NET.Core.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personas.Services;

namespace ASP.NET.Core.MVC.Controllers
{
    public class PersonasController : Controller
    {
        PersonasRepository _personasRepository;

        public PersonasController(PersonasRepository personasRepository)
        {
            _personasRepository = personasRepository;
        }


        // GET: PersonasController
        public ActionResult Index()
        {
            IEnumerable<PersonaViewModel> personas = 
                                              from p in _personasRepository.List() 
                                              select new PersonaViewModel
                                              { 
                                                  Id=p.Id,
                                                  DNI=p.DNI,
                                                  Nombre=p.Nombre
                                              };
            return View(personas);
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonasController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonasController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
