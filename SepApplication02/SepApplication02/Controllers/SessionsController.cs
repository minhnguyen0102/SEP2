using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SepApplication02.Models;

namespace SepApplication02.Controllers
{
    public class SessionsController : Controller
    {
        private sepoopcsEntities db = new sepoopcsEntities();

        // GET: /Sessions/
        public ActionResult Index(int courseId)
        {
            //ViewBag.DB = db;
            ViewBag.CourseId = courseId;
            var sessions = db.Sessions.Where(s => s.Course_id == courseId);
            return View(sessions.ToList());
        }

        // GET: /Sessions/Details/5
        public ActionResult Details(int courseId, int sessionId)
        {
            return RedirectToAction("Index", "Attendance", new { courseId = courseId});
            
        }

        // GET: /Sessions/Create
        public ActionResult Create(int courseId)
        {

            ViewBag.Course_id = courseId;
            return View();
        }

        // POST: /Sessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int courseId, Session session)
        {
            session.Course_id = courseId;
            if (ModelState.IsValid)
            {
                db.Sessions.Add(session);
                db.SaveChanges();
                return RedirectToAction("Index", new { courseId = courseId});

            }

            ViewBag.Course_id = courseId;
            return View(session);
        }

        // GET: /Sessions/Edit/5
        public ActionResult Edit(int? courseId, int id)
        {
            ViewBag.CourseId = courseId;
            var session = db.Sessions.SingleOrDefault(s => s.id == id);
            return View(session);
           
        }

        // POST: /Sessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Session session)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(session).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new {courseId = session.Course_id });
            }
            return View(session);
        }

        // GET: /Sessions/Delete/5
        public ActionResult Delete(int? courseId, int id)
        {
            ViewBag.CourseId = courseId;
            var session = db.Sessions.SingleOrDefault(s => s.id == id);
            return View(session);
        }

        // POST: /Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int courseId, int id)
        {
            ViewBag.CourseId = courseId;
            Session session = db.Sessions.SingleOrDefault(s => s.id == id);
            db.Sessions.Remove(session);
            db.SaveChanges();
            return RedirectToAction("Index", new { courseId = courseId});
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
