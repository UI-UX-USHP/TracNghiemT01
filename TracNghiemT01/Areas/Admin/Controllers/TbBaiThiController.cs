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
    public class TbBaiThiController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public TbBaiThiController(DbTracNghiemContext context)
        {
            _context = context;
        }

        // GET: Admins/TbBaiThi
        public async Task<IActionResult> Index()
        {
            var dbTracNghiemContext = _context.TbBaiThis.Include(t => t.SoLanToiDaNavigation);
            return View(await dbTracNghiemContext.ToListAsync());
        }

        // GET: Admins/TbBaiThi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBaiThi = await _context.TbBaiThis
                .Include(t => t.SoLanToiDaNavigation)
                .FirstOrDefaultAsync(m => m.IdBaiThi == id);
            if (tbBaiThi == null)
            {
                return NotFound();
            }

            return View(tbBaiThi);
        }

        // GET: Admins/TbBaiThi/Create
        public IActionResult Create()
        {
            ViewData["SoLanToiDa"] = new SelectList(_context.TbLoaiCauHois, "IdLoaiCauHoi", "IdLoaiCauHoi");
            return View();
        }

        // POST: Admins/TbBaiThi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBaiThi,TenBaiThi,SoLanToiDa,ThoiGian,ThoiGianBatDau,IdChuDe,SoCauHoi,SoCauDe,SoCauTrungBinh,SoCauKho,DiemCauDe,DiemCauTrungBinh,DiemCauKho,ThuTuHienThi,TonTai,IdSinhVien")] TbBaiThi tbBaiThi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbBaiThi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SoLanToiDa"] = new SelectList(_context.TbLoaiCauHois, "IdLoaiCauHoi", "IdLoaiCauHoi", tbBaiThi.SoLanToiDa);
            return View(tbBaiThi);
        }

        // GET: Admins/TbBaiThi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBaiThi = await _context.TbBaiThis.FindAsync(id);
            if (tbBaiThi == null)
            {
                return NotFound();
            }
            ViewData["SoLanToiDa"] = new SelectList(_context.TbLoaiCauHois, "IdLoaiCauHoi", "IdLoaiCauHoi", tbBaiThi.SoLanToiDa);
            return View(tbBaiThi);
        }

        // POST: Admins/TbBaiThi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBaiThi,TenBaiThi,SoLanToiDa,ThoiGian,ThoiGianBatDau,IdChuDe,SoCauHoi,SoCauDe,SoCauTrungBinh,SoCauKho,DiemCauDe,DiemCauTrungBinh,DiemCauKho,ThuTuHienThi,TonTai,IdSinhVien")] TbBaiThi tbBaiThi)
        {
            if (id != tbBaiThi.IdBaiThi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbBaiThi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbBaiThiExists(tbBaiThi.IdBaiThi))
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
            ViewData["SoLanToiDa"] = new SelectList(_context.TbLoaiCauHois, "IdLoaiCauHoi", "IdLoaiCauHoi", tbBaiThi.SoLanToiDa);
            return View(tbBaiThi);
        }

        // GET: Admins/TbBaiThi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBaiThi = await _context.TbBaiThis
                .Include(t => t.SoLanToiDaNavigation)
                .FirstOrDefaultAsync(m => m.IdBaiThi == id);
            if (tbBaiThi == null)
            {
                return NotFound();
            }

            return View(tbBaiThi);
        }

        // POST: Admins/TbBaiThi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbBaiThi = await _context.TbBaiThis.FindAsync(id);
            if (tbBaiThi != null)
            {
                _context.TbBaiThis.Remove(tbBaiThi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbBaiThiExists(int id)
        {
            return _context.TbBaiThis.Any(e => e.IdBaiThi == id);
        }
    }
}
