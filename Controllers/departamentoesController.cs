using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P2_2020ZR601_2020MG601.Data;
using P2_2020ZR601_2020MG601.Models;

namespace P2_2020ZR601_2020MG601.Controllers
{
    public class departamentoesController : Controller
    {
        private readonly P2_2020ZR601_2020MG601Context _context;

        public departamentoesController(P2_2020ZR601_2020MG601Context context)
        {
            _context = context;
        }

        // GET: departamentoes
        public async Task<IActionResult> Index()
        {
              return _context.departamento != null ? 
                          View(await _context.departamento.ToListAsync()) :
                          Problem("Entity set 'P2_2020ZR601_2020MG601Context.departamento'  is null.");
        }

        // GET: departamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.departamento
                .FirstOrDefaultAsync(m => m.IdDepartamento == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: departamentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: departamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDepartamento,Departamento")] departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        // GET: departamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        // POST: departamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDepartamento,Departamento")] departamento departamento)
        {
            if (id != departamento.IdDepartamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!departamentoExists(departamento.IdDepartamento))
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
            return View(departamento);
        }

        // GET: departamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.departamento
                .FirstOrDefaultAsync(m => m.IdDepartamento == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: departamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.departamento == null)
            {
                return Problem("Entity set 'P2_2020ZR601_2020MG601Context.departamento'  is null.");
            }
            var departamento = await _context.departamento.FindAsync(id);
            if (departamento != null)
            {
                _context.departamento.Remove(departamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool departamentoExists(int id)
        {
          return (_context.departamento?.Any(e => e.IdDepartamento == id)).GetValueOrDefault();
        }
    }
}
