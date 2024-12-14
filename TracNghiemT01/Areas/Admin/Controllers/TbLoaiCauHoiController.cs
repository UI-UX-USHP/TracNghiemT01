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
    public class TbLoaiCauHoiController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public TbLoaiCauHoiController(DbTracNghiemContext context)
        {
            _context = context;
        }

        // GET: Admin/TbLoaiCauHoi
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbLoaiCauHois.ToListAsync());
        }

        // GET: Admin/TbLoaiCauHoi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLoaiCauHoi = await _context.TbLoaiCauHois
                .FirstOrDefaultAsync(m => m.IdLoaiCauHoi == id);
            if (tbLoaiCauHoi == null)
            {
                return NotFound();
            }

            return View(tbLoaiCauHoi);
        }

        // GET: Admin/TbLoaiCauHoi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TbLoaiCauHoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoaiCauHoi,LoaiCauHoi,ThuTuHienThi,TonTai")] TbLoaiCauHoi tbLoaiCauHoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbLoaiCauHoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbLoaiCauHoi);
        }

        // GET: Admin/TbLoaiCauHoi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLoaiCauHoi = await _context.TbLoaiCauHois.FindAsync(id);
            if (tbLoaiCauHoi == null)
            {
                return NotFound();
            }
            return View(tbLoaiCauHoi);
        }

        // POST: Admin/TbLoaiCauHoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLoaiCauHoi,LoaiCauHoi,ThuTuHienThi,TonTai")] TbLoaiCauHoi tbLoaiCauHoi)
        {
            if (id != tbLoaiCauHoi.IdLoaiCauHoi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbLoaiCauHoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbLoaiCauHoiExists(tbLoaiCauHoi.IdLoaiCauHoi))
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
            return View(tbLoaiCauHoi);
        }

        // GET: Admin/TbLoaiCauHoi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLoaiCauHoi = await _context.TbLoaiCauHois
                .FirstOrDefaultAsync(m => m.IdLoaiCauHoi == id);
            if (tbLoaiCauHoi == null)
            {
                return NotFound();
            }

            return View(tbLoaiCauHoi);
        }

        // POST: Admin/TbLoaiCauHoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbLoaiCauHoi = await _context.TbLoaiCauHois.FindAsync(id);
            if (tbLoaiCauHoi != null)
            {
                _context.TbLoaiCauHois.Remove(tbLoaiCauHoi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbLoaiCauHoiExists(int id)
        {
            return _context.TbLoaiCauHois.Any(e => e.IdLoaiCauHoi == id);
        }
    }
}
