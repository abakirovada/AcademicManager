using Microsoft.AspNet.Identity;
using MyHomework.Models;
using MyHomework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHomework.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        [Authorize]
        public ActionResult Index()
        {
            //var userId = Int32.Parse(User.Identity.GetUserId());
            var service = new TeacherService();
            var model = service.GetTeachers();

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
        public ActionResult Create(TeacherCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTeacherService();

            if (service.CreateTeacher(model))
            {
                TempData["SaveResult"] = "A teacher was created.";
            return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "A teacher couldn't be created.");
            return View(model);
        }

        //get by id
        [Authorize]
        public ActionResult Details(int id)
        {
            var svc = CreateTeacherService();
            var model = svc.GetTeacherById(id);

            return View(model);
        }
        //get:Edit
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(int id)
        {
            var service = CreateTeacherService();
            var detail = service.GetTeacherById(id);
            var model = new TeacherEdit
            {
                TeacherId = detail.TeacherId,
                FirstName = detail.FirstName,
                LastName=detail.LastName,
                Classes=detail.Classes
            };
            return View(model);
        }

        //post:Edit
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TeacherEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TeacherId != id)
            {
                ModelState.AddModelError("", "Ids don't match");
                return View(model);
            }

            var service = CreateTeacherService();
            if (service.UpdateTeacher(model))
            {
                TempData["SaveResult"] = "The teacher was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The teacher update was not successful.");
            return View(model);
        }
        //get:delete
        [Authorize(Roles = "Teacher")]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTeacherService();
            var model = svc.GetTeacherById(id);

            return View(model);
        }

        //post/delete
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTeacherService();

            service.DeleteTeacher(id);

            TempData["SaveResult"] = "The teacher was successfully deleted from the system";

            return RedirectToAction("Index");
        }

        private TeacherService CreateTeacherService()
        {
            //var userId = Int32.Parse(User.Identity.GetUserId());
            var service = new TeacherService();
            return service;
        }

    }
}