namespace MVCEFCodeFirst.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public DateTime Date { get; set; }

        // Foreign keys
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}
