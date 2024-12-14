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
    public class TbSinhVienController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public TbSinhVienController(DbTracNghiemContext context)
        {
            _context = context;
        }

        // GET: Admin/TbSinhVien
        public async Task<IActionResult> Index()
        {
            var dbTracNghiemContext = _context.TbSinhViens.Include(t => t.IdBaiThiNavigation).Include(t => t.IdKetQuaChiTietNavigation).Include(t => t.IdKetQuaNavigation);
            return View(await dbTracNghiemContext.ToListAsync());
        }

        // GET: Admin/TbSinhVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSinhVien = await _context.TbSinhViens
                .Include(t => t.IdBaiThiNavigation)
                .Include(t => t.IdKetQuaChiTietNavigation)
                .Include(t => t.IdKetQuaNavigation)
                .FirstOrDefaultAsync(m => m.IdSinhVien == id);
            if (tbSinhVien == null)
            {
                return NotFound();
            }

            return View(tbSinhVien);
        }

        // GET: Admin/TbSinhVien/Create
        public IActionResult Create()
        {
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi");
            ViewData["IdKetQuaChiTiet"] = new SelectList(_context.TbKetQuaChiTiets, "IdKetQuaChiTiet", "IdKetQuaChiTiet");
            ViewData["IdKetQua"] = new SelectList(_context.TbKetQuas, "IdKetQua", "IdKetQua");
            return View();
        }

        // POST: Admin/TbSinhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSinhVien,TenDangNhap,MatKhau,Email,Sdt,TrangThai,IdBaiThi,ThuTuHienThi,TonTai,IdKetQua,IdKetQuaChiTiet")] TbSinhVien tbSinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbSinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi", tbSinhVien.IdBaiThi);
            ViewData["IdKetQuaChiTiet"] = new SelectList(_context.TbKetQuaChiTiets, "IdKetQuaChiTiet", "IdKetQuaChiTiet", tbSinhVien.IdKetQuaChiTiet);
            ViewData["IdKetQua"] = new SelectList(_context.TbKetQuas, "IdKetQua", "IdKetQua", tbSinhVien.IdKetQua);
            return View(tbSinhVien);
        }

        // GET: Admin/TbSinhVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSinhVien = await _context.TbSinhViens.FindAsync(id);
            if (tbSinhVien == null)
            {
                return NotFound();
            }
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi", tbSinhVien.IdBaiThi);
            ViewData["IdKetQuaChiTiet"] = new SelectList(_context.TbKetQuaChiTiets, "IdKetQuaChiTiet", "IdKetQuaChiTiet", tbSinhVien.IdKetQuaChiTiet);
            ViewData["IdKetQua"] = new SelectList(_context.TbKetQuas, "IdKetQua", "IdKetQua", tbSinhVien.IdKetQua);
            return View(tbSinhVien);
        }

        // POST: Admin/TbSinhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSinhVien,TenDangNhap,MatKhau,Email,Sdt,TrangThai,IdBaiThi,ThuTuHienThi,TonTai,IdKetQua,IdKetQuaChiTiet")] TbSinhVien tbSinhVien)
        {
            if (id != tbSinhVien.IdSinhVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbSinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbSinhVienExists(tbSinhVien.IdSinhVien))
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
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi", tbSinhVien.IdBaiThi);
            ViewData["IdKetQuaChiTiet"] = new SelectList(_context.TbKetQuaChiTiets, "IdKetQuaChiTiet", "IdKetQuaChiTiet", tbSinhVien.IdKetQuaChiTiet);
            ViewData["IdKetQua"] = new SelectList(_context.TbKetQuas, "IdKetQua", "IdKetQua", tbSinhVien.IdKetQua);
            return View(tbSinhVien);
        }

        // GET: Admin/TbSinhVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSinhVien = await _context.TbSinhViens
                .Include(t => t.IdBaiThiNavigation)
                .Include(t => t.IdKetQuaChiTietNavigation)
                .Include(t => t.IdKetQuaNavigation)
                .FirstOrDefaultAsync(m => m.IdSinhVien == id);
            if (tbSinhVien == null)
            {
                return NotFound();
            }

            return View(tbSinhVien);
        }

        // POST: Admin/TbSinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbSinhVien = await _context.TbSinhViens.FindAsync(id);
            if (tbSinhVien != null)
            {
                _context.TbSinhViens.Remove(tbSinhVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbSinhVienExists(int id)
        {
            return _context.TbSinhViens.Any(e => e.IdSinhVien == id);
        }
    }
}
