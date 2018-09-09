using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExams.BLL;
using OnlineExams.DataContext;
using OnlineExams.Models;

namespace OnlineExamApp.Controllers
{
    public class TrainersController : Controller
    {
        private OnlineExamDbContext db = new OnlineExamDbContext();
        TrainerManager _trainerManger = new TrainerManager();
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
            //Trainer trainer = db.Trainers.Find(id);
            Trainer trainer = _trainerManger.GetById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name");
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                AddImages(trainer);
                _trainerManger.Add(trainer);
                //db.Trainers.Add(trainer);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Org_Name", trainer.OrganizationId);
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
        // GET: Trainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Trainer trainer = db.Trainers.Find(id);
            Trainer trainer = _trainerManger.GetById(id);
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
        public ActionResult Edit([Bind(Include = "Id,Name,ContactNo,Email,AddressLine1,AddressLine2,City,PostalCode,Country,Image,LeadTrainer,OrganizationId")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(trainer).State = EntityState.Modified;
                //db.SaveChanges();
                _trainerManger.Update(trainer);
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
            //Trainer trainer = db.Trainers.Find(id);
            Trainer trainer = _trainerManger.GetById(id);
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
            //Trainer trainer = db.Trainers.Find(id);
            //db.Trainers.Remove(trainer);
            //db.SaveChanges();
            Trainer trainer = _trainerManger.GetById(id);
            _trainerManger.Remove(trainer);
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
