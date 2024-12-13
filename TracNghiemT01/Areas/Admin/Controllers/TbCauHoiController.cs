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
    [Area("Admins")]
    public class TbCauHoiController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public TbCauHoiController(DbTracNghiemContext context)
        {
            _context = context;
        }

        // GET: Admins/TbCauHoi
        public async Task<IActionResult> Index()
        {
            var dbTracNghiemContext = _context.TbCauHois.Include(t => t.IdChuDeNavigation).Include(t => t.IdLoaiCauHoiNavigation).Include(t => t.IdMucDoKhoNavigation);
            return View(await dbTracNghiemContext.ToListAsync());
        }

        // GET: Admins/TbCauHoi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCauHoi = await _context.TbCauHois
                .Include(t => t.IdChuDeNavigation)
                .Include(t => t.IdLoaiCauHoiNavigation)
                .Include(t => t.IdMucDoKhoNavigation)
                .FirstOrDefaultAsync(m => m.IdCauHoi == id);
            if (tbCauHoi == null)
            {
                return NotFound();
            }

            return View(tbCauHoi);
        }

        // GET: Admins/TbCauHoi/Create
        public IActionResult Create()
        {
            ViewData["IdChuDe"] = new SelectList(_context.TbChuDes, "IdChuDe", "IdChuDe");
            ViewData["IdLoaiCauHoi"] = new SelectList(_context.TbLoaiCauHois, "IdLoaiCauHoi", "IdLoaiCauHoi");
            ViewData["IdMucDoKho"] = new SelectList(_context.TbMucDoKhos, "IdMucDoKho", "IdMucDoKho");
            return View();
        }

        // POST: Admins/TbCauHoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCauHoi,IdChuDe,IdMucDoKho,NoiDung,UuTienSuDung,ChiDinhDacBiet,IdLoaiCauHoi,ThuTuHienThi,TonTai")] TbCauHoi tbCauHoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCauHoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdChuDe"] = new SelectList(_context.TbChuDes, "IdChuDe", "IdChuDe", tbCauHoi.IdChuDe);
            ViewData["IdLoaiCauHoi"] = new SelectList(_context.TbLoaiCauHois, "IdLoaiCauHoi", "IdLoaiCauHoi", tbCauHoi.IdLoaiCauHoi);
            ViewData["IdMucDoKho"] = new SelectList(_context.TbMucDoKhos, "IdMucDoKho", "IdMucDoKho", tbCauHoi.IdMucDoKho);
            return View(tbCauHoi);
        }

        // GET: Admins/TbCauHoi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCauHoi = await _context.TbCauHois.FindAsync(id);
            if (tbCauHoi == null)
            {
                return NotFound();
            }
            ViewData["IdChuDe"] = new SelectList(_context.TbChuDes, "IdChuDe", "IdChuDe", tbCauHoi.IdChuDe);
            ViewData["IdLoaiCauHoi"] = new SelectList(_context.TbLoaiCauHois, "IdLoaiCauHoi", "IdLoaiCauHoi", tbCauHoi.IdLoaiCauHoi);
            ViewData["IdMucDoKho"] = new SelectList(_context.TbMucDoKhos, "IdMucDoKho", "IdMucDoKho", tbCauHoi.IdMucDoKho);
            return View(tbCauHoi);
        }

        // POST: Admins/TbCauHoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCauHoi,IdChuDe,IdMucDoKho,NoiDung,UuTienSuDung,ChiDinhDacBiet,IdLoaiCauHoi,ThuTuHienThi,TonTai")] TbCauHoi tbCauHoi)
        {
            if (id != tbCauHoi.IdCauHoi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCauHoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCauHoiExists(tbCauHoi.IdCauHoi))
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
            ViewData["IdChuDe"] = new SelectList(_context.TbChuDes, "IdChuDe", "IdChuDe", tbCauHoi.IdChuDe);
            ViewData["IdLoaiCauHoi"] = new SelectList(_context.TbLoaiCauHois, "IdLoaiCauHoi", "IdLoaiCauHoi", tbCauHoi.IdLoaiCauHoi);
            ViewData["IdMucDoKho"] = new SelectList(_context.TbMucDoKhos, "IdMucDoKho", "IdMucDoKho", tbCauHoi.IdMucDoKho);
            return View(tbCauHoi);
        }

        // GET: Admins/TbCauHoi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCauHoi = await _context.TbCauHois
                .Include(t => t.IdChuDeNavigation)
                .Include(t => t.IdLoaiCauHoiNavigation)
                .Include(t => t.IdMucDoKhoNavigation)
                .FirstOrDefaultAsync(m => m.IdCauHoi == id);
            if (tbCauHoi == null)
            {
                return NotFound();
            }

            return View(tbCauHoi);
        }

        // POST: Admins/TbCauHoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCauHoi = await _context.TbCauHois.FindAsync(id);
            if (tbCauHoi != null)
            {
                _context.TbCauHois.Remove(tbCauHoi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCauHoiExists(int id)
        {
            return _context.TbCauHois.Any(e => e.IdCauHoi == id);
        }
    }
}
