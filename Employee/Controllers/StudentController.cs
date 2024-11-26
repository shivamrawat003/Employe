using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Student()
        {
            return View();
        }
        public ActionResult StudentList()
        {
            return View();
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.Id = id;
            return View();
        }
        public ActionResult Delete(int? id)
        {
            ViewBag.Id = id;
            return View();
        }

       // [AuthFilter]
        public ActionResult DeleteConfirm(int? Id)
        {
            Procs.Delete_Student(Id);
            return RedirectToAction("StudentList");
        }

        public ActionResult Save(string Name, string Course, double? Fees, string[] Subject, int[] Semester)
        {
            int StudId = Procs.SaveStudent(0, Name, Course, Fees);
            if (StudId > 0)
            {
                for (int i = 0; i < Subject.Length; i++)
                {
                    Procs.SaveSubject(0, StudId, Subject[i], Semester[i]);
                }
            }
            return RedirectToAction("StudentList");
        }
        public ActionResult Update( int? Id,string Name, string Course, double? Fees, int[] SubId, string[] Subject,int[] Semester,string DelIds)
        {
            int StudId = Procs.SaveStudent(Id, Name, Course, Fees);
            if (StudId > 0)
            {
                for (int i = 0; i < Subject.Length; i++)
                {
                    Procs.SaveSubject(SubId[i], StudId, Subject[i], Semester[i]);
                }
            }
            if (!string.IsNullOrEmpty(DelIds))
                Procs.DeleteSubs(DelIds);
            return RedirectToAction("StudentList");
        }
    }
}