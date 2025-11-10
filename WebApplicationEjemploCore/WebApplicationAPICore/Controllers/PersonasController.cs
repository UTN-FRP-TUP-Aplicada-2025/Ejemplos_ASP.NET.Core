using Microsoft.AspNetCore.Mvc;
using Personas.Services;
using WebApplicationAPICore.Models;

namespace WebApplicationAPICore.Controllers;

public class PersonasController : Controller
{
    PersonasRepository _personasRepository;

    public PersonasController(PersonasRepository personasRepository)
    {
        _personasRepository = personasRepository;
    }

    public ActionResult Index()
    {
        var lista = from p in _personasRepository.List() select new PersonaViewModel 
                    {
                            Id=p.Id,
                            DNI= p.DNI,
                            Nombre=p.Nombre
                    };
        return View(lista);
    }

    // GET: PersonasController/Details/5
    public ActionResult Details(int id)
    {
        var persona = _personasRepository.Get(id);
        var personaView = new PersonaViewModel()
        {
            Id = persona.Id,
            DNI = persona.DNI,
            Nombre = persona.Nombre,
        };
        return View(personaView);
    }

    // GET: PersonasController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PersonasController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(PersonaViewModel nuevo)
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

    // GET: PersonasController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: PersonasController/Delete/5
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
