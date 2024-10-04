using Microsoft.AspNetCore.Mvc;
using SistemaCooperativa.Models;


namespace SistemaCooperativa.Controllers
{
    public class EstatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estatus
        public IActionResult Index()
        {
            var estatus = _context.Estatus.ToList();
            return View(estatus);
        }

        // GET: Estatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estatus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Estatus estatus)
        {
            if (ModelState.IsValid)
            {
                _context.Estatus.Add(estatus);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(estatus);
        }

        // GET: Estatus/Edit/5
        public IActionResult Edit(int id)
        {
            var estatus = _context.Estatus.Find(id);
            if (estatus == null)
            {
                return NotFound();
            }
            return View(estatus);
        }

        // POST: Estatus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Estatus estatus)
        {
            if (id != estatus.IdEstatus)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(estatus);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(estatus);
        }

        // GET: Estatus/Delete/5
        public IActionResult Delete(int id)
        {
            var estatus = _context.Estatus.Find(id);
            if (estatus == null)
            {
                return NotFound();
            }
            return View(estatus);
        }

        // POST: Estatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var estatus = _context.Estatus.Find(id);
            _context.Estatus.Remove(estatus);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}