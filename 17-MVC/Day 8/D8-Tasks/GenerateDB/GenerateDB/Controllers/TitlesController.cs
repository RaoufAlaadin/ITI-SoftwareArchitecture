using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GenerateDB.Models;

namespace GenerateDB.Controllers
{
    public class TitlesController : Controller
    {
        private readonly pubsContext _context;

        public TitlesController(pubsContext context)
        {
            _context = context;
        }

        // GET: Titles
        public async Task<IActionResult> Index()
        {
            var pubsContext = _context.Titles.Include(t => t.Pub);
            return View(await pubsContext.ToListAsync());
        }

        // GET: Titles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Titles
                .Include(t => t.Pub)
                .FirstOrDefaultAsync(m => m.TitleId == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // GET: Titles/Create
        public IActionResult Create()
        {
            ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "PubId");
            return View();
        }

        // POST: Titles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TitleId,Title1,Type,PubId,Price,Advance,Royalty,YtdSales,Notes,Pubdate")] Title title)
        {
            if (ModelState.IsValid)
            {
                _context.Add(title);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "PubId", title.PubId);
            return View(title);
        }

        // GET: Titles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Titles.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }
            ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "PubId", title.PubId);
            return View(title);
        }

        // POST: Titles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TitleId,Title1,Type,PubId,Price,Advance,Royalty,YtdSales,Notes,Pubdate")] Title title)
        {
            if (id != title.TitleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(title);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitleExists(title.TitleId))
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
            ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "PubId", title.PubId);
            return View(title);
        }

        // GET: Titles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Titles
                .Include(t => t.Pub)
                .FirstOrDefaultAsync(m => m.TitleId == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // POST: Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var title = await _context.Titles.FindAsync(id);
            _context.Titles.Remove(title);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitleExists(string id)
        {
            return _context.Titles.Any(e => e.TitleId == id);
        }
    }
}
