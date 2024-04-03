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
            .Where(g => g.CourseCode.Equals(courseCode))
            .Select(g => new StudentGrade { Student = g.Student, Grade = g })
            .ToListAsync();
    }

    public async Task<List<StudentGradeCourse>> GradesAbove(string grade)
    {
        return await Grade
            .Include(g => g.Student)
            .Include(g => g.Course)
            .Where(g => string.Compare(g.Score, grade) <= 0)
            .Select(g => new StudentGradeCourse { Student = g.Student, Grade = g, Course = g.Course })
            .ToListAsync();
    }
}