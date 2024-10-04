using Microsoft.AspNetCore.Mvc;
using SistemaCooperativa.Models;


namespace SistemaCooperativa.Controllers
{
    public class TipoPersonaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoPersonaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoPersona
        public IActionResult Index()
        {
            var tipoPersonas = _context.TipoPersonas.ToList();
            return View(tipoPersonas);
        }

        // GET: TipoPersona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPersona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoPersona tipoPersona)
        {
            if (ModelState.IsValid)
            {
                _context.TipoPersonas.Add(tipoPersona);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPersona);
        }

        // GET: TipoPersona/Edit/5
        public IActionResult Edit(int id)
        {
            var tipoPersona = _context.TipoPersonas.Find(id);
            if (tipoPersona == null)
            {
                return NotFound();
            }
            return View(tipoPersona);
        }

        // POST: TipoPersona/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TipoPersona tipoPersona)
        {
            if (id != tipoPersona.IdTipoPersona)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(tipoPersona);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPersona);
        }

        // GET: TipoPersona/Delete/5
        public IActionResult Delete(int id)
        {
            var tipoPersona = _context.TipoPersonas.Find(id);
            if (tipoPersona == null)
            {
                return NotFound();
            }
            return View(tipoPersona);
        }

        // POST: TipoPersona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tipoPersona = _context.TipoPersonas.Find(id);
            _context.TipoPersonas.Remove(tipoPersona);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}