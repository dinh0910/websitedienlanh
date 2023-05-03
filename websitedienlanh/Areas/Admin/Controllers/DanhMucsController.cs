using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using websitedienlanh.Data;
using websitedienlanh.Models;

namespace websitedienlanh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DanhMucsController : Controller
    {
        private readonly websitedienlanhContext _context;

        public DanhMucsController(websitedienlanhContext context)
        {
            _context = context;
        }

        // GET: Admin/DanhMucs
        public async Task<IActionResult> Index()
        {
              return _context.DanhMuc != null ? 
                          View(await _context.DanhMuc.ToListAsync()) :
                          Problem("Entity set 'websitedienlanhContext.DanhMuc'  is null.");
        }

        // GET: Admin/DanhMucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DanhMuc == null)
            {
                return NotFound();
            }

            var danhMuc = await _context.DanhMuc
                .FirstOrDefaultAsync(m => m.DanhMucID == id);
            if (danhMuc == null)
            {
                return NotFound();
            }

            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Create
        public IActionResult Create()
        {
            ViewData["LoaiDanhMucID"] = new SelectList(_context.LoaiDanhMuc, "LoaiDanhMucID", "Ten");
            return View();
        }

        // POST: Admin/DanhMucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DanhMucID,LoaiDanhMucID,TenDanhMuc")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhMuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiDanhMucID"] = new SelectList(_context.LoaiDanhMuc, "LoaiDanhMucID", "Ten", danhMuc.LoaiDanhMucID);
            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DanhMuc == null)
            {
                return NotFound();
            }

            var danhMuc = await _context.DanhMuc.FindAsync(id);
            if (danhMuc == null)
            {
                return NotFound();
            }
            return View(danhMuc);
        }

        // POST: Admin/DanhMucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DanhMucID,LoaiDanhMucID,TenDanhMuc")] DanhMuc danhMuc)
        {
            if (id != danhMuc.DanhMucID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhMuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucExists(danhMuc.DanhMucID))
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
            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DanhMuc == null)
            {
                return NotFound();
            }

            var danhMuc = await _context.DanhMuc
                .FirstOrDefaultAsync(m => m.DanhMucID == id);
            if (danhMuc == null)
            {
                return NotFound();
            }

            return View(danhMuc);
        }

        // POST: Admin/DanhMucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DanhMuc == null)
            {
                return Problem("Entity set 'websitedienlanhContext.DanhMuc'  is null.");
            }
            var danhMuc = await _context.DanhMuc.FindAsync(id);
            if (danhMuc != null)
            {
                _context.DanhMuc.Remove(danhMuc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhMucExists(int id)
        {
          return (_context.DanhMuc?.Any(e => e.DanhMucID == id)).GetValueOrDefault();
        }
    }
}
