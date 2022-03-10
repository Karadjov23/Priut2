using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Priut2.Data;
using Priut2.Entities;

namespace Priut2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnimalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Animals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Animalss.Include(a => a.Breed);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animals = await _context.Animalss
                .Include(a => a.Breed)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animals == null)
            {
                return NotFound();
            }

            return View(animals);
        }

        // GET: Admin/Animals/Create
        public IActionResult Create()
        {
            ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "Id");
            return View();
        }

        // POST: Admin/Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,KindCategory,BreedId,Age,Gender,Image,Castrated,Passport,Condition,Date")] Animals animals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "Id", animals.BreedId);
            return View(animals);
        }

        // GET: Admin/Animals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animals = await _context.Animalss.FindAsync(id);
            if (animals == null)
            {
                return NotFound();
            }
            ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "Id", animals.BreedId);
            return View(animals);
        }

        // POST: Admin/Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,KindCategory,BreedId,Age,Gender,Image,Castrated,Passport,Condition,Date")] Animals animals)
        {
            if (id != animals.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalsExists(animals.Id))
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
            ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "Id", animals.BreedId);
            return View(animals);
        }

        // GET: Admin/Animals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animals = await _context.Animalss
                .Include(a => a.Breed)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animals == null)
            {
                return NotFound();
            }

            return View(animals);
        }

        // POST: Admin/Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animals = await _context.Animalss.FindAsync(id);
            _context.Animalss.Remove(animals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalsExists(int id)
        {
            return _context.Animalss.Any(e => e.Id == id);
        }
    }
}
