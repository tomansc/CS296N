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
        public ActionResult Index() 
        {
            var fview = db.ForumViews.ToList()[0]; //Replace with LINQ query to fetch all the forumviews. Cheater method for now until I implement multiple fora!
            fview.Messages = db.Messages.ToList();
            return View(fview);
        }

        // GET: ForumView/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Message = "Message details";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ForumView forumView = db.ForumViews.Find(id);
            Message msg = (from m in db.Messages
						   where m.MessageID == id 
						   select m).FirstOrDefault();
            MessageView selectedMsg = new MessageView();
            selectedMsg.MessageID = msg.MessageID;
            selectedMsg.Body = msg.Body;
            selectedMsg.Date = msg.Date;
            selectedMsg.Subject = msg.Subject;
            selectedMsg.Topics.Add(msg.Topic);
            selectedMsg.PostingMember = (from n in db.Members
                                         where n.MemberID == msg.MemberID
                                         select n).FirstOrDefault();
            if (selectedMsg == null)
            {
                return HttpNotFound();
            }
            return View(selectedMsg);
        }

        // GET: ForumView/Create
        public ActionResult Create() // Displays the form in which a new message's details are entered.
        {
            //ViewBag.ForumList = new SelectList(db.ForumViews.OrderBy(f => f.ForumID), "ForumID", "ForumName");
            ForumView testForum = new ForumView();
            Message testMessage = new Message();
            ViewBag.ForumList = new SelectList(db.ForumViews.OrderBy(f => f.ForumID), "ForumID", "ForumName"); // Thanks Toni! I suspect that, with validation, having this line up there causes the validation to be wiped out and resets the ModelState as a new ForumView is created.
            testForum.Messages.Add(testMessage);
            return View(testForum);
        }

        // POST: ForumView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ForumID,ForumName,MessageID,Body,Subject,PostingMember,Messages,ForumList")] ForumView forumView, int ForumList)
        {
            Message m = forumView.Messages[0];
            forumView.LastModified = DateTime.Now;
            m.Date = DateTime.Now;
            m.Subject = m.Subject;
            m.Topic = m.Topic;
            m.Body = m.Body;

            ForumView fv = (from f in db.ForumViews 
                           where f.ForumID == ForumList 
                           select f).FirstOrDefault(); 
            if (fv == null)
            {
                fv = new ForumView() { ForumName = forumView.ForumName };
                db.ForumViews.Add(fv);
            }

            if (ModelState.IsValid)
            {
                forumView.Messages.Add(m);
                db.ForumViews.Add(forumView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ForumList = new SelectList(db.ForumViews.OrderBy(f => f.ForumID), "ForumID", "ForumName");
                return View("Create", forumView);
            }

        }

        // GET: ForumView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message msg = db.Messages.Find(id);
            if (msg == null)
            {
                return HttpNotFound();
            }
            return View(msg);
        }

        // POST: ForumView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ForumID,ForumName,MessageID,Body,Subject,PostingMember,Messages,ForumList,Date")] Message msg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(msg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(msg);
        }

        // GET: ForumView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message m = db.Messages.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            return View(m);
        }

        // POST: ForumView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message msg = db.Messages.Find(id);
            db.Messages.Remove(msg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            return View();
        }

        //POST method
        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            var msgs = (from m in db.Messages     
                                where m.Subject.Contains(searchTerm)
                                select m).ToList();


            // If just one message, display it
            if (msgs.Count == 1)
            {
                int mid = msgs[0].MemberID;
                var member = (from n in db.Members where n.MemberID == mid select n).FirstOrDefault();
                MessageView selectedMsg = new MessageView();
                selectedMsg.MessageID = msgs[0].MessageID;
                selectedMsg.Body = msgs[0].Body;
                selectedMsg.Date = msgs[0].Date;
                selectedMsg.Subject = msgs[0].Subject;
                selectedMsg.Topics.Add(msgs[0].Topic);
                selectedMsg.PostingMember = member;
                return View("Details", selectedMsg); // We're sending it to the view, not the controller method (view takes a whole msg; controller method takes an int.)
            }
            // else, if more than one, display list. 
            else if (msgs.Count > 1)
            {
                ForumView resultView = new ForumView();
                foreach (Message m in msgs)
                {
                    resultView.Messages.Add(m);
                } 
                return View("Index", resultView);
            }
            else
                return RedirectToAction("Index"); // Aha. I just needed to change this from View to RedirectToAction since returning the view bypasses the necessary stuff in the controller method, causing the model to be null.
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
