using dapper.sql.api.Context;
using dapper.sql.api.Models;

namespace dapper.sql.api.Repository
{
    public class StudentRepository : IStudentRepository
    {
        AppDbContext _dbContext;
        public StudentRepository(AppDbContext _dbContext)
        { 
            this._dbContext = _dbContext;
        }
        public async Task<bool> Add(Student student)
        {
            int rowAffected = await _dbContext.ExecuteAsync("INSERT INTO Student(Name,Address) VALUES(@Name,@Address)", student);
            if(rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            int rowAffected = await _dbContext.ExecuteAsync("DELETE FROM Student WHERE Id=@Id", new {Id=id});
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Edit(Student student)
        {
            int rowAffected = await _dbContext.ExecuteAsync("UPDATE Student SET Name=@Name,Address=@Address WHERE Id=@Id",student);
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Student>> GetAll()
        {
            var students = await _dbContext.QueryAsync<Student>("SELECT * FROM Student");
            return students.ToList();
        }

        public async Task<Student> GetById(int id)
        {
            var student = await _dbContext.QuerySingleOrDefaultAsync<Student>("SELECT * FROM Student WHERE Id=@Id",new {Id=id});
            return student;
        }
    }
}
