using Microsoft.AspNetCore.Mvc;
using Semaine_6___ASP.NET_Core___Students_API_Controllers.Models;

namespace Semaine_6___ASP.NET_Core___Students_API_Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> _students = new List<Student>()
        {
        new Student { Id = 1, FirstName = "Paul", LastName = "Ochon", BirthDate = new DateTime(1950, 12, 1) },
        new Student { Id = 2, FirstName = "Daisy", LastName = "Drathey", BirthDate = new DateTime(1970, 12, 1) },
        new Student { Id = 3, FirstName = "Elie", LastName = "Coptaire", BirthDate = new DateTime(1980, 12, 1) }
        };

        [HttpGet]
        public IList<Student> GetStudents()
        {
            return _students;
        }

        [HttpGet("{id}")]
        public ActionResult<Student?> GetOneStudent(int id)
        {
            Student? student = _students.Find(s => s.Id == id);
            if (student == null) return NotFound(null);
            return student;
        }

        [HttpPost]
        public bool AddOneStudent([FromBody] Student student)
        {
            if (_students.Contains(student)) return false;
            _students.Add(student);
            return true;
        }
    }
}
