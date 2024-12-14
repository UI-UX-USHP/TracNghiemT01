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
    public class TbBaiThiCauHoiController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public TbBaiThiCauHoiController(DbTracNghiemContext context)
        {
            _context = context;
        }

        // GET: Admin/TbBaiThiCauHoi
        public async Task<IActionResult> Index()
        {
            var dbTracNghiemContext = _context.TbBaiThiCauHois.Include(t => t.IdBaiThiNavigation).Include(t => t.IdCauHoiNavigation);
            return View(await dbTracNghiemContext.ToListAsync());
        }

        // GET: Admin/TbBaiThiCauHoi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBaiThiCauHoi = await _context.TbBaiThiCauHois
                .Include(t => t.IdBaiThiNavigation)
                .Include(t => t.IdCauHoiNavigation)
                .FirstOrDefaultAsync(m => m.IdBaiThiCauHoi == id);
            if (tbBaiThiCauHoi == null)
            {
                return NotFound();
            }

            return View(tbBaiThiCauHoi);
        }

        // GET: Admin/TbBaiThiCauHoi/Create
        public IActionResult Create()
        {
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi");
            ViewData["IdCauHoi"] = new SelectList(_context.TbCauHois, "IdCauHoi", "IdCauHoi");
            return View();
        }

        // POST: Admin/TbBaiThiCauHoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBaiThiCauHoi,IdCauHoi,IdBaiThi,Diem,ThuTuHienThi,TonTai")] TbBaiThiCauHoi tbBaiThiCauHoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbBaiThiCauHoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi", tbBaiThiCauHoi.IdBaiThi);
            ViewData["IdCauHoi"] = new SelectList(_context.TbCauHois, "IdCauHoi", "IdCauHoi", tbBaiThiCauHoi.IdCauHoi);
            return View(tbBaiThiCauHoi);
        }

        // GET: Admin/TbBaiThiCauHoi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBaiThiCauHoi = await _context.TbBaiThiCauHois.FindAsync(id);
            if (tbBaiThiCauHoi == null)
            {
                return NotFound();
            }
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi", tbBaiThiCauHoi.IdBaiThi);
            ViewData["IdCauHoi"] = new SelectList(_context.TbCauHois, "IdCauHoi", "IdCauHoi", tbBaiThiCauHoi.IdCauHoi);
            return View(tbBaiThiCauHoi);
        }

        // POST: Admin/TbBaiThiCauHoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBaiThiCauHoi,IdCauHoi,IdBaiThi,Diem,ThuTuHienThi,TonTai")] TbBaiThiCauHoi tbBaiThiCauHoi)
        {
            if (id != tbBaiThiCauHoi.IdBaiThiCauHoi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbBaiThiCauHoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbBaiThiCauHoiExists(tbBaiThiCauHoi.IdBaiThiCauHoi))
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
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi", tbBaiThiCauHoi.IdBaiThi);
            ViewData["IdCauHoi"] = new SelectList(_context.TbCauHois, "IdCauHoi", "IdCauHoi", tbBaiThiCauHoi.IdCauHoi);
            return View(tbBaiThiCauHoi);
        }

        // GET: Admin/TbBaiThiCauHoi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBaiThiCauHoi = await _context.TbBaiThiCauHois
                .Include(t => t.IdBaiThiNavigation)
                .Include(t => t.IdCauHoiNavigation)
                .FirstOrDefaultAsync(m => m.IdBaiThiCauHoi == id);
            if (tbBaiThiCauHoi == null)
            {
                return NotFound();
            }

            return View(tbBaiThiCauHoi);
        }

        // POST: Admin/TbBaiThiCauHoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbBaiThiCauHoi = await _context.TbBaiThiCauHois.FindAsync(id);
            if (tbBaiThiCauHoi != null)
            {
                _context.TbBaiThiCauHois.Remove(tbBaiThiCauHoi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbBaiThiCauHoiExists(int id)
        {
            return _context.TbBaiThiCauHois.Any(e => e.IdBaiThiCauHoi == id);
        }
    }
}
