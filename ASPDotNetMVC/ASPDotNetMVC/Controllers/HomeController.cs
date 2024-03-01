using ASPDotNetMVC.Interface;
using ASPDotNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Dapper;

namespace ASPDotNetMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly string _connectionString = "Server=localhost;Port=3306;Database=student_management;Uid=root;Pwd=";

        public HomeController(ILogger<HomeController> logger, IStudentService studentService, ISubjectService subjectService)
        {
            _logger = logger;
            _studentService = studentService;
            _subjectService = subjectService;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetStudents();

            return View(new StudentList(students));
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
    }
}