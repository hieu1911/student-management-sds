using ASPDotNetNHibernate.Interface;
using ASPDotNetNHibernate.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPDotNetNHibernate.Controllers
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

        public IActionResult Index(int? id)
        {
            var subjects = new List<SubjectDetail>();

            if (id == null)
            {

            }
            else
            {
                subjects = _subjectService.GetSubjectsByStudentIdAsync((int)id);
            }
            ViewData["StudentId"] = id;
            return View(new SubjectList(subjects));
        }

        public IActionResult ChangeScore(int id, double processScore, double finalScore)
        {
            var response =  _studentSubjectService.UpdateScore(id, processScore, finalScore);

            return Json(response);
        }
    }
}
