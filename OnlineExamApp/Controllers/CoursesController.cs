using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExams.BLL;
using OnlineExams.DataContext;
using OnlineExams.Models;

namespace OnlineExamApp.Controllers
{
    public class CoursesController : Controller
    {
        private OnlineExamDbContext db = new OnlineExamDbContext();
        CourseManager _courseManager = new CourseManager();
        // GET: Courses
        public ActionResult Index()
        {
            //var courses = db.Courses.Include(c => c.Organization);
            var courses = _courseManager.GetAll();
            return View(courses);
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = _courseManager.GetById(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CourseCode,CourseDuration,Credit,CourseOutLine,OrganizationId")] Course course)
        {
            if (ModelState.IsValid)
            {
                //db.Courses.Add(course);
                //db.SaveChanges();
                _courseManager.Add(course);
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name", course.OrganizationId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             Course course = _courseManager.GetById(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name", course.OrganizationId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CourseCode,CourseDuration,Credit,CourseOutLine,OrganizationId")] Course course)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(course).State = EntityState.Modified;
                //db.SaveChanges();
                _courseManager.Update(course);
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name", course.OrganizationId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = _courseManager.GetById(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Course course = db.Courses.Find(id);
            //db.Courses.Remove(course);
            //db.SaveChanges();
            Course course = _courseManager.GetById(id);
            _courseManager.Remove(course);
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
