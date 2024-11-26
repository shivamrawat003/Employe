using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Employee.Models;

namespace Employee.Controllers
{
    public class StudentsController : Controller
    {
        private Contxt db = new Contxt();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student, string[] Subject, int[] Semester)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                int StudId = student.Id;
                List<Subject> SubList = new List<Subject>();
                for (int i = 0; i < Subject.Length; i++)
                {
                    Subject sub = new Subject
                    {
                        StudentId = StudId,
                        Sub_Name = Subject[i],
                        Sem = Semester[i]
                    };
                    SubList.Add(sub);
                }

                db.Subjects.AddRange(SubList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student, int[] SubId, string[] Subject, int[] Semester, string DelIds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();

                int StudId = student.Id;
                for (int i = 0; i < SubId.Length; i++)
                {
                    Subject sub = new Subject
                    {
                        Id = SubId[i],
                        Sub_Name = Subject[i],
                        Sem = Semester[i],
                        StudentId = StudId
                    };
                    if (SubId[i] == 0)
                    {
                        db.Subjects.Add(sub);
                    }
                    else
                    {
                        db.Entry(sub).State = EntityState.Modified;
                    }
                }
                db.SaveChanges();

                if (!string.IsNullOrEmpty(DelIds))
                    Procs.DeleteSubs(DelIds);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Procs.Delete_Student(id);
            //Student student = db.Students.Find(id);
            //db.Students.Remove(student);
            //db.SaveChanges();
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
