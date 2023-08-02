using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dto;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.RepositoryPattern
{
   public interface IStudentRepository
    {
        void CreateStudent(StudentAndEducationalDetailsDto studentEducationDetails);
        StudentDto GetStudentById(int studentId);
        void UpdateStudent(StudentAndEducationalDetailsDto studentEducationDetails);
        void DeleteStudent(Guid studentId);
        IEnumerable<StudentDto> GetAllStudents();
    }
}
