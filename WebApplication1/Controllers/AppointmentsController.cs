using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Index Action - should display appointments
        public IActionResult Index()
        {
            var appointments = _context.Appointments.Include(a => a.Pet).ToList();
            return View(appointments); // Return to a view that lists appointments
        }

        // Create Action - used to create new appointments
        public IActionResult Create()
        {
            ViewBag.Pets = _context.Pets.ToList(); // Pass pets to the view
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Repopulate ViewBag.Pets if the model is not valid
            ViewBag.Pets = _context.Pets.ToList();
            return View(appointment);
        }
    }
}
