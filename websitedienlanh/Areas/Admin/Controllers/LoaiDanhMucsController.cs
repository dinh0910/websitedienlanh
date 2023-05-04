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
    public class LoaiDanhMucsController : Controller
    {
        private readonly websitedienlanhContext _context;

        public LoaiDanhMucsController(websitedienlanhContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiDanhMucs
        public async Task<IActionResult> Index()
        {
              return _context.LoaiDanhMuc != null ? 
                          View(await _context.LoaiDanhMuc.ToListAsync()) :
                          Problem("Entity set 'websitedienlanhContext.LoaiDanhMuc'  is null.");
        }

        // GET: Admin/LoaiDanhMucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LoaiDanhMuc == null)
            {
                return NotFound();
            }

            var loaiDanhMuc = await _context.LoaiDanhMuc
                .FirstOrDefaultAsync(m => m.LoaiDanhMucID == id);
            ViewBag.dm = _context.DanhMuc;
            if (loaiDanhMuc == null)
            {
                return NotFound();
            }

            return View(loaiDanhMuc);
        }

        public async Task<IActionResult> DeleteDM(int? id)
        {
            //var tt = await _context.DanhMuc.Include(s => s.LoaiDanhMuc)
                //.FirstOrDefaultAsync(m => m.DanhMucID == id);

            var danhMuc = await _context.DanhMuc.FindAsync(id);
            _context.DanhMuc.Remove(danhMuc);
            await _context.SaveChangesAsync();

            return View(nameof(Index));
            //return RedirectToAction("Details", "LoaiDanhMucs", routeValues: new { id });
        }

        // GET: Admin/LoaiDanhMucs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiDanhMucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoaiDanhMucID,Ten")] LoaiDanhMuc loaiDanhMuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiDanhMuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiDanhMuc);
        }

        // GET: Admin/LoaiDanhMucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LoaiDanhMuc == null)
            {
                return NotFound();
            }

            var loaiDanhMuc = await _context.LoaiDanhMuc.FindAsync(id);
            if (loaiDanhMuc == null)
            {
                return NotFound();
            }
            return View(loaiDanhMuc);
        }

        // POST: Admin/LoaiDanhMucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoaiDanhMucID,Ten")] LoaiDanhMuc loaiDanhMuc)
        {
            if (id != loaiDanhMuc.LoaiDanhMucID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiDanhMuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiDanhMucExists(loaiDanhMuc.LoaiDanhMucID))
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
            return View(loaiDanhMuc);
        }

        // GET: Admin/LoaiDanhMucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LoaiDanhMuc == null)
            {
                return NotFound();
            }

            var loaiDanhMuc = await _context.LoaiDanhMuc
                .FirstOrDefaultAsync(m => m.LoaiDanhMucID == id);
            if (loaiDanhMuc == null)
            {
                return NotFound();
            }

            return View(loaiDanhMuc);
        }

        // POST: Admin/LoaiDanhMucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LoaiDanhMuc == null)
            {
                return Problem("Entity set 'websitedienlanhContext.LoaiDanhMuc'  is null.");
            }
            var loaiDanhMuc = await _context.LoaiDanhMuc.FindAsync(id);
            if (loaiDanhMuc != null)
            {
                _context.LoaiDanhMuc.Remove(loaiDanhMuc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiDanhMucExists(int id)
        {
          return (_context.LoaiDanhMuc?.Any(e => e.LoaiDanhMucID == id)).GetValueOrDefault();
        }
    }
}
