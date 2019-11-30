using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MidTermNetCore.Models;

namespace MidTermNetCore.Controllers
{
    public class LopHocPhanController : Controller
    {
        private readonly MyDBContext _context;

        public LopHocPhanController(MyDBContext context)
        {
            _context = context;
        }

        // GET: LopHocPhan
        public async Task<IActionResult> Index()
        {
            var result = _context.LopHocPhans
                        .Include(x => x.SinhVienNavigation)
                        .Include(x => x.MonHocNavigation)
                        .Select(p => new LopHPView
                        {
                            ID=p.ID,
                            MaLopHP=p.MaLHP,
                            TenMon=p.MonHocNavigation.TenMon,
                            TenSV=p.SinhVienNavigation.HoTen,
                            HocKy=p.HocKy,
                            DiemGK=p.DiemGK,
                            DiemCK=p.DiemCK
                            
                        });
            return View(await result.ToListAsync());
        }

        // GET: LopHocPhan/Details/5
        public async Task<IActionResult> Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var lopHocPhan = _context.LopHocPhans
                         .Include(x => x.SinhVienNavigation)
                         .Include(x => x.MonHocNavigation)
                         .Where(p => p.ID == ID)
                         .Select(p => new LopHPView
                         {
                             ID = p.ID,
                             MaLopHP = p.MaLHP,
                             TenMon = p.MonHocNavigation.TenMon,
                             TenSV = p.SinhVienNavigation.HoTen,
                             HocKy = p.HocKy,
                             DiemGK = p.DiemGK,
                             DiemCK = p.DiemCK

                         })
                         .SingleOrDefaultAsync();
            if (lopHocPhan == null)
            {
                return NotFound();
            }

            return View(lopHocPhan);
        }

        // GET: LopHocPhan/Create
        public IActionResult Create()
        {
            ViewData["MaSV"] = new SelectList(_context.SinhViens, "MaSV", "HoTen");
            ViewData["MaMon"] = new SelectList(_context.MonHocs, "MaMon", "TenMon");
            return View();
        }

        // POST: LopHocPhan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLHP,NamHoc,HocKy,DiemGK,DiemCK,MaSV,Mon")] LopHocPhan lopHocPhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopHocPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaSV"] = new SelectList(_context.SinhViens, "MaSV", "HoTen");
            ViewData["MaMon"] = new SelectList(_context.MonHocs, "MaMon", "TenMon");
            return View(lopHocPhan);
        }

        // GET: LopHocPhan/Edit/5
        public async Task<IActionResult> Edit(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.LopHocPhans.SingleOrDefaultAsync(p => p.ID == ID);
            if (lopHocPhan == null)
            {
                return NotFound();
            }
            ViewData["MaSV"] = new SelectList(_context.SinhViens, "MaSV", "HoTen");
            ViewData["MaMon"] = new SelectList(_context.MonHocs, "MaMon", "TenMon");
            return View(lopHocPhan);
        }

        // POST: LopHocPhan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ID, [Bind("MaLHP,NamHoc,HocKy,DiemGK,DiemCK,MaSV,Mon")] LopHocPhan lopHocPhan)
        {
            if (ID != lopHocPhan.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopHocPhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopHocPhanExists(lopHocPhan.ID))
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
            ViewData["MaSV"] = new SelectList(_context.SinhViens, "MaSV", "HoTen");
            ViewData["MaMon"] = new SelectList(_context.MonHocs, "MaMon", "TenMon");
            return View(lopHocPhan);
        }

        // GET: LopHocPhan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.LopHocPhans
                .Include(l => l.SinhVienNavigation)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }

            return View(lopHocPhan);
        }

        // POST: LopHocPhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lopHocPhan = await _context.LopHocPhans.FindAsync(id);
            _context.LopHocPhans.Remove(lopHocPhan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopHocPhanExists(int id)
        {
            return _context.LopHocPhans.Any(e => e.MaLHP == id);
        }
    }
}
