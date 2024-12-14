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
    public class TbMucDoKhoController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public TbMucDoKhoController(DbTracNghiemContext context)
        {
            _context = context;
        }

        // GET: Admin/TbMucDoKho
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbMucDoKhos.ToListAsync());
        }

        // GET: Admin/TbMucDoKho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMucDoKho = await _context.TbMucDoKhos
                .FirstOrDefaultAsync(m => m.IdMucDoKho == id);
            if (tbMucDoKho == null)
            {
                return NotFound();
            }

            return View(tbMucDoKho);
        }

        // GET: Admin/TbMucDoKho/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TbMucDoKho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMucDoKho,TenMucDo,ThuTuHienThi,TonTai")] TbMucDoKho tbMucDoKho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbMucDoKho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbMucDoKho);
        }

        // GET: Admin/TbMucDoKho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMucDoKho = await _context.TbMucDoKhos.FindAsync(id);
            if (tbMucDoKho == null)
            {
                return NotFound();
            }
            return View(tbMucDoKho);
        }

        // POST: Admin/TbMucDoKho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMucDoKho,TenMucDo,ThuTuHienThi,TonTai")] TbMucDoKho tbMucDoKho)
        {
            if (id != tbMucDoKho.IdMucDoKho)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbMucDoKho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbMucDoKhoExists(tbMucDoKho.IdMucDoKho))
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
            return View(tbMucDoKho);
        }

        // GET: Admin/TbMucDoKho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMucDoKho = await _context.TbMucDoKhos
                .FirstOrDefaultAsync(m => m.IdMucDoKho == id);
            if (tbMucDoKho == null)
            {
                return NotFound();
            }

            return View(tbMucDoKho);
        }

        // POST: Admin/TbMucDoKho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbMucDoKho = await _context.TbMucDoKhos.FindAsync(id);
            if (tbMucDoKho != null)
            {
                _context.TbMucDoKhos.Remove(tbMucDoKho);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbMucDoKhoExists(int id)
        {
            return _context.TbMucDoKhos.Any(e => e.IdMucDoKho == id);
        }
    }
}
