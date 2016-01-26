using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Toman296Lab2.Models;

namespace Toman296Lab2.Controllers
{
    public class ForumViewController : Controller
    {
        private Toman296Lab2Context db = new Toman296Lab2Context();

        // GET: ForumView
        public ActionResult Index() // I'm currently experimenting with this default method to ensure that 
            // *all* components of the ForumView appear here. Still to do: Add Member for each message, fix
            // ForumView view so that it appears a lot more "forum-like."
        {
            var fview = db.ForumViews.ToList()[0];
            fview.Messages = db.Message.ToList();
            
            //return View(db.ForumViews.ToList());
            return View(fview);
        }

        // GET: ForumView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumView forumView = db.ForumViews.Find(id);
            if (forumView == null)
            {
                return HttpNotFound();
            }
            return View(forumView);
        }

        // GET: ForumView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForumView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ForumID,ForumName,LastModified")] ForumView forumView)
        {
            if (ModelState.IsValid)
            {
                db.ForumViews.Add(forumView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(forumView);
        }

        // GET: ForumView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumView forumView = db.ForumViews.Find(id);
            if (forumView == null)
            {
                return HttpNotFound();
            }
            return View(forumView);
        }

        // POST: ForumView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ForumID,ForumName,LastModified")] ForumView forumView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forumView);
        }

        // GET: ForumView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumView forumView = db.ForumViews.Find(id);
            if (forumView == null)
            {
                return HttpNotFound();
            }
            return View(forumView);
        }

        // POST: ForumView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForumView forumView = db.ForumViews.Find(id);
            db.ForumViews.Remove(forumView);
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
