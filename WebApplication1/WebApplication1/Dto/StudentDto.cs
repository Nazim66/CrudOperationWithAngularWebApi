using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Dto
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Roll { get; set; }
        public string Section { get; set; }
        public int Class { get; set; }
        public string? MobileNumber { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public double PSCGPA { get; set; }
        public int PSCPassingYear { get; set; }
        public double SSCGPA { get; set; }
        public int SSCPassingYear { get; set; }
    }
}
