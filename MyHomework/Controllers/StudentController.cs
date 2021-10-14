using MyHomework.Models;
using MyHomework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHomework.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [Authorize]
        public ActionResult Index()
        {
            //var userId = Int32.Parse(User.Identity.GetUserId());
            var service = new StudentService();
            var model = service.GetStudents();

            return View(model);
        }
        private StudentService CreateStudentService()
        {
            //var userId = Int32.Parse(User.Identity.GetUserId());
            var service = new StudentService();
            return service;
        }
        //Get: Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //post:Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateStudentService();

            if (service.CreateStudent(model))
            {
                TempData["SaveResult"] = "A student was successfully added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "A student couldn't be added.");
            return View(model);
        }
        //get by id
        [Authorize]
        public ActionResult Details(int id)
        {
            var svc = CreateStudentService();
            var model = svc.GetStudentById(id);

            return View(model);
        }

        //get:update
        [Authorize]
        public ActionResult Edit(int id)
        {
            var service = CreateStudentService();
            var detail = service.GetStudentById(id);
            var model = new StudentEdit
            {
                StudentId = detail.StudentId,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                EnrollmentId=detail.EnrollmentId,
                AssignmentId=detail.AssignmentId,
                GradeId=detail.GradeId
            };
            return View(model);
        }

        //post:Edit
        [Authorize]
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.StudentId != id)
            {
                ModelState.AddModelError("", "Ids don't match");
                return View(model);
            }

            var service = CreateStudentService();
            if (service.UpdateStudent(model))
            {
                TempData["SaveResult"] = "The student was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The student update was not successful.");
            return View(model);
        }

        //get:delete
        [Authorize]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateStudentService();
            var model = svc.GetStudentById(id);

            return View(model);
        }

        //post/delete
        [Authorize]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStudent(int id)
        {
            var service = CreateStudentService();

            service.DeleteStudent(id);

            TempData["SaveResult"] = "The student was successfully deleted from the system";

            return RedirectToAction("Index");
        }
    }
}