
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Principal;
using WebApplication1.Model;
using WebApplication1.Models;

namespace Assignment_Web_API.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<EducationalDetail> EdcuationDetails { get; set; }
    }
}
