using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto.ContextDB;
using projeto.Models;

namespace projeto.Controllers
{
    public class ProfessoresController : Controller
    {
        private readonly DatabaseContext _context;

        public ProfessoresController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Professores
        public async Task<IActionResult> Index()
        {
            return _context.Professores != null ?
                        View(await _context.Professores.ToListAsync()) :
                        Problem("Entity set 'DatabaseContext.Professores'  is null.");
        }

        // GET: Professores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Professores == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores
                .Include(p => p.Cursos)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: Professores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Cpf,Logradouro,Numero,Complemento,Bairro,Cidade,UF,Pais")] Professor professor)
        {
            //aqui - ajustar model para nullable navigationproperty
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Professores == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Professores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Cpf,Logradouro,Numero,Complemento,Bairro,Cidade,UF,Pais")] Professor professor)
        {
            if (id != professor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.ID))
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
            return View(professor);
        }

        // GET: Professores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Professores == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores
                .FirstOrDefaultAsync(m => m.ID == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Professores == null)
            {
                return Problem("Entity set 'DatabaseContext.Professores'  is null.");
            }
            var professor = await _context.Professores.FindAsync(id);
            if (professor != null)
            {
                _context.Professores.Remove(professor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return (_context.Professores?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
