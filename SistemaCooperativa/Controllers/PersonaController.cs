using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCooperativa.Models;
using System.Threading.Tasks;

namespace SistemaCooperativa.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var personas = _context.Personas.Include(p => p.TipoPersona).Include(p => p.Estatus);
            return View(await personas.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var persona = await _context.Personas
                .Include(p => p.TipoPersona)
                .Include(p => p.Estatus)
                .FirstOrDefaultAsync(m => m.IdPersona == id);

            if (persona == null) return NotFound();

            return View(persona);
        }

        public IActionResult Create()
        {
            ViewData["IdTipoPersona"] = new SelectList(_context.TipoPersonas, "IdTipoPersona", "Descripcion");
            ViewData["IdEstatus"] = new SelectList(_context.Estatus, "IdEstatus", "Descripcion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersona,Nombre,Apellido,Direccion,Telefono,Email,IdTipoPersona,IdEstatus")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoPersona"] = new SelectList(_context.TipoPersonas, "IdTipoPersona", "Descripcion", persona.IdTipoPersona);
            ViewData["IdEstatus"] = new SelectList(_context.Estatus, "IdEstatus", "Descripcion", persona.IdEstatus);
            return View(persona);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var persona = await _context.Personas.FindAsync(id);
            if (persona == null) return NotFound();

            ViewData["IdTipoPersona"] = new SelectList(_context.TipoPersonas, "IdTipoPersona", "Descripcion", persona.IdTipoPersona);
            ViewData["IdEstatus"] = new SelectList(_context.Estatus, "IdEstatus", "Descripcion", persona.IdEstatus);
            return View(persona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersona,Nombre,Apellido,Direccion,Telefono,Email,IdTipoPersona,IdEstatus")] Persona persona)
        {
            if (id != persona.IdPersona) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.IdPersona)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoPersona"] = new SelectList(_context.TipoPersonas, "IdTipoPersona", "Descripcion", persona.IdTipoPersona);
            ViewData["IdEstatus"] = new SelectList(_context.Estatus, "IdEstatus", "Descripcion", persona.IdEstatus);
            return View(persona);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var persona = await _context.Personas
                .Include(p => p.TipoPersona)
                .Include(p => p.Estatus)
                .FirstOrDefaultAsync(m => m.IdPersona == id);

            if (persona == null) return NotFound();

            return View(persona);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.IdPersona == id);
        }
    }
}
