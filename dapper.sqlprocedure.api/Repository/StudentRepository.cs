using dapper.sqlprocedure.api.Context;
using dapper.sqlprocedure.api.Models;
using System.Data;

namespace dapper.sqlprocedure.api.Repository
{
    public class StudentRepository:IStudentRepository
    {
        AppDbContext _dbContext;
        public StudentRepository(AppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<bool> Add(Student student)
        {
            int rowAffected = await _dbContext.ExecuteAsync("AddStudent", new {name=student.Name,address=student.Address},commandType:CommandType.StoredProcedure);
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            int rowAffected = await _dbContext.ExecuteAsync("DeleteStudent", new { id = id },commandType:CommandType.StoredProcedure);
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Edit(Student student)
        {
            int rowAffected = await _dbContext.ExecuteAsync("UpdateStudent", student,commandType:CommandType.StoredProcedure);
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Student>> GetAll()
        {
            var students = await _dbContext.QueryAsync<Student>("GetAllStudent",commandType:CommandType.StoredProcedure);
            return students.ToList();
        }

        public async Task<Student> GetById(int id)
        {
            var student = await _dbContext.QuerySingleOrDefaultAsync<Student>("GetStudentById", new { id = id },commandType:CommandType.StoredProcedure);
            return student;
        }
    }
}

