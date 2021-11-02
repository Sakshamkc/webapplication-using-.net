using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication51.Data;
using WebApplication51.Models;

namespace WebApplication51.Controllers
{
   [Authorize(Roles =WC.adminRole)]
    public class ApplicationlistController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationlistController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Applicationlist> obj = _db.Applicationlist;
            return View(obj);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Applicationlist obj)
        {
            if (ModelState.IsValid)
            {
                _db.Applicationlist.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Applicationlist.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Applicationlist obj)
        {
            if (ModelState.IsValid)
            {
                _db.Applicationlist.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Applicationlist.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Applicationlist.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Applicationlist.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
