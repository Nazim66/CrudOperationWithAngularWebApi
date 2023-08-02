using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.Dto
{
    public class StudentAndEducationalDetailsDto
    {
        public Student Student { get; set; }
        public EducationalDetail EducationDetails { get; set; }
      
    }
}
