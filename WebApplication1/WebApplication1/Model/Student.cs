using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text.Json.Serialization;
using WebApplication1.Model;

namespace WebApplication1.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(60, ErrorMessage = "First Name can't be longer than 10 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(60, ErrorMessage = "Last Name can't be longer than 10 characters")]
        public string LastName { get; set; }

        public int Roll { get; set; }
        public string Section { get; set; }
        public int Class { get; set; }

        [Required(ErrorMessage = "Mobile Number Field is required")]
        public string? MobileNumber { get; set; }

        [Required(ErrorMessage = "Father's Name Field is required")]
        public string FathersName { get; set; }

        [Required(ErrorMessage = "Mother's Name Field is required")]
        public string MothersName { get; set; }

        public List<EducationalDetail> EducationalDetails { get; set; }
    }
}

