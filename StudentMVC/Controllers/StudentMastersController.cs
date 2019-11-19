using StudentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace StudentMVC.Controllers
{
    public class StudentMastersController : Controller
    {
        // GET: StudentMasters
        public ActionResult Index()
        {
            IEnumerable<StudentVM> stList;
            HttpResponseMessage response = APIContent.WebApiClient.GetAsync("StudentMasters").Result;
            stList = response.Content.ReadAsAsync<IEnumerable<StudentVM>>().Result;
            return View(stList);
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new StudentVM());
            else
            {
                HttpResponseMessage response = APIContent.WebApiClient.GetAsync("StudentMasters/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<StudentVM>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(StudentVM studentVM)
        {
            if (studentVM.ID == 0)
            {
                HttpResponseMessage response = APIContent.WebApiClient.PostAsJsonAsync("StudentMasters", studentVM).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = APIContent.WebApiClient.PutAsJsonAsync("StudentMasters/" + studentVM.ID, studentVM).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = APIContent.WebApiClient.DeleteAsync("StudentMasters/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}