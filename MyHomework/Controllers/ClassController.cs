using MyHomework.Models;
using MyHomework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHomework.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateClassService();
            var model = service.GetClasses();

            return View(model);
        }

        //Get:Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //post:create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateClassService();

            if (service.CreateClass(model))
            {
                TempData["SaveResult"] = "A class was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "A Class couldn't be created.");
            return View(model);
        }

        //get by id
        [Authorize]
        public ActionResult Details(int id)
        {
            var svc = CreateClassService();
            var model = svc.GetClassById(id);

            return View(model);
        }

        private ClassService CreateClassService()
        {
            //var userId = Int32.Parse(User.Identity.GetUserId());
            var service = new ClassService();
            return service;
        }

        //get:Edit
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(int id)
        {
            var service = CreateClassService();
            var detail = service.GetClassById(id);
            var model = new ClassEdit
            {
                ClassId = detail.ClassId,
                Name = detail.Name,
                TeacherId = detail.TeacherId,
                Teacher = detail.Teacher,
                Assignments = detail.Assignments,
            };
            return View(model);
        }
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClassEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ClassId != id)
            {
                ModelState.AddModelError("", "Ids don't match");
                return View(model);
            }

            var service = CreateClassService();
            if (service.UpdateClass(model))
            {
                TempData["SaveResult"] = "The class was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The class update was not successful.");
            return View(model);
        }
        //get:delete
        [Authorize(Roles = "Teacher")]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateClassService();
            var model = svc.GetClassById(id);

            return View(model);
        }

        //post/delete
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClass(int id)
        {
            var service = CreateClassService();

            service.DeleteClass(id);

            TempData["SaveResult"] = "The teacher was successfully deleted from the system";

            return RedirectToAction("Index");
        }
    }
}