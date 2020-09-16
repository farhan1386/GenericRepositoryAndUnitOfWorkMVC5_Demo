using CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Models;
using DependencyInjectionUnityContainerMVC5_Demo.Data;
using DependencyInjectionUnityContainerMVC5_Demo.Repositories;
using System.Net;
using System.Web.Mvc;

namespace GenericRepositoryAndUnitOfWorkMVC5_Demo.Controllers
{
    public class CoursesController : Controller
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());

        public ActionResult Index()
        {
            var courses = unitOfWork.CourseRepositroy.GetAll();
            return View(courses);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = unitOfWork.CourseRepositroy.Get(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CourseRepositroy.Add(course);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = unitOfWork.CourseRepositroy.Get(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CourseRepositroy.Update(course);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = unitOfWork.CourseRepositroy.Get(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = unitOfWork.CourseRepositroy.Get(id);
            unitOfWork.CourseRepositroy.Remove(course);
            unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}
