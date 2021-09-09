using Microsoft.AspNetCore.Mvc;
using ParkingSpacesApp.Data;
using ParkingSpacesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSpacesApp.Controllers
{
    public class ParkingSpacesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ParkingSpacesController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<ParkingSpaces> objList = _db.ParkingSpaces;
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
        public IActionResult Create(ParkingSpaces obj)
        {
            if (ModelState.IsValid)
            {
                _db.ParkingSpaces.Add(obj);
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
            var obj = _db.ParkingSpaces.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ParkingSpaces obj)
        {
            if (ModelState.IsValid)
            {
                _db.ParkingSpaces.Update(obj);
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
            var obj = _db.ParkingSpaces.Find(id);
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
            var obj = _db.ParkingSpaces.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ParkingSpaces.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
