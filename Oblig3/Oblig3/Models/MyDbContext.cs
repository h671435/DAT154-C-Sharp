using Microsoft.EntityFrameworkCore;

namespace Oblig3;

public class MyDbContext : DbContext
{
    public DbSet<Course> Course { get; set; }
    public DbSet<Grade> Grade { get; set; }
    public DbSet<Student> Student { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "data source=dat154demo.database.windows.net;Initial Catalog=dat154;User ID=dat154_rw;Password=Svart_Katt;");
    }

    public async Task<List<Student>> SearchStudents(string partialStudentName)
    {
        return await Student.Where(s => s.Studentname.Contains(partialStudentName)).ToListAsync();
    }

    public async Task<List<StudentGrade>> StudentsInCourse(string courseCode)
    {
        return await Grade
            .Include(g => g.Student)
            .Where(g => g.CourseCode == courseCode)
            .Select(g => new StudentGrade { Student = g.Student, Grade = g })
            .ToListAsync();
    }
    
}