using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerosnController : ControllerBase
    {
        Random rnd = new Random();
        private static readonly string[] names = new[]
        {
            "Jan","Janusz","Adam"
        };
        private static readonly string[] lastnames = new[]
        {
            "Kowalki","Nowak"
        };
        private static readonly string[] pesels = new[]
        {
            "00000000000","11111111111","22222222222"
        };

        private readonly ILogger<PerosnController> _logger;

        public PerosnController(ILogger<PerosnController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPerson")]
        public IEnumerable<Person> Get()
        {
            return Enumerable.Range(1, 3).Select(index => new Person
            {
                name = names[rnd.Next(0, 3)],
                lastname = lastnames[rnd.Next(0, 2)],
                age = rnd.Next(35,46),
                pesel = pesels[rnd.Next(0, 3)]
            })
            .ToArray();
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
