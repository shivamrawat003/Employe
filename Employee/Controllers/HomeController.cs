using Employee.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Employee()
        {
            return View();
        }
        public ActionResult Save(string FName, string LName, string Email, string ContactNum, int? Salary, int? Department, string Address, int? State, int? Country, string Password)
        {
            Procs.SaveEmployeeData(FName, LName, Email, ContactNum, Salary, Department, Address, State, Country, Password);
            return RedirectToAction("Employee");
        }
        public ActionResult Update(int Id,string FName, string LName, string Email, string Phonenum, int? Salary, int? Department, string Address, int? State, int? Country, string Password)
        {
            {
                Procs.UpdateEmployeeData(Id,FName, LName, Email, Phonenum, Salary, Department, Address, State, Country, Password);
                return RedirectToAction("Employee");
            }
        }
        public ActionResult DeleteConfirm(int? Id)
        {
            Procs.Delete_Employee(Id);
            return RedirectToAction("Employee");

        }
        public ActionResult Details(int? id)
        {
            ViewBag.Id = id;
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
        public PartialViewResult EmpSearch(int? Rows, int? Offset, string SearchVal)
        {
            ViewBag.Rows = Rows;
            ViewBag.Offset = Offset;
            ViewBag.Sv = SearchVal;
            return PartialView();
        }
        public string GetState(int? Id)
        {
            string data = JsonConvert.SerializeObject(Procs.State_Select(Id));
            return data;
        }
        //string GenerateRandomString(int length)
        //{
        //    var random = new Random();
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        //    return new string(Enumerable.Repeat(chars, length)
        //                                .Select(s => s[random.Next(s.Length)]).ToArray());
        //}

        //public int GenerateRandomInt()
        //{
        //    Random random = new Random();

        //    // Generate random numbers
        //    int randomInt = random.Next();  // Generates a random integer (positive)
        //    int randomIntInRange = random.Next(1, 101);
        //    return randomIntInRange;
        //}

        ////static DateTime GenerateRandomDate(Random random, DateTime startDate, DateTime endDate)
        ////{
        ////    int range = (endDate - startDate).Days;
        ////    return startDate.AddDays(random.Next(range));
        ////}
        //public string SaveMulti()
        //{

        //    for (int i = 0; i < 50000; i++)
        //    {
        //        Procs.insertemployee(GenerateRandomString(9), GenerateRandomString(9), GenerateRandomString(9), GenerateRandomString(9), GenerateRandomInt(),2, GenerateRandomString(9),1,2, GenerateRandomString(9));
        //    }
        //    return "1";
        //}
        public string AutoSuggest(string data)
        {
            return JsonConvert.SerializeObject(Procs.AutoSuggest(data));
        }
    }
}