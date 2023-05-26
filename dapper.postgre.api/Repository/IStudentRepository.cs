using dapper.postgre.api.Models;

namespace dapper.postgre.api.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<bool> Add(Student student);
        Task<bool> Edit(Student student);
        Task<bool> Delete(int id);
    }
}
