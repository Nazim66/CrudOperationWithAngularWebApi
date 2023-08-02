using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.RepositoryPattern
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<StudentDto> GetAllStudents()
        {
            var students = new List<StudentDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("usp_GetAllStudents", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = new StudentDto
                            {
                                Id = Guid.Parse(reader["Id"].ToString()),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Roll = Convert.ToInt32(reader["Roll"].ToString()),
                                Section = reader["Section"].ToString(),
                                Class = Convert.ToInt32(reader["Class"].ToString()),
                                MobileNumber = reader["MobileNumber"].ToString(),
                                FathersName = reader["FirstName"].ToString(),
                                MothersName = reader["MothersName"].ToString(),
                                PSCGPA = Convert.ToDouble(reader["PSCGPA"]),
                                PSCPassingYear = Convert.ToInt32(reader["PSCPassingYear"]),
                                SSCGPA = Convert.ToDouble(reader["SSCGPA"]),
                                SSCPassingYear = Convert.ToInt32(reader["SSCPassingYear"])
                            };
                            students.Add(student);
                        }
                    }
                }
            }

            return students;
        }

        public void CreateStudent(StudentAndEducationalDetailsDto studentEducationDetails)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("InsertStudentWithEducationDetails", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", studentEducationDetails.Student.FirstName);
                    command.Parameters.AddWithValue("@LastName", studentEducationDetails.Student.LastName);
                    command.Parameters.AddWithValue("@Roll", studentEducationDetails.Student.Roll);
                    command.Parameters.AddWithValue("@Section", studentEducationDetails.Student.Section);
                    command.Parameters.AddWithValue("@Class", studentEducationDetails.Student.Class);
                    command.Parameters.AddWithValue("@MobileNumber", studentEducationDetails.Student.MobileNumber);
                    command.Parameters.AddWithValue("@FathersName", studentEducationDetails.Student.FathersName);
                    command.Parameters.AddWithValue("@MothersName", studentEducationDetails.Student.MothersName);
                    command.Parameters.AddWithValue("@PSCGPA", studentEducationDetails.EducationDetails.PSCGPA);
                    command.Parameters.AddWithValue("@PSCPassingYear", studentEducationDetails.EducationDetails.PSCPassingYear);
                    command.Parameters.AddWithValue("@SSCGPA", studentEducationDetails.EducationDetails.SSCGPA);
                    command.Parameters.AddWithValue("@SSCPassingYear", studentEducationDetails.EducationDetails.SSCPassingYear);
                    command.ExecuteNonQuery();
                }
            }
        }

        public StudentDto GetStudentById(Guid studentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("usp_GetStudentById", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentId", studentId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var student = new StudentDto
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Roll = Convert.ToInt32(reader["Roll"].ToString()),
                                Section = reader["Section"].ToString(),
                                Class = Convert.ToInt32(reader["Class"].ToString()),
                                MobileNumber = reader["MobileNumber"].ToString(),
                                FathersName = reader["FirstName"].ToString(),
                                MothersName = reader["MothersName"].ToString(),
                                PSCGPA = Convert.ToDouble(reader["PSCGPA"]),
                                PSCPassingYear = Convert.ToInt32(reader["PSCPassingYear"]),
                                SSCGPA = Convert.ToDouble(reader["SSCGPA"]),
                                SSCPassingYear = Convert.ToInt32(reader["SSCPassingYear"])
                            };
                            return student;
                        }
                        return null;
                    }
                }
            }
        }

        public void UpdateStudent(StudentAndEducationalDetailsDto studentEducationDetails)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("UpdateStudentWithEducationalDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentId", studentEducationDetails.Student.Id);
                    command.Parameters.AddWithValue("@FirstName", studentEducationDetails.Student.FirstName);
                    command.Parameters.AddWithValue("@LastName", studentEducationDetails.Student.LastName);
                    command.Parameters.AddWithValue("@Roll", studentEducationDetails.Student.Roll);
                    command.Parameters.AddWithValue("@Section", studentEducationDetails.Student.Section);
                    command.Parameters.AddWithValue("@Class", studentEducationDetails.Student.Class);
                    command.Parameters.AddWithValue("@MobileNumber", studentEducationDetails.Student.MobileNumber);
                    command.Parameters.AddWithValue("@FathersName", studentEducationDetails.Student.FathersName);
                    command.Parameters.AddWithValue("@MothersName", studentEducationDetails.Student.MothersName);
                    command.Parameters.AddWithValue("@PSCGPA", studentEducationDetails.EducationDetails.PSCGPA);
                    command.Parameters.AddWithValue("@PSCPassingYear", studentEducationDetails.EducationDetails.PSCPassingYear);
                    command.Parameters.AddWithValue("@SSCGPA", studentEducationDetails.EducationDetails.SSCGPA);
                    command.Parameters.AddWithValue("@SSCPassingYear", studentEducationDetails.EducationDetails.SSCPassingYear);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteStudent(Guid studentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DeleteStudentWithEducationalDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.ExecuteNonQuery();
                }
            }
        }  

        public StudentDto GetStudentById(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
