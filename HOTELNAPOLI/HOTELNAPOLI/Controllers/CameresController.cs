using HOTELNAPOLI.Data;
using HOTELNAPOLI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOTELNAPOLI.Controllers
{
    [Authorize]
    public class CameresController : Controller
    {
        private readonly HOTELNAPOLIContext _context;

        public CameresController(HOTELNAPOLIContext context)
        {
            _context = context;
        }

        // GET: Cameres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Camere.ToListAsync());
        }

        // GET: Cameres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camere = await _context.Camere
                .FirstOrDefaultAsync(m => m.ID == id);
            if (camere == null)
            {
                return NotFound();
            }

            return View(camere);
        }

        // GET: Cameres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cameres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Numero,Descrizione,Doppia,Disponibilita")] Camere camere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(camere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(camere);
        }

        // GET: Cameres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camere = await _context.Camere.FindAsync(id);
            if (camere == null)
            {
                return NotFound();
            }
            return View(camere);
        }

        // POST: Cameres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Descrizione,Doppia,Disponibilita")] Camere camere)
        {
            if (id != camere.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CamereExists(camere.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(camere);
        }

        // GET: Cameres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camere = await _context.Camere
                .FirstOrDefaultAsync(m => m.ID == id);
            if (camere == null)
            {
                return NotFound();
            }

            return View(camere);
        }

        // POST: Cameres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camere = await _context.Camere.FindAsync(id);
            if (camere != null)
            {
                _context.Camere.Remove(camere);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CamereExists(int id)
        {
            return _context.Camere.Any(e => e.ID == id);
        }
    }
}
