using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
            var model = new State();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddState(State state)
        {
            if (!ModelState.IsValid)
            {
                return View(state);
            }
            try
            {
                StateRepository.Add(state);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to create record: {ex.Message}");
                return View(state);
            }
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult EditState(string stateAbbr)
        {
            State model = new State();
            model.StateAbbreviation = stateAbbr;
            model.StateName = StateRepository.GetAll().FirstOrDefault(x => x.StateAbbreviation == stateAbbr).StateName;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditState(State state)
        {
            if(!ModelState.IsValid)
            {
                return View("EditState", state);
            }
            try
            {
                StateRepository.Edit(state);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to edit record: {ex.Message}");
                return View("EditState", state);
            }
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult DeleteState(string stateAbbr)
        {
            State model = new State();
            model.StateAbbreviation = stateAbbr;
            model.StateName = StateRepository.GetAll().FirstOrDefault(x => x.StateAbbreviation == stateAbbr).StateName;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteState(State state)
        {
            if (state.StateName != "")
            {
                if (!ModelState.IsValid)
                {
                    return View("DeleteState", state);
                }
                try
                {
                    StateRepository.Delete(state.StateAbbreviation);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $@"Unable to delete record: {ex.Message}");
                    return View("DeleteState", state);
                }
                StateRepository.Delete(state.StateAbbreviation);
            }
            return RedirectToAction("States");
        }
        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            var model = new Course();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            try
            {
                CourseRepository.Add(course.CourseName);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to create record: {ex.Message}");
                return View(course);
            }
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult EditCourse(int courseID)
        {
            Course model = new Course();
            model.CourseId = courseID;
            model.CourseName = CourseRepository.GetAll().FirstOrDefault(x => x.CourseId == courseID).CourseName;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return View("EditCourse", course);
            }
            try
            {
                CourseRepository.Edit(course);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to edit record: {ex.Message}");
                return View("EditCourse", course);
            }
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult DeleteCourse(int courseID)
        {
            Course model = new Course();
            model.CourseId = courseID;
            model.CourseName = CourseRepository.GetAll().FirstOrDefault(x => x.CourseId == courseID).CourseName;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCourse(Course course)
        {
            if (course.CourseName != "")
            {
                if (!ModelState.IsValid)
                {
                    return View("DeleteCourse", course);
                }
                try
                {
                    CourseRepository.Delete(course.CourseId);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $@"Unable to delete record: {ex.Message}");
                    return View("DeleteCourse", course);
                }
            }
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            MajorRepository.Add(major.MajorName);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            MajorRepository.Edit(major);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

    }
}