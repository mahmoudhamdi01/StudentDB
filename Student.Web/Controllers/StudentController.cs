using Microsoft.AspNetCore.Mvc;
using Student.Business.Interfaces;
using Student.Data.Entities;

namespace Student.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public IActionResult Index()
        {
            var students = _studentRepository.GetAll();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                 _studentRepository.Add(student);
                
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public IActionResult Details(int? Id, string viewName = "Details")
        {
            if (Id is null)
                return BadRequest();
            var student = _studentRepository.GetByID(Id.Value);
            if (student is null)
                return NotFound();
            return View(viewName, student);
        }
        public IActionResult Edit(int? Id)
        {
            return Details(Id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit(StudentModel student)
        {
            if (ModelState.IsValid)
                try
                {
                    _studentRepository.Update(student);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            return View(student);
        }


        public IActionResult Delete(int? Id)
        {
            return Details(Id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Delete(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
    }
}
