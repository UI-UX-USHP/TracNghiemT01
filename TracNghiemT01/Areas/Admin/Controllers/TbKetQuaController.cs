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
    public class TbKetQuaController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public TbKetQuaController(DbTracNghiemContext context)
        {
            _context = context;
        }

        // GET: Admin/TbKetQua
        public async Task<IActionResult> Index()
        {
            var dbTracNghiemContext = _context.TbKetQuas.Include(t => t.IdBaiThiNavigation).Include(t => t.IdNguoiDungNavigation).Include(t => t.IdSinhVienNavigation);
            return View(await dbTracNghiemContext.ToListAsync());
        }

        // GET: Admin/TbKetQua/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKetQua = await _context.TbKetQuas
                .Include(t => t.IdBaiThiNavigation)
                .Include(t => t.IdNguoiDungNavigation)
                .Include(t => t.IdSinhVienNavigation)
                .FirstOrDefaultAsync(m => m.IdKetQua == id);
            if (tbKetQua == null)
            {
                return NotFound();
            }

            return View(tbKetQua);
        }

        // GET: Admin/TbKetQua/Create
        public IActionResult Create()
        {
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi");
            ViewData["IdNguoiDung"] = new SelectList(_context.TbGiangViens, "IdNguoiDung", "IdNguoiDung");
            ViewData["IdSinhVien"] = new SelectList(_context.TbSinhViens, "IdSinhVien", "IdSinhVien");
            return View();
        }

        // POST: Admin/TbKetQua/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKetQua,IdNguoiDung,IdBaiThi,TongDiem,ThoiGianNop,ThuTuHienThi,TonTai,IdSinhVien")] TbKetQua tbKetQua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbKetQua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi", tbKetQua.IdBaiThi);
            ViewData["IdNguoiDung"] = new SelectList(_context.TbGiangViens, "IdNguoiDung", "IdNguoiDung", tbKetQua.IdNguoiDung);
            ViewData["IdSinhVien"] = new SelectList(_context.TbSinhViens, "IdSinhVien", "IdSinhVien", tbKetQua.IdSinhVien);
            return View(tbKetQua);
        }

        // GET: Admin/TbKetQua/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKetQua = await _context.TbKetQuas.FindAsync(id);
            if (tbKetQua == null)
            {
                return NotFound();
            }
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi", tbKetQua.IdBaiThi);
            ViewData["IdNguoiDung"] = new SelectList(_context.TbGiangViens, "IdNguoiDung", "IdNguoiDung", tbKetQua.IdNguoiDung);
            ViewData["IdSinhVien"] = new SelectList(_context.TbSinhViens, "IdSinhVien", "IdSinhVien", tbKetQua.IdSinhVien);
            return View(tbKetQua);
        }

        // POST: Admin/TbKetQua/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKetQua,IdNguoiDung,IdBaiThi,TongDiem,ThoiGianNop,ThuTuHienThi,TonTai,IdSinhVien")] TbKetQua tbKetQua)
        {
            if (id != tbKetQua.IdKetQua)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbKetQua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbKetQuaExists(tbKetQua.IdKetQua))
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
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi", tbKetQua.IdBaiThi);
            ViewData["IdNguoiDung"] = new SelectList(_context.TbGiangViens, "IdNguoiDung", "IdNguoiDung", tbKetQua.IdNguoiDung);
            ViewData["IdSinhVien"] = new SelectList(_context.TbSinhViens, "IdSinhVien", "IdSinhVien", tbKetQua.IdSinhVien);
            return View(tbKetQua);
        }

        // GET: Admin/TbKetQua/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKetQua = await _context.TbKetQuas
                .Include(t => t.IdBaiThiNavigation)
                .Include(t => t.IdNguoiDungNavigation)
                .Include(t => t.IdSinhVienNavigation)
                .FirstOrDefaultAsync(m => m.IdKetQua == id);
            if (tbKetQua == null)
            {
                return NotFound();
            }

            return View(tbKetQua);
        }

        // POST: Admin/TbKetQua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKetQua = await _context.TbKetQuas.FindAsync(id);
            if (tbKetQua != null)
            {
                _context.TbKetQuas.Remove(tbKetQua);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbKetQuaExists(int id)
        {
            return _context.TbKetQuas.Any(e => e.IdKetQua == id);
        }
    }
}
