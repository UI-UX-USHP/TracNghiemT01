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
    public class TbChuDeController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public TbChuDeController(DbTracNghiemContext context)
        {
            _context = context;
        }

        // GET: Admin/TbChuDe
        public async Task<IActionResult> Index()
        {
            var dbTracNghiemContext = _context.TbChuDes.Include(t => t.IdMonHocNavigation);
            return View(await dbTracNghiemContext.ToListAsync());
        }

        // GET: Admin/TbChuDe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChuDe = await _context.TbChuDes
                .Include(t => t.IdMonHocNavigation)
                .FirstOrDefaultAsync(m => m.IdChuDe == id);
            if (tbChuDe == null)
            {
                return NotFound();
            }

            return View(tbChuDe);
        }

        // GET: Admin/TbChuDe/Create
        public IActionResult Create()
        {
            ViewData["IdMonHoc"] = new SelectList(_context.TbMonHocs, "IdMonHoc", "IdMonHoc");
            return View();
        }

        // POST: Admin/TbChuDe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChuDe,IdMonHoc,TenChuDe,ThuTuHienThi,TonTai")] TbChuDe tbChuDe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbChuDe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMonHoc"] = new SelectList(_context.TbMonHocs, "IdMonHoc", "IdMonHoc", tbChuDe.IdMonHoc);
            return View(tbChuDe);
        }

        // GET: Admin/TbChuDe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChuDe = await _context.TbChuDes.FindAsync(id);
            if (tbChuDe == null)
            {
                return NotFound();
            }
            ViewData["IdMonHoc"] = new SelectList(_context.TbMonHocs, "IdMonHoc", "IdMonHoc", tbChuDe.IdMonHoc);
            return View(tbChuDe);
        }

        // POST: Admin/TbChuDe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChuDe,IdMonHoc,TenChuDe,ThuTuHienThi,TonTai")] TbChuDe tbChuDe)
        {
            if (id != tbChuDe.IdChuDe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbChuDe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbChuDeExists(tbChuDe.IdChuDe))
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
            ViewData["IdMonHoc"] = new SelectList(_context.TbMonHocs, "IdMonHoc", "IdMonHoc", tbChuDe.IdMonHoc);
            return View(tbChuDe);
        }

        // GET: Admin/TbChuDe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChuDe = await _context.TbChuDes
                .Include(t => t.IdMonHocNavigation)
                .FirstOrDefaultAsync(m => m.IdChuDe == id);
            if (tbChuDe == null)
            {
                return NotFound();
            }

            return View(tbChuDe);
        }

        // POST: Admin/TbChuDe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbChuDe = await _context.TbChuDes.FindAsync(id);
            if (tbChuDe != null)
            {
                _context.TbChuDes.Remove(tbChuDe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbChuDeExists(int id)
        {
            return _context.TbChuDes.Any(e => e.IdChuDe == id);
        }
    }
}
