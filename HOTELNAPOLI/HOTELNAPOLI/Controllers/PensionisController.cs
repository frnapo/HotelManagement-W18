using HOTELNAPOLI.Data;
using HOTELNAPOLI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOTELNAPOLI.Controllers
{
    [Authorize]
    public class PensionisController : Controller
    {
        private readonly HOTELNAPOLIContext _context;

        public PensionisController(HOTELNAPOLIContext context)
        {
            _context = context;
        }

        // GET: Pensionis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pensioni.ToListAsync());
        }

        // GET: Pensionis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pensioni = await _context.Pensioni
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pensioni == null)
            {
                return NotFound();
            }

            return View(pensioni);
        }

        // GET: Pensionis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pensionis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Tipologia,Prezzo")] Pensioni pensioni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pensioni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pensioni);
        }

        // GET: Pensionis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pensioni = await _context.Pensioni.FindAsync(id);
            if (pensioni == null)
            {
                return NotFound();
            }
            return View(pensioni);
        }

        // POST: Pensionis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Tipologia,Prezzo")] Pensioni pensioni)
        {
            if (id != pensioni.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pensioni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PensioniExists(pensioni.ID))
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
            return View(pensioni);
        }

        // GET: Pensionis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pensioni = await _context.Pensioni
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pensioni == null)
            {
                return NotFound();
            }

            return View(pensioni);
        }

        // POST: Pensionis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pensioni = await _context.Pensioni.FindAsync(id);
            if (pensioni != null)
            {
                _context.Pensioni.Remove(pensioni);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PensioniExists(int id)
        {
            return _context.Pensioni.Any(e => e.ID == id);
        }
    }
}
