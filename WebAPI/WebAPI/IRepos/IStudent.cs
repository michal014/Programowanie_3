using WebAPI.Models;

namespace WebAPI.IRepos
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> GetStudents();
    }
}
