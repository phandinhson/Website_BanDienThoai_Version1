using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website_BanDienThoai_Version1.Data;
using Website_BanDienThoai_Version1.Models;

namespace Website_BanDienThoai_Version1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SpecialTagController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            return View(_db.SpecialTag.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTag special)
        {
            if (ModelState.IsValid)
            {
                _db.Add(special);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(special);
        }
        // Get Edit Action Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _db.SpecialTag.FindAsync(id);
            //var product =_db.SpecialTag.FromSql("EXECUTE DBO.Sellect_SpecialTag_Id {0}", id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //POST Edit action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpecialTag special)
        {
            if (id != special.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
               
                _db.Update(special);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(special);
        }
        // Get Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _db.SpecialTag.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //POST Details action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, SpecialTag special)
        {
            if (id != special.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
               
                _db.Update(special);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return View(special);
        }

        // Get Delete Action Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _db.SpecialTag.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var special = await _db.SpecialTag.FindAsync(id);
            _db.SpecialTag.Remove(special);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}