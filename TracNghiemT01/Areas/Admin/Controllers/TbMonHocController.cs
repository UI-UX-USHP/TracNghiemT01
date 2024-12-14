using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TracNghiemT01.Models;

namespace TracNghiemT01.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class TbMonHocController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public TbMonHocController(DbTracNghiemContext context)
        {
            _context = context;
        }

        // GET: Admin/TbMonHoc
        public async Task<IActionResult> Index()
        {
            var dbTracNghiemContext = _context.TbMonHocs.Include(t => t.IdKhoaNavigation);
            return View(await dbTracNghiemContext.ToListAsync());
        }

        // GET: Admin/TbMonHoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMonHoc = await _context.TbMonHocs
                .Include(t => t.IdKhoaNavigation)
                .FirstOrDefaultAsync(m => m.IdMonHoc == id);
            if (tbMonHoc == null)
            {
                return NotFound();
            }

            return View(tbMonHoc);
        }

        // GET: Admin/TbMonHoc/Create
        public IActionResult Create()
        {
            ViewData["IdKhoa"] = new SelectList(_context.TbKhoas, "IdKhoa", "IdKhoa");
            return View();
        }

        // POST: Admin/TbMonHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMonHoc,TenMonHoc,IdKhoa,ThuTuHienThi,TonTai")] TbMonHoc tbMonHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbMonHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKhoa"] = new SelectList(_context.TbKhoas, "IdKhoa", "IdKhoa", tbMonHoc.IdKhoa);
            return View(tbMonHoc);
        }

        // GET: Admin/TbMonHoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMonHoc = await _context.TbMonHocs.FindAsync(id);
            if (tbMonHoc == null)
            {
                return NotFound();
            }
            ViewData["IdKhoa"] = new SelectList(_context.TbKhoas, "IdKhoa", "IdKhoa", tbMonHoc.IdKhoa);
            return View(tbMonHoc);
        }

        // POST: Admin/TbMonHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMonHoc,TenMonHoc,IdKhoa,ThuTuHienThi,TonTai")] TbMonHoc tbMonHoc)
        {
            if (id != tbMonHoc.IdMonHoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbMonHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbMonHocExists(tbMonHoc.IdMonHoc))
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
            ViewData["IdKhoa"] = new SelectList(_context.TbKhoas, "IdKhoa", "IdKhoa", tbMonHoc.IdKhoa);
            return View(tbMonHoc);
        }

        // GET: Admin/TbMonHoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMonHoc = await _context.TbMonHocs
                .Include(t => t.IdKhoaNavigation)
                .FirstOrDefaultAsync(m => m.IdMonHoc == id);
            if (tbMonHoc == null)
            {
                return NotFound();
            }

            return View(tbMonHoc);
        }

        // POST: Admin/TbMonHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbMonHoc = await _context.TbMonHocs.FindAsync(id);
            if (tbMonHoc != null)
            {
                _context.TbMonHocs.Remove(tbMonHoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbMonHocExists(int id)
        {
            return _context.TbMonHocs.Any(e => e.IdMonHoc == id);
        }
    }
}
