using ASPDotNetMVC.Interface;
using ASPDotNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPDotNetMVC.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
       
        private readonly IStudentSubjectService _studentSubjectService;

        public SubjectController(ISubjectService subjectService, IStudentSubjectService studentSubjectService)
        {
            _subjectService = subjectService;
            _studentSubjectService = studentSubjectService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var subjects = new List<SubjectDetail>();

            if (id == null)
            {
                
            }
            else
            {
                subjects = await _subjectService.GetSubjectsByStudentIdAsync((int)id);
            }
            ViewData["StudentId"] = id;
            return View(new SubjectList(subjects));
        }

        public async Task<IActionResult> ChangeScore(int id, double processScore, double finalScore)
        {
            var response = await _studentSubjectService.UpdateScore(id, processScore, finalScore);

            return Json(response);
        }
    }
}
