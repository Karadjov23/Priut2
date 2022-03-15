using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Priut2.Data;
using Priut2.Models;

namespace Priut2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SignalController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<User> _userManager;
        
        public SignalController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Admin/Signal
        public async Task<IActionResult> Index()
        {
            ViewBag.userid = _userManager.GetUserId(HttpContext.User);
            var applicationDbContext = _context.Signals.Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Signal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signal = await _context.Signals
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signal == null)
            {
                return NotFound();
            }

            return View(signal);
        }

        // GET: Admin/Signal/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Admin/Signal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Description,Date")] Signal signal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", signal.UserId);
            return View(signal);
        }

        // GET: Admin/Signal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signal = await _context.Signals.FindAsync(id);
            if (signal == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", signal.UserId);
            return View(signal);
        }

        // POST: Admin/Signal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Description,Date")] Signal signal)
        {
            if (id != signal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignalExists(signal.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", signal.UserId);
            return View(signal);
        }

        // GET: Admin/Signal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signal = await _context.Signals
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signal == null)
            {
                return NotFound();
            }

            return View(signal);
        }

        // POST: Admin/Signal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signal = await _context.Signals.FindAsync(id);
            _context.Signals.Remove(signal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignalExists(int id)
        {
            return _context.Signals.Any(e => e.Id == id);
        }
    }
}
