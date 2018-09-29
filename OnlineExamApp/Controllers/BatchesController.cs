using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExams.DataContext;
using OnlineExams.Models;

namespace OnlineExamApp.Controllers
{
    public class BatchesController : Controller
    {
        private OnlineExamDbContext db = new OnlineExamDbContext();

        // GET: Batches
        public ActionResult Index()
        {
            var batches = db.Batches.Include(b => b.Course);
            return View(batches.ToList());
        }

        // GET: Batches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // GET: Batches/Create
        public ActionResult Create()
        {
<<<<<<< HEAD
            //ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            var defaultSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value="",Text="...Select..."}
            };
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name");
            ViewBag.CourseId = defaultSelectListItems;
=======
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
>>>>>>> bec26b27843d4effc520e9a64f21d64bda4cf0ee
            return View();
        }

        // POST: Batches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BatchNo,Description,StartDate,EndDate,CourseId")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                db.Batches.Add(batch);
<<<<<<< HEAD
                bool IsSaved = db.SaveChanges() > 0;
                if (IsSaved)
                {
                    return RedirectToAction("Edit", new { @id = batch.Id });
                }
            }

            //ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", batch.CourseId);
            var defaultSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value="",Text="...Select..."}
            };
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name");
            ViewBag.CourseId = defaultSelectListItems;
=======
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", batch.CourseId);
>>>>>>> bec26b27843d4effc520e9a64f21d64bda4cf0ee
            return View(batch);
        }

        // GET: Batches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", batch.CourseId);
            return View(batch);
        }

        // POST: Batches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BatchNo,Description,StartDate,EndDate,CourseId")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", batch.CourseId);
            return View(batch);
        }

        // GET: Batches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // POST: Batches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Batch batch = db.Batches.Find(id);
            db.Batches.Remove(batch);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
