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
    public class TbDapAnController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public TbDapAnController(DbTracNghiemContext context)
        {
            _context = context;
        }

        // GET: Admin/TbDapAn
        public async Task<IActionResult> Index()
        {
            var dbTracNghiemContext = _context.TbDapAns.Include(t => t.IdCauHoiNavigation);
            return View(await dbTracNghiemContext.ToListAsync());
        }

        // GET: Admin/TbDapAn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDapAn = await _context.TbDapAns
                .Include(t => t.IdCauHoiNavigation)
                .FirstOrDefaultAsync(m => m.IdDapAn == id);
            if (tbDapAn == null)
            {
                return NotFound();
            }

            return View(tbDapAn);
        }

        // GET: Admin/TbDapAn/Create
        public IActionResult Create()
        {
            ViewData["IdCauHoi"] = new SelectList(_context.TbCauHois, "IdCauHoi", "IdCauHoi");
            return View();
        }

        // POST: Admin/TbDapAn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDapAn,IdCauHoi,NoiDung,DapAnDung,ThuTu,ThuTuHienThi,TonTai")] TbDapAn tbDapAn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDapAn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCauHoi"] = new SelectList(_context.TbCauHois, "IdCauHoi", "IdCauHoi", tbDapAn.IdCauHoi);
            return View(tbDapAn);
        }

        // GET: Admin/TbDapAn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDapAn = await _context.TbDapAns.FindAsync(id);
            if (tbDapAn == null)
            {
                return NotFound();
            }
            ViewData["IdCauHoi"] = new SelectList(_context.TbCauHois, "IdCauHoi", "IdCauHoi", tbDapAn.IdCauHoi);
            return View(tbDapAn);
        }

        // POST: Admin/TbDapAn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDapAn,IdCauHoi,NoiDung,DapAnDung,ThuTu,ThuTuHienThi,TonTai")] TbDapAn tbDapAn)
        {
            if (id != tbDapAn.IdDapAn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDapAn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDapAnExists(tbDapAn.IdDapAn))
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
            ViewData["IdCauHoi"] = new SelectList(_context.TbCauHois, "IdCauHoi", "IdCauHoi", tbDapAn.IdCauHoi);
            return View(tbDapAn);
        }

        // GET: Admin/TbDapAn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDapAn = await _context.TbDapAns
                .Include(t => t.IdCauHoiNavigation)
                .FirstOrDefaultAsync(m => m.IdDapAn == id);
            if (tbDapAn == null)
            {
                return NotFound();
            }

            return View(tbDapAn);
        }

        // POST: Admin/TbDapAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDapAn = await _context.TbDapAns.FindAsync(id);
            if (tbDapAn != null)
            {
                _context.TbDapAns.Remove(tbDapAn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDapAnExists(int id)
        {
            return _context.TbDapAns.Any(e => e.IdDapAn == id);
        }
    }
}
