using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Model
{
    public class EducationalDetail
    {
        public Guid Id { get; set; }

        [ForeignKey("Student")]
        public Guid? StudentId { get; set; }

        [Required]
        public double PSCGPA { get; set; }

        [Required]
        public  int PSCPassingYear { get; set; }

        [Required]
        public double SSCGPA { get; set; }

        [Required]
        public  int SSCPassingYear { get; set; }

        public Student Student { get; set; }
    }
}
