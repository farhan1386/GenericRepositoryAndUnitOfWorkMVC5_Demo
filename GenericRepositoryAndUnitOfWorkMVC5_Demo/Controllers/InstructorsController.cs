using CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Models;
using DependencyInjectionUnityContainerMVC5_Demo.Data;
using DependencyInjectionUnityContainerMVC5_Demo.Repositories;
using System.Net;
using System.Web.Mvc;

namespace GenericRepositoryAndUnitOfWorkMVC5_Demo.Controllers
{
    public class InstructorsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());

        public ActionResult Index()
        {
            var intrucotrs = unitOfWork.InstructorRepository.GetAll();
            return View(intrucotrs);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = unitOfWork.InstructorRepository.GetById(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.InstructorRepository.Add(instructor);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(instructor);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = unitOfWork.InstructorRepository.GetById(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                Instructor edit = unitOfWork.InstructorRepository.GetById(instructor.Id);
                edit.InstructorName = instructor.InstructorName;
                edit.Qualification = instructor.Qualification;
                edit.Experience = instructor.Experience;
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = unitOfWork.InstructorRepository.GetById(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instructor instructor = unitOfWork.InstructorRepository.GetById(id);
            unitOfWork.InstructorRepository.Remove(instructor);
            unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}
