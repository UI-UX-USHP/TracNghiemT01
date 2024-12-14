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
    public class TbKetQuaChiTietController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public TbKetQuaChiTietController(DbTracNghiemContext context)
        {
            _context = context;
        }

        // GET: Admin/TbKetQuaChiTiet
        public async Task<IActionResult> Index()
        {
            var dbTracNghiemContext = _context.TbKetQuaChiTiets.Include(t => t.IdCauHoiNavigation).Include(t => t.IdKetQuaNavigation);
            return View(await dbTracNghiemContext.ToListAsync());
        }

        // GET: Admin/TbKetQuaChiTiet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKetQuaChiTiet = await _context.TbKetQuaChiTiets
                .Include(t => t.IdCauHoiNavigation)
                .Include(t => t.IdKetQuaNavigation)
                .FirstOrDefaultAsync(m => m.IdKetQuaChiTiet == id);
            if (tbKetQuaChiTiet == null)
            {
                return NotFound();
            }

            return View(tbKetQuaChiTiet);
        }

        // GET: Admin/TbKetQuaChiTiet/Create
        public IActionResult Create()
        {
            ViewData["IdCauHoi"] = new SelectList(_context.TbCauHois, "IdCauHoi", "IdCauHoi");
            ViewData["IdKetQua"] = new SelectList(_context.TbKetQuas, "IdKetQua", "IdKetQua");
            return View();
        }

        // POST: Admin/TbKetQuaChiTiet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKetQuaChiTiet,IdKetQua,IdCauHoi,DapAnChon,DapAnDienKhuyet,DapAnSxthuTu,IsCorrect,ThuTuHienThi,TonTai")] TbKetQuaChiTiet tbKetQuaChiTiet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbKetQuaChiTiet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCauHoi"] = new SelectList(_context.TbCauHois, "IdCauHoi", "IdCauHoi", tbKetQuaChiTiet.IdCauHoi);
            ViewData["IdKetQua"] = new SelectList(_context.TbKetQuas, "IdKetQua", "IdKetQua", tbKetQuaChiTiet.IdKetQua);
            return View(tbKetQuaChiTiet);
        }

        // GET: Admin/TbKetQuaChiTiet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKetQuaChiTiet = await _context.TbKetQuaChiTiets.FindAsync(id);
            if (tbKetQuaChiTiet == null)
            {
                return NotFound();
            }
            ViewData["IdCauHoi"] = new SelectList(_context.TbCauHois, "IdCauHoi", "IdCauHoi", tbKetQuaChiTiet.IdCauHoi);
            ViewData["IdKetQua"] = new SelectList(_context.TbKetQuas, "IdKetQua", "IdKetQua", tbKetQuaChiTiet.IdKetQua);
            return View(tbKetQuaChiTiet);
        }

        // POST: Admin/TbKetQuaChiTiet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKetQuaChiTiet,IdKetQua,IdCauHoi,DapAnChon,DapAnDienKhuyet,DapAnSxthuTu,IsCorrect,ThuTuHienThi,TonTai")] TbKetQuaChiTiet tbKetQuaChiTiet)
        {
            if (id != tbKetQuaChiTiet.IdKetQuaChiTiet)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbKetQuaChiTiet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbKetQuaChiTietExists(tbKetQuaChiTiet.IdKetQuaChiTiet))
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
            ViewData["IdCauHoi"] = new SelectList(_context.TbCauHois, "IdCauHoi", "IdCauHoi", tbKetQuaChiTiet.IdCauHoi);
            ViewData["IdKetQua"] = new SelectList(_context.TbKetQuas, "IdKetQua", "IdKetQua", tbKetQuaChiTiet.IdKetQua);
            return View(tbKetQuaChiTiet);
        }

        // GET: Admin/TbKetQuaChiTiet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKetQuaChiTiet = await _context.TbKetQuaChiTiets
                .Include(t => t.IdCauHoiNavigation)
                .Include(t => t.IdKetQuaNavigation)
                .FirstOrDefaultAsync(m => m.IdKetQuaChiTiet == id);
            if (tbKetQuaChiTiet == null)
            {
                return NotFound();
            }

            return View(tbKetQuaChiTiet);
        }

        // POST: Admin/TbKetQuaChiTiet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKetQuaChiTiet = await _context.TbKetQuaChiTiets.FindAsync(id);
            if (tbKetQuaChiTiet != null)
            {
                _context.TbKetQuaChiTiets.Remove(tbKetQuaChiTiet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbKetQuaChiTietExists(int id)
        {
            return _context.TbKetQuaChiTiets.Any(e => e.IdKetQuaChiTiet == id);
        }
    }
}
