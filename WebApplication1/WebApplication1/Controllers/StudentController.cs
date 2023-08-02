using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dto;
using WebApplication1.Model;
using WebApplication1.Models;
using WebApplication1.RepositoryPattern;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;


        public StudentController(
            IStudentRepository studentRepository
            )
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("api/student/getAll")]
        public IActionResult GetAllStudents()
        {
            var students = _studentRepository.GetAllStudents();
            return Ok(students);
        }

        [HttpPost]
        [Route("api/student/create")]
        public IActionResult CreateStudnet([FromBody] StudentAndEducationalDetailsDto studentEducationDetails)
        {
            try
            {
                _studentRepository.CreateStudent(studentEducationDetails);
                return Ok("Student and EducationDetails created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/student/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _studentRepository.DeleteStudent(id);
                return Ok("Student and EducationalDetails deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
