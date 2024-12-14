using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TracNghiemT01.Models;

namespace TracNghiemT01.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TbGiangVienController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public TbGiangVienController(DbTracNghiemContext context)
        {
            _context = context;
        }

        // GET: Admin/TbGiangVien
        public async Task<IActionResult> Index()
        {
            var dbTracNghiemContext = _context.TbGiangViens.Include(t => t.IdKhoaNavigation);
            return View(await dbTracNghiemContext.ToListAsync());
        }

        // GET: Admin/TbGiangVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiangVien = await _context.TbGiangViens
                .Include(t => t.IdKhoaNavigation)
                .FirstOrDefaultAsync(m => m.IdNguoiDung == id);
            if (tbGiangVien == null)
            {
                return NotFound();
            }

            return View(tbGiangVien);
        }

        // GET: Admin/TbGiangVien/Create
        public IActionResult Create()
        {
            ViewData["IdKhoa"] = new SelectList(_context.TbKhoas, "IdKhoa", "IdKhoa");
            return View();
        }

        // POST: Admin/TbGiangVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNguoiDung,HoTen,Email,TenDangNhap,MatKhau,Lop,IdKhoa,NgaySinh,GioiTinh,Sdt,ThuTuHienThi,TonTai")] TbGiangVien tbGiangVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbGiangVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKhoa"] = new SelectList(_context.TbKhoas, "IdKhoa", "IdKhoa", tbGiangVien.IdKhoa);
            return View(tbGiangVien);
        }

        // GET: Admin/TbGiangVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiangVien = await _context.TbGiangViens.FindAsync(id);
            if (tbGiangVien == null)
            {
                return NotFound();
            }
            ViewData["IdKhoa"] = new SelectList(_context.TbKhoas, "IdKhoa", "IdKhoa", tbGiangVien.IdKhoa);
            return View(tbGiangVien);
        }

        // POST: Admin/TbGiangVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNguoiDung,HoTen,Email,TenDangNhap,MatKhau,Lop,IdKhoa,NgaySinh,GioiTinh,Sdt,ThuTuHienThi,TonTai")] TbGiangVien tbGiangVien)
        {
            if (id != tbGiangVien.IdNguoiDung)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbGiangVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbGiangVienExists(tbGiangVien.IdNguoiDung))
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
            ViewData["IdKhoa"] = new SelectList(_context.TbKhoas, "IdKhoa", "IdKhoa", tbGiangVien.IdKhoa);
            return View(tbGiangVien);
        }

        // GET: Admin/TbGiangVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiangVien = await _context.TbGiangViens
                .Include(t => t.IdKhoaNavigation)
                .FirstOrDefaultAsync(m => m.IdNguoiDung == id);
            if (tbGiangVien == null)
            {
                return NotFound();
            }

            return View(tbGiangVien);
        }

        // POST: Admin/TbGiangVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbGiangVien = await _context.TbGiangViens.FindAsync(id);
            if (tbGiangVien != null)
            {
                _context.TbGiangViens.Remove(tbGiangVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbGiangVienExists(int id)
        {
            return _context.TbGiangViens.Any(e => e.IdNguoiDung == id);
        }
    }
}
