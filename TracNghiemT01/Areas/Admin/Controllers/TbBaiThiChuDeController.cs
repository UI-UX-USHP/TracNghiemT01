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
    public class TbBaiThiChuDeController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public TbBaiThiChuDeController(DbTracNghiemContext context)
        {
            _context = context;
        }

        // GET: Admins/TbBaiThiChuDe
        public async Task<IActionResult> Index()
        {
            var dbTracNghiemContext = _context.TbBaiThiChuDes.Include(t => t.IdBaiThiNavigation).Include(t => t.IdChuDeNavigation);
            return View(await dbTracNghiemContext.ToListAsync());
        }

        // GET: Admins/TbBaiThiChuDe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBaiThiChuDe = await _context.TbBaiThiChuDes
                .Include(t => t.IdBaiThiNavigation)
                .Include(t => t.IdChuDeNavigation)
                .FirstOrDefaultAsync(m => m.IdBaiThiChuDe == id);
            if (tbBaiThiChuDe == null)
            {
                return NotFound();
            }

            return View(tbBaiThiChuDe);
        }

        // GET: Admins/TbBaiThiChuDe/Create
        public IActionResult Create()
        {
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi");
            ViewData["IdChuDe"] = new SelectList(_context.TbChuDes, "IdChuDe", "IdChuDe");
            return View();
        }

        // POST: Admins/TbBaiThiChuDe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBaiThiChuDe,IdBaiThi,IdChuDe,ThuTuHienThi,TonTai")] TbBaiThiChuDe tbBaiThiChuDe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbBaiThiChuDe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi", tbBaiThiChuDe.IdBaiThi);
            ViewData["IdChuDe"] = new SelectList(_context.TbChuDes, "IdChuDe", "IdChuDe", tbBaiThiChuDe.IdChuDe);
            return View(tbBaiThiChuDe);
        }

        // GET: Admins/TbBaiThiChuDe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBaiThiChuDe = await _context.TbBaiThiChuDes.FindAsync(id);
            if (tbBaiThiChuDe == null)
            {
                return NotFound();
            }
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi", tbBaiThiChuDe.IdBaiThi);
            ViewData["IdChuDe"] = new SelectList(_context.TbChuDes, "IdChuDe", "IdChuDe", tbBaiThiChuDe.IdChuDe);
            return View(tbBaiThiChuDe);
        }

        // POST: Admins/TbBaiThiChuDe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBaiThiChuDe,IdBaiThi,IdChuDe,ThuTuHienThi,TonTai")] TbBaiThiChuDe tbBaiThiChuDe)
        {
            if (id != tbBaiThiChuDe.IdBaiThiChuDe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbBaiThiChuDe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbBaiThiChuDeExists(tbBaiThiChuDe.IdBaiThiChuDe))
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
            ViewData["IdBaiThi"] = new SelectList(_context.TbBaiThis, "IdBaiThi", "IdBaiThi", tbBaiThiChuDe.IdBaiThi);
            ViewData["IdChuDe"] = new SelectList(_context.TbChuDes, "IdChuDe", "IdChuDe", tbBaiThiChuDe.IdChuDe);
            return View(tbBaiThiChuDe);
        }

        // GET: Admins/TbBaiThiChuDe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBaiThiChuDe = await _context.TbBaiThiChuDes
                .Include(t => t.IdBaiThiNavigation)
                .Include(t => t.IdChuDeNavigation)
                .FirstOrDefaultAsync(m => m.IdBaiThiChuDe == id);
            if (tbBaiThiChuDe == null)
            {
                return NotFound();
            }

            return View(tbBaiThiChuDe);
        }

        // POST: Admins/TbBaiThiChuDe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbBaiThiChuDe = await _context.TbBaiThiChuDes.FindAsync(id);
            if (tbBaiThiChuDe != null)
            {
                _context.TbBaiThiChuDes.Remove(tbBaiThiChuDe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbBaiThiChuDeExists(int id)
        {
            return _context.TbBaiThiChuDes.Any(e => e.IdBaiThiChuDe == id);
        }
    }
}
