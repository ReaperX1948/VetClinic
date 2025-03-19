using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pets = _context.Pets.ToList();
            return View(pets);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pet pet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pet);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }

        public IActionResult Edit(int id)
        {
            var pet = _context.Pets.Find(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                    _context.SaveChanges();
                }
                catch
                {
                    return View(pet);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }
    }
}
