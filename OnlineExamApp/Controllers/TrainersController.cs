using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using OnlineExams.DataContext;
using OnlineExams.Models;
using OnlineExams.Models.View_Model;

namespace OnlineExamApp.Controllers
{
    public class TrainersController : Controller
    {
        private OnlineExamDbContext db = new OnlineExamDbContext();

        // GET: Trainers
        public ActionResult Index()
        {
            var trainers = db.Trainers.Include(t => t.Organization);
            return View(trainers.ToList());
        }

        // GET: Trainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            //var model = new TrainerCreateVM();
            //model.OrganizationLookUps = db.Organizations.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Org_Name }).ToList();
            //model.CourseLookUps = db.Courses.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name");
            //var course = db.Trainers.Select(x => x.CourseTrainers.Select(c=>c.Course.Id));
            //var selectListItem = new SelectList(course, "Id", "Name", null);
            var defaultSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value="",Text="...Select..."}
            };
            ViewBag.CourseId =defaultSelectListItems;
            ViewBag.BatchId = defaultSelectListItems;
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*TrainerCreateVM*/ Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                //CourseTrainer courseTrainer = new CourseTrainer();


                //var entity = Mapper.Map<Trainer>(trainer);
                //db.Trainers.Add(entity);
                //db.SaveChanges();
                AddImages(trainer);
                db.Trainers.Add(trainer);
                bool IsSaved = db.SaveChanges() > 0;
                if (IsSaved)
                {
                    ViewBag.Message = "Trainer Saved Successfully";
                }
                else
                {
                    ViewBag.Message = "Trainer Saved Failed";
                }
                //return RedirectToAction("Index");
            }

           ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name", trainer.OrganizationId);
            //trainer.OrganizationLookUps = db.Organizations.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Org_Name }).ToList();
            //trainer.CourseLookUps = db.Courses.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
            var defaultSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value="",Text="...Select..."}
            };
            ViewBag.CourseId = defaultSelectListItems;
            ViewBag.BatchId = defaultSelectListItems;
            return View(trainer);
        }
        public void AddImages(Trainer trainer)
        {
            string fileName = Path.GetFileNameWithoutExtension(trainer.Logo.FileName);
            string extension = Path.GetExtension(trainer.Logo.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            trainer.ImagePath = "/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("/Images/"), fileName);
            trainer.Logo.SaveAs(fileName);
        }
        public JsonResult GetCourse(int organizationId)
        {
            var courses = db.Courses.Where(x => x.OrganizationId == organizationId);
            var jsonResult = courses.Select(c => new { c.Id, c.Name, c.CourseCode, c.CourseDuration, c.CourseOutLine, c.Credit, c.OrganizationId });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBatch(int courseId)
        {
            var batches = db.Batches.Where(c => c.CourseId == courseId);
            var jsonResult = batches.Select(c => new { c.Id, c.BatchNo, c.Description, c.StartDate, c.EndDate, c.ExamSchedules, c.CourseId });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        // GET: Trainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name", trainer.OrganizationId);
            return View(trainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ContactNo,Email,AddressLine1,AddressLine2,City,PostalCode,Country,LeadTrainer,OrganizationId,ImagePath")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name", trainer.OrganizationId);
            return View(trainer);
        }

        // GET: Trainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
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
