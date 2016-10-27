using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using Microsoft.AspNet.Identity;

namespace P3Ef.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private ModelsDA db = new ModelsDA();

        // GET: Projects
        public ActionResult Index()
        {
            return View(db.ListProjects(User.Identity.GetUserId()));
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            project.Lang = db.Languages.Find(project.LangId);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            ViewBag.langs = new SelectList(db.Languages, "Id", "Name");

            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LangId")] Project project)
        {
            project.Lang = db.Languages.Find(project.LangId);
            project.UId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
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
            ViewBag.langs = new SelectList(db.Languages, "Id", "Name");
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            TempData["poname"] = project.Name;
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UId,Name,LangId")] Project project)
        {
            project.Lang = db.Languages.Find(project.LangId);
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                List<Source> tsrc = db.ListSources(TempData["poname"].ToString());
                foreach(Source s in tsrc)
                {
                    s.PName = project.Name;
                }
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
            List<Source> srcs = db.ListSources(project.Name);
            foreach(Source src in srcs)
            {
                db.Sources.Remove(src);
            }
            srcs.Clear();
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
    }
}
