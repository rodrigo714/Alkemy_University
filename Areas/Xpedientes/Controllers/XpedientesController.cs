using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expedientes_Goya.Areas.Expedientes.Models;
using Expedientes_Goya.Data;

namespace Expedientes_Goya.Areas.Expedientes.Controllers
{
    [Area("Expedientes")]
    public class XpedientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public XpedientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expedientes/Xpedientes
        public async Task<IActionResult> Index()
        {
            return View(await _context._TExpedientes.ToListAsync());
        }

        // GET: Expedientes/Xpedientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedientes = await _context._TExpedientes
                .FirstOrDefaultAsync(m => m.IdExpdt == id);
            if (expedientes == null)
            {
                return NotFound();
            }

            return View(expedientes);
        }

        // GET: Expedientes/Xpedientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expedientes/Xpedientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExpdt,NumExpdt,IdDepInicio,IdOperador,IdUsuario,Extracto,Observaciones,FechaAltaExpte,FechaFinalExpte,Estado")] Expediente expedientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expedientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expedientes);
        }

        // GET: Expedientes/Xpedientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedientes = await _context._TExpedientes.FindAsync(id);
            if (expedientes == null)
            {
                return NotFound();
            }
            return View(expedientes);
        }

        // POST: Expedientes/Xpedientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExpdt,NumExpdt,IdDepInicio,IdOperador,IdUsuario,Extracto,Observaciones,FechaAltaExpte,FechaFinalExpte,Estado")] Expediente expedientes)
        {
            if (id != expedientes.IdExpdt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expedientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpedientesExists(expedientes.IdExpdt))
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
            return View(expedientes);
        }

        // GET: Expedientes/Xpedientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedientes = await _context._TExpedientes
                .FirstOrDefaultAsync(m => m.IdExpdt == id);
            if (expedientes == null)
            {
                return NotFound();
            }

            return View(expedientes);
        }

        // POST: Expedientes/Xpedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expedientes = await _context._TExpedientes.FindAsync(id);
            _context._TExpedientes.Remove(expedientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpedientesExists(int id)
        {
            return _context._TExpedientes.Any(e => e.IdExpdt == id);
        }
    }
}
