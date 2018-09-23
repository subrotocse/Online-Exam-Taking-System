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
    public class CourseTrainersController : Controller
    {
        private OnlineExamDbContext db = new OnlineExamDbContext();

        // GET: CourseTrainers
        public ActionResult Index()
        {
            var courseTrainers = db.CourseTrainers.Include(c => c.Course).Include(c => c.Trainer);
            return View(courseTrainers.ToList());
        }

        // GET: CourseTrainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTrainer courseTrainer = db.CourseTrainers.Find(id);
            if (courseTrainer == null)
            {
                return HttpNotFound();
            }
            return View(courseTrainer);
        }

        // GET: CourseTrainers/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "Name");
            return View();
        }

        // POST: CourseTrainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,TrainerId")] CourseTrainer courseTrainer)
        {
            if (ModelState.IsValid)
            {
                db.CourseTrainers.Add(courseTrainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", courseTrainer.CourseId);
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "Name", courseTrainer.TrainerId);
            return View(courseTrainer);
        }

        // GET: CourseTrainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTrainer courseTrainer = db.CourseTrainers.Find(id);
            if (courseTrainer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", courseTrainer.CourseId);
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "Name", courseTrainer.TrainerId);
            return View(courseTrainer);
        }

        // POST: CourseTrainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,TrainerId")] CourseTrainer courseTrainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseTrainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", courseTrainer.CourseId);
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "Name", courseTrainer.TrainerId);
            return View(courseTrainer);
        }

        // GET: CourseTrainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTrainer courseTrainer = db.CourseTrainers.Find(id);
            if (courseTrainer == null)
            {
                return HttpNotFound();
            }
            return View(courseTrainer);
        }

        // POST: CourseTrainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseTrainer courseTrainer = db.CourseTrainers.Find(id);
            db.CourseTrainers.Remove(courseTrainer);
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
