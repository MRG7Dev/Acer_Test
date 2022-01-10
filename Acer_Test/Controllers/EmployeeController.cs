using Acer_Test.Models;
using Acer_Test.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Acer_Test.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Employee_List( )
        {

            string a="all";
            EmployeeRepository empRepo = new EmployeeRepository();
            var EmpList = empRepo.Emp_getlist(a).ToList();
            return View(EmpList);
        }

        // GET: Employee/Create
        public ActionResult Emp_Register()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "KARNATAKA", Value = "KARNATAKA" });
            li.Add(new SelectListItem { Text = "ANDRA PRADESH", Value = "ANDRA PRADESH" });
            ViewData["country"] = li;
            ViewBag.CITYLIST= new List<SelectListItem> { };
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Emp_Register(Employee emp)
        {

            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "KARNATAKA", Value = "KARNATAKA" });
            li.Add(new SelectListItem { Text = "ANDRA PRADESH", Value = "ANDRA PRADESH" });
            ViewData["country"] = li;
            ViewBag.CITYLIST = new List<SelectListItem> { };

            try
            {

                EmployeeRepository empRepo = new EmployeeRepository();

               var val= empRepo.Emp_Insert(emp);

                if(val == 1)
                {

                    TempData["Message"] = "User added successfully";
                    TempData["Messageclass"] = "alert-success";

                    return RedirectToAction("Employee_List");
                }
                else if (val == 0)
                {
                    TempData["Message"] = "Error occured while saving. Please try again with valid details";
                    TempData["Messageclass"] = "alert-danger";
                    return View();
                }
                else if (val == 2)
                {
                    TempData["Message"] = "Employee Id Already exists, kindly use NEW ONE!";
                    TempData["Messageclass"] = "alert-danger";
                    return View();
                }




            }
            catch(Exception e)
            {
                TempData["Message"] = "Error occured while saving. Please try again with valid details";
                TempData["Messageclass"] = "alert-danger";
                return View();
            }

            return View();
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string id)
        {
            EmployeeRepository empRepo = new EmployeeRepository();

            var empd = empRepo.Emp_getlist(id).SingleOrDefault();

            return View(empd);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            try
            {

                EmployeeRepository empRepo = new EmployeeRepository();

                var val = empRepo.Emp_update(emp);

                if (val == 1)
                {

                    TempData["Message"] = "User updated successfully";
                    TempData["Messageclass"] = "alert-success";

                    return RedirectToAction("Employee_List");
                }
                else if (val == 0)
                {
                    TempData["Message"] = "Error occured while updating. Please try again with valid details";
                    TempData["Messageclass"] = "alert-danger";
                    return View();
                }
                else if (val == 2)
                {
                    TempData["Message"] = "kindly check Employee id is wrong. Please try again with valid details";
                    TempData["Messageclass"] = "alert-danger";
                    return View();
                }




            }
            catch (Exception e)
            {
                TempData["Message"] = "Error occured while updating. Please try again with valid details";
                TempData["Messageclass"] = "alert-danger";
                return View();
            }

            return View();
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(string id)
        {

            EmployeeRepository empRepo = new EmployeeRepository();

            var empd = empRepo.Emp_getlist(id).SingleOrDefault();

            return PartialView(empd);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(Employee emp)
        {
            try
            {

                // TODO: Add delete logic here

                EmployeeRepository empRepo = new EmployeeRepository();

                var val = empRepo.Emp_Delete(emp);

                if (val == 1)
                {

                    TempData["Message"] = "User deleted successfully";
                    TempData["Messageclass"] = "alert-success";

                    return RedirectToAction("Employee_List");
                }
                else if (val == 0)
                {
                    TempData["Message"] = "Error occured while deleting. Please try again with valid details";
                    TempData["Messageclass"] = "alert-danger";
                    return RedirectToAction("Employee_List");
                }

                return RedirectToAction("Employee_List");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult City_Bind(string state)
        {
            EmployeeRepository empRepo = new EmployeeRepository();

            try
            {
                List<City> CityList = empRepo.Get_City(state).ToList();
                return Json(CityList, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {

                List<City> CityList1 = new List<City>().ToList();
                return Json(CityList1, JsonRequestBehavior.AllowGet);
            }

          
        }
    }
}
