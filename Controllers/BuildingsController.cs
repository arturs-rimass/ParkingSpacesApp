using Microsoft.AspNetCore.Mvc;
using ParkingSpacesApp.Data;
using ParkingSpacesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSpacesApp.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BuildingsController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Buildings> objList = _db.Buildings;
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Buildings obj)
        {
            if (ModelState.IsValid)
            {
                _db.Buildings.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Buildings.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Buildings obj)
        {
            if (ModelState.IsValid)
            {
                _db.Buildings.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Buildings.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Buildings.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Buildings.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
