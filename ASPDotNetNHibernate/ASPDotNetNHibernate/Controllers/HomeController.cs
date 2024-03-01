using ASPDotNetNHibernate.Interface;
using ASPDotNetNHibernate.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPDotNetNHibernate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;

        public HomeController(ILogger<HomeController> logger, IStudentService studentService, ISubjectService subjectService)
        {
            _logger = logger;
            _studentService = studentService;
            _subjectService = subjectService;
        }

        public IActionResult Index()
        {
            var students = _studentService.GetStudents();

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