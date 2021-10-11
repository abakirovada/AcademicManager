using MyHomework.Models;
using MyHomework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHomework.Controllers
{
    public class GradeController : Controller
    {
        // GET: Grade
        [Authorize]
        public ActionResult Index()
        {
            var service = new GradeService();
            var model = service.GetGrades();

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
        public ActionResult Create(GradeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGradeService();

            if (service.CreateGrade(model))
            {
                TempData["SaveResult"] = "A grade was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "A grade couldn't be created.");
            return View(model);
        }

        //get by id
        [Authorize]
        public ActionResult Details(int id)
        {
            var svc = CreateGradeService();
            var model = svc.GetGradeById(id);

            return View(model);
        }
        //get:Edit
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(int id)
        {
            var service = CreateGradeService();
            var detail = service.GetGradeById(id);
            var model = new GradeEdit
            {
                GradeId = detail.GradeId,
                Points = detail.Points
            };
            return View(model);
        }

        //post:Edit
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GradeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GradeId != id)
            {
                ModelState.AddModelError("", "Ids don't match");
                return View(model);
            }

            var service = CreateGradeService();
            if (service.UpdateGrade(model))
            {
                TempData["SaveResult"] = "The grade was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The grade update was not successful.");
            return View(model);
        }
        //get:delete
        [Authorize(Roles = "Teacher")]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGradeService();
            var model = svc.GetGradeById(id);

            return View(model);
        }

        //post/delete
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGrade(int id)
        {
            var service = CreateGradeService();

            service.DeleteGrade(id);

            TempData["SaveResult"] = "The grade was successfully deleted.";

            return RedirectToAction("Index");
        }

        private GradeService CreateGradeService()
        {
            //var userId = Int32.Parse(User.Identity.GetUserId());
            var service = new GradeService();
            return service;
        }
    }
}