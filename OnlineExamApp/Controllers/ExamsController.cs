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
    public class ExamsController : Controller
    {
        private OnlineExamDbContext db = new OnlineExamDbContext();
        ExamManager _examManager = new ExamManager();
        // GET: Exams
        public ActionResult Index()
        {
            var exams = db.Exams.Include(e => e.Course).Include(e => e.Organization);
            return View(exams.ToList());
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Exam exam = db.Exams.Find(id);
           Exam exam= _examManager.GetById(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ExamType,ExamCode,Topic,FullMarks,Duration,CourseId,OrganizationId")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                //db.Exams.Add(exam);
                //db.SaveChanges();
                _examManager.Add(exam);
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", exam.CourseId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name", exam.OrganizationId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Exam exam = db.Exams.Find(id);
            Exam exam = _examManager.GetById(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", exam.CourseId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name", exam.OrganizationId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExamType,ExamCode,Topic,FullMarks,Duration,CourseId,OrganizationId")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(exam).State = EntityState.Modified;
                //db.SaveChanges();
                _examManager.Update(exam);
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", exam.CourseId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name", exam.OrganizationId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Exam exam = db.Exams.Find(id);
            Exam exam = _examManager.GetById(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Exam exam = db.Exams.Find(id);
            //db.Exams.Remove(exam);
            //db.SaveChanges();
            Exam exam = _examManager.GetById(id);
            _examManager.Remove(exam);
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
