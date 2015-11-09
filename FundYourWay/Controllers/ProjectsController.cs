using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FundYourWay.DAL;
using FundYourWay.Models;
using System.Web.Security;
using WebMatrix.WebData;

namespace FundYourWay.Controllers
{
    public class ProjectsController : Controller
    {
        private FundYourWayContext db = new FundYourWayContext();

        // GET: Projects
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectId,ProjectName,ProjectDescription,CurrentFundingAmount")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                UserProfile projectHolder = db.UserProfiles.Find(WebSecurity.CurrentUserId);
                project.ProjectOwerId = WebSecurity.CurrentUserId;
                project.ProjectOwner = projectHolder;
                //project.FundingUsers.Add(projectHolder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectId,ProjectName,ProjectDescription,CurrentFundingAmount")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                var projectHolder = db.UserProfiles.Find(WebSecurity.CurrentUserId);
                project.ProjectOwerId = WebSecurity.CurrentUserId;
                project.ProjectOwner = projectHolder;
               // project.FundingUsers.Add(projectHolder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
        public ActionResult contribute (int? id)
        {
            ViewBag.ProjectId = id;
            return View();
        }
        [HttpPost, ActionName("contribute")]
        [ValidateAntiForgeryToken]
        public ActionResult contribute(int? projectId,int fundAmount)
        {
            if (projectId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(projectId);
            project.CurrentFundingAmount = project.CurrentFundingAmount + fundAmount;

            db.Transtions.Add(new Transaction
            {
                amount = fundAmount,
                FunderId = WebSecurity.CurrentUserId,
                Funder = db.UserProfiles.Find(WebSecurity.CurrentUserId),
                ProjectId = projectId,
                Project = project

            });
            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
