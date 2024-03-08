using HOTELNAPOLI.Data;
using HOTELNAPOLI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HOTELNAPOLI.Controllers
{
    [Authorize]
    public class PrenotazionisController : Controller
    {
        private readonly HOTELNAPOLIContext _context;

        public PrenotazionisController(HOTELNAPOLIContext context)
        {
            _context = context;
        }

        // GET: Prenotazionis
        public async Task<IActionResult> Index()
        {
            var hOTELNAPOLIContext = _context.Prenotazioni.Include(p => p.Camera).Include(p => p.Cliente).Include(p => p.Pensione);
            return View(await hOTELNAPOLIContext.ToListAsync());
        }

        // GET: Prenotazionis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazioni = await _context.Prenotazioni
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prenotazioni == null)
            {
                return NotFound();
            }

            return View(prenotazioni);
        }

        // GET: Prenotazionis/Create
        public IActionResult Create()
        {
            ViewData["IDCamera"] = new SelectList(_context.Camere, "ID", "ID");
            var camere = _context.Camere.ToList();
            ViewBag.IDCamera = camere.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = $"{c.ID} - {c.Descrizione}"
            }).ToList();
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "Id", "Cognome");
            ViewData["IDPensione"] = new SelectList(_context.Pensioni, "ID", "Tipologia");
            return View();
        }

        // POST: Prenotazionis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DataPrenotazione,DataInizioSoggiorno,DataFineSoggiorno,Anno,Acconto,Prezzo,IDCliente,IDCamera,IDPensione")] Prenotazioni prenotazioni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prenotazioni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCamera"] = new SelectList(_context.Camere, "ID", "ID", prenotazioni.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "Id", "Cognome", prenotazioni.IDCliente);
            ViewData["IDPensione"] = new SelectList(_context.Pensioni, "ID", "Tipologia", prenotazioni.IDPensione);
            return View(prenotazioni);
        }

        // GET: Prenotazionis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazioni = await _context.Prenotazioni.FindAsync(id);
            if (prenotazioni == null)
            {
                return NotFound();
            }
            ViewData["IDCamera"] = new SelectList(_context.Camere, "ID", "ID", prenotazioni.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "Id", "Cognome", prenotazioni.IDCliente);
            ViewData["IDPensione"] = new SelectList(_context.Pensioni, "ID", "Tipologia", prenotazioni.IDPensione);
            return View(prenotazioni);
        }

        // POST: Prenotazionis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DataPrenotazione,DataInizioSoggiorno,DataFineSoggiorno,Anno,Acconto,Prezzo,IDCliente,IDCamera,IDPensione")] Prenotazioni prenotazioni)
        {
            if (id != prenotazioni.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prenotazioni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrenotazioniExists(prenotazioni.ID))
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
            ViewData["IDCamera"] = new SelectList(_context.Camere, "ID", "ID", prenotazioni.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "Id", "Cognome", prenotazioni.IDCliente);
            ViewData["IDPensione"] = new SelectList(_context.Pensioni, "ID", "Tipologia", prenotazioni.IDPensione);
            return View(prenotazioni);
        }

        // GET: Prenotazionis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazioni = await _context.Prenotazioni
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prenotazioni == null)
            {
                return NotFound();
            }

            return View(prenotazioni);
        }

        // POST: Prenotazionis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prenotazioni = await _context.Prenotazioni.FindAsync(id);
            if (prenotazioni != null)
            {
                _context.Prenotazioni.Remove(prenotazioni);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrenotazioniExists(int id)
        {
            return _context.Prenotazioni.Any(e => e.ID == id);
        }


        // action asincrona per la ricerca di prenotazioni per codice fiscale
        [HttpGet]
        public async Task<IActionResult> SearchByCodiceFiscale(string codiceFiscale)
        {
            if (string.IsNullOrEmpty(codiceFiscale))
            {
                TempData["Message1"] = "Inserire un codice fiscale valido";
                return RedirectToAction("Index");
            }

            var cliente = await _context.Clienti.FirstOrDefaultAsync(c => c.CodiceFiscale == codiceFiscale);

            if (cliente == null)
            {
                TempData["Message2"] = "Nessun cliente trovato";
                return RedirectToAction("Index");
            }

            var prenotazioni = await _context.Prenotazioni
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .Where(p => p.IDCliente == cliente.Id)
                .ToListAsync();

            return View(prenotazioni);
        }
        // action asincrona per la ricerca del numero totale di prenotazioni per soggiorni di tipo "pensione completa"
        [HttpGet]
        public async Task<IActionResult> TotalPensioneCompleta()
        {
            var pensioneCompleta = await _context.Pensioni.FirstOrDefaultAsync(p => p.Tipologia == "pensione completa");

            if (pensioneCompleta == null)
            {
                TempData["Message3"] = "Nessuna pensione completa trovata";
                return RedirectToAction("Index");
            }

            var totalPrenotazioni = await _context.Prenotazioni
                .Where(p => p.IDPensione == pensioneCompleta.ID)
                .CountAsync();

            return View(totalPrenotazioni);
        }

        // action asincrona per il checkout di una prenotazione
        public async Task<IActionResult> Checkout(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazioni
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            var servizi = await _context.Servizi
                .Where(s => s.IDPrenotazione == id)
                .ToListAsync();


            var model = new CheckoutViewModel
            {
                Prenotazione = prenotazione,
                Servizi = servizi
            };

            return View(model);
        }

    }
}
