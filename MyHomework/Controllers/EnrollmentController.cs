using MyHomework.Models;
using MyHomework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHomework.Controllers
{
    public class EnrollmentController : Controller
    {
        // GET: Enrollment
        [Authorize]
        public ActionResult Index()
        {
            var service = new EnrollmentService();
            var model = service.GetEnrollments();

            return View(model);
        }

        //Get: Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        //post:create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnrollmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEnrollmentService();

            if (service.CreateEnrollment(model))
            {
                TempData["SaveResult"] = "An enrollment was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "An enrollment couldn't be created.");
            return View(model);
        }

        //get by id
        [Authorize]
        public ActionResult Details(int id)
        {
            var svc = CreateEnrollmentService();
            var model = svc.GetEnrollmentById(id);

            return View(model);
        }
        //get:Edit
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(int id)
        {
            var service = CreateEnrollmentService();
            var detail = service.GetEnrollmentById(id);
            var model = new EnrollmentEdit
            {
                EnrollmentId = detail.EnrollmentId,
                StudentId = detail.StudentId
            };
            return View(model);
        }

        //post:Edit
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EnrollmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EnrollmentId != id)
            {
                ModelState.AddModelError("", "Ids don't match");
                return View(model);
            }

            var service = CreateEnrollmentService();
            if (service.UpdateEnrollment(model))
            {
                TempData["SaveResult"] = "The enrollment was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The enrollment update was not successful.");
            return View(model);
        }
        //get:delete
        [Authorize(Roles = "Teacher")]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEnrollmentService();
            var model = svc.GetEnrollmentById(id);

            return View(model);
        }

        //post/delete
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEnrollment(int id)
        {
            var service = CreateEnrollmentService();

            service.DeleteEnrollment(id);

            TempData["SaveResult"] = "The enrollment was successfully deleted from the system";

            return RedirectToAction("Index");
        }

        private EnrollmentService CreateEnrollmentService()
        {
            //var userId = Int32.Parse(User.Identity.GetUserId());
            var service = new EnrollmentService();
            return service;
        }
    }
}