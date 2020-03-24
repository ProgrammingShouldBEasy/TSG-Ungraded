using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int studentId)
        {
            StudentVM student = new StudentVM();
            //List<Course> courses = CourseRepository.GetAll().ToList();
            //foreach (Course x in courses)
            //{
            //    student.Student.Courses.Add(x);
            //}
            student.Student = StudentRepository.Get(studentId);
            student.Student.StudentId = studentId;
            student.SetCourseItems(CourseRepository.GetAll());
            student.SetMajorItems(MajorRepository.GetAll());
            student.SetStateItems(StateRepository.GetAll());
            List<Course> studentCourseList = StudentRepository.GetAll().ToList().FirstOrDefault(x => x.StudentId == studentId).Courses.ToList();
            List<int> CourseIDs = new List<int>();
            foreach(Course z in studentCourseList)
            {
                CourseIDs.Add(z.CourseId);
            }
            student.SelectedCourseIds = CourseIDs;
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(StudentVM editStudent)
        {
            editStudent.SetCourseItems(CourseRepository.GetAll());
            editStudent.SetMajorItems(MajorRepository.GetAll());
            editStudent.SetStateItems(StateRepository.GetAll());
            editStudent.Student.Courses = new List<Course>();
            foreach(Course x in CourseRepository.GetAll().ToList())
            {
                if(editStudent.SelectedCourseIds.Contains(x.CourseId))
                {
                    editStudent.Student.Courses.Add(x);
                }
            }
            editStudent.Student.Address.State.StateName = StateRepository.GetAll().FirstOrDefault(x => x.StateAbbreviation == editStudent.Student.Address.State.StateAbbreviation).StateName;
            editStudent.Student.Major = MajorRepository.GetAll().FirstOrDefault(x => x.MajorId == editStudent.Student.Major.MajorId);
            StudentRepository.SaveAddress(editStudent.Student.StudentId, editStudent.Student.Address);
            ModelState.Remove("State");
            if (!ModelState.IsValid)
            {
                return View("Edit", editStudent);
            }
            try
            {
                StudentRepository.Edit(editStudent.Student);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to edit record: {ex.Message}");
                return View("Edit", editStudent);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete (int studentId)
        {
            var student = StudentRepository.Get(studentId);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            try
            {
                StudentRepository.Delete(student.StudentId);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to delete record: {ex.Message}");
                return View("Delete", student);
            }
            return RedirectToAction("Index");
        }
    }
}