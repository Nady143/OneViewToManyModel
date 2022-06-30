using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneViewToManyModel.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace OneViewToManyModel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Welcome index";
            dynamic mymodel = new ExpandoObject();
            mymodel.Teachers = GetTeachers();
            mymodel.Students = GetStudents();
            return View(mymodel);
        }

        public IActionResult IndexViewModel()
        {
            ViewBag.Message = "Welcome index";
            ViewModel mymodel = new ViewModel();
            mymodel.Teachers = GetTeachers();
            mymodel.Students = GetStudents();
            return View(mymodel);
        }
        public IActionResult IndexViewData()
        {
            ViewBag.Message = "Welcome index";
            ViewData["mymodel"] = GetTeachers();
            ViewData["mymodel"] = GetStudents();
            return View();
        }
        public IActionResult IndexViewBag()
        {
            ViewBag.Message = "Welcome index";
            ViewBag.teachers = GetTeachers();
            ViewBag.student = GetStudents();
            return View();
        }

        public IActionResult PartialView()
        {
            ViewBag.Message = "Welcome index";
            return View();
        }
        public PartialViewResult RendorTeacher()
        {
            return PartialView(GetTeachers());
        }

        public PartialViewResult RendorStudent()
        {
            return PartialView(GetStudents());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            teachers.Add(new Teacher { TeacherId = 1,Code ="111C",Name ="teacher 1" }) ;
            teachers.Add(new Teacher { TeacherId = 2, Code = "222C", Name = "teacher 2" });
            teachers.Add(new Teacher { TeacherId = 3, Code = "333C", Name = "teacher 3" });
            return teachers;
        }

        public List<Student> GetStudents()
        {
            List<Student> student = new List<Student>();
            student.Add(new Student { StudentId = 1, Code = "111S", Name = "StudentId 1" });
            student.Add(new Student { StudentId = 2, Code = "222S", Name = "StudentId 2" });
            student.Add(new Student { StudentId = 3, Code = "333S", Name = "StudentId 3" });
            return student;
        }
    }
}
