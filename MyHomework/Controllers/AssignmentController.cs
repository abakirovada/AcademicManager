using MyHomework.Models;
using MyHomework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHomework.Controllers
{
    public class AssignmentController : Controller
    {
        private AssignmentService CreateAssignmentService()
        {
            var service = new AssignmentService();
            return service;
        }
        // GET: Assignment
        [Authorize]
        public ActionResult Index()
        {
            var service = new AssignmentService();
            var model = service.GetAssignments();

            return View(model);
        }

        //Get: Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //post: Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssignmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAssignmentService();

            if (service.CreateAssignment(model))
            {
                TempData["SaveResult"] = "An assignment was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "An assignment couldn't be created.");
            return View(model);
        }

        //get by id
        [Authorize]
        public ActionResult Details(int id)
        {
            var svc = CreateAssignmentService();
            var model = svc.GetAssignmentById(id);

            return View(model);
        }

        //get:Edit
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(int id)
        {
            var service = CreateAssignmentService();
            var detail = service.GetAssignmentById(id);
            var model = new AssignmentEdit
            {
                AssignmentId = detail.AssignmentId,
                Name = detail.Name,
                Deadline = detail.Deadline,
                IsAssigned = detail.IsAssigned,
                IsGraded=detail.IsGraded
            };
            return View(model);
        }

        //post:Edit
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssignmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AssignmentId != id)
            {
                ModelState.AddModelError("", "Ids don't match");
                return View(model);
            }

            var service = CreateAssignmentService();
            if (service.UpdateAssignment(model))
            {
                TempData["SaveResult"] = "The assignment was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The assignment update was not successful.");
            return View(model);
        }

        //get:delete
        [Authorize(Roles = "Teacher")]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAssignmentService();
            var model = svc.GetAssignmentById(id);

            return View(model);
        }

        //post/delete
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAssignment(int id)
        {
            var service = CreateAssignmentService();

            service.DeleteAssignment(id);

            TempData["SaveResult"] = "The assignment was successfully deleted from the system";

            return RedirectToAction("Index");
        }

    }
}