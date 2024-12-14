using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TracNghiemT01.Models;

namespace TracNghiemT01.Controllers
{
    public class TbKhoaController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public TbKhoaController(DbTracNghiemContext context)
        {
            _context = context;
        }

        // GET: TbKhoa
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbKhoas.ToListAsync());
        }

        // GET: TbKhoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoa = await _context.TbKhoas
                .FirstOrDefaultAsync(m => m.IdKhoa == id);
            if (tbKhoa == null)
            {
                return NotFound();
            }

            return View(tbKhoa);
        }

        // GET: TbKhoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbKhoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKhoa,TenKhoa")] TbKhoa tbKhoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbKhoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbKhoa);
        }

        // GET: TbKhoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoa = await _context.TbKhoas.FindAsync(id);
            if (tbKhoa == null)
            {
                return NotFound();
            }
            return View(tbKhoa);
        }

        // POST: TbKhoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKhoa,TenKhoa")] TbKhoa tbKhoa)
        {
            if (id != tbKhoa.IdKhoa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbKhoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbKhoaExists(tbKhoa.IdKhoa))
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
            return View(tbKhoa);
        }

        // GET: TbKhoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoa = await _context.TbKhoas
                .FirstOrDefaultAsync(m => m.IdKhoa == id);
            if (tbKhoa == null)
            {
                return NotFound();
            }

            return View(tbKhoa);
        }

        // POST: TbKhoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKhoa = await _context.TbKhoas.FindAsync(id);
            if (tbKhoa != null)
            {
                _context.TbKhoas.Remove(tbKhoa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbKhoaExists(int id)
        {
            return _context.TbKhoas.Any(e => e.IdKhoa == id);
        }
    }
}
