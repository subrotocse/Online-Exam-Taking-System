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
using OnlineExams.Models.View_Model;

namespace OnlineExamApp.Controllers
{
    public class CoursesController : Controller
    {
        private OnlineExamDbContext db = new OnlineExamDbContext();
        CourseTrainerManager courseTrainerManager = new CourseTrainerManager();
        // GET: Courses
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Organization);
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
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
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CourseCode,CourseDuration,Credit,CourseOutLine,OrganizationId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                bool IsSaved = db.SaveChanges() > 0;
                if (IsSaved)
                {
                    return RedirectToAction("Edit", new { @id = course.Id });
                }

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
            Course course = db.Courses.Find(id);
            //ViewBag.Name = course.Name;

            if (course == null)
            {
                return HttpNotFound();
            }
            //ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name", course.OrganizationId);
            var courseEdit = AutoMapper.Mapper.Map<CourseEditVM>(course);
            //courseEdit.Name = course.Name;
            courseEdit.OrganizationLookUps = db.Organizations.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Org_Name }).ToList();
            courseEdit.TrainerLookUps = db.Trainers.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
            courseEdit.CourseLookUps = db.Courses.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
            return View(courseEdit);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CourseCode,CourseDuration,Credit,CourseOutLine,OrganizationId")] CourseEditVM course)
        {

            if (ModelState.IsValid)
            {

                var entity = AutoMapper.Mapper.Map<Course>(course);
                //entity.Name = course.Name;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            //ViewBag.Name = course.Name;
            //ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name", course.OrganizationId);

            course.OrganizationLookUps = db.Organizations.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Org_Name }).ToList();
            course.TrainerLookUps = db.Trainers.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
            course.CourseLookUps = db.Courses.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
            return View(course);
        }
        public ActionResult CourseAssignToTrainer(List<CourseTrainerVM> Trainers)
        {
            var courseTrainers = AutoMapper.Mapper.Map<List<CourseTrainer>>(Trainers);
            bool IsSaved = courseTrainerManager.Add(courseTrainers);
            if (IsSaved)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
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
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
