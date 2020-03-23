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
            var model = new State();
            model.StateAbbreviation = stateAbbr;
            model.StateName = "";
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditState(State state)
        {
            if(!ModelState.IsValid)
            {
                return View("EditState", state.StateAbbreviation);
            }
            try
            {
                StateRepository.Edit(state);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to edit record: {ex.Message}");
                return View("EditState", state.StateAbbreviation);
            }
            StateRepository.Edit(state);
            return RedirectToAction("States");
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