using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oblig3;

public class Grade
{
    [Key]
    public int StudentId { get; set; }
    public string CourseCode { get; set; } = null!;
    [Column("grade")]
    public string Score { get; set; }
    [ForeignKey("StudentId")]
    public Student Student { get; set; }
    [ForeignKey("CourseCode")]
    public Course Course { get; set; }
}