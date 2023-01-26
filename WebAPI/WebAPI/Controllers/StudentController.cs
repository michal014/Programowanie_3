using Microsoft.AspNetCore.Mvc;
using WebAPI.IRepos;

namespace WebAPI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _studentRepo;

        public StudentController(IStudent studentRepo)
        {
            _studentRepo = studentRepo;
        }


        [HttpGet]
        [Route("Students")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentRepo.GetStudents();
            return Ok(students);
        }
    }
}
