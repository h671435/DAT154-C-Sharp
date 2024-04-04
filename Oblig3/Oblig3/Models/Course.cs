using System.ComponentModel.DataAnnotations;

namespace Oblig3;

public class Course
{
    [Key]
    public string CourseCode { get; set; } = null!;
    public string CourseName { get; set; } = null!;
    public string Semester { get; set; } = null!;
    public string Teacher { get; set; } = null!;
    
}