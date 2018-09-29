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
    public class OrganizationsController : Controller
    {
        private OnlineExamDbContext db = new OnlineExamDbContext();
        OrganizationManager _organizationManager = new OrganizationManager();

        // GET: Organizations
        public ActionResult Index()
        {
            return View(db.Organizations.ToList());
        }

        // GET: Organizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Organization organization)
        {
            if (ModelState.IsValid)
            {
                AddImages(organization);
                db.Organizations.Add(organization);
                db.SaveChanges();
                return RedirectToAction("SearchOrganization");
            }

            return View(organization);
        }
        public void AddImages(Organization organization)
        {
            string fileName = Path.GetFileNameWithoutExtension(organization.Logo.FileName);
            string extension = Path.GetExtension(organization.Logo.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            organization.ImagePath = "/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("/Images/"), fileName);
            organization.Logo.SaveAs(fileName);
        }
        public ActionResult SearchOrganization()
        {
            var organizations = _organizationManager.GetAll();
            return View(organizations);
        }
        [HttpPost]
        public ActionResult SearchOrganization(string org_name, string address, string org_code, string contactNo)
        {
            var organizations = from m in _organizationManager.GetAll()
                                select m;
            if (!String.IsNullOrEmpty(org_name))
            {
                organizations = organizations.Where(s => s.Org_Name.Contains(org_name)
                                                    ||s.Org_Name.ToLower().Contains(org_name)
                );
            }
            if (!String.IsNullOrEmpty(address))
            {
                organizations = organizations.Where(s => s.Address.Contains(address)
                                        || s.Address.ToLower().Contains(address)
                );
            }
            if (!String.IsNullOrEmpty(org_code))
            {
                organizations = organizations.Where(s => s.Org_Code.Contains(org_code)
                 || s.Org_Code.ToLower().Contains(org_code)
                );
            }
            if (!String.IsNullOrEmpty(contactNo))
            {
                organizations = organizations.Where(s => s.ContactNo.Contains(contactNo)
                 || s.ContactNo.ToLower().Contains(contactNo)
                );
            }
            return View(organizations);
        }
        //public JsonResult GetOrganizationCode(string org_code)
        ////{
        //    var orgCode = db.Organizations.Select(c => c.Org_Code);
        //    return Json(orgCode, JsonRequestBehavior.AllowGet);
        //}
        // GET: Organizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Org_Name,Org_Code,Address,ContactNo,About,ImagePath")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        // GET: Organizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = db.Organizations.Find(id);
            db.Organizations.Remove(organization);
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
