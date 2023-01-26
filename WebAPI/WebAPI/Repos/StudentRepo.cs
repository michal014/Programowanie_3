using Microsoft.EntityFrameworkCore;
using WebAPI.IRepos;
using WebAPI.Models;

namespace WebAPI.Repos
{
    public class StudentRepo : IStudent
    {
        private readonly StudentsContext _studentsContext;
        public StudentRepo(StudentsContext studentsContext) 
        {
            _studentsContext = studentsContext;
        }
        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await _studentsContext.students.ToArrayAsync();
            return students;
        }
    }
}
